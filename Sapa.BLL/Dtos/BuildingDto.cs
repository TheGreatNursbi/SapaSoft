using System;
using System.Collections.Generic;
using System.Text;
using Sapa.DAL.Models;

namespace Sapa.BLL.Dtos
{
    public class BuildingDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Height { get; set; }

        public int Floors { get; set; }

        public string Address { get; set; }

        public int Price { get; set; }
        public Builder Builder { get; set; }
    }
}
