using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.WebForms
{
    /// <summary>
    /// UpdateStaffHandler 的摘要说明
    /// </summary>
    public class UpdateStaffHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request.Form["staff_id"];
            string name = context.Request.Form["staff_name"];
            string gender = context.Request.Form["staff_gender"];
            string birthday = context.Request.Form["staff_birthday"];
            string address = context.Request.Form["staff_address"];
            string salary = context.Request.Form["staff_salary"];
            string positionId = context.Request.Form["staff_position_id"];

            if (new StaffBLL().UpdateById(Convert.ToInt32(id), name, gender, Convert.ToDateTime(birthday), address, Convert.ToDouble(salary), Convert.ToInt32(positionId)))
            {
                context.Response.Write("{\"status\": 0,\"message\":\"修改成功\"}");
            }
            else
            {
                context.Response.Write("{\"status\": 1,\"message\":\"修改失败\"}");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}