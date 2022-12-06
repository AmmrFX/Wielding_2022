using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Wielding_2022;

namespace Backkk
{
   public static class DbSetup
    {
        public static List<Main_Tables> GetAllMain()
        {
            try
            {
                using (WeEntities db = new WeEntities())
                {
                    var x = db.Main_Tables.ToList();
                    return x;
                }
            }
            catch
            {
                return null;
            }
          

        }
        public static List<Wield_Details> GetAllWields(Main_Tables mainDetails,int no)
        {
            try
            {
                using (WeEntities db = new WeEntities())
                {
                    if (no==1)
                    {
                        List<Wield_Details> x = db.Wield_Details.Where(a => a.Drawing_Number == mainDetails.Drawing_Number).ToList();
                        return x;
                    } if (no==2)
                    {
                        List<Wield_Details> x = db.Wield_Details.Where(a => a.Line_Class == mainDetails.Line_Class).ToList();
                        return x;
                    } if (no==3)
                    {
                        List<Wield_Details> x = db.Wield_Details.Where(a => a.Line_Number == mainDetails.Line_Number).ToList();
                        return x;
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static Main_Tables getOne(Main_Tables mainTables,int no)
        {
            try
            {
                using (WeEntities db = new WeEntities())
                {
                    if (no==1)
                    {
                        var x = db.Main_Tables.FirstOrDefault(a => a.Drawing_Number == mainTables.Drawing_Number);
                        return x;
                    }
                    if (no==2)
                    {
                        var x = db.Main_Tables.FirstOrDefault(a => a.Line_Class == mainTables.Line_Class);
                        return x;
                    }
                    if (no==3)
                    {
                        var x = db.Main_Tables.FirstOrDefault(a => a.Line_Number == mainTables.Line_Number);
                        return x;
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static Wield_Details getOneWield(string wieldNumber)
        {
            try
            {
                using (WeEntities db = new WeEntities())
                {
                    var x = db.Wield_Details.FirstOrDefault(a => a.Weld_Number == wieldNumber);
                    return x;
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool Delete(Wield_Details shop)
        {
            try
            {
                using (WeEntities db = new WeEntities())
                {

                    var x = db.Wield_Details.Remove(shop);
                    db.SaveChanges();
                    return true ;
                }
                
            }
            catch
            {
                return false;
            }
        } 
     /*   public static bool UpdateMain(int id , Main_Tables main)
        {
            try
            {
                using (WeEntities db = new WeEntities())
                {
                    if (main != null && id != 0)
                    {
                        var x =db.Main_Tables.Where(a=>a.ID == id).
                }
                }
                   
            }
            catch (Exception)
            {

                
            }
        } */
        public static bool UpdateWield(string wieldNo,Wield_Details shop)
        {
            try
            {
                using (WeEntities db = new WeEntities())
                {
                    var x = db.Wield_Details.Where(a=>a.Weld_Number ==wieldNo).FirstOrDefault();
                    if (x != null)
                    {
                        x.Weld_Number = wieldNo;
                       
                        x.Diametere = shop.Diametere;
                        x.Line_Number = shop.Line_Number;
                        x.Weld_Number = shop.Weld_Number;
                        x.Line_Class = shop.Line_Class;
                        x.Material_G_Side_A = shop.Material_G_Side_A;
                    }
                    db.SaveChanges();
                    return true ;

                }
            }
            catch
            {
                return false;
            }
        }
        public static void Add_Main(Main_Tables main)
        {
            using (WeEntities db = new WeEntities())
            {
                db.Main_Tables.Add(main);
                db.SaveChanges();
            }
        }
        public static void Add_Wield(string DrawingNo, Wield_Details wield)
        {
            using (WeEntities db = new WeEntities())
            {
                if (wield != null)
                {
                    wield.Drawing_Number = DrawingNo;
                    db.Wield_Details.Add(wield);
                    db.SaveChanges();
                } 
            
            }
        }
        public static int DeleteWield(string WieldNo)
        {
            try
            {
                using (WeEntities db = new WeEntities())
                {
                    var target = db.Wield_Details.Where(a => a.Weld_Number == WieldNo).FirstOrDefault();
                    if (target != null)
                    {
                        db.Wield_Details.Remove(target);
                        db.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}
