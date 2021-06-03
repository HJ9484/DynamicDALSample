using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicDAL;

namespace DynamicDALSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Models.Share share = new Models.Share()
            {
                Name = "EUR/USD",
                Namad = "EURUSD"
            };

            try
            {
                BL.ShareController controller = new BL.ShareController();
                var list = controller.GetListAsync().Result.ToList();
           
            }
            catch (Exception ex)
            {

                throw;
            }
            Console.ReadLine();

        }
    }
}
