using System;
using System.Collections.Generic;

namespace CoffeeMachineKata
{
    internal class Cashier
    {
        private readonly Dictionary<BeverageType, decimal> _priceList;

        internal Cashier()
        {
            _priceList = new Dictionary<BeverageType, decimal>
            {
                {BeverageType.Tea, 0.4m},
                {BeverageType.Coffee, 0.6m},
                {BeverageType.Chocolate, 0.5m}
            };
        }

        internal void Checkout(BeverageRequest beverageRequest, Action onCheckoutDone, Action<decimal> onCheckoutBlocked)
        {
            if (beverageRequest.Money >= _priceList[beverageRequest.Type])
                onCheckoutDone();
            else
                onCheckoutBlocked(_priceList[beverageRequest.Type] - beverageRequest.Money);
        }
    }
}