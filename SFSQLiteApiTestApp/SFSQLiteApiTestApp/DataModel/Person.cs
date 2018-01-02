using SFSQLiteApi.Utils.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SFSQLiteApiTestApp.DataModel
{
    //Object and table Person
    public class Person
    {
        [TableKey] //Marks the property as table key
        [TableColumn] //Marks the property as table column
        public int PersonId { get; set; }

        [TableColumn] //Marks the property as table column
        public string Name { get; set; }

        [TableColumn] //Marks the property as table column
        public DateTime BirthDate { get; set; }

        [TableColumn] //Marks the property as table column
        public string Address { get; set; }

        [TableColumn] //Marks the property as table column
        public bool IsValid { get; set; }

        //Without the TableColumn attribute this property will not be a table column
        public string AuxProperty { get; set; }
    }
}
