using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GAASquadSelector.Models
{

    public class Selector
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SelectionID { get; set; }
        public int SquadID { get; set; }
        public int PlayerID { get; set; }
        public Positions Position { get; set; }

        public virtual Player Players { get; set; }
        public virtual Squad Squad { get; set; }
    }
}