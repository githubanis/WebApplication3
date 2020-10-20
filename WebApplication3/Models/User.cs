﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InitialBalance { get; set; }
        public int TotalMeal { get; set; }
        public int Status { get; set; }
    }
}