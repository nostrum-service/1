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

            GetData();

            void GetData()
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
                    dataGridView1.DataSource = Listex;
                    
                }
            }
        }



        private void Button_CreateDoc_Click(object sender, EventArgs e)
        {
           // MainForm MainForm1 = new MainForm();
           // MainForm1.Show();

            CreateForm newFormCreate = new CreateForm();
            newFormCreate.Show();
        }

       
    }
}