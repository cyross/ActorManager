using Grapevine;
using System.Diagnostics;
using VHActorManager.Master;

namespace VHActorManager.WebService
{
    internal class WebServer
    {
        private const string DOCUMENT_ROOT = "docroot";
        private string baseUrl;
        private bool isRunning;
        private User userMaster;

        public bool IsRunning { get { return isRunning; } }

        public string BaseUrl { get { return baseUrl; } }

        public WebServer(User user)
        {
            userMaster = user;
            baseUrl = "";
            isRunning = false;
        }

        public async void Start()
        {
            using(var server = RestServerBuilder.UseDefaults().Build())
            {
                string contentPath = Utility.ExecFilepath(DOCUMENT_ROOT);
                server.ContentFolders.Add(contentPath);
                server.UseContentFolders();

                string serverPort = PortFinder.FindNextLocalOpenPort(userMaster.Server.Port);
                baseUrl = $"http://localhost:{serverPort}/";
                server.Prefixes.Add(baseUrl);

                server.AutoParseFormUrlEncodedData();

                server.Start();

                isRunning = true;

                Debug.WriteLine("Server Listening start");

                await Task.Run(() => { while (isRunning) ; });

                Debug.WriteLine("Server Listening finished");
            }
        }

        public void Stop() {
            baseUrl = "";
            isRunning = false;
        }
    }
}
