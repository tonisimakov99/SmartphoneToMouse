﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseImitation
{
    interface IClientCommandsHandler
    {
        void Handle(byte[] bytes);
    }
}