﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzerianLab3.Models
{
    public class ResponseViewModel
    {
		public Guid OrderId { get; set; }
		public List<PizzaViewModel> Pizzas { get; set; } = new List<PizzaViewModel>();
		public List<SodaViewModel> Sodas { get; set; } = new List<SodaViewModel>();
		public long Modified { get; set; }
		public double TotalPrice { get; set; }
		public bool IsEmpty => !Pizzas.Any() && !Sodas.Any();
	}
}
