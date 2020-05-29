using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlDemo.Models
{
    public class ClassInfo
    {
        public int ClsId { get; set; }
        public string ClsName { get; set; }
        public string ClsMajor { get; set; }
        public int ClsNumber { get; set; }
        public DateTime ClsCreateTime { get; set; }
        public string ClsRoom { get; set; }
    }
}
