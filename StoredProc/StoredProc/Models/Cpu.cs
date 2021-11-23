using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoredProc.Models
{
    public class Cpu
    {
        [Key]
        public string Name { get; set; }
        public string Company { get; set; }
        public double? BaseClock { get; set; }
        public double? MaxClockSpeed { get; set; }

        public int? CoreCount { get; set; }

        public int? ThreadCount { get; set; }
    }
}
