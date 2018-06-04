using SFSQLiteApi.Utils.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFSQLiteApi.Utils
{
    internal class Cache
    {
        /// <summary>
        /// The insert object list
        /// </summary>
        internal static Dictionary<string, InsertObject> InsertObjectList = new Dictionary<string,InsertObject>();
    }
}
