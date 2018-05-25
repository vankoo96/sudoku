using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class Grade
    {
        [Key]
        public int id { get; set; }
        public int value { get; set; }
    }
}
