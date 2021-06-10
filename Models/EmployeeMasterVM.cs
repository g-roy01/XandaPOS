﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XandaPOS.Models
{
    public class EmployeeMasterVM
    {
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public string emp_addr { get; set; }
        public string emp_pin { get; set; }
        public string emp_phone { get; set; }
        public string emp_govt_id_type { get; set; }
        public string emp_govt_id_no { get; set; }
        public Nullable<System.DateTime> emp_join_date { get; set; }
        public Nullable<System.DateTime> emp_resign_date { get; set; }
    }
}