﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAuctionApp.Dtos.Dtos
{
    namespace onlineAuctionApp.BLL.Dtos
    {
        public class UserUpdateDto
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public bool IsBaned { get; set; }
        }
    }

}
