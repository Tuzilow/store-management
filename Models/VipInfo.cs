using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class VipInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        // 加入时间
        public DateTime JoinTime { get; set; }

        /// <summary>
        /// DataSet转List
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static List<VipInfo> ToList(DataSet ds)
        {
            List<VipInfo> vipList = new List<VipInfo>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                VipInfo vip = new VipInfo();
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    switch (dc.ToString())
                    {
                        case "vip_id":
                            vip.Id = Convert.ToInt32(dr[dc]);
                            break;
                        case "vip_name":
                            vip.Name = dr[dc].ToString();
                            break;
                        case "vip_gender":
                            vip.Gender = dr[dc].ToString();
                            break;
                        case "vip_birthday":
                            vip.Birthday = Convert.ToDateTime(dr[dc]);
                            break;
                        case "vip_join":
                            vip.JoinTime = Convert.ToDateTime(dr[dc]);
                            break;
                    }
                }
                vipList.Add(vip);

            }
            return vipList;
        }
    }
}
