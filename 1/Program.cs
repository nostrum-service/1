using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using NLog;
using System.Reflection;
using Reader;
using Newtonsoft.Json;
using Execution;



namespace JSonProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramExecution pr = new ProgramExecution();
            pr.MainExec(args);
        }
       

    }

}
