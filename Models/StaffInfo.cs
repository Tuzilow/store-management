using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StaffInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        // 工资
        public double Salary { get; set; }
        // 职位
        public string Position { get; set; }
    }
}
