using BLL;
using Commons;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ProjectDB db = new ProjectDB();
            Console.WriteLine(db.CreateDatabase());
            Console.WriteLine(db.ChangeDatabase());
            Console.WriteLine(db.CreateGoodsTable());
            Console.WriteLine(db.CreateFactoryTable());
            Console.WriteLine(db.CreateOrderTable());
            Console.WriteLine(db.CreateStaffTable());

            GoodsBLL goodsBLL = new GoodsBLL();
            FactoryBLL factoryBLL = new FactoryBLL();

            //factoryBLL.Insert("军火商", "terrier", "11111111111");

            //goodsBLL.Insert("坦克", "载具", 100, 0, 10, 50, Convert.ToDateTime("2018/01/12"), Convert.ToDateTime("2021/10/12"), 1);
            List<GoodsInfo> goods = goodsBLL.Find();
            foreach (var item in goods)
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadLine();
        }
    }
}
