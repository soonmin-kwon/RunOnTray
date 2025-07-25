using System.Diagnostics;
using System.IO;
using System.Windows;

namespace RunOnTray
{
    public partial class App : System.Windows.Application
    {
        public int runAnimLength = 8;
        private NotifyIcon trayIcon = null;
        private List<Icon> icons = null;
        private int currentIndex = 0;

        private CpuUsageTimer timer = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //MainWindow = new MainWindow();
            //MainWindow.Topmost = false;
            //MainWindow.Hide(); // 윈도우 숨기기 (트레이 앱용)
            //MainWindow.Visibility = Visibility.Hidden;

            SetIcons();

            // 트레이 아이콘 설정
            trayIcon = new NotifyIcon();
            trayIcon.Icon = icons[currentIndex];
            trayIcon.Visible = true;
            trayIcon.Text = "RunOnTray";
            
            // 트레이 메뉴
            var contextMenu = new ContextMenuStrip();
            SetTurtleContextMenu(contextMenu);
            SetPerformanceCounter();

            trayIcon.ContextMenuStrip = contextMenu;
        }


        private void SetIcons()
        {
            icons = new List<Icon>(runAnimLength);

            for (int i=0; i< runAnimLength; i++)
            {
                icons.Add(new Icon(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", $"{(i + 1).ToString()}.ico")));
            }
        }

        private void SetTurtleContextMenu(ContextMenuStrip contextMenu)
        {
            var exitItem = new ToolStripMenuItem("Exit");
            exitItem.Click += (s, args) =>
            {
                trayIcon.Visible = false;
                Shutdown();
            };

            
            // 설정 누르면 새 윈도우 열리고 거기서 아이콘 path 설정
            // 아이콘 path 설정 시 아이콘 리셋
            var speedUpItem = new ToolStripMenuItem("Speed Up");
            speedUpItem.Click += (s, args) =>
            {
                if (timer != null)
                {
                    timer.SetInterval(true);
                }
            };

            var slowDownItem = new ToolStripMenuItem("Slow Down");
            slowDownItem.Click += (s, args) =>
            {
                if (timer != null)
                {
                    timer.SetInterval(false);
                }
            };

            contextMenu.Items.Add(exitItem);
            contextMenu.Items.Add(speedUpItem);
            contextMenu.Items.Add(slowDownItem);
        }

        private void SetPerformanceCounter()
        {            
            timer = new CpuUsageTimer();

            timer.Tick += (s, args) =>
            {
                if (trayIcon != null)
                {
                    if (currentIndex > runAnimLength - 1)
                    {
                        currentIndex = 0;
                    }

                    trayIcon.Icon = icons[currentIndex];
                    currentIndex += 1;
                }
            };

            timer.Start();
        }
    }
}
