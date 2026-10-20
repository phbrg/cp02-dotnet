using System.Drawing;
using System.Windows.Forms;
using CafeteriaDev.Core;

namespace CafeteriaDev.Forms;

public sealed class SplashForm : Form
{

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

        var continueButton = UiTheme.CreatePrimaryButton("Entrar");
        continueButton.Location = new Point(225, 222);
        continueButton.Click += (_, _) => Close();

        Controls.Add(title);
        Controls.Add(subtitle);
        Controls.Add(continueButton);
    }

}
