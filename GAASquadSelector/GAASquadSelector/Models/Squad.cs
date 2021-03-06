﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GAASquadSelector.Models
{
    public class Squad
    {
        [Key]
        public int SquadID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Selector> Selections { get; set; }
    }
}