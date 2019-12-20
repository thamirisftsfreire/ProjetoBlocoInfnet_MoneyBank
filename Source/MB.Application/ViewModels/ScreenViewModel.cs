using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Application.ViewModels
{
    public class ScreenViewModel
    {
        public String DisplayMessage(String Message) {
            return Message;
        } 
        public String DisplayDollarAmount(decimal amount) {
            return "U$" + amount.ToString();
        } 

    }
}
