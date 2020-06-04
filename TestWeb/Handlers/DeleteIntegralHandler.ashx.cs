using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.Handlers
{
    /// <summary>
    /// DeleteIntegralHandler 的摘要说明
    /// </summary>
    public class DeleteIntegralHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request.Form["integral_id"];

            if (new IntegralBLL().DeleteById(Convert.ToInt32(id)))
            {
                context.Response.Write("{\"status\": 0,\"message\":\"删除成功\"}");
            }
            else
            {
                context.Response.Write("{\"status\": 1,\"message\":\"删除失败\"}");
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