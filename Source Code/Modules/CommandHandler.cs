using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DiscordRT.Modules
{
    public class CommandHandler
    {
        DiscordSocketClient dSocketClient;
        CommandService dCommandService;

        public async Task InitAsync(DiscordSocketClient client)
        {
            dSocketClient = client;
            dCommandService = new CommandService();
            await dCommandService.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), services: null);
            dSocketClient.MessageReceived += DiscordSocket_IncomingMSG;
        }
        private async Task DiscordSocket_IncomingMSG(SocketMessage sm)
        {
            await dSocketClient.SetStatusAsync(UserStatus.Idle);
            await dSocketClient.SetGameAsync("Processing Request --", null, ActivityType.Playing);

            var message = sm as SocketUserMessage;
            if (message == null) return;

            var context = new SocketCommandContext(dSocketClient, message);
            int argPos = 0;

            if (message.HasStringPrefix(Configuration.botCfg.cmdPrefix, ref argPos) || message.HasMentionPrefix(dSocketClient.CurrentUser, ref argPos))
            {
                var result = await dCommandService.ExecuteAsync(context, argPos, services: null);
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nHandled exception thrown: " + result.ErrorReason);
                    Console.ForegroundColor = ConsoleColor.Blue;
                  
                  
                }
              
            }

            await dSocketClient.SetStatusAsync(UserStatus.Online);
            await dSocketClient.SetGameAsync("Microsoft .NET Framework 4.7", null, ActivityType.Playing);

        }
   
    }
}
