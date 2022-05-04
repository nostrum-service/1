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
        public CreateForm()
        {
            InitializeComponent();
        }

        public CreateForm(MainForm f)
        {
            InitializeComponent();
            f.BackColor = Color.Pink;
        }


        
        private void AddRecord_Click(object sender, EventArgs e)
        {
            if (Number.Text == "")
            {
                MessageBox.Show("Не заполнен Номер", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    Organization = Organization.Text,
                    DateDay = DateTime.Now,
                    Department = "",
                    Initiator = "",
                    Chapter = "",
                    Quantity = ""
                };
                coldoc.Insert(doc);

            }
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
