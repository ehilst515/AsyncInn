﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncApp.Models
{
    public class Hotel
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string StreetAdress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }


        public long RoomId { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }

    }
}
