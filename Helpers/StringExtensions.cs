using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*TCKN kullanıcıya gösterirken gizlemek için burayı oluşturdum. */
namespace HospitalSystem.Helpers
{
    public static class StringExtensions
    {
        public static string MaskTCKN(this string tckn)
        {
            if (string.IsNullOrEmpty(tckn) || tckn.Length != 11)
            {  
                return "***********"; 
            }
            return tckn.Substring(0,2) + "*******" + tckn.Substring(9,2);
        }
    }
}
