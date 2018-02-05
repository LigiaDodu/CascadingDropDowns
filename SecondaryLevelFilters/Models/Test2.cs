using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondaryLevelFilters.Models
{
    public class Test2
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Test Country{ get; set; }

        
        public Test2(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}