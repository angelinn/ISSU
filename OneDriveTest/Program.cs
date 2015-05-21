using Microsoft.Live;
using OneDriveRestAPI;
using OneDriveRestAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDriveTest
{
    class Program
    {
        static async void Main(string[] args)
        {
            string id = "0000000048154E3D";
            string secret = "UMk2JtIS05EPBd3vwtFkJg2w52xk7JJ8";
            bool connected = false;
            try
            {
                var authClient = new LiveAuthClient(id);
                authClient.Session.
                LiveLoginResult result = await authClient.LoginAsync( new string[] { "wl.signin", "wl.skydrive" });
                authClient.l
                if (result.Status == LiveConnectSessionStatus.Connected)
                {
                    connected = true;
                    var connectClient = new LiveConnectClient(result.Session);
                    var meResult = await connectClient.GetAsync("me");
                    dynamic meData = meResult.Result;
                    updateUI(meData);
                }
            }
            catch (LiveAuthException ex)
            {
                // Display an error message.
            }
            catch (LiveConnectException ex)
            {
                // Display an error message.
            }
        }
    }
}
