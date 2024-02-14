﻿using CompetitionAnalysis.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Domain.CompanyEntities
{
    public sealed class Customer : Entity
    {
        public string Name { get; set; }
    }
}
