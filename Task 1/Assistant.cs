namespace session5
{
    public class Assistant : Account
    {

        public bool FullAuth { get; set; } = false;
        public List<Customer> WaitingList { get; set; } = new List<Customer>();

        public Assistant(int id, string name, string phone, string shift, string username, string password)
            : base(id, name, phone, shift, username, password) { }


        #region Add New Customer
        public void AddNewCustomer(Customer customer)
        {
            if (!WaitingList.Contains(customer))
            {
                WaitingList.Add(customer);
            }
        }

        #endregion

        #region Add To Waiting List
        public void AddToWaiting(Customer customer)
        {
            WaitingList.Add(customer);
            Console.WriteLine($"{customer.Name} has been added to the waiting list.");
        }

        #endregion

        #region Add Appointment
        public void AddAppointment(Appointment appointment)
        {
            appointment.Assistant = this;
        }
        #endregion

        #region Delete Appointment
        public bool DeleteAppointment(DB db, Appointment appointment)
        {
            string appointmentKey = $"{appointment.Customer.CustomerId}_{appointment.Date.ToShortDateString()}";

            return db.Delete("Appointment", appointmentKey);
        }
        #endregion

        #region  Change Appointment Status
        public void ChangeAppointmentStatus(Appointment appointment, string status)
        {
            appointment.Status = status;
        }
        #endregion

        #region Get Waiting List
        public List<Customer> GetWaitingList()
        {
            return WaitingList;
        }
        #endregion

        #region Change Appointment Date
        public void ChangeAppointment(Appointment appointment, DateTime newDateTime)
        {
            appointment.Date = newDateTime;
            Console.WriteLine($"Appointment has been rescheduled to {newDateTime}.");
        }
        #endregion

    }
}