using System.Drawing;
using System.Windows.Forms;
using CafeteriaDev.Core;

namespace CafeteriaDev.Forms;

public sealed class SplashForm : Form
{
    public SplashForm()
    {
        UiTheme.ConfigureForm(this, "Cafeteria Dev | Abertura", 550, 260);

        var title = UiTheme.CreateLabel("Cafeteria Dev", 24F, bold: true);
        title.Location = new Point(160, 60);

        var continueButton = UiTheme.CreatePrimaryButton("Continuar");
        continueButton.Location = new Point(180, 145);
        continueButton.Click += (_, _) => Close();

        Controls.Add(title);
        Controls.Add(continueButton);
    }
}
