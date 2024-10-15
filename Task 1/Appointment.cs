namespace session5
{
    public class Appointment
    {
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public Doctor Doctor { get; set; }
        public Assistant Assistant { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }

        public Appointment(DateTime date, Customer customer, Doctor doctor, Assistant assistant, double totalPrice, string status)
        {
            Date = date;
            Customer = customer;
            Doctor = doctor;
            Assistant = assistant;
            TotalPrice = totalPrice;
            Status = status;
        }

        #region Check if Doctor is available
        public bool AppointmentDoctorAvalibility()
        {
            return Doctor.IsAvailable(Date);
        }
        #endregion

        #region Change Appointment Status
        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
        }
        public void ChangeAppointmentStatus(DB db, Appointment appointment, string status)
        {
            appointment.UpdateStatus(status);
            db.Update("Appointment", appointment);
            appointment.Doctor.Appointments.Remove(appointment);

        }

        #endregion

        #region  Get Details
        public string GetDetails()
        {
            return $"Appointment on {Date.Month}/{Date.Day}/{Date.Year} at {Date.Hour}:00 AM, Doctor: {Doctor.Name}, Status: {Status}";
        }

        #endregion

        #region Schedule Appointment
        public bool ScheduleAppointment(DB db)
        {
            if (!AppointmentDoctorAvalibility())
            {
                Console.WriteLine($"Doctor {Doctor.Name} is not available on {Date.ToString("MM/dd/yyyy hh:mm tt")}");
                return false;
            }

            foreach (var existingAppointment in Doctor.Appointments)
            {
                if (existingAppointment.Date == Date)
                {
                    Console.WriteLine($"An appointment already exists on {Date.ToString("MM/dd/yyyy hh:mm tt")}");
                    return false;
                }
            }

            bool success = db.Insert("Appointment", this);
            if (success)
            {
                Doctor.Appointments.Add(this);
                return true;
            }
            return false;

        }
        #endregion

    }
}