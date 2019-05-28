class ExchangeRate {
    constructor(localCurrency, foreignCurrency, rate) {
        this.LocalCurrency = localCurrency;
        this.ForeignCurrency = foreignCurrency;
        this.Rate = rate;
    }
}

class Currency{
    constructor(id, name, surcharge, rates, lastUpdate) {
        this.Id = id;
        this.Name = name;
        this.Rates = rates;
        this.Surcharge = surcharge;
        this.LastUpdate = lastUpdate;
    }
}

class OrderRequest {
    constructor(localCurrency, foreignCurrency,
        localCurrencyAmount, foreignCurrencyAmount,
        rate, surcharge, surchargeAmount, discount, orderDate) {
        this.LocalCurrency = localCurrency;
        this.ForeignCurrency = foreignCurrency;
        this.LocalCurrencyAmount = localCurrencyAmount;
        this.ForeignCurrencyAmount = foreignCurrencyAmount;
        this.Rate = rate;
        this.Surcharge = surcharge;
        this.SurchargeAmount = surchargeAmount;
        this.Discount = discount;
        this.DateCreated = orderDate;
    }
}

class OrderConfirmation {
    constructor(localCurrencyName, localCurrencyAmount,
        foreignCurrencyName, foreignCurrencyAmount,
        surcharge, discount, orderDate) {
        this.LocalCurrencyName = localCurrencyName;
        this.LocalCurrencyAmount = localCurrencyAmount;
        this.ForeignCurrencyName = foreignCurrencyName;
        this.ForeignCurrencyAmount = foreignCurrencyAmount;
        this.Surcharge = surcharge;
        this.Discount = discount;
        this.OrderDate = orderDate;
    }
}