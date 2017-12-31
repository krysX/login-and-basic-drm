using System;
using System.Collections.Generic;

namespace LoginAndDRM
{
    public class AccountManager
    {
         private List<UserAccount> allUsers = new List<UserAccount>();
         private List<KeyManager> allSoftware = new List<KeyManager>();
         private UserAccount currentUser;

         public AccountManager(){
             Register("admin", "admin");
         }

         public void Register(string name, string pass)
         {
             UserAccount acc = new UserAccount(name, pass);
             foreach(var user in allUsers)
             {
                if(user.Username == acc.Username && user.Password == acc.Password)
                {
                    Console.WriteLine("The username and the password are already taken.");
                }
                else if(user.Username == acc.Username)
                {
                    Console.WriteLine("The username is already taken. Please try another one.");
                    return;
                }
                else if(user.Password == acc.Password)
                {
                    Console.WriteLine("The password is already taken. Please try another one.");
                    return;
                }
             }
             allUsers.Add(acc);
         }

         public void Login(string name, string pass)
         {
             if(currentUser == null){
                foreach (var user in allUsers)
                {
                    if(user.Username == name && user.Password == pass)
                        currentUser = user;
                }
             }
             else Console.WriteLine("You are already logged in.");

             if(currentUser == null)
                Console.WriteLine("The username or password is incorrect. Please try again.");
         }

        //methods that need being logged in start here
         public void Logout()
         {
             if(currentUser != null)
             {
                 foreach (var user in allUsers)
                 {
                     if(user.Username == currentUser.Username && user.RegisteredOn == currentUser.RegisteredOn)
                     {
                        UserAccount cu = currentUser;
                        allUsers[allUsers.IndexOf(user)] = cu;
                     }
                 }
                 currentUser = null;
                 Console.WriteLine("You are successfully logged out.");
             }
             else Console.WriteLine("You are already logged out.");
         }

         public void PrintUserData()
         {
             if(currentUser != null)
             {
                Console.WriteLine($"Username\t{currentUser.Username}");
                Console.WriteLine($"Password\t{currentUser.Password}");
                Console.WriteLine($"Registered on\t{currentUser.RegisteredOn}");
                Console.WriteLine($"Activated software:\t");
                currentUser.GetActivatedSoftware();
             }
             else Console.WriteLine("You are logged out. Please login to continue.");
         }

         public List<string> GetKeys(string softwareName)
         {
             if(currentUser != null && currentUser.Username == "admin")
             {
                 foreach(var software in allSoftware)
                 {
                     if(software.SoftwareName == softwareName)
                     {
                         Console.WriteLine($"The keys for {software.SoftwareName}:");
                         foreach(string key in software.Keys)
                            Console.WriteLine(key);
                         return software.Keys;
                     }
                     else 
                     {
                         Console.WriteLine("No such software found");
                         return null;
                     }
                 }
                 return null;
             }
             return null;
         }

         public void Activate(string key)
         {
             if(currentUser != null)
             {
                 bool hasSucceeded = false;
                 foreach (var software in allSoftware)
                {
                    hasSucceeded = software.ActivateKey(key);
                    if(hasSucceeded)
                        currentUser.ActivateSoftware(software.SoftwareName);
                }
                if(!hasSucceeded)
                    Console.WriteLine("Invalid key.");
             }
             else Console.WriteLine("You are logged out. Please login to continue.");
         }

         public void ChangePassword(string oldPass, string newPass)
         {
             if(currentUser != null)
             {
                if (oldPass == currentUser.Password)
                {
                    currentUser.Password = newPass;
                    Console.WriteLine("Password has been successfully changed.");
                }
             }
             else Console.WriteLine("You are logged out. Please login to continue.");
             
         }

         public void AddSoftware(string name)
         {
             if(currentUser != null && currentUser.Username == "admin")
                allSoftware.Add(new KeyManager(name));
            else if (currentUser.Username != "admin")
                Console.WriteLine("You can't access this. Please log in as administrator to continue.");
            else Console.WriteLine("You are logged out. Please login to continue.");
         }
    }
}