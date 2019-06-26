using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRT.Modules
{
    public class BlackList
    {
        private const string blPath = "Config/blacklist.cfg";
        private const string blFolder = "Config";

        public BlackList()
        {
            if (!Directory.Exists(blFolder))
                Directory.CreateDirectory(blFolder);

            if (!File.Exists(blPath))
            {
                File.WriteAllText(blPath, "DISCRT BLACKLIST FILE -- DO NOT EDIT!" + Environment.NewLine);
            }
            else
            {
                string[] results = File.ReadAllLines(blPath);
            }
        }

        public static async Task AddToBan(ulong userID)
        {
            string UserID = userID.ToString();
            string Data = UserID + Environment.NewLine;

            File.AppendAllText(blPath, Data);

                      
        }

        public static async Task<bool> IsBanned(ulong userID)
        {
            string UserID = userID.ToString();
            string[] IDs = File.ReadAllLines(blPath);
            if (IDs.Contains(UserID))
                return true;
            else
                return false;

        }

        // Ban removing doesn't yet exist but there is no point as the person could harm your PC with cmd.
    }
}
