using System;
using System.Collections.Generic;
using System.Text;

namespace FacilityServices.BusinessLayer
{
    public class Floor
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public Floor(int name)
        {
            this.Name = name;
        }
    }
}
