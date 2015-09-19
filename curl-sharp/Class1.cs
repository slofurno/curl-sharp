using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace curl_sharp
{
    public class CurlClient
    {
      private ProcessStartInfo startInfo;

      public CurlClient()
      {

      }


      public static async Task<string> Get(string url)
      {
        //-i -H "Accept: application/json" -H "Content-Type: application/json" -X GET http://hostname/resource
        var startInfo = new ProcessStartInfo();
        //startInfo.FileName = "C:/Program Files (x86)/Microsoft SDKs/F#/4.0/Framework/v4.0/fsi.exe";
        startInfo.FileName = "curl";
        startInfo.Arguments = "-i -H \"Accept: application/json\" -H \"Content-Type: application/json\" -X GET " + url;
        startInfo.RedirectStandardInput = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        startInfo.UseShellExecute = false;

        var process = Process.Start(startInfo);
        var reader = process.StandardOutput;
        var writer = process.StandardInput;
        var error = process.StandardError;

        string response = "";
        string output;
        while ((output = await reader.ReadLineAsync()) != null)
        {
          response += output;
          response += "\r\n";
        }

        return response;

      }

      public static async Task<string> Post(string url, string data)
      {
        //curl -X POST -d @filename http://hostname/resource

        var startInfo = new ProcessStartInfo();
        //startInfo.FileName = "C:/Program Files (x86)/Microsoft SDKs/F#/4.0/Framework/v4.0/fsi.exe";
        startInfo.FileName = "curl";
        startInfo.Arguments = "-X POST -H \"Accept: Application/json\" -H \"Content-Type: application/json\" -d \"" + data + "\" " + url;
        startInfo.RedirectStandardInput = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        startInfo.UseShellExecute = false;

        var process = Process.Start(startInfo);
        var reader = process.StandardOutput;
        var writer = process.StandardInput;
        var error = process.StandardError;

        string response = "";
        string output;
        while ((output = await reader.ReadLineAsync()) != null)
        {
          response += output;
          response += "\r\n";
        }

        return response;

      }


    }
}
