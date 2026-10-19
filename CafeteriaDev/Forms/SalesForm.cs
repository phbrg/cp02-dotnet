using System.Drawing;
using System.Windows.Forms;
using CafeteriaDev.Core;

namespace CafeteriaDev.Forms;

public sealed class SalesForm : Form
{
    public SalesForm(SalesRepository repository)
    {
        ArgumentNullException.ThrowIfNull(repository);
        UiTheme.ConfigureForm(this, "Cafeteria Dev | Vendas", 740, 500);

        var title = UiTheme.CreateLabel("Registrar venda", 22F, bold: true);
        title.Location = new Point(35, 35);

        var notice = UiTheme.CreateLabel("Tela em desenvolvimento.");
        notice.Location = new Point(38, 110);

        Controls.Add(title);
        Controls.Add(notice);
    }
}
