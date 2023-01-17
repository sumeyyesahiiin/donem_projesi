using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace donem_projesi
{
    class sqlbaglantisi
    {
          /*public static void baglanti()
         {
             SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-I7E1JEI;Initial Catalog=DbYurt;Integrated Security=True");
         }*/

        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-I7E1JEI;Initial Catalog=DbYurt;Integrated Security=True");
            baglan.Open();
            return baglan;
        }

        //private string tc;
        //private string sifre;

        /*public void girisyap(string _tc, string _sifre)//kullanılabilir mi
        {
            tc = _tc;
            sifre = _sifre;
        }*/
        /*public string gettc()
        {
            return tc;
        }
        public void settc(string _tc)
        {
            tc=_tc;
        }
        public string getsifre()
        {
            return sifre;
        }
        public void setsifre(string _sifre)
        {
            sifre = _sifre;
        }*/
    }
}

