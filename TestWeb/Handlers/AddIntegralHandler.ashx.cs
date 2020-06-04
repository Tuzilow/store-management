using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.Handlers
{
    /// <summary>
    /// AddIntegralHandler 的摘要说明
    /// </summary>
    public class AddIntegralHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string count = context.Request.Form["integral_count"];
            string isOut = context.Request.Form["is_out"];
            string vipId = context.Request.Form["vip_id"];

            if (new IntegralBLL().Insert(Convert.ToBoolean(isOut), Convert.ToInt32(count), Convert.ToInt32(vipId)))
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