using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Ticket
    {
        private string _ID;
        private string _UserID;
        private string _ScheduleID; // cái này là foreign key
        private string _CabinTypeID; // cái này là foreign key
        private string _FirstName;
        private string _LastName;
        private string _Phone;
        private string _PassportNumber;
        private string _PassportCountryID; // cái này là foreign key
        private string _BookingReference;
        private string _Confirmed;

        public DTO_Ticket(string iD, string userID, string scheduleID, string cabinTypeID, string firstName, string lastName, string phone, string passportNumber, string passportCountryID, string bookingReference, string confirmed)
        {
            ID = iD;
            UserID = userID;
            ScheduleID = scheduleID;
            CabinTypeID = cabinTypeID;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            PassportNumber = passportNumber;
            PassportCountryID = passportCountryID;
            BookingReference = bookingReference;
            Confirmed = confirmed;
        }

        public DTO_Ticket() { }

        public string ID { get => _ID; set => _ID = value; }
        public string UserID { get => _UserID; set => _UserID = value; }
        public string ScheduleID { get => _ScheduleID; set => _ScheduleID = value; }
        public string CabinTypeID { get => _CabinTypeID; set => _CabinTypeID = value; }
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public string LastName { get => _LastName; set => _LastName = value; }
        public string Phone { get => _Phone; set => _Phone = value; }
        public string PassportNumber { get => _PassportNumber; set => _PassportNumber = value; }
        public string PassportCountryID { get => _PassportCountryID; set => _PassportCountryID = value; }
        public string BookingReference { get => _BookingReference; set => _BookingReference = value; }
        public string Confirmed { get => _Confirmed; set => _Confirmed = value; }
    }
}
