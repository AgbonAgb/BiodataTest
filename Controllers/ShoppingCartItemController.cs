using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using static BiodataTest.Controllers.Common.Enum;
using Microsoft.AspNetCore.Authorization;
using BiodataTest.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
//using AspNetCore.

namespace BiodataTest.Controllers
{
    public class ShoppingCartItemController : BaseController// Controller
    {
        private readonly IShoppingCartItem _shoppingCartItem;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IApplication _application;
        public ShoppingCartItemController(IShoppingCartItem shoppingCartItem, IHttpContextAccessor httpContextAccessor, IApplication application)
        {
            _shoppingCartItem = shoppingCartItem;
            _httpContextAccessor = httpContextAccessor;
            _application = application;
        }
        [Authorize]
        public async Task<IActionResult> CheckOut(int Id)
        {


            string empid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;//.
                                                                                                            // ShoppingCartItemViewModel SPC = new ShoppingCartItemViewModel();

            //spSPC.ShoppingCartTotal= "45000.00";

            var items = await _shoppingCartItem.getMyCartItems(empid);
            decimal ShoppingCartTotal = await _shoppingCartItem.GetShoppingCartTotal(empid);// decimal.Parse("25,00.00");
            int ShoppingCartQty = _shoppingCartItem.ShoppingitemQty(empid);// decimal.Parse("25,00.00");

            string transRef = Guid.NewGuid().ToString();
            //load my db payments
            Payments pay = new Payments();
            pay.Status = 0;
            pay.Amount = ShoppingCartTotal;
            pay.Qty = ShoppingCartQty;
            pay.TransRef = transRef;
            pay.TransDate = DateTime.Now;// "";
            pay.EmployerId = empid;


            // bool suss = await _shoppingCartItem.AddPaymentTrans(pay);
            //if(suss == true)
            //{
            CybPayload paycyb = new CybPayload();
            paycyb.Amount = ShoppingCartTotal;
            paycyb.Currency = "NGN";
            paycyb.Description = "CYB Outsourced Purchased";
            paycyb.MerchantRef = transRef;// "GodwinAGB202201";
            paycyb.CustomerId = "67898077";
            paycyb.IntegrationKey = "078b48a5c64442ddb63ac3d1f0604153";
            paycyb.ReturnUrl = "http://9320-212-100-86-17.ngrok.io/ShoppingCartItem/CompleteCyberPay/";//http://localhost:26954/
          //paycyb.ReturnUrl = "http://0449-212-100-86-17.ngrok.io/ShoppingCartItem/CompleteCyberPay/";//http://localhost:26954/

            using (var Client = new HttpClient())
            {
                //string cyburl = "https://payment-api.cyberpay.ng/api/v1/payments";
                ////string cyburl = "https://payment-api.staging.cyberpay.ng/api/v1/payments/";
                //var serialisedRequest = JsonConvert.SerializeObject(paycyb);
                //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

                Client.BaseAddress = new Uri("https://payment-api.staging.cyberpay.ng/");
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json1 = JsonConvert.SerializeObject(paycyb);
                var data1 = new StringContent(json1, Encoding.UTF8, "application/json");
                string token = string.Empty;
                HttpResponseMessage response = await Client.PostAsync("api/v1/payments", data1);


                //var response2 = string.Empty;
                // var responseString = _client.UploadString(cyburl, "POST", serialisedRequest);
                CYbPaymentresponse customers = new CYbPaymentresponse();
                // var response = JsonConvert.DeserializeObject<CYbPaymentresponse>(responseString);
                if (response.IsSuccessStatusCode)
                {

                    // var response2 = await response.Content.ReadAsStringAsync();
                    customers = JsonConvert.DeserializeObject<CYbPaymentresponse>(response.Content.ReadAsStringAsync().Result);

                    string oldref = customers.data.transactionReference;
                    pay.CybRef = oldref;
                    //Save local trans details
                    await _shoppingCartItem.AddPaymentTrans(pay);

                    //RedirectToAction(customers.data.redirectUrl);
                    return RedirectPermanent(customers.data.redirectUrl);


                }
                else
                {
                    return View();
                }
                //_client
                //var endPoint = "https://payment-api.cyberpay.ng/api/v1/payments";
                //var json = await client.GetStringAsync(endPoint);
                //return JsonConvert.DeserializeObject<List<User>>(json);
            }
            //call the end point
            //}

            //load Cyb payload



            //1 loop throught and set finalize to tue,
            //2. update application table employeer id
            //notify Admin and generate PO
            //Check awaiting ordeer and generate PO
            // SPC.EmployerId = empid;

            //return View();
        }

        //await the rsponse of payment that was trigerred
        [HttpGet]
        public async Task<IActionResult> CompleteCyberPay()
        {
            //var transRef = Request.QueryString["ref"].ToString();
            var transRef = HttpContext.Request.Query["ref"].ToString();
            if (!string.IsNullOrEmpty(transRef))
            {


                CyberPayV2RequeryResponse resp = new CyberPayV2RequeryResponse();

                using (var Client = new HttpClient())
                {

                    Client.BaseAddress = new Uri("https://payment-api.staging.cyberpay.ng/");
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage response = await Client.GetAsync("api/v1/payments/" + transRef);

                    resp = JsonConvert.DeserializeObject<CyberPayV2RequeryResponse>(response.Content.ReadAsStringAsync().Result);
                    if (resp.succeeded == true)
                    {
                        //update Payment table,
                        string empid = await _shoppingCartItem.UpdatePaymentTrans(transRef);
                        //update cartitems
                        //List<ShoppingCartItem> myitems = new List<ShoppingCartItem>();
                       var myitems = await _shoppingCartItem.getMyCartItems(empid);
                        foreach(ShoppingCartItem mys in myitems)
                        {
                            int applicationid = mys.ApplicationId;
                            //update application table
                            await _application.UpdateApplicationPostPayment(applicationid, empid);
                            


                        }
                        //update shoping cart items for them not to be availabl again
                        await _shoppingCartItem.UpdateShoppingCarttable(transRef, empid);
                       
                        TempData["Message"] = "Payment successful, purchase order will be delivered to you manually";

                        dynamic msg = TempData["Message"];

                        Alert("success", msg, NotificationType.success);
                        return RedirectToAction("existedApplications","career");
                       // return RedirectToActionPermanent("existedApplications");

                        //employeer cart where Cybref =transRef, my table status and ref(
                        //update application table
                        //

                        //Send email to admin for this transaction and preparation of purchase order
                    }
                    else
                    {
                        TempData["Message"] = "Try again, Payment was not successful";

                        dynamic msg = TempData["Message"];

                        Alert("success", msg, NotificationType.error);
                        return View();
                    }


                    // JsonConvert.DeserializeObject<User>(response);
                }
            }
            else
            {
                TempData["Message"] = "Try again, Payment was not successful";

                dynamic msg = TempData["Message"];

                Alert("success", msg, NotificationType.error);
                return View();
            }
               // return RedirectToAction("existedApplications");// View(model);
            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            string empid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;//.


            var remove = await _shoppingCartItem.RemoveItem(Id);
            if (remove == true)
            {



                TempData["Message"] = "item removed from cart Successfull";

                dynamic transRef = TempData["Message"];

                Alert("success", transRef, NotificationType.success);/*as AlertMessage;*/
                return RedirectToAction("MyCart", "Career");
            }
            else
            {
                TempData["Message"] = "item could not be removed from cart";

                dynamic transRef = TempData["Message"];

                Alert("success", transRef, NotificationType.success);/*as AlertMessage;*/
                return RedirectToAction("MyCart", "Career");
            }

        }
    }
}
