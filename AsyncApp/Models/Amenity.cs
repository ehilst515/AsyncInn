﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncApp.Models
{
    public class Amenity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<RoomAmenity> RoomAmenities { get; set; }

    }

}
