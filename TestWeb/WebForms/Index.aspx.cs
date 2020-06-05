using BLL;
using Commons;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWeb.WebForms
{
    public partial class Index : BasePage
    {
        readonly StaffBLL staffBLL = new StaffBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected StaffInfo GetUser()
        {
            string account = Session["User"].ToString();

            return staffBLL.FindOne(account);
        }
    }
}