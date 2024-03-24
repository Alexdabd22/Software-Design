﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoriLibrary1
{
    public interface IDeviceFactory
    {
        Ebook CreateEbook();
        Laptop CreateLaptop();
        Netbook CreateNetbook();
        Smartphone CreateSmartphone();
    }
}
