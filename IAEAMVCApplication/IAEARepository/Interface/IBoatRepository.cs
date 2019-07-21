using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IAEADataModel;

namespace IAEARepository.Interface
{
    public interface IBoatRepository : IDisposable
    {
        IList<Boat> GetBoats();
        Boat GetBoatByID(int boatId);
        void InsertBoat(Boat boat);
        void DeleteBoat(int boatId);
        void UpdateBoat(Boat boat);
        void Save();        
    }
}
