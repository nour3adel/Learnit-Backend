namespace session5
{
    public class DB
    {
        public Dictionary<string, Appointment> AppointmentList { get; private set; } = new Dictionary<string, Appointment>();
        public Dictionary<int, Customer> CustomerList { get; private set; } = new Dictionary<int, Customer>();
        public Dictionary<int, Assistant> AssistantList { get; private set; } = new Dictionary<int, Assistant>();


        #region  Insert
        public bool Insert(string table, object data)
        {
            if (table == "Appointment" && data is Appointment appointment)
            {
                string key = $"{appointment.Customer.CustomerId}_{appointment.Date.ToShortDateString()}";
                AppointmentList[key] = appointment;
                return true;
            }
            if (table == "Customer" && data is Customer customer)
            {
                CustomerList[customer.CustomerId] = customer;
                return true;
            }
            if (table == "Assistant" && data is Assistant assistant)
            {
                AssistantList[assistant.ID] = assistant;
                return true;
            }
            return false;
        }
        #endregion

        #region  Update   
        public bool Update(string table, object data)
        {

            if (table == "Appointment" && data is Appointment appointment)
            {
                string key = $"{appointment.Customer.CustomerId}_{appointment.Date.ToShortDateString()}";
                if (AppointmentList.ContainsKey(key))
                {
                    AppointmentList[key] = appointment;
                    return true;
                }
            }
            else if (table == "Customer" && data is Customer customer)
            {
                if (CustomerList.ContainsKey(customer.CustomerId))
                {
                    CustomerList[customer.CustomerId] = customer;
                    return true;
                }
            }
            else if (table == "Assistant" && data is Assistant assistant)
            {
                if (AssistantList.ContainsKey(assistant.ID))
                {
                    AssistantList[assistant.ID] = assistant;
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Delete
        public bool Delete(string table, string key)
        {

            if (table == "Appointment" && AppointmentList.ContainsKey(key))
            {
                AppointmentList.Remove(key);
                return true;
            }
            else if (table == "Customer" && int.TryParse(key, out int customerId) && CustomerList.ContainsKey(customerId))
            {
                CustomerList.Remove(customerId);
                return true;
            }
            else if (table == "Assistant" && int.TryParse(key, out int assistantId) && AssistantList.ContainsKey(assistantId))
            {
                AssistantList.Remove(assistantId);
                return true;
            }
            return false;
        }
        #endregion

        #region  Select
        public List<object> Select(string table)
        {
            if (table == "Appointment")
            {
                return new List<object>(AppointmentList.Values);
            }
            else if (table == "Customer")
            {
                return new List<object>(CustomerList.Values);
            }
            else if (table == "Assistant")
            {
                return new List<object>(AssistantList.Values);
            }
            return new List<object>();
        }
        #endregion
    }
}
