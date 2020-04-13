using System;
using System.Collections.Generic;
using System.Text;

namespace Sapa.BLL.Dtos
{
    public class BaseBuildingDto
    {
        public string Name { get; set; }

        public int Height { get; set; }

        public int Floors { get; set; }

        public string Address { get; set; }

        public int Price { get; set; }
        public int BuilderId { get; set; }
    }
}
