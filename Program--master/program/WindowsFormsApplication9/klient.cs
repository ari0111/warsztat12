using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;


namespace WindowsFormsApplication9
{
    public partial class klient : Form
    {
        public klient()
        {
            InitializeComponent();
       
        }
        
        public void ZapisXml()
        {
            DataSet ds = new DataSet();
            DataTable dt1 = new DataTable();
            dt1.TableName = "Klient";
            dt1.Columns.Add("Imie");
            dt1.Columns.Add("Nazwisko");
            dt1.Columns.Add("NazwaFirmy");
            dt1.Columns.Add("NIP");
            dt1.Columns.Add("Miasto");
            dt1.Columns.Add("Ulica");
            dt1.Columns.Add("Numer");
            dt1.Columns.Add("KodPocztowy");
            dt1.Columns.Add("Telefon");
            dt1.Columns.Add("Email");
            dt1.Columns.Add("Firma");
            ds.Tables.Add(dt1);
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                DataRow row1 = ds.Tables["Klient"].NewRow();
                row1["Imie"] = r.Cells[0].Value;
                row1["Nazwisko"] = r.Cells[1].Value;
                row1["NazwaFirmy"] = r.Cells[2].Value;
                row1["NIP"] = r.Cells[3].Value;
                row1["Miasto"] = r.Cells[4].Value;
                row1["Ulica"] = r.Cells[5].Value;
                row1["Numer"] = r.Cells[6].Value;
                row1["KodPocztowy"] = r.Cells[7].Value;
                row1["Telefon"] = r.Cells[8].Value;
                row1["Email"] = r.Cells[9].Value;


                row1["Firma"] = Convert.ToBoolean(r.Cells[10].Value);
                ds.Tables["Klient"].Rows.Add(row1);
            }
  
            ds.WriteXml("klient.xml");
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                if ((txtImie.Text == "") | (txtNazwisko.Text == "") | (txtNazwaFirmy.Text == "") | (txtNIP.Text == "") | (txtMiasto.Text == "") |
                   (txtUlica.Text == "") | (txtNumer.Text == "") | (txtKodPocztowy.Text == "") |
                   (txtTelefon.Text == "") | (txtEmail.Text == ""))
                {
                    MessageBox.Show("Uzupełnij wszystkie pola!");
                }


                else
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = txtImie.Text;
                    dataGridView1.Rows[n].Cells[1].Value = txtNazwisko.Text;
                    dataGridView1.Rows[n].Cells[2].Value = txtNazwaFirmy.Text;
                    dataGridView1.Rows[n].Cells[3].Value = txtNIP.Text;
                    dataGridView1.Rows[n].Cells[4].Value = txtMiasto.Text;
                    dataGridView1.Rows[n].Cells[5].Value = txtUlica.Text;
                    dataGridView1.Rows[n].Cells[6].Value = txtNumer.Text;
                    dataGridView1.Rows[n].Cells[7].Value = txtKodPocztowy.Text;
                    dataGridView1.Rows[n].Cells[8].Value = txtTelefon.Text;
                    dataGridView1.Rows[n].Cells[9].Value = txtEmail.Text;


                    dataGridView1.Rows[n].Cells[10].Value = checkBox1.Checked == true ? Convert.ToBoolean(1) : Convert.ToBoolean(0);
                    txtImie.Text = "";
                    txtNazwisko.Text = "";
                    txtNazwaFirmy.Text = "";
                    txtNIP.Text = "";
                    txtMiasto.Text = "";
                    txtUlica.Text = "";
                    txtNumer.Text = "";
                    txtKodPocztowy.Text = "";
                    txtTelefon.Text = "";
                    txtEmail.Text = "";
                    ZapisXml();
                }

            }
            else

            if ((txtImie.Text == "") | (txtNazwisko.Text == "") | (txtMiasto.Text == "") |
                (txtUlica.Text == "") | (txtNumer.Text == "") | (txtKodPocztowy.Text == "") |
                (txtTelefon.Text == "") | (txtEmail.Text == ""))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!");
            }


            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = txtImie.Text;
                dataGridView1.Rows[n].Cells[1].Value = txtNazwisko.Text;
                dataGridView1.Rows[n].Cells[2].Value = "";
                dataGridView1.Rows[n].Cells[3].Value = "";
                dataGridView1.Rows[n].Cells[4].Value = txtMiasto.Text;
                dataGridView1.Rows[n].Cells[5].Value = txtUlica.Text;
                dataGridView1.Rows[n].Cells[6].Value = txtNumer.Text;
                dataGridView1.Rows[n].Cells[7].Value = txtKodPocztowy.Text;
                dataGridView1.Rows[n].Cells[8].Value = txtTelefon.Text;
                dataGridView1.Rows[n].Cells[9].Value = txtEmail.Text;


                dataGridView1.Rows[n].Cells[10].Value = checkBox1.Checked == true ? Convert.ToBoolean(1) : Convert.ToBoolean(0);
                txtImie.Text = "";
                txtNazwisko.Text = "";
                txtNazwaFirmy.Text = "";
                txtNIP.Text = "";
                txtMiasto.Text = "";
                txtUlica.Text = "";
                txtNumer.Text = "";
                txtKodPocztowy.Text = "";
                txtTelefon.Text = "";
                txtEmail.Text = "";
                ZapisXml();
            }


        }
        private void button5_Click(object sender, EventArgs e)
        {
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

      
        private void button3_Click(object sender, EventArgs e)
        {
            string tekst = "Czy na pewno chcesz usunąć wiersz?";
            string tytul = "Usuwanie";
            MessageBoxButtons przyciski = MessageBoxButtons.YesNo;
            MessageBoxIcon ikona = MessageBoxIcon.Warning;
            if (MessageBox.Show(tekst, tytul, przyciski, ikona) == DialogResult.Yes)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                ZapisXml();
            }
        }



        private void klient_Load(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml("klient.xml");
                foreach (DataRow item in ds.Tables["Klient"].Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();
                    dataGridView1.Rows[n].Cells[7].Value = item[7].ToString();
                    dataGridView1.Rows[n].Cells[8].Value = item[8].ToString();
                    dataGridView1.Rows[n].Cells[9].Value = item[9].ToString();
                    if (Convert.ToBoolean(item[10]) == true)
                    {
                        dataGridView1.Rows[n].Cells[10].Value = Convert.ToBoolean(1);

                    }
                    else
                    {
                        dataGridView1.Rows[n].Cells[10].Value = Convert.ToBoolean(0);
                    }
                }
            }
            catch { }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked == true)
            {

                if ((txtImie.Text == "") | (txtNazwisko.Text == "") | (txtNazwaFirmy.Text == "") | (txtNIP.Text == "") | (txtMiasto.Text == "") |
                      (txtUlica.Text == "") | (txtNumer.Text == "") | (txtKodPocztowy.Text == "") |
                      (txtTelefon.Text == "") | (txtEmail.Text == ""))

                {
                    MessageBox.Show("Uzupełnij wszystkie pola!");
                }
                else
                {
                    button1.Enabled = true;
                    button3.Enabled = true;
                    dataGridView1.SelectedRows[0].Cells[0].Value = txtImie.Text;
                    dataGridView1.SelectedRows[0].Cells[1].Value = txtNazwisko.Text;
                    dataGridView1.SelectedRows[0].Cells[2].Value = txtNazwaFirmy.Text;
                    dataGridView1.SelectedRows[0].Cells[3].Value = txtNIP.Text;
                    dataGridView1.SelectedRows[0].Cells[4].Value = txtMiasto.Text;
                    dataGridView1.SelectedRows[0].Cells[5].Value = txtUlica.Text;
                    dataGridView1.SelectedRows[0].Cells[6].Value = txtNumer.Text;
                    dataGridView1.SelectedRows[0].Cells[7].Value = txtKodPocztowy.Text;
                    dataGridView1.SelectedRows[0].Cells[8].Value = txtTelefon.Text;
                    dataGridView1.SelectedRows[0].Cells[9].Value = txtEmail.Text;
                    if (checkBox1.Checked == true)
                    {
                        dataGridView1.SelectedRows[0].Cells[10].Value = 1;
                    }
                    else
                    {
                        dataGridView1.SelectedRows[0].Cells[10].Value = 0;
                    }
                    txtImie.Text = "";
                    txtNazwisko.Text = "";
                    txtNazwaFirmy.Text = "";
                    txtNIP.Text = "";
                    txtMiasto.Text = "";
                    txtUlica.Text = "";
                    txtNumer.Text = "";
                    txtKodPocztowy.Text = "";
                    txtTelefon.Text = "";
                    txtEmail.Text = "";
                    button2.Enabled = false;
                    ZapisXml();
                    checkBox1.Checked = false;
                }
            }
            else
            if ((txtImie.Text == "") | (txtNazwisko.Text == "") | (txtMiasto.Text == "") |
                  (txtUlica.Text == "") | (txtNumer.Text == "") | (txtKodPocztowy.Text == "") |
                  (txtTelefon.Text == "") | (txtEmail.Text == ""))

            {
                MessageBox.Show("Uzupełnij wszystkie pola!");
            }
            else
            {
                button1.Enabled = true;
                button3.Enabled = true;
                dataGridView1.SelectedRows[0].Cells[0].Value = txtImie.Text;
                dataGridView1.SelectedRows[0].Cells[1].Value = txtNazwisko.Text;
                dataGridView1.SelectedRows[0].Cells[2].Value = "";
                dataGridView1.SelectedRows[0].Cells[3].Value = "";
                dataGridView1.SelectedRows[0].Cells[4].Value = txtMiasto.Text;
                dataGridView1.SelectedRows[0].Cells[5].Value = txtUlica.Text;
                dataGridView1.SelectedRows[0].Cells[6].Value = txtNumer.Text;
                dataGridView1.SelectedRows[0].Cells[7].Value = txtKodPocztowy.Text;
                dataGridView1.SelectedRows[0].Cells[8].Value = txtTelefon.Text;
                dataGridView1.SelectedRows[0].Cells[9].Value = txtEmail.Text;
                if (checkBox1.Checked == true)
                {
                    dataGridView1.SelectedRows[0].Cells[10].Value = 1;
                }
                else
                {
                    dataGridView1.SelectedRows[0].Cells[10].Value = 0;
                }
                txtImie.Text = "";
                txtNazwisko.Text = "";
                txtNazwaFirmy.Text = "";
                txtNIP.Text = "";
                txtMiasto.Text = "";
                txtUlica.Text = "";
                txtNumer.Text = "";
                txtKodPocztowy.Text = "";
                txtTelefon.Text = "";
                txtEmail.Text = "";
                button2.Enabled = false;
                
            }
        

    }



    private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            button2.Enabled = true;
            txtImie.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtNazwisko.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtNazwaFirmy.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtNIP.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtMiasto.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtUlica.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtNumer.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            txtKodPocztowy.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            txtTelefon.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            txtEmail.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            if (Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[10].Value) == true)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }

            button1.Enabled = false;
            button3.Enabled = false;
        }



        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
