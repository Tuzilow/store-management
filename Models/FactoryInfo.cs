using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 供应商
    /// </summary>
    public class FactoryInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        /// <summary>
        /// DataSet转List
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static List<FactoryInfo> ToList(DataSet ds)
        {
            List<FactoryInfo> factoryList = new List<FactoryInfo>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                FactoryInfo  factory= new FactoryInfo();
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    switch (dc.ToString())
                    {
                        case "factory_id":
                            factory.Id = Convert.ToInt32(dr[dc]);
                            break;
                        case "factory_name":
                            factory.Name = dr[dc].ToString();
                            break;
                        case "factory_address":
                            factory.Address = dr[dc].ToString();
                            break;
                        case "factory_phone":
                            factory.Phone = dr[dc].ToString();
                            break;
                    }
                }
                factoryList.Add(factory);

            }
            return factoryList;
        }
    }
}
