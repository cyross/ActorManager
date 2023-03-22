using VHActorManager.Master;

namespace VHActorManager
{
    public partial class Form1 : Form
    {
        private readonly User user;
        private readonly ActorMaster actorMaster;
        private readonly VoiceEngineMaster voiceEngineMaster;

        public Form1()
        {
            user = new();
            user.Load();

            actorMaster = new();
            actorMaster.Load();

            voiceEngineMaster = new();
            voiceEngineMaster.Load();

            InitializeComponent();

            MasterYAMLPathBox.Text = user.MasterFilepath;
            PortBox.Text = user.Server.Port.ToString();
            VSYAMLEnableCheck.Checked = user.VHYaml.Enable;
            VSYAMLFilePathBox.Text = user.VHYaml.Path;
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MasterYAMLPathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog.FileName = MasterYAMLPathBox.Text;

            if(OpenFileDialog.ShowDialog() == DialogResult.Cancel) { return; }

            MasterYAMLPathBox.Text = OpenFileDialog.FileName;
        }

        private void VSYAMLFilePathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog.FileName = VSYAMLFilePathBox.Text;

            if (OpenFileDialog.ShowDialog() == DialogResult.Cancel) { return; }

            VSYAMLFilePathBox.Text = OpenFileDialog.FileName;
        }

        private void SaveUserYAMLButton_Click(object sender, EventArgs e)
        {
            user.MasterFilepath = MasterYAMLPathBox.Text;
            user.Server.Port = int.Parse(PortBox.Text);
            user.VHYaml.Enable = VSYAMLEnableCheck.Checked;
            user.VHYaml.Path = VSYAMLFilePathBox.Text;

            user.Save();
        }
    }
}