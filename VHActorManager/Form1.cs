using VHActorManager.Master;
using VHActorManager.WebService;

namespace VHActorManager
{
    public partial class Form1 : Form
    {
        private const string SERVER_RUNNING = "‹N“®’†";
        private const string SERVER_STOPPING = "’âŽ~’†";

        private readonly User user;
        private readonly ActorMaster actorMaster;
        private readonly VoiceEngineMaster voiceEngineMaster;
        private readonly WebServer webServer;

        public Form1()
        {
            user = new();
            user.Load();

            actorMaster = new();
            actorMaster.Load();

            voiceEngineMaster = new();
            voiceEngineMaster.Load();

            webServer = new WebServer(user);

            InitializeComponent();

            ServerStartButton.Enabled = true;
            ServerStopButton.Enabled = false;
            ServerStatusBox.Text = SERVER_STOPPING;

            PortBox.Text = user.Server.Port.ToString();
            VSYAMLEnableCheck.Checked = user.VHYaml.Enable;
            VSYAMLFilePathBox.Text = user.VHYaml.Path;
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void VSYAMLFilePathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog.FileName = VSYAMLFilePathBox.Text;

            if (OpenFileDialog.ShowDialog() == DialogResult.Cancel) { return; }

            VSYAMLFilePathBox.Text = OpenFileDialog.FileName;
        }

        private void SaveUserYAMLButton_Click(object sender, EventArgs e)
        {
            user.Server.Port = int.Parse(PortBox.Text);
            user.VHYaml.Enable = VSYAMLEnableCheck.Checked;
            user.VHYaml.Path = VSYAMLFilePathBox.Text;

            user.Save();
        }

        private void ServerStartButton_Click(object sender, EventArgs e)
        {
            webServer.Start();
            ServerStartButton.Enabled = false;
            ServerStopButton.Enabled = true;
            ServerStatusBox.Text = SERVER_RUNNING;
            BaseUrlBox.Text = webServer.BaseUrl;
        }

        private void ServerStopButton_Click(object sender, EventArgs e)
        {
            webServer.Stop();
            ServerStartButton.Enabled = true;
            ServerStopButton.Enabled = false;
            ServerStatusBox.Text = SERVER_STOPPING;
            BaseUrlBox.Text = "";
        }
    }
}