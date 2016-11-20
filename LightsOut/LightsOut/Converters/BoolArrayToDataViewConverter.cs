﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LightsOut.Converters
{
    public class BoolArrayToDataViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var array = value as bool[,];
            if (array == null) return null;

            var rows = array.GetLength(0);
            if (rows == 0) return null;

            var columns = array.GetLength(1);
            if (columns == 0) return null;

            var t = new DataTable();

            // Add columns with name "0", "1", "2", ...
            for (var c = 0; c < columns; c++)
            {
                t.Columns.Add(new DataColumn("Column" + c.ToString()));
            }

            // Add data to DataTable
            for (var r = 0; r < rows; r++)
            {
                var newRow = t.NewRow();
                for (var c = 0; c < columns; c++)
                {
                    newRow[c] = array[c, r];
                }
                t.Rows.Add(newRow);
            }

            return t.DefaultView;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
