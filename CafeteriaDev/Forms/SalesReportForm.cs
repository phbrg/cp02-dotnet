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
    private readonly TextBox _searchInput = new();

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

        var searchLabel = UiTheme.CreateLabel("Buscar café:", 10F, bold: true);
        searchLabel.Location = new Point(38, 124);

        _searchInput.Location = new Point(151, 118);
        _searchInput.Size = new Size(315, 32);
        _searchInput.PlaceholderText = "Digite o nome do café";
        _searchInput.TextChanged += (_, _) => LoadSales();

        refreshButton.Click += (_, _) => LoadSales();
        LoadSales();

        Controls.Add(title);
        Controls.Add(subtitle);
        Controls.Add(_salesGrid);
        Controls.Add(_countLabel);
        Controls.Add(_revenueLabel);
        Controls.Add(refreshButton);
        Controls.Add(closeButton);
        Controls.Add(searchLabel);
        Controls.Add(_searchInput);
    }

    private void LoadSales()
    {
        var searchText = _searchInput.Text.Trim();
        var sales = _repository.GetAll()
            .Where(sale => string.IsNullOrEmpty(searchText) ||
                sale.CoffeeName.Contains(searchText, StringComparison.CurrentCultureIgnoreCase))
            .OrderByDescending(sale => sale.CreatedAt)
            .ToList();

        _salesGrid.Rows.Clear();

        foreach (var sale in sales)
        {
            _salesGrid.Rows.Add(
                sale.CreatedAt.ToString("dd/MM/yyyy HH:mm"),
                sale.CoffeeName,
                sale.Quantity,
                sale.UnitPrice.ToString("C", BrazilianCulture),
                sale.Total.ToString("C", BrazilianCulture));
        }

        _countLabel.Text = $"Pedidos exibidos: {sales.Count}";
        _revenueLabel.Text =
            $"Faturamento exibido: {sales.Sum(sale => sale.Total).ToString("C", BrazilianCulture)}";
    }

}
