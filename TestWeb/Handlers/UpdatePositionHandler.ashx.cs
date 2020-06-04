using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.WebForms
{
    /// <summary>
    /// UpdatePositionHandler 的摘要说明
    /// </summary>
    public class UpdatePositionHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request.Form["position_id"];
            string name = context.Request.Form["position_name"];
            string desc = context.Request.Form["position_desc"];

            if (new PositionBLL().Update(Convert.ToInt32(id), name, desc))
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