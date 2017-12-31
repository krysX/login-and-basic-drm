using System;
using System.Collections.Generic;
using System.Text;

namespace LoginAndDRM
{
    public class KeyManager
    {
        private List<string> keys = new List<string>();
        public List<string> Keys { get => keys; set => keys = value; }
        public string SoftwareName { get; }
        

        public KeyManager(string name)
        {
            this.SoftwareName = name;

            for(int i = 0; i < 10; i++)
                keys.Add(GenerateKey(4, 5));

        }

        public string GenerateKey(int blockLength, int numOfBlocks)
        {
            //variables that could be set

            Random r = new Random();
            string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < numOfBlocks; i++)
            {
                for (int j = 0; j < blockLength ; j++)
                {
                    char c = validChars[r.Next(validChars.Length)];
                    sb.Append(c);
                }
                if(i < numOfBlocks -1)
                    sb.Append('-');
            }
            return sb.ToString();
        }

        public bool ActivateKey(string key)
        {
            foreach(var item in keys)
            {
                if(key == item)
                {
                    keys.Remove(item);
                    keys.Add(GenerateKey(4, 5));
                    Console.WriteLine("Activation successful.");
                    return true;
                }
                    
            }
            return false;
        }

        
    }
}