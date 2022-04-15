// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

'use strict';

if (document.querySelector('input[id="Price"]')) {
    document.querySelector('input[id="Price"]').onchange = function () {
        Price.value = Price.value.replace('.', ',');
    }
};