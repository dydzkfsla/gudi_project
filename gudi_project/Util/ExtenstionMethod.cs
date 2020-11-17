using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gudi_project
{
    public static class ExtenstionMethod
    {
        public static DataRow insertRow(this DataTable dt)
        {
            DataRow row= dt.NewRow();
            dt.Rows.InsertAt(row, 0);
            return row;
        }
    }
}
