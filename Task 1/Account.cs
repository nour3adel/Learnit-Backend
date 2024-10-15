namespace session5
{
    public class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Shift { get; set; }
        public bool Online { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public Account(int id, string name, string phone, string shift, string username, string password)
        {
            ID = id;
            Name = name;
            Phone = phone;
            Shift = shift;
            Online = false;
            Username = username;
            Password = password;
        }

        #region Login 

        public bool Login(string username, string password)
        {
            if (this.Username == username && this.Password == password)
            {
                this.Online = true;
                this.LastLoggedIn = DateTime.Now;
                return true;
            }
            return false;
        }

        #endregion

        #region Logout 
        public bool Logout()
        {
            if (this.Online)
            {
                this.Online = false;
                return true;
            }
            return false;
        }

        #endregion

    }
}