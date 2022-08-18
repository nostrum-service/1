using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.IO;
using System.Globalization;
using System.Reflection;
using Reader;
using TableOfPartners;
using PartnersAndDocs;
using LiteDB;
using System.ComponentModel;
//using JSonProject;

namespace _0422
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        public void ConnectToDB()
        {
            string connectString = ConfigurationManager.AppSettings["database"];

            using (var db = new LiteDatabase(connectString))
            {
                // Получаем коллекцию
                var coldoc = db.GetCollection<ExampleForReader>("Docs");
                var result = coldoc.FindAll();
                BindingList<ExampleForReader> Listex = new BindingList<ExampleForReader>();
                foreach (ExampleForReader c in result)
                    Listex.Add(c);
                dataGridView1.ColumnHeadersVisible = true;
                dataGridView1.DataSource = Listex;
                
                dataGridView1.ReadOnly = true;
                //dataGridView1.AllowUserToDeleteRowsChanged += false;

            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateForm newFormCreate = new CreateForm(this);
            newFormCreate.ShowDialog(this);
            if (newFormCreate.DialogResult == DialogResult.OK)
            {
                ConnectToDB();
            }

        }

        private void btnConnectToDB_Click(object sender, EventArgs e)
        {
            ConnectToDB();
        }
    }
}