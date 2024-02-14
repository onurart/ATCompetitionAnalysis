﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Domain.Dtos
{
    public sealed class LogDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string TableName { get; set; }
        public string Progress { get; set; }
        public string Data { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
