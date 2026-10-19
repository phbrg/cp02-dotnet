using System.Drawing;
using System.Windows.Forms;
using CafeteriaDev.Core;

namespace CafeteriaDev.Forms;

public sealed class MainForm : Form
{
    public MainForm(SalesRepository repository)
    {
        ArgumentNullException.ThrowIfNull(repository);
        UiTheme.ConfigureForm(this, "Cafeteria Dev | Menu", 720, 440);

        var title = UiTheme.CreateLabel("Menu principal", 24F, bold: true);
        title.Location = new Point(40, 45);

        var subtitle = UiTheme.CreateLabel("As funcionalidades serão integradas pelo time.");
        subtitle.Location = new Point(42, 110);

        Controls.Add(title);
        Controls.Add(subtitle);
    }
}
