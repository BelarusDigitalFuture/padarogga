﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Padarogga.Shared
{
    public class AddCustomerModel
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
