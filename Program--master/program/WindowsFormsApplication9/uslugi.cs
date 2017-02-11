using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication9
{
    public partial class uslugi : Form
    {
        public uslugi()
        {
            InitializeComponent();
        }
        public void ZapisXml()
        {
            DataSet ds = new DataSet();
            DataTable dt1 = new DataTable();
            dt1.TableName = "Uslugi";
            dt1.Columns.Add("Nazwa");
            dt1.Columns.Add("Cena");



            ds.Tables.Add(dt1);
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                DataRow row1 = ds.Tables["Uslugi"].NewRow();
                row1["Nazwa"] = r.Cells[0].Value;
                row1["Cena"] = r.Cells[1].Value;


                ds.Tables["Uslugi"].Rows.Add(row1);
            }
            ds.WriteXml("uslugi.xml");
        }
        private void uslugi_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml("uslugi.xml");
                foreach (DataRow item in ds.Tables["Uslugi"].Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") | (textBox2.Text == ""))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!");
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;

                textBox1.Text = "";
                textBox2.Text = "";
                ZapisXml();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") | (textBox2.Text == ""))

            {
                MessageBox.Show("Uzupełnij wszystkie pola!");
            }
            else
            {
                button1.Enabled = true;
                button3.Enabled = true;
                dataGridView1.SelectedRows[0].Cells[0].Value = textBox1.Text;
                dataGridView1.SelectedRows[0].Cells[1].Value = textBox2.Text;

                textBox1.Text = "";
                textBox2.Text = "";

                button2.Enabled = false;
                ZapisXml();
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.Enabled = true;
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            button1.Enabled = false;
            button3.Enabled = false;
        }
    }
}
