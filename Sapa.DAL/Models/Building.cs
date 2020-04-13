using System;
using System.Collections.Generic;
using System.Text;

namespace Sapa.DAL.Models
{
    public class Building
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Height { get; set; }

        public int Floors { get; set; }

        public string Address { get; set; }

        public int Price { get; set; }

        public int BuilderId { get; set; }

        public Boolean IsDeleted { get; set; }

        public Builder Builder { get; set; }
    }
}
