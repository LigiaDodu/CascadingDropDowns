using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondaryLevelFilters.Models
{
    public class Test3
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Test3(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}