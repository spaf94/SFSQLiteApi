using SFSQLiteApi.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFSQLiteApiTestApp.DataModel
{
    public class Book
    {
        [TableKey]
        [TableColumn] 
        public int BookId { get; set; }

        [TableKey]
        [TableColumn]
        public int AuthorId { get; set; }

        [TableColumn]
        public string Name { get; set; }

        [TableColumn]
        public DateTime PublishDate { get; set; }
    }
}

