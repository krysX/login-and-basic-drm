using System;
using System.Collections.Generic;

namespace LoginAndDRM
{
    class Program
    {
        static void Main(string[] args)
        {
            PassChangeTest();
            KeysTest();
        }

        static void PassChangeTest()
        {
            AccountManager accMan = new AccountManager();
            accMan.Register("krysX", "password");
            accMan.Login("krysX", "password");
            accMan.PrintUserData();
            Console.WriteLine("");
            accMan.ChangePassword("password", "krysX123");
            accMan.PrintUserData();
            Console.WriteLine("");
        }

        static void KeysTest()
        {
            AccountManager accMan = new AccountManager();
            accMan.Login("admin", "admin");
            accMan.PrintUserData();
            Console.WriteLine("");
            accMan.AddSoftware("Project Voxtronaut");
            List<string> keys = accMan.GetKeys("Project Voxtronaut");
            Console.WriteLine("");
            Random r = new Random();
            string key = keys[r.Next(keys.Count)];
            accMan.Activate(key);
            Console.WriteLine("");
            accMan.PrintUserData();
            Console.WriteLine("");
            accMan.GetKeys("Project Voxtronaut");
        }
    }
}
