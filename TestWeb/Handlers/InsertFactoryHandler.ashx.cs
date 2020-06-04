using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Models;

namespace TestWeb.Handlers
{
    /// <summary>
    /// InsertFactoryHandler 的摘要说明
    /// </summary>
    public class InsertFactoryHandler : IHttpHandler
    {
        FactoryBLL factoryBll = new FactoryBLL();
        public void ProcessRequest(HttpContext context)
        {
            string pName = context.Request.Form["pName"];
            string pAddress = context.Request.Form["pAddress"];
            string pPhone = context.Request.Form["pPhone"];

            FactoryInfo factoryInfo = new FactoryInfo();
            factoryInfo.Name = pName;
            factoryInfo.Address = pAddress;
            factoryInfo.Phone = pPhone;
            if (factoryBll.Insert(factoryInfo.Name, factoryInfo.Address, factoryInfo.Phone))
            {
                context.Response.Write("<script>alert('供应商添加成功！');window.location='../WebForms/Factory.aspx'</script>");
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