using MB.Domain.Aggregations.ATMAggregate.ValueObjects;
using System;

namespace MB.Domain.Aggregations.ATMAggregate.ObjectsValue
{
    public class ATM
    {
        private bool userIsAuthenticated = false;
        public CashDispenser CashDispenser { get; set; }
        public DepositSlot DepositSlot { get; set; }
        public Keypad Keyboard { get; set; }
        public Screen Screen { get; set; }
    }
}
