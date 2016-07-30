using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gtech.mobilefinance.dal
{
    public class Model
    {
        protected int _id;

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual void Validate()
        {
        }
    }
}
