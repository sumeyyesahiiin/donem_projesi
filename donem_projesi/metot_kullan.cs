using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace donem_projesi
{
    public class metot_kullan
    {
        Random r = new Random();

        private string tc;
        private string sifre;
        // GET SET
        public string gettc()
        {
            return tc;
        }
        public void settc(string _tc)
        {
            tc = _tc;
        }
        public string getsifre()
        {
            return sifre;
        }
        public void setsifre(string _sifre)
        {
            sifre = _sifre;
        }
        public void set(string _tc, string _sifre)
        {
            settc(_tc);
            setsifre(_sifre);
        }
        /*(1-9) arasındaki tek basamaktaki sayıların toplamının 7 katı katı (1-9)arasındaki çift basamakta olan 
          sayılardan çıkarınca kalanın mod 10'u ile 10. basamak aynı olmalı*/

        public string mod10_10(string tcnumarası)
        { 
            int cbasamakt = 0;
            int tbasamakt = 0;

            for (int i = 0; i < 9; i++)
            {
                if (i % 2 == 1)
                {
                    cbasamakt +=Convert.ToInt16(tcnumarası.Substring(i,1));
                }
                else if(i % 2 == 0)
                {
                    tbasamakt += Convert.ToInt16(tcnumarası.Substring(i, 1));
                }
            }
            int sonuc= (tbasamakt * 7) - cbasamakt;
            string mod10_10 = Convert.ToString(sonuc % 10);
            return mod10_10;
        }
        //ilk 10 hanenin toplamının %10'u 11.basamaktaki rakam ile aynı olmalı....
        public string mod10_11(string tckimlik)
        {
            int toplam = 0;
            foreach (char chr in tckimlik.Substring(0,10))
            {
                toplam +=Convert.ToInt16(chr);
            }
            int sonuc = toplam % 10;
            string mod10_11 = Convert.ToString(sonuc);
            return mod10_11;
        }

        public string tckontrol(string _tckimlik)
        {
            tc = _tckimlik;
            string kontrol="0";

            if (tc.Length == 11)
            {
                kontrol = "1";

                if (tc.Substring(0, 1) != "0")
                {
                    kontrol = "2";
                    if (mod10_10(tc) == tc.Substring(9, 1))
                    {
                        kontrol = "3";

                        if (mod10_11(tc) == tc.Substring(10, 1))
                        {
                            kontrol = "4";
                        }
                    }
                }
            }
            return kontrol;
        }
        public void message()
        {
            string rdegeri = tckontrol(tc);

            if (rdegeri == "0")
            {
                MessageBox.Show("TC KİMLİK NUMARASI EKSİK TEKRAR DENEYİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (rdegeri == "1")
            {
                MessageBox.Show("ILK KARAKTER 0 OLAMAZ. TEKRAR DENEYİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (rdegeri == "2")
            {
                MessageBox.Show("HATALI TC KİMLİK NUMARASI. TEKRAR DENEYİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (rdegeri == "3")
            {
                MessageBox.Show("HATALI TC KİMLİK NUMARASI. TEKRAR DENEYİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public string tcolustur(int sınır)
        {
            //tc nin ilk karakteri döngüden önce atanıyor. for --> tc icin sınır 9 olmalı 10 ve 11. basamak farklı metotlar geliyor
            string tc = Convert.ToString(r.Next(1, 10));

            for (int i = 1; i < sınır ; i++)
            {
                string basamak = Convert.ToString(r.Next(1, 10)); ;

                tc = tc + basamak;
            }
            tc = tc + mod10_10(tc);
            tc = tc + mod10_11(tc);
            return tc;
        }
        public string sifreolustur(int sinir)
        {

            string harf = "ABCDEFGHIİJKLMNOPRSTUVYZWXqabcdefghijklmnoprstuvyzwxq";
            string ozelkarakter = "><'^#+$%&/[]=?*-_";
            int hbelirle = 0, obelirle = 0, sbelirle = 0;

            int sec;
            string sifre = "";
            for (int i = 0; i < sinir; i++)
            {
                sec = r.Next(1, 4);

                if (sec == 1 && hbelirle!=4)
                {
                    sifre = sifre + harf[r.Next(harf.Length)];
                    hbelirle += 1;
                }
                else if (sec == 2 && obelirle!=2)
                {
                    sifre += ozelkarakter[r.Next(ozelkarakter.Length)];
                    obelirle += 1;
                }
                else if (sec == 3 && sbelirle!=2)
                {
                    sifre += r.Next(1, 10); ;
                    sbelirle += 1;
                }
                else
                {
                    i -= 1;
                }
            }
            return sifre;
        }
    }
}
