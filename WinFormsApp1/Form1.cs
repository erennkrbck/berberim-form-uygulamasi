using System.Drawing.Drawing2D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btnSign2.Hide();
            btnBack.Hide();

            panel1.Size = new Size(750, 450);
            panel2.Size = new Size(800, 600);

            int x = (panel1.Size.Width - title.Size.Width) / 2;
            int y = (panel1.Size.Height - title.Size.Height) / 10;
            title.Location = new Point(x, y);

            int a = panel1.Height / 6;
            int b = panel1.Width / 4;
            label1.Location = new Point(a, b);
            label2.Location = new Point(a, b + 50);
            textBox1.Location = new Point(a + 275, b);
            textBox2.Location = new Point(a + 275, b + 50);
            pswrdbtn5.Location = new Point(a + 531, b + 49);
            pswrdbtn6.Location = new Point(a + 531, b + 49);
            btnSign.Location = new Point(a + 225, b + 175);
            btnLogin.Location = new Point(a + 450, b + 175);

            int l = (panel2.Size.Width - title.Size.Width) / 2;
            int m = (panel2.Size.Height - title.Size.Height) / 16;
            title2.Location = new Point(l, m);

            int q = panel2.Height / 6;
            int z = panel2.Width / 5;
            label7.Location = new Point(q, z);
            label6.Location = new Point(q, z + 50);
            label3.Location = new Point(q, z + 100);
            label4.Location = new Point(q, z + 150);
            label5.Location = new Point(q, z + 200);
            tcbox.Location = new Point(q + 275, z);
            sifrebox2.Location = new Point(q + 275, z + 50);
            textBox3.Location = new Point(q + 275, z + 100);
            textBox4.Location = new Point(q + 275, z + 150);
            textBox5.Location = new Point(q + 275, z + 200);
            checkBox1.Location = new Point(q + 275, z + 250);
            linkLabel1.Location = new Point(q + 295, z + 250);
            pswrdbtn.Location = new Point(q + 531, z + 149);
            pswrdbtn2.Location = new Point(q + 531, z + 149);
            pswrdbtn3.Location = new Point(q + 531, z + 199);
            pswrdbtn4.Location = new Point(q + 531, z + 199);
            label8.Location = new Point(q + 575, z - 3);
            label9.Location = new Point(q + 575, z + 97);
            label10.Location = new Point(q + 575, z + 147);
            label11.Location = new Point(q + 575, z + 197);
            btnBack.Location = new Point(q, z + 325);
            btnSign2.Location = new Point(q + 350, z + 325);
            panel1.BackColor = Color.Bisque;
            panel2.BackColor = Color.Bisque;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            panel2.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, EventArgs e)
        {

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            btnLogin.Hide();
            btnSign.Hide();
            btnSign2.Show();
            btnBack.Show();
            label8.Show();
            label9.Show();
            label10.Show();
            label11.Show();
            panel2.Show();
            panel1.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OGHJT7U;Initial Catalog=BerberimDB;Integrated Security=True");
            baglanti.Open();
            SqlCommand MusteriCagir = new SqlCommand("Select * from Musteriler",baglanti);
            SqlDataReader MusteriListesi = MusteriCagir.ExecuteReader();

            while(MusteriListesi.Read())
            {
                string Musteritc = MusteriListesi[3].ToString();
                string Musterisifre = MusteriListesi[4].ToString();
                string x = textBox1.Text;
                string y = textBox2.Text;

                if(x== Musteritc && y == Musterisifre)
                {
                    MessageBox.Show("Giriþ Baþarýlý");
                }
              
            }
           


        }

        private void btnSign2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OGHJT7U;Initial Catalog=BerberimDB;Integrated Security=True");

            string KullaniciAdi = tcbox.Text;
            string KullaniciSoyadi = sifrebox2.Text;
            string KullaniciTc = textBox3.Text;
            string KullaniciSifre = textBox4.Text;


            if (checkBox1.Checked == false)
            {
                System.Windows.Forms.MessageBox.Show("Sözleþmeyi Kabul Ediniz");
            }
            else if (tcbox.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Zorunlu Alanlarý Doldurunuz");
            }
            else if (textBox3.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Zorunlu Alanlarý Doldurunuz");
            }
            else if (textBox4.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Zorunlu Alanlarý Doldurunuz");
            }
            else if (textBox5.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Zorunlu Alanlarý Doldurunuz");
            }
            else if (textBox4.Text != textBox5.Text)
            {
                System.Windows.Forms.MessageBox.Show("Þifreleriniz birbiriyle uyuþmuyor");
            }
            else
            {
                baglanti.Open();
                SqlCommand Ekle = new SqlCommand("Insert into Musteriler (MusteriIsim,MusteriSoyadi,MusteriTc,MusteriSifre)\r\nValues (" + "'" + KullaniciAdi + "'" + "," + "'" + KullaniciSoyadi + "'" + "," + KullaniciTc + "," + "'" + KullaniciSifre + "'" + ")", baglanti);
                Ekle.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Baþarýyla Kayýt Oldunuz");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnBack.Hide();
            btnSign2.Hide();
            btnLogin.Show();
            btnSign.Show();
            panel1.Show();
            panel2.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 11;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.MaxLength = 11;
        }

        private void tcbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pswrdbtn_Click(object sender, EventArgs e)
        {
            if (textBox4.UseSystemPasswordChar == false)
            {
                pswrdbtn2.BringToFront();
                textBox4.UseSystemPasswordChar = true;
            }
        }

        private void pswrdbtn2_Click(object sender, EventArgs e)
        {
            if (textBox4.UseSystemPasswordChar == true)
            {

                pswrdbtn.BringToFront();
                textBox4.UseSystemPasswordChar = false;
            }
        }

        private void pswrdbtn3_Click(object sender, EventArgs e)
        {
            if (textBox5.UseSystemPasswordChar == false)
            {
                pswrdbtn4.BringToFront();
                textBox5.UseSystemPasswordChar = true;
            }
        }

        private void pswrdbtn4_Click(object sender, EventArgs e)
        {
            if (textBox5.UseSystemPasswordChar == true)
            {

                pswrdbtn3.BringToFront();
                textBox5.UseSystemPasswordChar = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string message = "User Agreement. The User Agreement forms part of this Agreement. As much as possible, this Agreement and the User Agreement should be interpreted as a consistent whole. Where a conflict of interpretation arises, this Agreement overrides the User Agreement to the extent of the conflict, except in relation to your use of the Product or Online Card Payment Service as part of our new checkout solution as set out in the User Agreement. Capitalised words which are not defined in this Agreement are defined in that User Agreement. The definition of “Services” and “Agreement” in the User Agreement, when read together with these terms, include the Product and this Agreement. The User Agreement includes important provisions which:";
            string title = "Kullanýcý Sözleþmesi";
            MessageBox.Show(message, title);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.Location = new Point(
            this.ClientSize.Width / 2 - panel2.Size.Width / 2,
            this.ClientSize.Height / 2 - panel2.Size.Height / 2);
            panel2.Anchor = AnchorStyles.None;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Location = new Point(
            this.ClientSize.Width / 2 - panel1.Size.Width / 2,
            this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void pswrdbtn5_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                pswrdbtn6.BringToFront();
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void pswrdbtn6_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == false)
            {
                pswrdbtn5.BringToFront();
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

