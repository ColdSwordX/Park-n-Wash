﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash
{
    public interface IBillet
    {
        string Navn { get; set; }
        int Rabat { get; set; }
        int Pris { get; set; }
    }
}
