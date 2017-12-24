using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SFSQLiteApiTestApp.DataModel
{
    //Object and table Person
    public class Person
    {
        [Key] //Marks the property as table key
        [DataMember] //Marks the property as table column
        public int PersonId { get; set; }

        [DataMember] //Marks the property as table column
        public string Name { get; set; }

        [DataMember] //Marks the property as table column
        public DateTime BirthDate { get; set; }

        [DataMember] //Marks the property as table column
        public string Address { get; set; }

        [DataMember] //Marks the property as table column
        public bool IsValid { get; set; }

        //Without the DataMember attribute this property will not be a table column
        public string AuxProperty { get; set; }
    }
}
