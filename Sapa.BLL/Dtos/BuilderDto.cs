using System;
using System.Collections.Generic;
using System.Text;

namespace Sapa.BLL.Dtos
{
    public class BuilderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BIN { get; set; }
        public DateTime ActivityStartDate { get; set; }
        public string Address { get; set; }
    }
}
