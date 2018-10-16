using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace perseptron
{
    public partial class Form1 : Form
    {
        double yeniW1, yeniW2;
        public Form1()
        {
            InitializeComponent();
        }


        public void Hesaplamalar() {
            bool hesaplamaIslemiDurumu = true;
            yeniW1 = Convert.ToDouble(tbwx1.Text);
            yeniW2 = Convert.ToDouble(tbwx2.Text);
            int ornek1Sonuc=0,ornek2Sonuc=0;
            int iterasyon=1;
            while (hesaplamaIslemiDurumu) 
            {
                tbsonuc.Text += "\r\n" + iterasyon.ToString()+".İterasyon "+"1.Örnek" ;
                ornek1Sonuc = NetHesaplama(
                                1, iterasyon, Convert.ToDouble(tbx11.Text), Convert.ToDouble(tbx12.Text),
                                yeniW1, yeniW2,
                                Convert.ToDouble(tbOgrenme.Text), Convert.ToDouble(tbb1.Text)
                                );
                iterasyon++;
                tbsonuc.Text += "\r\n" + iterasyon.ToString() + ".İterasyon " + "2.Örnek";
                ornek2Sonuc = NetHesaplama(
                    2, iterasyon, Convert.ToDouble(tbx21.Text), Convert.ToDouble(tbx22.Text),
                   yeniW1, yeniW2,
                   Convert.ToDouble(tbOgrenme.Text), Convert.ToDouble(tbb2.Text)
                   );
                iterasyon++;
                if (ornek1Sonuc == 1 && ornek2Sonuc == 1)
                {
                    hesaplamaIslemiDurumu = false;
                }
            }          
            tbsonuc.Text += "\r\n"+"Öğrenme Sonunda ağırlıklar:" +"\r\n" + "w1= "+yeniW1.ToString()+ "\r\n"+"w2= " +yeniW2.ToString();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            tbsonuc.Text = "Perseptron Çözümü" + "\r\n";
            Hesaplamalar();
        }

        public int NetHesaplama(int ornekNo,int iterasyon,double x1, double x2, double w1,double w2, double ogrenme,double beklenen) {
            double net=0;
            net =  x1* w1 + x2 * w2;
            tbsonuc.Text+= "\r\n"+"NET= "+net.ToString() ;
            if (net>Convert.ToDouble(tbEsik.Text))
            {
                tbsonuc.Text += "\r\n"+ "Net > ɸ olduğundan Ç" + ornekNo.ToString() + "= 1 olacaktır.";       
                if (beklenen == 1)
                {
                    tbsonuc.Text += "\r\n" + "Ç" + ornekNo.ToString() + "=B" + ornekNo.ToString() +" olduğundan ağırlıklar değişmez."+ "\r\n";
                    tbsonuc.Text += "W1 ve W2 değerli aynı kalır.\r\nw1=" + w1.ToString() + " w2=" + w2.ToString() + "\r\n";
                    return 1;
                    
                }
                else
                {
                    yeniW1 = w1 - (ogrenme * x1);
                    tbsonuc.Text += "\r\n" + "W1Yeni= " + w1.ToString() + "-(" + ogrenme.ToString() + "*" + x1.ToString() + ")";
                    yeniW2 = w2 - (ogrenme * x2);
                    tbsonuc.Text += "\r\n" + "W2Yeni= " + w2.ToString() + "-(" + ogrenme.ToString() + "*" + x2.ToString() + ")" + "\r\n";
                    tbsonuc.Text += "\r\n" + "Yeni Değerler şöyle olur:" + "\r\n" + "w1= " + yeniW1.ToString() + "\r\n"+ "w2= " + yeniW2.ToString() + "\r\n";
                    return -1;
                }
            }
            else
            {
                tbsonuc.Text += "\r\n"+ "Net <= ɸ olduğundan Ç" + ornekNo.ToString() + "= 0 olacaktır.";
                if (beklenen == 0)
                {
                    tbsonuc.Text += "\r\n" + "Ç" + ornekNo.ToString() + "=B" + ornekNo.ToString() + " olduğundan ağırlıklar değişmez." + "\r\n";
                    tbsonuc.Text += "W1 ve W2 değerli aynı kalır.\r\nw1=" + w1.ToString() + " w2=" + w2.ToString() + "\r\n";
                    return 1;
                }
                else
                {            
                       yeniW1 = w1 + (ogrenme * x1);
                    tbsonuc.Text += "\r\n" + "W1Yeni= " + w1.ToString() + "+(" + ogrenme.ToString() + "*" + x1.ToString() + ")";
                    yeniW2 = w2 + (ogrenme * x2);
                    tbsonuc.Text += "\r\n" + "W2Yeni= " + w2.ToString() + "+(" + ogrenme.ToString() + "*" + x2.ToString() + ")" + "\r\n";

                    tbsonuc.Text += "\r\n" + "Yeni Değerler şöyle olur:" + "\r\n" + "w1= " + yeniW1.ToString() + "\r\n"+ "w2= " + yeniW2.ToString() + "\r\n";
                    return -1;
                    
                }
            }
        }
       
    }
}
