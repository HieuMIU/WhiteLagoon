using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Services.Interfaces
{
    public interface IAmenityService
    {
        IEnumerable<Amenity> GetAllAmenities();
        Amenity GetAmenityById(int id);
        void CreateAmenity(Amenity amenity);
        void UpdateAmenity(Amenity amenity);
        bool DeleteAmenity(int id);

        bool IsNameExists(int villaId,  string name);
    }
}
