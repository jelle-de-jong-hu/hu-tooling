namespace WinFormsApp1
{
    public class SendKeysContext : ApplicationContext
    {
        private NotifyIcon trayIcon;
        private bool Paused = false;
        private ToolStripMenuItem pauseResumeMenuItem;

        public SendKeysContext()
        {
            var contextMenuStrip = new ContextMenuStrip();
            var exitMenuItem = new ToolStripMenuItem();
            exitMenuItem.Click += Exit;
            exitMenuItem.Text = "Exit";

            contextMenuStrip.Items.Add(exitMenuItem);
            trayIcon = new NotifyIcon()
            {
                Icon = new Icon("PowerButtonIcon.ico"),
                ContextMenuStrip = contextMenuStrip,
                Visible = true
            };
            pauseResumeMenuItem = new ToolStripMenuItem();
            pauseResumeMenuItem.Click += PauseResume;
            pauseResumeMenuItem.Text = "Pause";

            contextMenuStrip.Items.Add(pauseResumeMenuItem);

            Task.Factory.StartNew(Run, TaskCreationOptions.LongRunning);
        }

        private void PauseResume(object sender, EventArgs e)
        {
            if (Paused)
            {
                pauseResumeMenuItem.Text = "Pause";
            } else
            {
                pauseResumeMenuItem.Text = "Resume";
            }

            Paused = !Paused;
        }

        private void Run()
        {
            while (true)
            {
                if (!Paused) { 
                    SendKeys.SendWait("{F15}");
                }
                Thread.Sleep(60 * 10 * 1000);
            }
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;

            Application.Exit();
        }
    }
}
