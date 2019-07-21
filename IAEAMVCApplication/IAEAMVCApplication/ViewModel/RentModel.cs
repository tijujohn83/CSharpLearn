using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAEAMVCApplication.ViewModel
{
    public class RentModel
    {
        public int RentID;
        public int BoatID;
        public int CustomerID;
        public DateTime DateRentStart;
        public DateTime? DateRentEnd;
        public string BoatName;
        public string CustomerName;
    }

    public class AllRentListModel
    {
        public IList<BoatModel> AvailableBoats;
        public IList<RentModel> RentedBoats;

    }
}