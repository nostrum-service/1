using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;
using System.Reflection;
using CsvHelper.Configuration;

namespace BaseMap
{
    public class ExampleMap : ClassMap<Example>
    {
        public ExampleMap()
        {
            Map(m => m.Number).Name("№ п/п");
            Map(m => m.Document).Name("Документ");
            Map(m => m.Organization).Name("Организация");
            Map(m => m.DateDay).Name("Дата замечания");
            Map(m => m.Department).Name("Подразделение инициатора");
            Map(m => m.Initiator).Name("Инициатор (ФИО)");
            Map(m => m.Chapter).Name("№ и название раздела");
            Map(m => m.Quantity).Name("Количество");
        }
    }
}
