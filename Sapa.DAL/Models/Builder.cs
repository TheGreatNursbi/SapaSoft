using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sapa.DAL.Models
{
    public class Builder
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BIN { get; set; }

        public DateTime ActivityStartDate { get; set; }

        public string Address { get; set; }

        public Boolean IsDeleted { get; set; }

        [JsonIgnore]
        public virtual ICollection<Building> Buildings { get; set; }
    }
}
