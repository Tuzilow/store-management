using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using System.IO;
using Models;

namespace TestWeb.Handlers
{
    /// <summary>
    /// UpdateFactoryHandler 的摘要说明
    /// </summary>
    public class UpdateFactoryHandler : IHttpHandler
    {
        FactoryBLL factoryBll = new FactoryBLL();
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod.ToUpper() == "GET")
            {
                this.DoGet(context);
            }
            else
            {
                this.DoPost(context);
            }
        }
        private void DoGet(HttpContext context)
        {
            string pId = context.Request.QueryString["Id"];
            if (!string.IsNullOrEmpty(pId))
            {
                int sId = int.Parse(pId);
                string html = File.ReadAllText(context.Request.MapPath("../HTML/UpdateFactory.html"));
                FactoryInfo pro = factoryBll.FindOne(sId);
                html = html.Replace("{@pId}", pro.Id.ToString()).Replace("{@pName}", pro.Name).Replace("{@pAddress}", pro.Address);
                html = html.Replace("{@pPhone}", pro.Phone);
                context.Response.Write(html);
            }
        }
        private void DoPost(HttpContext context)
        {
            string pId = context.Request.Form["pId"];
            string pName = context.Request.Form["pName"];
            string pAddress = context.Request.Form["pAddress"];
            string pPhone = context.Request.Form["pPhone"];

            FactoryInfo factoryInfo = new FactoryInfo();
            factoryInfo.Id = Convert.ToInt32(pId);
            factoryInfo.Name = pName;
            factoryInfo.Address = pAddress;
            factoryInfo.Phone = pPhone;
           
            if (factoryBll.UpdateById (factoryInfo.Id, factoryInfo.Name, factoryInfo.Address, factoryInfo.Phone))
            {
                context.Response.Write("<script>alert('修改成功！');window.location='../WebForms/Factory.aspx'</script>");
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