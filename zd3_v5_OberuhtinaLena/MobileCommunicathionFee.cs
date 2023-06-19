using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd3_v5_OberuhtinaLena
{
    public class MobileCommunicathionFee: MobileConnection
    {
        public bool P { get; set; }
        public int User { get; set; }
        public MobileCommunicathionFee(int id, string name, int pricemin, double spuare, string speed,bool p,int user):base(id,name,pricemin,spuare,speed)
        {
            P = p;
            User = user;
        }
        public override double Q()
        {
            double rezult = 100 * Spuare / Pricemin;
            return P ? 0.7 * rezult : 1.5 * rezult;
        }
        public new string Print ()
        {
            return $"ID:{Id},Название: {Name}, Цена : {Pricemin}, Плошадь покрытия: {Spuare}, Скорость: {Speed},P {P},Kлиентов:{User} ";
        }
        public static void Add (List<MobileCommunicathionFee> 
            mobilecommunicathionfeelist, MobileCommunicathionFee mobilecommunicathionfee)
        {
            mobilecommunicathionfeelist.Add(mobilecommunicathionfee);
        }
        public static void Remove (List<MobileCommunicathionFee> mobilecommunicathionfeelist, MobileCommunicathionFee mobilecommunicathionfee)
        {
            mobilecommunicathionfeelist.Remove(mobilecommunicathionfee);
        }
        public static bool ID(List<MobileCommunicathionFee> mobilecommunicathionfeelist, int id)
        {
            return mobilecommunicathionfeelist.Any(rww => rww.Id == id);
        }
        public static bool Names(List<MobileCommunicathionFee> mobilecommunicathionfeelist, string name)
        {
            return mobilecommunicathionfeelist.Any(rww => rww.Name == name);
        }
    }
}
