using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.WebForms
{
    /// <summary>
    /// AddVipHandler 的摘要说明
    /// </summary>
    public class AddVipHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string name = context.Request.Form["vip_name"];
            string gender = context.Request.Form["vip_gender"];
            string birthday = context.Request.Form["vip_birthday"];
            string joinTime = context.Request.Form["vip_join"];

            if (new VipBLL().Insert(name, gender, Convert.ToDateTime(birthday), Convert.ToDateTime(joinTime)))
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