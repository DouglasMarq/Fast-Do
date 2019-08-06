using Fast_Do.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fast_Do.Models
{
    public class AccessItem : DBService<Item>
    {
        public AccessItem() : base()
        {
        }
    }
}
