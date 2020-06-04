using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.WebForms
{
    /// <summary>
    /// DeletePositionHandler 的摘要说明
    /// </summary>
    public class DeletePositionHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request.Form["position_id"];

            if (new PositionBLL().Delete(Convert.ToInt32(id)))
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