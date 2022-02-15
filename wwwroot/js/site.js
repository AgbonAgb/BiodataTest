﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    /*alert("am here");*/
    var PlaceHolderElement = $('#PlaceHolderHere');
    /*var PlaceHolderElement = $('#UpdateCareer');*/
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
            /*PlaceHolderElement.find('UpdateCareer').modal('show');*/
            /*alert("am back");*/
        })
    })

    /* save data from popup*/
    PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (data) {
            PlaceHolderElement.find('.modal').modal('hide');
        })
    })

    /*Close or hide popup*/
    PlaceHolderElement.on('click', '[data-dismiss="modal"]', function (event) {
        PlaceHolderElement.find('.modal').modal('hide');
    })
})

