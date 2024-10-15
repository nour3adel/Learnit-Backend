namespace session5
{
    public enum WorkingDays
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
    }

    public class Doctor : Account
    {

        public string Department { get; set; }
        public bool FullAuth { get; set; } = true;
        public List<Assistant> Assistants { get; set; } = new List<Assistant>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public List<WorkingDays> WorkingDays { get; set; } = new List<WorkingDays>();

        public Doctor(int id, string name, string phone, string shift, string username, string password, string department)
            : base(id, name, phone, shift, username, password)
        {
            Department = department;
        }


        #region Add Assistants

        public void AddAssistant(Assistant assistant)
        {
            if (!Assistants.Contains(assistant))
            {
                Assistants.Add(assistant);
            }
        }

        #endregion

        #region Get Schedules

        public List<Appointment> GetSchedule()
        {
            return Appointments;
        }

        #endregion

        #region Is it Available?
        public bool IsAvailable(DateTime dateTime)
        {
            foreach (var appointment in Appointments)
            {

                if (appointment.Date.Date == dateTime.Date && appointment.Date.TimeOfDay == dateTime.TimeOfDay)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Is it a working day?

        public bool IsWorkingDay(DateTime date)
        {
            return WorkingDays.Contains((WorkingDays)date.DayOfWeek);
        }
        #endregion

        #region Get Assistants
        public List<Assistant> GetAssistants()
        {
            return Assistants;
        }

        #endregion
    }


}