using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using IAEARepository.Interface;
using IAEADataModel;

namespace IAEARepository.Repository
{
    public class RentRepository : IRentRepository
    {
        private IAEADatabaseEntities context;

        public RentRepository(IAEADatabaseEntities context)
        {
            this.context = context;
        }

        public IList<Rent> GetRentedBoats()
        {
            return context.Rents.Include("Boat").Include("Customer").Where(r => r.DateRentEnd == null).ToList();
        }

        public IList<Boat> GetAvailableBoats()
        {
            //return context.Rents.Include("Boat").Include("Customer").Where(r => r.Boat.IsRented == false).ToList();
            return context.Boats.Where(b => b.IsRegistered == true && b.IsRented == false).ToList();
        }

        public Rent GetRentByID(int rentID)
        {
            return context.Rents.Single(r => r.ID == rentID);
        }

        public void RentBoat(Rent rent)
        {
            rent.DateRentStart = DateTime.UtcNow;
            var boatID = new SqlParameter("@BoatID", System.Data.SqlDbType.Int);
            boatID.Value = rent.BoatID;
            var customerID = new SqlParameter("@CustomerID", System.Data.SqlDbType.Int);
            customerID.Value = rent.CustomerID;
            var dateRentStart = new SqlParameter("@RentStartDate", System.Data.SqlDbType.DateTime);
            dateRentStart.Value = DateTime.UtcNow;
            var outputReturned = new SqlParameter("@SuccessReturn", System.Data.SqlDbType.Int);
            outputReturned.Direction = ParameterDirection.Output;

            context.ExecuteStoreCommand("spRentBoat @BoatID,@CustomerID,@RentStartDate, @SuccessReturn out",
                           boatID, customerID, dateRentStart, outputReturned);

            int output = Convert.ToInt32(outputReturned.Value);
        }

        public string ReturnRentedBoat(Rent rent)
        {
            int totalCost = 0;

            rent.DateRentEnd = DateTime.UtcNow;
            var rentID = new SqlParameter("@RentID", System.Data.SqlDbType.Int);
            rentID.Value = rent.ID;
            var dateRentEnd = new SqlParameter("@RentEndDate", System.Data.SqlDbType.DateTime);
            dateRentEnd.Value = rent.DateRentEnd;
            var outputReturned = new SqlParameter("@SuccessReturn", System.Data.SqlDbType.Int);
            outputReturned.Direction = ParameterDirection.Output;

            context.ExecuteStoreCommand("spReturnRentedBoat @RentID,@RentEndDate, @SuccessReturn out",
                           rentID, dateRentEnd, outputReturned);

            int output = Convert.ToInt32(outputReturned.Value);
            if (output == 0)
            {
                TimeSpan? rentedTime = rent.DateRentEnd - rent.DateRentStart;
                int totalHours = Convert.ToInt32(rentedTime.Value.TotalHours);

                if (totalHours == 0)
                {
                    totalHours = 1;
                }

                //get boat info
                Boat boat = context.Boats.Where(b => b.ID == rent.BoatID).SingleOrDefault();
                if (boat != null)
                {
                    totalCost = totalHours * boat.HourlyRate;
                }

                return "Total Hours: " + totalHours + ", Total Cost: " + totalCost;
            }
            else
            {
                return "Something went wrong, please contact the administrator!";
            }
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