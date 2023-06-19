using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd3_v5_OberuhtinaLena
{
    public class MobileConnection
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pricemin { get; set; }
        public double Spuare { get; set; }
        public string Speed { get; set; }
       
        public MobileConnection(int id,string name, int pricemin, double spuare, string speed)
        {
            Id = id;
            Name = name;
            Pricemin = pricemin;
            Spuare = spuare;
            Speed = speed;
            
        }
        public virtual double Q ()
        {
            double result = 100 * Spuare / Pricemin;
            return result;
        }
        public string Print ()
        {
            return $"ID: {Id},Название: {Name}, Цена: {Pricemin}\n Плошадь покрытия: {Spuare}, Скорость: {Speed}";
        }
        public static bool ID (List<MobileConnection> mobileconnectionlist, int id)
        {
            return mobileconnectionlist.Any(rw => rw.Id == id);
        }
        public static bool Names (List<MobileConnection> mobileconnectionlist, string name)
        {
            return mobileconnectionlist.Any(rw => rw.Name == name);
        }
        public static void Add (List<MobileConnection> mobileconnectionlist, MobileConnection mobileconnection)
        {
            mobileconnectionlist.Add(mobileconnection);
        }     
        public static void Remove (List<MobileConnection> mobileconnectionlist, MobileConnection mobileconnection)
        {
            mobileconnectionlist.Remove(mobileconnection);
        }

       
       
    }
}
