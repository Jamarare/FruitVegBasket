﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitVegBasket.Interfaces
{
    public interface IPlatformHttpMessageHandler
    {
        HttpMessageHandler GetHttpMessageHandler();
    }
}
