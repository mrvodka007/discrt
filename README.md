# DiscordRT
##### Discord Remote Administration Tool / Bot. Allows you to remotely control Windows PC shell and basic functions via Discord. 
![Logo](https://raw.githubusercontent.com/mrvodka007/discrt/master/Bot_Resources_Web/DISCRT_LOGO_SMALLER.png "DiscRT - Logo") 

### DiscRT is an open source remote administration tool for Discord Bot Servers, it allows remote control over a PC through the Discord interface powered by Discord.NET Framework.


## How to install and use.
> **This is not for beginners! If you are a beginner, I advise you to look elsewhere on getting started with a Discord bot.**
#### This application only runs on *Windows with .NET Framework 4.7 or higher!*
1. Download or clone this repository to your PC and open it with File Explorer.
2. Open *DiscordRT.csproj* or *DiscordRT.sln* __(Preferably with Visual Studio 2019)__
3. Make any modifications you desire *(if any at all :)* and compile! __(Make sure it is in *release* not *debug*)__
4. Find the executable in **"bin\x86"** and run the application. _(ignore all errors if any and close or wait for the program to end)
5. Find the _config_ folder in **"bin\x86\Release"** and open it. 
6. Modify the **settings.json** file and add your Discord Application API credentials _(Token)_, your desired command prefix and a password **(This is used for authenticating yourself with the bot in chat)**.
7. Relaunch the program and wait for it to connect to Discord.
8. Allow it to connect to the Internet *(in case of a firewall alert)*
9. Once it connects to Discord, go to your Discord Dev Portal and get the client ID.
10. Replace the client ID in this URL and open it in your browser to add the bot to your server. 
`https://discordapp.com/oauth2/authorize?client_id=CLIENT_ID_HERE&scope=bot&permissions=8`

---
##### DiscordRT - Made by Mr. Vodka
