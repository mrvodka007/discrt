using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using System.Drawing;
using System.IO;
using Discord;
using System;

namespace DiscordRT.Modules
{
    public class ChatBot : ModuleBase<SocketCommandContext>
    {
        public static List<ulong> AllowedUsers = new List<ulong>();
        public static bool NerdMode = false;
       
        
        [Command("authme")]
        public async Task Response0([Remainder] string password = "0")
        {
            if (await BlackList.IsBanned(Context.User.Id))
                return;
            if (password == Configuration.botCfg.passKey) {
                AllowedUsers.Add(Context.User.Id);
                await Context.Channel.DeleteMessageAsync(Context.Message);
                if (NerdMode) await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("GRANTED_BIN") + Context.User.Username);
                else
                    await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("GRANTED") + Context.User.Username);

            }
            else
                if (NerdMode) await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("DENIED_BIN") + Context.User.Username);
            else
                await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("DENIED") + Context.User.Username);

        }

        [Command("deauthme")]
        public async Task Respone1()
        {
            if (await BlackList.IsBanned(Context.User.Id))
                return;
            var UserID = Context.User.Id;
            if (AllowedUsers.Contains(UserID))
            {
                AllowedUsers.Remove(UserID);
                if (NerdMode) await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("REMOVED_LST_BIN") + Context.User.Username);
                else
                    await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("REMOVED_LST") + Context.User.Username);
            }
            else
                if (NerdMode) await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("REMOVED_ERR_BIN") + Context.User.Username);
            else
                await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("REMOVED_ERR") + Context.User.Username);

        }

        [Command("cmd")]
        public async Task Response2([Remainder] string command = "echo Hellow World!")
        {
            if (await BlackList.IsBanned(Context.User.Id))
                return;
            ulong UserID = Context.User.Id;
            if (AllowedUsers.Contains(UserID))
            {
                string output = LocalPCExecutor.ExecuteCommandPrompt(command);
                if (output.StartsWith("ERR_TOO_LNG"))
                {
                    var xout = output.Substring(11);
                    if (NerdMode)
                    {
                        output += "_BIN";
                        xout = output.Substring(15);
                    }

                    var oldmsg = await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse(output) + "\nUploading text file with data =>\r");
                    var dat_file = System.IO.File.Create("exec_cmd" + ".txt");
                    dat_file.Dispose();

                    File.WriteAllText("exec_cmd" + ".txt", xout);


                    await Context.Channel.SendFileAsync("exec_cmd" + ".txt", "`" + command + "`" + " Output File", false, null, null, false);
                    await Context.Channel.DeleteMessageAsync(oldmsg);
                    File.Delete(command + ".txt");
                }
                else if (!output.StartsWith("OK"))
                    await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse(output));
                else
                {
                    string xout = output.Substring(2);
                    if (NerdMode)
                        await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("OK_BIN") + "```" + xout + "```");
                    else
                        await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("OK") + "```" + xout + "```");
                }

            }
            else
                if (NerdMode) await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("OP_NO_BIN") + Context.User.Username);
            else
                await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("OP_NO") + Context.User.Username);

        }

        [Command("pwsh")]
        public async Task Response3([Remainder] string command = "echo Hello World!")
        {
            if (await BlackList.IsBanned(Context.User.Id))
                return;
            ulong UserID = Context.User.Id;
            if (AllowedUsers.Contains(UserID))
            {
                string output = LocalPCExecutor.ExecutePowerShell(command);
                if (output.StartsWith("ERR_TOO_LNG"))
                {
                    var xout = output.Substring(11);
                    if (NerdMode)
                    {
                        output += "_BIN";
                        xout = output.Substring(15);
                    }

                    var oldmsg = await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse(output) + "\nUploading text file with data =>\r");
                    var dat_file = System.IO.File.Create("exec_cmd" + ".txt");
                    dat_file.Dispose();

                    File.WriteAllText("exec_cmd" + ".txt", xout);


                    await Context.Channel.SendFileAsync("exec_cmd" + ".txt", "`" + command + "`" + " Output File", false, null, null, false);
                    await Context.Channel.DeleteMessageAsync(oldmsg);
                    File.Delete(command + ".txt");
                }
                else if (!output.StartsWith("OK"))
                    await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse(output));
                else
                {
                    string xout = output.Substring(2);
                    if (NerdMode)
                        await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("OK_BIN") + "```" + xout + "```");
                    else
                        await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("OK") + "```" + xout + "```");
                }

            }
            else
                if (NerdMode) await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("OP_NO_BIN") + Context.User.Username);
            else
                await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("OP_NO") + Context.User.Username);
        }

        [Command("screencap")]
        public async Task Response4()
        {
            if (await BlackList.IsBanned(Context.User.Id))
                return;
            ulong UserID = Context.User.Id;
            if (AllowedUsers.Contains(UserID))
            {
                Bitmap img = await LocalPCExecutor.TakeScreenshot();
                img.Save("tempimg.png", System.Drawing.Imaging.ImageFormat.Png);

                await Context.Channel.SendFileAsync("tempimg.png", "PC Screenshot: ");
                File.Delete("tempimg.png");
            }
            else
                if (NerdMode) await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("OP_NO_BIN") + Context.User.Username);
            else
                await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("OP_NO") + Context.User.Username);

        }

        [Command("help")]
        public async Task Response5()
        {
            if (await BlackList.IsBanned(Context.User.Id))
                return;
            var HelpDoc = new EmbedBuilder();
            HelpDoc.Color = new Discord.Color(0, 255, 255);
            HelpDoc.Title = "DiscordRT - Commands :robot:";

            HelpDoc.Description = "**!rt_help** - Shows this help menu.\n" +
                "**!rt_authme {password}** - Allows you to execute remote commands.\n" +
                "**!rt_deauthme** - Disallows you to execute remote commands.\n" +
                "**!rt_cmd {command}** - Executes the CMD command on the remote PC (host).\n" +
                "**!rt_pwsh {command}** - Executes the PowerShell command on the remote PC (host).\n" +
                "**!rt_screencap** - Takes a screenshot of the remote PC and sends it in the current channel.\n" +
                "**!rt_shutdown {op/time}** - Shuts down the remote PC after a specified or default time period.\n" +
                "**!rt_restart {op/time}** - Restarts the remote PC after a specified or defualt time period.\n" +
                "**!rt_talkshit** - this is quite self-explanatory\n" +
                "**!rt_nerdmode** - don't even try tis mode\n" +
                "**!rt_blacklist {userid}** - bans a person from using this bot (only removable thru cfg)\n" +
                "**!rt_hello** - bot just says hello backh" +
                "\n\n\n" +
                "**!rt_abort** - Will get you an abortion. (jk it will cancel Shutdown / Restart)\r"
                ;

            HelpDoc.ImageUrl = "https://raw.githubusercontent.com/mrvodka007/discrt/master/Bot_Resources_Web/DISCRT_LOGO_SMALLER.png";


            HelpDoc.Footer = new EmbedFooterBuilder();
            HelpDoc.Footer.Text = "Contact DiscRT dev or submit issue - Github: https://github.com/mrvodka007/discrt";
            HelpDoc.Footer.Build();

            Embed HelpDocument = HelpDoc.Build();

            await Context.Channel.SendMessageAsync("", false, HelpDocument);

        }

        [Command("nerdmode")]
        public async Task Response6()
        {
            if (await BlackList.IsBanned(Context.User.Id))
                return;
            if (!NerdMode)
            {
                NerdMode = true;
                await Context.Channel.SendMessageAsync("*you have been warned my friend......* :eyes: ");
                return;
            }
            if (NerdMode)
            {
                NerdMode = false;
                await Context.Channel.SendMessageAsync(":clap: :clap: :clap:  __You have passed the test__");
                return;
            }
        }

        [Command("talkshit")]
        public async Task Response7()
        {
            if (await BlackList.IsBanned(Context.User.Id))
                return;
            string[] Garbage = new string[] { "Binary is a number, Denary is a number, Is Hex also a number? :question:", "Did you know that RAT's are very dangerous, they can leak your info and cause the plague.", "Why is Discord the best platform in the universe? - It's the only one that people like to use without relying on it", "What's the difference between a burning PC and an orange tomato? One is a vegetable.", "Do you like DiscRT? If not please don't complain on Github! :middle_finger: I don't care about your opinions if they aint gonna be constructive.", "Intrinsically, the super-postition exists only to prove that therein lies some metaphysical proof in an existential manner, there is in fact a higher power, higher than the nth degree, but we cannot yet comprehend its true connotation without examining the intensity of the subject.", "It can only serve to expose in the harshest possible light the fallacy of these analytical constructs (if we may, at least pro demonstratiu, indulge the conceit of referencing them thus) to take them to their logical conclusion; for while it is not a formally constructed axiom within the framework of the Standard Model -- though one suspects that, given Godel's theorem, it could be axiomated by the Socratic method of demonstrating the unprovability of its negation -- it is accepted as a truism among idiosyncratics and traditionalists alike that any attempted isomorphism between such constructs and any concrete system, but not necessarily a subset of a system, must result in a self-contradiction which cannot be resolved without metareferencing the conditions attendant to the self-contradiction; as is demonstrated by the classic 'catalogues paradox' of Set Theory that was so anathemic to Whitehead and Russell's magnum opus, notwithstanding.", "Blue is greener than purple"};
            Random rnd = new Random();
            int CurrentIndex = rnd.Next(0, Garbage.Length);

            await Context.Channel.SendMessageAsync(Garbage[CurrentIndex]);
        }
           
        [Command("abort")]
        public async Task Response8()
        {
            if (await BlackList.IsBanned(Context.User.Id))
                return;
            bool OkOrNo = LocalPCExecutor.AbortShutDown();
            if(OkOrNo)
            {
                await Context.Channel.SendMessageAsync(":zap: Windows.... stop that shutdown! ---- cheers!, Right mate all done.");
            }
            else
            {
                await Context.Channel.SendMessageAsync(":no_entry_sign: --- Operation Refused! -- PC is shutting down.");
            }


        }

        [Command("shutdown")]
        public async Task Response9([Remainder]string duration = "30")
        {
            if (await BlackList.IsBanned(Context.User.Id))
                return;
            ulong UserID = Context.User.Id;
            if (AllowedUsers.Contains(UserID))
            {
                string output = LocalPCExecutor.ExecuteCommandPrompt("shutdown -s -f -t " + duration);
               
                if (!output.StartsWith("OK"))
                    await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse(output));
                else
                {
                    
                    if (NerdMode)
                        await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("BLANK_BIN"));
                    else
                        await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("BLANK"));
                }

            }
            else
                if (NerdMode) await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("OP_NO_BIN") + Context.User.Username);
            else
                await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("OP_NO") + Context.User.Username);
        }
     
        [Command("restart")]
        public async Task Response10([Remainder]string duration = "30")
        {
            if (await BlackList.IsBanned(Context.User.Id))
                return;
            ulong UserID = Context.User.Id;
            if (AllowedUsers.Contains(UserID))
            {
                string output = LocalPCExecutor.ExecuteCommandPrompt("shutdown -r -t " + duration);


                if (!output.StartsWith("OK"))
                    await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse(output));
                else
                {
                    if (NerdMode)
                        await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("BLANK_BIN"));
                    else
                        await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("BLANK"));
                }

            }
            else
                if (NerdMode) await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("OP_NO_BIN") + Context.User.Username);
            else
                await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("OP_NO") + Context.User.Username);
        }

        [Command("blacklist")]
        public async Task BlackListCmd([Remainder]string user)
        {
            ulong UserID = Context.User.Id;

            if (await BlackList.IsBanned(Context.User.Id))
                return;

            if (AllowedUsers.Contains(UserID))
            {
                ulong userID = ulong.Parse(user);
                BlackList.AddToBan(userID);
                await Context.Channel.SendMessageAsync("The user with ID: " + user + " has been banned from using this bot. :hammer: ");
            }
            else
            {
                if (NerdMode) await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("OP_NO_BIN") + Context.User.Username);
                else
                    await Context.Channel.SendMessageAsync(JsonExtr.GrabResponse("OP_NO") + Context.User.Username);
            }
        }

        [Command("hello")]
        public async Task SayHi()
        {
            if (await BlackList.IsBanned(Context.User.Id))
                return;
            EmbedBuilder eb = new EmbedBuilder();
            eb.Title = "**Hello!** - 0xFFFF";
            eb.Description = "I am DiscRT a simple AIO remote access tool for Discord. I am useful for performing remote admin tasks through Discord. I can help you run other bots and shut your PC down whenever you forget. And don't worry! **NO ONE** but you can use the important commands. __I hope I can serve well.__ ";
            Embed embed = eb.Build();
            await Context.Channel.SendMessageAsync("", false, embed, null);

        }


        
    }
}