using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequesFeatures
{
    public abstract class RequesParameters
    {
        const int MaxPageSize = 50;

        //auto implemented property
        public int PageNumber{ get; set; }

        //full property
        public int _pageSize;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public String? OrderBy { get; set; }
        protected RequesParameters()
        {
            OrderBy = "Id";
        }
    }
}
