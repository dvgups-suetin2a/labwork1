using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Лабораторная_работа__1
{
    interface IRateAndCopy
    {
        object DeepCopy();
        int Rating { get; set; }
    }
}
