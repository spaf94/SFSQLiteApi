using SFSQLiteApi.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFSQLiteApiTestApp.DataModel
{
    public class Author
    {
        [TableKey]
        [TableColumn]
        public int AuthorId { get; set; }

        [TableColumn]
        public string Name { get; set; }

        [TableColumn]
        public DateTime BirthDate { get; set; }

        [TableColumn]
        public byte[] ArrayA { get; set; }

        [TableColumn]
        public byte[] ArrayB { get; set; }
    }
}

