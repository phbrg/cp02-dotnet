using System.Drawing;
using System.Windows.Forms;
using CafeteriaDev.Core;

namespace CafeteriaDev.Forms;

public sealed class SplashForm : Form
{
    private readonly System.Windows.Forms.Timer _loadingTimer =
        new() { Interval = 1600 };

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

        var status = UiTheme.CreateLabel("Carregando o sistema...", 11F);
        status.ForeColor = Color.White;
        status.Location = new Point(225, 240);

        Shown += (_, _) => _loadingTimer.Start();
        _loadingTimer.Tick += (_, _) => FinishLoading();
        FormClosed += (_, _) => _loadingTimer.Dispose();

        Controls.Add(title);
        Controls.Add(subtitle);
        Controls.Add(status);
    }

    private void FinishLoading()
    {
        _loadingTimer.Stop();
        Close();
    }

}
