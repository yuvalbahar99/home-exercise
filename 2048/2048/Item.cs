using System;
using System.Collections.Generic;
using System.Text;

namespace _2048
{
    class Item
    {
        public int Value { get; set; }
        public bool IsBlended { get; set; }
        public Item()
        {
            Value = 0;
            IsBlended = false;
        }
    }
}
