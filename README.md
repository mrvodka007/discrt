<h1 align="center">DiscordRT - Remote Administration Tool</h1>

##### Discord Remote Administration Tool / Bot. Allows you to remotely control Windows PC shell and basic functions via Discord. 

<center>
<img src="https://raw.githubusercontent.com/mrvodka007/discrt/master/Bot_Resources_Web/DISCRT_LOGO_SMALLER.png">
</center>

### DiscRT is an open source remote administration tool for Discord Bot Servers, it allows remote control over a PC through the Discord interface powered by Discord.NET Framework.


## How to install and use.
> **This is not for beginners! If you are a beginner, I advise you to look elsewhere on getting started with a Discord bot.**
#### This application only runs on *Windows with .NET Framework 4.7 or higher!*
1. Download or clone this repository to your PC and open it with File Explorer. __YOU WILL NEED TO EXTRACT *packages.zip* unless you choose to re-download them from NuGet.__
2. Open *DiscordRT.csproj* or *DiscordRT.sln* __(Preferably with Visual Studio 2019)__
3. Make any modifications you desire *(if any at all :)* and compile! __(Make sure it is in *release* not *debug* and set to x86)__
4. Find the executable in **"bin\x86"** and run the application. _(ignore all errors if any and close or wait for the program to end)_
5. Find the _config_ folder in **"bin\x86\Release"** and open it. 
6. Modify the **settings.json** file and add your Discord Application API credentials _(Token)_, your desired command prefix and a password **(This is used for authenticating yourself with the bot in chat)**.
7. Relaunch the program and wait for it to connect to Discord.
8. Allow it to connect to the Internet *(in case of a firewall alert)*
9. Once it connects to Discord, go to your Discord Dev Portal and get the client ID.
10. Replace the client ID in this URL and open it in your browser to add the bot to your server. 
`https://discordapp.com/oauth2/authorize?client_id=CLIENT_ID_HERE&scope=bot&permissions=8`

### You have successfully installed DiscRT on your server. Happy Admin-ing? - _Oh and happy Discord Hack Week!_

![Discord Hack Week](https://raw.githubusercontent.com/mrvodka007/discrt/master/Bot_Resources_Web/hack_badge_black.png "Discord")

# Commands
| Command       | Function      | Need Auth? |
| ------------- |:-------------:| -----:|
| !rt_help      | Shows help | No |
| !rt_authme {password}     | Allows you to execute remote cmds    |   No |
| !rt_deauthme | Disallows you to execute remote cmds  |    Yes |
| !rt_cmd {command} | Executes the CMD command on remote PC | Yes |
| !rt_pwsh {command} | Executes the PowerShell command on remote PC | Yes |
| !rt_screencap | Takes a screenshot of remote PC and sends it in chat | Yes |
| !rt_shutdown {time} | Shuts down the remote PC after specified or default time | Yes |
| !rt_restart {time~ | Restarts the remote PC after specified or default time | Yes |
| !rt_talkshit | Quite self explanatory | No |
| !rt_nerdmode | Don't try it, everything is binary | No |
| !rt_blacklist {userid} | Bans the user from using any commands (non removable, only by cfg) | Yes |
| !rt_hello | the bot says hello message | No |
| !rt_abort | Will get you an abortion. (jk it will cancel the shutdown / restart operation) | No |

---
##### DiscordRT - Made by Mr. Vodka
