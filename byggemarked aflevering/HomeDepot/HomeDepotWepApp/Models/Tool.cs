using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeDepotWepApp.Models
{
    public class Tool
    {
        public int ToolId { get; set; }
        public string Name { get; set; }


        public Tool(int id, string name)
        {
            ToolId = id;
            Name = name;
        }

        public Tool()
        {

        }

        override
        public string ToString()
        {
            return Name;
        }
    }
}