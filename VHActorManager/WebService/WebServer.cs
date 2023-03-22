using Grapevine;
using System.Diagnostics;
using VHActorManager.Master;

namespace VHActorManager.WebService
{
    internal class WebServer
    {
        private const string DOCUMENT_ROOT = "docroot";
        private bool isRunning = false;
        private User userMaster;

        public bool IsRunning { get { return isRunning; } }

        public WebServer(User userMaster)
        {
            this.userMaster = userMaster;
        }

        public async void Start()
        {
            using(var server = RestServerBuilder.UseDefaults().Build())
            {
                string contentPath = Utility.ExecFilepath(DOCUMENT_ROOT);
                server.ContentFolders.Add(contentPath);
                server.UseContentFolders();

                string serverPort = PortFinder.FindNextLocalOpenPort(userMaster.Server.Port);
                server.Prefixes.Add($"http://localhost:{serverPort}/");

                server.AutoParseFormUrlEncodedData();

                server.Start();

                isRunning = true;

                Debug.WriteLine("Server Listening start");

                await Task.Run(() => { while (isRunning) ; });

                Debug.WriteLine("Server Listening finished");
            }
        }

        public void Stop() { isRunning = false; }
    }
}
