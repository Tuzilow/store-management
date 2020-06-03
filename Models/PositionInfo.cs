using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 职位信息
    /// </summary>
    public class PositionInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        /// <summary>
        /// DataSet转List
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static List<PositionInfo> ToList(DataSet ds)
        {
            List<PositionInfo> positionList = new List<PositionInfo>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                PositionInfo position = new PositionInfo();
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    switch (dc.ToString())
                    {
                        case "position_id":
                            position.Id = Convert.ToInt32(dr[dc]);
                            break;
                        case "position_name":
                            position.Name = dr[dc].ToString();
                            break;
                        case "position_desc":
                            position.Desc = dr[dc].ToString();
                            break;
                    }
                }
                positionList.Add(position);

            }
            return positionList;
        }
    }
}
