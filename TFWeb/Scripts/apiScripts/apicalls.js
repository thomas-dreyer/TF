// 
var server = "http://localhost:54542/api/";
var currency = "Currency/"; 
var order = "Order/"
var currencies = "";
var _rate = null;
var _currency = null;


$("#getCurrency").click(function () {
    getCurrencies();
});
$("#placeOrder").click(function () {
    placeOrder();
})

function getOrders() {
    makeApiCall(server + order, "GET", "", function (orders) {
        console.log("Orders:");
        console.log(orders);
    });
}

function printConversion() {
    $("#buyCurrency").empty();
    let amount = document.getElementById("buyRate").value;
    $("#buyCurrency").append("<div>Buy " + _currency.Name + " " + amount + " for ZAR " + calculateConversion()+"</div>");
    $("#buyCurrency").append("<i>A surcharge of " + _currency.Surcharge + "% will be added to your order.</i>");
}

$(document).ready(function () {
    let numberInput = document.getElementById('buyRate');
    numberInput.addEventListener("keyup", function () {
        printConversion();
    });
    getCurrencies();
    getOrders();
});

function calculateConversion() {
    let foreignAmount = document.getElementById('buyRate').value;
    let localAmount = foreignAmount / _rate.Rate;
    return localAmount;
}

function placeOrder() {
    let date = new Date();
    let datestring = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
    let request = new OrderRequest(_rate.LocalCurrency, _rate.ForeignCurrency,
        calculateConversion(), document.getElementById('buyRate').value, _rate.Rate,
        _currency.Surcharge, (calculateConversion() * _currency.Surcharge) / 100, 0, datestring);
    console.log(request);
    $("#orderResult").empty();
    $("#orderResult").append("<i>Placing your order...</i>");
    makeApiCall(server + order, "POST", request, function (result) {
        console.log(result);
        $("#orderResult").empty();
        $("#orderResult").append("<i>"+ result.MetaData +"</i>");
    });
}

function makeApiCall(url, method, requestData, callBack) {
    let result = "";
    $.ajax({
        url: url,
        type: method,
        dataType: 'json',
        data: requestData,
        success: function (data, textStatus, xhr) {
            result = data;
            console.log(textStatus);
            callBack(result);
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation: ' + errorThrown);
        }
    });
    return result; 
}

function createElement(elementType, elementId, content) {
    let result = "<div class='col-sm-12'><" + elementType + " id= " + elementId + ">" + content + "</" + elementType + "></div>";
    return result;
}

function getCurrencies() {
    $("#_currency").empty();
    $("#_currency").append("<i>Querying server...</i>");
    makeApiCall(server + currency, "GET", "", function (currencies) {
        $("#_currency").empty();
        for (i = 0; i < currencies.length; i++) {
            let element = createElement("button", "currency_" + currencies[i].Id, currencies[i].Name);
            $("#_currency").append(element);
            let button = document.getElementById('currency_' + currencies[i].Id);
            button.addEventListener("click", showExchangeOrder);
            button.myParam = currencies[i];
        }
    });
}

function showExchangeOrder(event) {
    _currency = event.target.myParam;
    console.log(_currency);
    $("#LocalCurrencyName").empty();
    // populate the modal
    $("#LocalCurrencyName").append(_currency.Name);

    $("#CurrencyDetails").empty();
    if (_currency.ExchangeRates.length > 0) {
        _rate = _currency.ExchangeRates[0];
        let _rateAmount = _currency.ExchangeRates[0].Rate;
        $("#CurrencyDetails").append("<i>Rate: " + _rateAmount+ "</i>");
    }
    $("#buyRate").value = 1;
    printConversion();
    // show the modal.
    $("#showExhangeOrder").modal("show");
}