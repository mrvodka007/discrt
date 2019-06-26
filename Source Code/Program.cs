using Discord;
using Discord.WebSocket;
using DiscordRT.Modules;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordRT
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        DiscordSocketClient dSocketClient;
        CommandHandler dCommandHanlder;
        public static int res_x = Screen.PrimaryScreen.Bounds.Width;
        public static int res_y = Screen.PrimaryScreen.Bounds.Height;

        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();


        public async Task StartAsync()
        {
            var InitBl = new BlackList();

            Console.Title = "DiscordRT";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("This is DiscordRT! - Setting up...");
            Console.Write($"My Config Data: \n Authorisation Token: {Configuration.botCfg.token}\n Command Prefix: {Configuration.botCfg.cmdPrefix}\n\r");

            if (Configuration.botCfg.token == "" || Configuration.botCfg.token == null) return;

            dSocketClient = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Debug

            });
            dSocketClient.Log += Client_Log;
            await dSocketClient.LoginAsync(TokenType.Bot, Configuration.botCfg.token);
            await dSocketClient.StartAsync();
            await dSocketClient.SetStatusAsync(UserStatus.DoNotDisturb);
            await dSocketClient.SetGameAsync("Sleeping....", null, ActivityType.Playing);

            dCommandHanlder = new CommandHandler();
            await dCommandHanlder.InitAsync(dSocketClient);
            AllowConsoleType();
            await Task.Delay(-1);


            Console.Title = "DiscordRT - Service: Active";
          
        }

        private async Task AllowConsoleType()
        {
            while(true)
            {
                var x = Console.ReadLine();
                if (x == "quit")
                {
                    await dSocketClient.LogoutAsync();
                    Application.Exit();
                }
                if(x == "logout")
                {
                    await dSocketClient.LogoutAsync();
                }
             
            }
           
        }
        private async Task Client_Log(LogMessage LMSG)
        {
            Console.WriteLine("\n[INFO-LOG]: " + LMSG.Message);
        }

    }
}
