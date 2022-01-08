using BiodataTest.Utility;
using System.Threading.Tasks;

namespace BiodataTest.Interfaces
   
{
    public interface IEmailSender
    {
        Task<bool> sendPlainEmail(CMail cm);
        Task<bool> sendTemplatedEmail(CMail cm);
    }
}
