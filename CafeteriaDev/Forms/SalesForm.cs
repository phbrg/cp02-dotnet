using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CafeteriaDev.Core;

namespace CafeteriaDev.Forms;

public sealed class SalesForm : Form
{
    private static readonly CultureInfo BrazilianCulture =
        CultureInfo.GetCultureInfo("pt-BR");

    private readonly SalesRepository _repository;
    private readonly ComboBox _coffeeCombo = new();
    private readonly NumericUpDown _quantityInput = new();
    private readonly Label _totalLabel = new();
    private readonly Button _saveButton;

    public SalesForm(SalesRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        UiTheme.ConfigureForm(this, "Cafeteria Dev | Registrar venda", 760, 530);

        var title = UiTheme.CreateLabel("Registrar venda", 24F, bold: true);
        title.Location = new Point(38, 27);

        var subtitle = UiTheme.CreateLabel("Selecione o café e informe a quantidade.", 11F);
        subtitle.ForeColor = UiTheme.Muted;
        subtitle.Location = new Point(41, 89);

        var coffeeLabel = UiTheme.CreateLabel("Café", 11F, bold: true);
        coffeeLabel.Location = new Point(41, 147);

        _coffeeCombo.Location = new Point(41, 180);
        _coffeeCombo.Size = new Size(440, 37);
        _coffeeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
        _coffeeCombo.DataSource = CoffeeCatalog.Products.ToArray();
        _coffeeCombo.SelectedIndex = -1;

        var quantityLabel = UiTheme.CreateLabel("Quantidade", 11F, bold: true);
        quantityLabel.Location = new Point(518, 147);

        _quantityInput.Location = new Point(521, 180);
        _quantityInput.Size = new Size(195, 35);
        _quantityInput.Minimum = 1;
        _quantityInput.Maximum = 50;
        _quantityInput.Value = 1;
        _quantityInput.TextAlign = HorizontalAlignment.Center;

        _totalLabel.AutoSize = true;
        _totalLabel.Text = "Total: R$ 0,00";
        _totalLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        _totalLabel.ForeColor = UiTheme.Dark;
        _totalLabel.Location = new Point(40, 282);

        _saveButton = UiTheme.CreatePrimaryButton("Finalizar pedido");
        _saveButton.Location = new Point(41, 392);
        _saveButton.Size = new Size(280, 57);

        var closeButton = UiTheme.CreateSecondaryButton("Voltar ao menu");
        closeButton.Location = new Point(342, 392);
        closeButton.Size = new Size(210, 57);
        closeButton.Click += (_, _) => Close();

        // Business events are connected in the next feature commit.
        _saveButton.Enabled = false;

        Controls.Add(title);
        Controls.Add(subtitle);
        Controls.Add(coffeeLabel);
        Controls.Add(_coffeeCombo);
        Controls.Add(quantityLabel);
        Controls.Add(_quantityInput);
        Controls.Add(_totalLabel);
        Controls.Add(_saveButton);
        Controls.Add(closeButton);

    }

}
