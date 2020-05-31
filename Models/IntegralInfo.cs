using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 积分
    /// </summary>
    public class IntegralInfo
    {
        public int Id { get; set; }
        public bool IsOut { get; set; }
        public int Count { get; set; }
        public int VipId { get; set; }

        /// <summary>
        /// DataSet转List
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static List<IntegralInfo> ToList(DataSet ds)
        {
            List<IntegralInfo> integralList = new List<IntegralInfo>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                IntegralInfo integral = new IntegralInfo();
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    switch (dc.ToString())
                    {
                        case "integral_id":
                            integral.Id = Convert.ToInt32(dr[dc]);
                            break;
                        case "is_out":
                            integral.IsOut = Convert.ToBoolean(dr[dc]);
                            break;
                        case "integral_count":
                            integral.Count = Convert.ToInt32(dr[dc]);
                            break;
                        case "vip_id":
                            integral.VipId = Convert.ToInt32(dr[dc]);
                            break;
                    }
                }
                integralList.Add(integral);
            }
            return integralList;
        }
    }
}
