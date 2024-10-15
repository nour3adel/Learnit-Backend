namespace session5
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string History { get; set; }


        public Customer(int customerId, string name, string address, int age, string gender, string history)
        {
            CustomerId = customerId;
            Name = name;
            Address = address;
            Age = age;
            Gender = gender;
            History = history;
        }

        #region Get Customer Details

        public string GetCustomerDetails()
        {
            return $"ID: {CustomerId}, Name: {Name}, Address: {Address}, Age: {Age}, Gender: {Gender}, History: {History}";
        }

        #endregion
    }
}