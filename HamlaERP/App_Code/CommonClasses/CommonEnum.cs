using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enums
{
    public class CommonEnum
    {
        public CommonEnum()
        {

        }
        public enum Payabletype
        {
            BankTransfer = 1,
            Cheque = 2,
            Cash = 3,
            CreditCard = 4,
        }
        public enum ProcessType
        {
            Sales = 1,
            Purchase = 2,

        }
        public enum type
        {
            Credit = 1,
            Debit = 2,
        }
        public enum Operation
        {
            Insert = 1,
            Update = 2,
            Delete = 3,
        }
        public enum Separator
        {
            Comma = ',',
            Tab = '\t',
            Space = ' ',
            Hyphen='-',            
            Slash='/',
            Colon=':',
            Pipe='|',
        }
    }
   
}