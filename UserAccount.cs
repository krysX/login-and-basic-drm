using System;
using System.Collections.Generic;

namespace LoginAndDRM
{
    public class UserAccount
    {
        public string Username { get; }
        public string Password { get; set; }
        public DateTime RegisteredOn { get; }
        private List<string> activatedSoftware = new List<string>();

        public UserAccount(string name, string pass)
        {
            this.Username = name;
            this.Password = pass;
            this.RegisteredOn = DateTime.Now;
        }

        public void GetActivatedSoftware()
        {
            foreach (var item in activatedSoftware)
            {
                Console.WriteLine($"\t{item}");
            }
        }

        public void ActivateSoftware(string name)
        {
            activatedSoftware.Add(name);
        }
    }
}