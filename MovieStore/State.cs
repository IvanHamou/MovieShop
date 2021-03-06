﻿using System;
using System.Collections.Generic;
using System.Text;
using DatabaseConnection;
using Microsoft.EntityFrameworkCore;

namespace MovieStore
{
    static class State
    {
        public static Customer User { get; set; } 
        public static List<Movie> Movies { get; set; }
        public static Movie Pick { get; set; } 
    }
}
