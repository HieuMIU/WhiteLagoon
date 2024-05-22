using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Services.Interfaces;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Services.Implementations
{
    public class VillaNumberService : IVillaNumberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VillaNumberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateVillaNumber(VillaNumber VillaNumber)
        {
            _unitOfWork.VillaNumber.Add(VillaNumber);
            _unitOfWork.Save();
        }

        public bool DeleteVillaNumber(int id)
        {
            try
            {
                VillaNumber? objFromDb = GetVillaNumberById(id);
                if (objFromDb is not null)
                {
                    _unitOfWork.VillaNumber.Delete(objFromDb);
                    _unitOfWork.Save();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<VillaNumber> GetAllVillaNumbers()
        {
            return _unitOfWork.VillaNumber.GetAll(includeProperties: "Villa");
        }

        public VillaNumber GetVillaNumberById(int id)
        {
            return _unitOfWork.VillaNumber.Get(u => u.Villa_Number == id);
        }

        public bool IsRoomNumberExists(int roomNumber)
        {
            return _unitOfWork.VillaNumber.Any(u => u.Villa_Number == roomNumber);
        }

        public void UpdateVillaNumber(VillaNumber VillaNumber)
        {            
            _unitOfWork.VillaNumber.Update(VillaNumber);
            _unitOfWork.Save();
        }
    }
}
