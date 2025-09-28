﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class Product : IAggregateRoot<Guid>
    {
        public Guid Id {  get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
    }
}
