using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Burliai.Models
{
    class ZodiacSigns
    {
        #region Fields
        private DateTime? _date;
        #endregion

        #region Properties
        public DateTime? Date
        {
            get { return _date; }
            set { _date = value; }
        }
        #endregion
    }
}
