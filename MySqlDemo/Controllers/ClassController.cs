using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlDemo.BLL;
using MySqlDemo.DB;
using MySqlDemo.Models;

namespace MySqlDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassController : ControllerBase
    {
        public DbContext context;

        public ClassController(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ClassInfo> Get()
        {
            using (context)
            {
                context.Connection.Open();

                List<ClassInfo> classes = new ClassBLL(context).Find();

                return classes;
            }
        }
    }
}