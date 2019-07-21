using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IAEADataModel;

namespace IAEARepository.Interface
{
    public interface IRentRepository : IDisposable
    {        
        void RentBoat(Rent rent);
        Rent GetRentByID(int rentID);
        string ReturnRentedBoat(Rent rent);
        IList<Boat> GetAvailableBoats();
        IList<Rent> GetRentedBoats();
    }
}
