using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reader;
using TableOfPartners;
using PartnersAndDocs;
using LiteDB;
using System.Configuration;
//using System.ComponentModel;

namespace _0422
{
    public partial class CreateForm : Form
    {
        string s;
        double a;
        double b;
        double c;

        public CreateForm(MainForm f)
        {
            InitializeComponent();
            //Number.Validated += Number_Validated;
            //Organization.Validated += (sender, evt) => {  };
            //DateDay.Validated += true;
            //Document.Validated += true;

        }

        private void Number_Validated(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddRecord_Click(object sender, EventArgs e)
        {
            if (Number.Text == "")
            {
                MessageBox.Show("Не заполнен Номер", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Number.Focus();
                return;

            }

            string connectString = ConfigurationManager.AppSettings["database"];

            using (var db = new LiteDatabase(connectString))
            {
                // Получаем коллекцию
                var coldoc = db.GetCollection<ExampleForReader>("Docs");

                var doc = new ExampleForReader
                {
                    Number = Number.Text,
                    Document = Document.Text,
                    PartnerID = new Partners("", 0),
                    Organization = Organization1.Text,
                    DateDay = dateTimePicker1.Value,
                    Department = "",
                    Initiator = "",
                    Chapter = "",
                    Quantity = ""
                };
                coldoc.Insert(doc);
            }
           DialogResult = DialogResult.OK;
           this.Close();
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Number_Validating(object sender, CancelEventArgs e)
        {
            if (Number.Text == "")
            {
                e.Cancel = false;
            }
            else
            {
                try
                {
                    double.Parse(Number.Text);
                    e.Cancel = false;
                }
                catch
                { 
                    e.Cancel = true;
                    MessageBox.Show("Поле 'Номер' должно содержать только цифры");
                }
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            s = textBox1.Text;
            a = Convert.ToDouble(s);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            s = textBox2.Text;
            b = Convert.ToDouble(s);

        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            c = a + b;
            textBox3.Text = Convert.ToString(c);
        }
    }
}
