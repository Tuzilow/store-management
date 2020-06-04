using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.Handlers
{
    /// <summary>
    /// UpdateVipHandler 的摘要说明
    /// </summary>
    public class UpdateVipHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request.Form["vip_id"];
            string name = context.Request.Form["vip_name"];
            string gender = context.Request.Form["vip_gender"];
            string birthday = context.Request.Form["vip_birthday"];
            string joinTime = context.Request.Form["vip_join"];

            if (new VipBLL().UpdateById(Convert.ToInt32(id),name, gender, Convert.ToDateTime(birthday), Convert.ToDateTime(joinTime)))
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