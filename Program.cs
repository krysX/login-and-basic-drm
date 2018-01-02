using System;
using System.Collections.Generic;

namespace LoginAndDRM
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountsTest();
            DRMTest();
        }

        static void AccountsTest()
        {
            AccountManager accMan = new AccountManager();
            accMan.Register("krysX", "password");
            accMan.Login("krysX", "password");
            accMan.PrintUserData();
            Console.WriteLine("");
            accMan.ChangePassword("password", "qwertz");
            accMan.PrintUserData();
            Console.WriteLine("");
            accMan.AddSoftware("Minecraft");
            accMan.Logout();
            accMan.Logout();
            accMan.Login("krysX", "test");
            accMan.Register("krysX", "gvrjkgjresh");
            accMan.Register("test", "qwertz");
            accMan.Register("krysX", "qwertz");
            accMan.Login("krysX", "qwertz");
            accMan.PrintUserData();
        }

        static void DRMTest()
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
