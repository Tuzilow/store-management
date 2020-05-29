using MySqlDemo.DAL;
using MySqlDemo.DB;
using MySqlDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlDemo.BLL
{
    public class ClassBLL
    {
        readonly DbContext context;
        public ClassBLL(DbContext context)
        {
            this.context = context;
        }
        public List<ClassInfo> Find()
        {
            DbDataReader reader = new ClassDAL(context).Find();

            List<ClassInfo> classList = new List<ClassInfo>();
            using (reader)
            {
                while (reader.Read())
                {
                    ClassInfo cls = new ClassInfo()
                    {
                        ClsId = reader.GetFieldValue<int>(0),
                        ClsName = reader.GetFieldValue<string>(1),
                        ClsMajor = reader.GetFieldValue<string>(2),
                        ClsNumber = reader.GetFieldValue<int>(3),
                        ClsCreateTime = reader.GetFieldValue<DateTime>(4),
                        ClsRoom = reader.GetFieldValue<string>(5)
                    };
                    classList.Add(cls);
                }
            }

            return classList;
        }
    }
}
