using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCoWeekOneHW.Error_Management
{
    public class Messages
    {
        public static string EmptyResults = "Herhangi bir veri bulunamadı";
        public static string WrongRequest = "Id numarası bulunamadı";
        public static string updated(string name,int id) { return $"{id}id numaralı verinin ismi {name} olarak değiştirilmiştir "; }
    }
}
