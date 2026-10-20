using System.Drawing;
using System.Windows.Forms;
using CafeteriaDev.Core;

namespace CafeteriaDev.Forms;

public sealed class SplashForm : Form
{
    private readonly System.Windows.Forms.Timer _loadingTimer =
        new() { Interval = 120 };
    private readonly ProgressBar _progressBar = new();
    private readonly Label _statusLabel = new();

    public SplashForm()
    {
        UiTheme.ConfigureForm(this, "Cafeteria Dev | Abertura", 640, 340);
        BackColor = UiTheme.Dark;
        ControlBox = false;

        var title = UiTheme.CreateLabel("CAFETERIA DEV", 31F, bold: true);
        title.ForeColor = Color.White;
        title.Location = new Point(151, 72);

        var subtitle = UiTheme.CreateLabel("Seu café, seu momento.", 12F);
        subtitle.ForeColor = Color.FromArgb(184, 210, 207);
        subtitle.Location = new Point(217, 146);

        _progressBar.Location = new Point(150, 221);
        _progressBar.Size = new Size(340, 14);
        _progressBar.Minimum = 0;
        _progressBar.Maximum = 100;
        _progressBar.Style = ProgressBarStyle.Continuous;

        _statusLabel.AutoSize = true;
        _statusLabel.Text = "Preparando o sistema... 0%";
        _statusLabel.ForeColor = Color.White;
        _statusLabel.Location = new Point(226, 254);

        Shown += (_, _) => _loadingTimer.Start();
        _loadingTimer.Tick += (_, _) => UpdateProgress();
        FormClosed += (_, _) => _loadingTimer.Dispose();

        Controls.Add(title);
        Controls.Add(subtitle);
        Controls.Add(_progressBar);
        Controls.Add(_statusLabel);
    }

    private void UpdateProgress()
    {
        _progressBar.Value = Math.Min(_progressBar.Value + 10, 100);
        _statusLabel.Text = $"Preparando o sistema... {_progressBar.Value}%";

        if (_progressBar.Value == 100)
        {
            _loadingTimer.Stop();
            Close();
        }
    }

}
