﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAuctionApp.Dtos.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsBaned { get; set; }
    }

}