using System;
using System.Collections.Generic;
using System.Text;

namespace Ioasys.Application.ViewModels
{
    public class InvestorViewModel
    {
        public int id { get; set; }
        public string investor_name { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public float balance { get; set; }
        public object photo { get; set; }
        public float portfolio_value { get; set; }
        public bool first_access { get; set; }
        public bool super_angel { get; set; }
    }
}
