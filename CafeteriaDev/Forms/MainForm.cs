using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CafeteriaDev.Core;

namespace CafeteriaDev.Forms;

public sealed class MainForm : Form
{
    private static readonly CultureInfo BrazilianCulture =
        CultureInfo.GetCultureInfo("pt-BR");

    private readonly SalesRepository _repository;
    private readonly Button _salesButton;
    private readonly Button _reportButton;

    public MainForm(SalesRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        UiTheme.ConfigureForm(this, "Cafeteria Dev | Menu principal", 760, 460);

        var title = UiTheme.CreateLabel("CAFETERIA DEV", 28F, bold: true);
        title.Location = new Point(45, 40);

        var subtitle = UiTheme.CreateLabel("Escolha uma opção para continuar.", 12F);
        subtitle.ForeColor = UiTheme.Muted;
        subtitle.Location = new Point(48, 103);

        _salesButton = UiTheme.CreatePrimaryButton("Registrar venda");
        _salesButton.Location = new Point(48, 178);
        _salesButton.Size = new Size(306, 75);

        _reportButton = UiTheme.CreateSecondaryButton("Relatório de vendas");
        _reportButton.Location = new Point(405, 178);
        _reportButton.Size = new Size(306, 75);

        _salesButton.Click += (_, _) => OpenSales();
        _reportButton.Click += (_, _) => OpenReport();

        Controls.Add(title);
        Controls.Add(subtitle);
        Controls.Add(_salesButton);
        Controls.Add(_reportButton);

    }

    private void OpenSales()
    {
        using var salesForm = new SalesForm(_repository);
        salesForm.StartPosition = FormStartPosition.CenterParent;
        salesForm.ShowDialog(this);
    }

    private void OpenReport()
    {
        using var reportForm = new SalesReportForm(_repository);
        reportForm.StartPosition = FormStartPosition.CenterParent;
        reportForm.ShowDialog(this);
    }

}
