using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CafeteriaDev.Core;

namespace CafeteriaDev.Forms;

public sealed class SalesReportForm : Form
{
    private static readonly CultureInfo BrazilianCulture =
        CultureInfo.GetCultureInfo("pt-BR");

    private readonly SalesRepository _repository;
    private readonly DataGridView _salesGrid = new();
    private readonly Label _countLabel = new();
    private readonly Label _revenueLabel = new();

    public SalesReportForm(SalesRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        UiTheme.ConfigureForm(this, "Cafeteria Dev | Relatório de vendas", 1000, 620);

        var title = UiTheme.CreateLabel("Relatório de vendas", 24F, bold: true);
        title.Location = new Point(34, 26);

        var subtitle = UiTheme.CreateLabel("Acompanhe os pedidos registrados nesta sessão.", 11F);
        subtitle.ForeColor = UiTheme.Muted;
        subtitle.Location = new Point(37, 82);

        _salesGrid.Location = new Point(36, 164);
        _salesGrid.Size = new Size(925, 327);
        _salesGrid.ReadOnly = true;
        _salesGrid.AllowUserToAddRows = false;
        _salesGrid.AllowUserToDeleteRows = false;
        _salesGrid.MultiSelect = false;
        _salesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _salesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _salesGrid.RowHeadersVisible = false;
        _salesGrid.BackgroundColor = UiTheme.Surface;
        _salesGrid.BorderStyle = BorderStyle.None;

        _salesGrid.Columns.Add("Date", "Data e hora");
        _salesGrid.Columns.Add("Coffee", "Café");
        _salesGrid.Columns.Add("Quantity", "Quantidade");
        _salesGrid.Columns.Add("UnitPrice", "Preço unitário");
        _salesGrid.Columns.Add("Total", "Total");

        _countLabel.AutoSize = true;
        _countLabel.Text = "Pedidos: 0";
        _countLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        _countLabel.Location = new Point(37, 523);

        _revenueLabel.AutoSize = true;
        _revenueLabel.Text = "Faturamento: R$ 0,00";
        _revenueLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        _revenueLabel.Location = new Point(255, 523);

        var refreshButton = UiTheme.CreatePrimaryButton("Atualizar");
        refreshButton.Location = new Point(700, 518);
        refreshButton.Size = new Size(125, 46);

        var closeButton = UiTheme.CreateSecondaryButton("Voltar");
        closeButton.Location = new Point(836, 518);
        closeButton.Size = new Size(125, 46);
        closeButton.Click += (_, _) => Close();

        // Data loading is implemented in the next feature commit.
        refreshButton.Enabled = false;

        Controls.Add(title);
        Controls.Add(subtitle);
        Controls.Add(_salesGrid);
        Controls.Add(_countLabel);
        Controls.Add(_revenueLabel);
        Controls.Add(refreshButton);
        Controls.Add(closeButton);

    }

}
