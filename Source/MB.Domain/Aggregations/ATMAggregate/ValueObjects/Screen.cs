using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Aggregations.ATMAggregate.ValueObjects
{
    public abstract class Screen
    {
        public String DisplayMessage(String Message) {
            return Message;
        } 
        public String DisplayDollarAmount(decimal amount) {
            return "U$" + amount.ToString();
        } 

    }
}
