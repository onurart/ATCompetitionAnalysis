using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Core.Abstractions
{
    public class Entity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDelete { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public DateTime? DeletedDate { get; set; }
    }
}
