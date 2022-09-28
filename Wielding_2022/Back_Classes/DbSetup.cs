using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wielding_2022;

namespace Backkk
{
   public static class DbSetup
    {
        public static List<ShopTest> GetAll()
        {
            try
            {
                using (WeEntities db = new WeEntities())
                {
                    var x = db.ShopTests.ToList();
                    return x;
                }
            }
            catch
            {
                return null;
            }
        }
        public static List<ShopTest> GetAllWields(string Drawing_number)
        {
            try
            {
                using (WeEntities db = new WeEntities())
                {
                    List<ShopTest> x = db.ShopTests.Where(a=>a.Drawing_Number ==Drawing_number).ToList();
                    return x;
                }
            }
            catch
            {
                return null;
            }
        }

        public static ShopTest getOne(string drawingNumber)
        {
            try
            {
                using (WeEntities db = new WeEntities())
                {
                    var x = db.ShopTests.Where(a => a.Drawing_Number == drawingNumber).FirstOrDefault();
                    return x;
                }
            }
            catch
            {
                return null;
            }
        }

        public static ShopTest getOneWield(string wieldNumber)
        {
            try
            {
                using (WeEntities db = new WeEntities())
                {
                    var x = db.ShopTests.Where(a => a.Weld_Number == wieldNumber).FirstOrDefault();
                    return x;
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool Delete(ShopTest shop)
        {
            try
            {
                using (WeEntities db = new WeEntities())
                {
                    var x = db.ShopTests.Remove(shop);
                    return true ;
                }
            }
            catch
            {
                return false;
            }
        } 
        public static bool Update(ShopTest shop)
        {
            try
            {
                using (WeEntities db = new WeEntities())
                {
                    var x = db.ShopTests.Where(a=>a.Id ==shop.Id).FirstOrDefault();
                    if (x != null)
                    {
                        x.Drawing_Number = shop.Drawing_Number;
                        x.Diameter__inch_ = shop.Diameter__inch_;
                        x.Line_Number = shop.Line_Number;
                        x.Weld_Number = shop.Weld_Number;
                    }  
                    return true ;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
