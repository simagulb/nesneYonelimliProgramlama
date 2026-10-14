using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nesneoedevi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] hafizadakiKelimeler = new string[20];
        int kelimeSayisi = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(new object[] {
                "karaman", "adana", "gaziantep", "eskişehir", "konya", "malatya", 
                "edirne", "sivas", "diyarbakır", "mersin", "denizli", "çanakkale"
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] islemDizisi = new string[kelimeSayisi];
            for (int k = 0; k < kelimeSayisi; k++)
            {
                islemDizisi[k] = hafizadakiKelimeler[k];
            }

            int islemAdedi = kelimeSayisi;

            listBox1.ClearSelected();
            kelimeSayisi = 0;

            for (int m = 0; m < islemAdedi; m++)
            {
                string tasinanDeger = islemDizisi[m];

                listBox2.Items.Add(tasinanDeger);
                listBox1.Items.Remove(tasinanDeger);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int x = 0; x < listBox1.SelectedItems.Count; x++)
            {
                string anlikDeger = listBox1.SelectedItems[x].ToString();
                bool oncedenVarMi = false;

                for (int y = 0; y < kelimeSayisi; y++)
                {
                    if (hafizadakiKelimeler[y] == anlikDeger)
                    {
                        oncedenVarMi = true;
                        break;
                    }
                }

                if (oncedenVarMi == false)
                {
                    hafizadakiKelimeler[kelimeSayisi] = anlikDeger;
                    kelimeSayisi++;
                }
            }

            for (int a = 0; a < kelimeSayisi; a++)
            {
                string kayitliDeger = hafizadakiKelimeler[a];
                bool halaAktifMi = false;

                for (int b = 0; b < listBox1.SelectedItems.Count; b++)
                {
                    if (listBox1.SelectedItems[b].ToString() == kayitliDeger)
                    {
                        halaAktifMi = true;
                        break;
                    }
                }

                if (halaAktifMi == false)
                {
                    for (int c = a; c < kelimeSayisi - 1; c++)
                    {
                        hafizadakiKelimeler[c] = hafizadakiKelimeler[c + 1];
                    }

                    hafizadakiKelimeler[kelimeSayisi - 1] = null;
                    kelimeSayisi--;
                    a--;
                }
            }
        }
    }
}
