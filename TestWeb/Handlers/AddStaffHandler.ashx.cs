using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.WebForms
{
    /// <summary>
    /// AddStaffHandler 的摘要说明
    /// </summary>
    public class AddStaffHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string account = context.Request.Form["staff_account"];
            string name = context.Request.Form["staff_name"];
            string gender = context.Request.Form["staff_gender"];
            string birthday = context.Request.Form["staff_birthday"];
            string address = context.Request.Form["staff_address"];
            string salary = context.Request.Form["staff_salary"];
            string positionId = context.Request.Form["staff_position_id"];

            if (new StaffBLL().Insert(account, name, gender, Convert.ToDateTime(birthday), address, Convert.ToDouble(salary), Convert.ToInt32(positionId)))
            {
                context.Response.Write("{\"status\": 0,\"message\":\"添加成功\"}");
            }
            else
            {
                context.Response.Write("{\"status\": 1,\"message\":\"添加失败\"}");
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