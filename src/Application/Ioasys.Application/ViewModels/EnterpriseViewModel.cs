using System;
using System.Collections.Generic;
using System.Text;

namespace Ioasys.Application.ViewModels
{
    public class EnterpriseViewModel
    {
        public int id { get; set; }
        public object email_enterprise { get; set; }
        public object facebook { get; set; }
        public object twitter { get; set; }
        public object linkedin { get; set; }
        public object phone { get; set; }
        public bool own_enterprise { get; set; }
        public string enterprise_name { get; set; }
        public object photo { get; set; }
        public string description { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public int value { get; set; }
        public float share_price { get; set; }
        public EnterpriseTypeViewModel enterprise_type { get; set; }
    }
}
