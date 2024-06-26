﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interface;

namespace WhiteLagoon.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IVillaReppository Villa { get; }

        IVillaNumberRepository VillaNumber { get; }

        IAmenityReppository Amenity { get; }

        IBookingRepository Booking { get; }

        IApplicationUserRepository User { get; }    

        void Save();
    }
}
