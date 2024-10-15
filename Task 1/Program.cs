namespace session5;

class Program
{
    static void Main(string[] args)
    {

        Doctor doctor1 = new Doctor(1, "Dr. Ahmed Ibrahim", "+20123456789", "Morning", "Ahmed", "123", "Dentist");
        Doctor doctor2 = new Doctor(2, "Dr. Mariem Khaled", "+20112233445", "Evening", "Mariem", "321", "Eyes");

        Assistant assistant1 = new Assistant(1, "Mosatfa Mosa", "+201245871", "Morning", "Mostafa", "111");
        Assistant assistant2 = new Assistant(2, "Kareem Adel", "+201365997", "Evening", "Kareem", "222");

        Customer customer1 = new Customer(1, "Sara Hamed", "Obour city, cairo", 22, "Female", "No history");
        Customer customer2 = new Customer(2, "Ahmed Rabiee", "Elmadee city, cairo", 23, "Male", "Diabetes");

        DB db = new DB();

        db.Insert("Doctor", doctor1);
        db.Insert("Doctor", doctor2);
        db.Insert("Assistant", assistant1);
        db.Insert("Assistant", assistant2);
        db.Insert("Customer", customer1);
        db.Insert("Customer", customer2);
        Console.WriteLine("-------------------------------------");

        DateTime appointmentDate1 = new DateTime(2024, 10, 4, 9, 0, 0);
        Appointment appointment1 = new Appointment(appointmentDate1, customer1, doctor1, assistant1, 200, "Scheduled");

        bool success1 = appointment1.ScheduleAppointment(db);
        if (success1)
        {
            Console.WriteLine("Appointment 1 scheduled successfully!");
        }
        else
        {
            Console.WriteLine("Failed to schedule appointment 1.");
        }

        Console.WriteLine("-------------------------------------");

        DateTime appointmentDate2 = new DateTime(2024, 10, 11, 5, 30, 0);
        Appointment appointment2 = new Appointment(appointmentDate2, customer2, doctor2, assistant2, 300, "Scheduled");

        bool success2 = appointment2.ScheduleAppointment(db);
        if (success2)
        {
            Console.WriteLine("Appointment 2 scheduled successfully!");
        }
        else
        {
            Console.WriteLine("Failed to schedule appointment 2.");
        }
        Console.WriteLine("-------------------------------------");


        DateTime appointmentDate3 = new DateTime(2024, 10, 11, 5, 30, 0);
        Appointment appointment3 = new Appointment(appointmentDate3, customer2, doctor2, assistant2, 300, "Scheduled");

        bool success3 = appointment3.ScheduleAppointment(db);
        if (success3)
        {
            Console.WriteLine("Appointment 3 scheduled successfully!");
        }
        else
        {
            Console.WriteLine("Failed to schedule appointment 3.");
        }

        Console.WriteLine("-------------------------------------");


        DateTime appointmentDate4 = new DateTime(2024, 10, 25, 4, 30, 0);
        Appointment appointment4 = new Appointment(appointmentDate4, customer2, doctor2, assistant2, 300, "Scheduled");

        bool success4 = appointment4.ScheduleAppointment(db);
        if (success4)
        {
            Console.WriteLine("Appointment 4 scheduled successfully!");
        }
        else
        {
            Console.WriteLine("Failed to schedule appointment 4.");
        }

        Console.WriteLine("-------------------------------------");

        Console.WriteLine("Appointments for " + doctor1.Name + ":");
        List<Appointment> schedule = doctor1.GetSchedule();
        foreach (var appointment in schedule)
        {
            Console.WriteLine(appointment.GetDetails());
        }

        Console.WriteLine("-------------------------------------");

        Console.WriteLine("Appointments for " + doctor2.Name + ":");
        List<Appointment> schedule2 = doctor2.GetSchedule();
        foreach (var appointment in schedule2)
        {
            Console.WriteLine(appointment.GetDetails());
        }
        Console.WriteLine("-------------------------------------");


        DateTime requestedDate = new DateTime(2024, 10, 10, 9, 0, 0);
        bool isDoctor1Available = doctor1.IsAvailable(requestedDate);

        if (isDoctor1Available)
        {
            Console.WriteLine("Doctor 1 is available for this time slot.");
        }
        else
        {
            Console.WriteLine("Doctor 1 is not available for this time slot.");
        }
        Console.WriteLine("-------------------------------------");


        DateTime requestedDate2 = new DateTime(2024, 10, 4, 9, 0, 0);
        bool isDoctor1Available2 = doctor1.IsAvailable(requestedDate2);
        if (isDoctor1Available2)
        {
            Console.WriteLine("Doctor 1 is available for this time slot.");
        }
        else
        {
            Console.WriteLine("Doctor 1 is not available for this time slot.");
        }
        Console.WriteLine("-------------------------------------");


        Console.WriteLine("Changing Appointment 1 status to 'Completed'.");
        appointment2.ChangeAppointmentStatus(db, appointment1, "Completed");
        Console.WriteLine("-------------------------------------");



        Console.WriteLine("Appointments for " + doctor1.Name + ":");
        List<Appointment> schedule4 = doctor1.GetSchedule();
        foreach (var appointment in schedule4)
        {
            Console.WriteLine(appointment.GetDetails());
        }
        if (schedule4.Count == 0)
        {
            Console.WriteLine("No appointments for " + doctor1.Name + ".");
        }
        else
        {
            foreach (var appointment in schedule4)
            {
                Console.WriteLine(appointment.GetDetails());
            }
        }
        Console.WriteLine("-------------------------------------");


        Console.WriteLine("Canceling Appointment 2.");
        db.Delete("Appointment", appointment2.ToString());
        doctor2.Appointments.Remove(appointment2);
        Console.WriteLine("Appointment 2 has been canceled.");
        Console.WriteLine("-------------------------------------");



        Console.WriteLine("Appointments for " + doctor2.Name + ":");
        List<Appointment> schedule3 = doctor2.GetSchedule();
        if (schedule3.Count == 0)
        {
            Console.WriteLine("No appointments for " + doctor2.Name + ".");
        }
        else
        {
            foreach (var appointment in schedule3)
            {
                Console.WriteLine(appointment.GetDetails());
            }
        }
        Console.WriteLine("-------------------------------------");


        assistant1.AddToWaiting(customer2);
        Console.WriteLine($"Customer {customer2.Name} added to the waiting list by Assistant {assistant1.Name}.");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Rescheduling Appointment 1.");
        DateTime newAppointmentDate = new DateTime(2024, 10, 12, 10, 30, 0);
        assistant1.ChangeAppointment(appointment1, newAppointmentDate);
        db.Update("Appointment", appointment1);
        Console.WriteLine($"Appointment 1 rescheduled to {appointment1.Date}.");

        Console.WriteLine("------------------------------------------");
        Console.WriteLine("-------------- Final Summary --------------");
        Console.WriteLine($"Doctor 1 has {doctor1.Appointments.Count} appointments.");
        Console.WriteLine($"Doctor 2 has {doctor2.Appointments.Count} appointments.");
        Console.WriteLine($"Assistant 1 has {assistant1.WaitingList.Count} people on the waiting list.");
        Console.WriteLine("-------------------------------------");
    }
}
