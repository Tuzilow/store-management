using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.WebForms
{
    /// <summary>
    /// AddPositionHandler 的摘要说明
    /// </summary>
    public class AddPositionHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string name = context.Request.Form["position_name"];
            string desc = context.Request.Form["position_desc"];

            if (new PositionBLL().Insert(name, desc))
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