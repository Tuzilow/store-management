using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Commons;

namespace MySqlDemo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        DBHelper db = DBHelper.Ins;

        public IEnumerable<object> Create()
        {
            yield return db.ExecuteScalar("create database if not exists netcreate");
        }
    }
}