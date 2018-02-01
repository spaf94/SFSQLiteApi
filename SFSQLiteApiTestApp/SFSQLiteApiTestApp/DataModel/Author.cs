using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFSQLiteApiTestApp.DataModel
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; } 
    }
}
