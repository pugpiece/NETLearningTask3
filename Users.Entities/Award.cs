﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Entities
{
    public class Award
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Award() { }

        public Award(string newTitle)
        {
            Title = newTitle;
        }
    }
}
