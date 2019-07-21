using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using IAEARepository.Interface;
using IAEADataModel;

namespace IAEARepository.Repository
{
    public class BoatRepository : IBoatRepository
    {
        private IAEADatabaseEntities context;

        public BoatRepository(IAEADatabaseEntities context)
        {
            this.context = context;
        }

        public IList<Boat> GetBoats()
        {
            return context.Boats.Where(b => b.IsRegistered == true).ToList();
        }

        public Boat GetBoatByID(int boatId)
        {
            return context.Boats.Single(b => b.ID == boatId);
        }

        public void InsertBoat(Boat boat)
        {
            boat.IsRegistered = true;
            boat.IsRented = false;
            context.Boats.AddObject(boat);
            context.SaveChanges();            
        }

        public void DeleteBoat(int boatId)
        {
            Boat boat = context.Boats.Single(b => b.ID == boatId);
            boat.IsRegistered = false;
            context.ObjectStateManager.ChangeObjectState(boat, EntityState.Modified);
            context.SaveChanges();
        }

        public void UpdateBoat(Boat boat)
        {
            context.Boats.Attach(boat);
            context.ObjectStateManager.ChangeObjectState(boat, EntityState.Modified);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IList<Boat> GetAvailableBoats()
        {
            return context.Boats.Where(b => b.IsRegistered == true && b.IsRented == false).ToList();
        }

        public IList<Boat> GetRentedBoats()
        {
            return context.Boats.Where(b => b.IsRegistered == true && b.IsRented == true).ToList();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}