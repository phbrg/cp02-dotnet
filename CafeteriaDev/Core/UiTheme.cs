using System.Drawing;
using System.Windows.Forms;

namespace CafeteriaDev.Core;

public static class UiTheme
{
    public static readonly Color Background = Color.FromArgb(245, 247, 250);
    public static readonly Color Surface = Color.White;
    public static readonly Color Dark = Color.FromArgb(23, 37, 49);
    public static readonly Color Primary = Color.FromArgb(16, 133, 112);
    public static readonly Color Muted = Color.FromArgb(94, 109, 121);

    public static void ConfigureForm(Form form, string title, int width, int height)
    {
        form.Text = title;
        form.ClientSize = new Size(width, height);
        form.BackColor = Background;
        form.Font = new Font("Segoe UI", 10F);
        form.StartPosition = FormStartPosition.CenterScreen;
        form.FormBorderStyle = FormBorderStyle.FixedSingle;
        form.MaximizeBox = false;
        form.AutoScaleMode = AutoScaleMode.Font;
    }

    public static Label CreateLabel(string text, float size = 10F, bool bold = false)
    {
        return new Label
        {
            AutoSize = true,
            Text = text,
            Font = new Font("Segoe UI", size, bold ? FontStyle.Bold : FontStyle.Regular),
            ForeColor = Dark
        };
    }

    public static Button CreatePrimaryButton(string text)
    {
        return CreateButton(text, Primary, Color.White);
    }

    public static Button CreateSecondaryButton(string text)
    {
        return CreateButton(text, Color.FromArgb(226, 232, 238), Dark);
    }

    private static Button CreateButton(string text, Color background, Color foreground)
    {
        var button = new Button
        {
            Text = text,
            Width = 190,
            Height = 46,
            BackColor = background,
            ForeColor = foreground,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            UseVisualStyleBackColor = false
        };

        button.FlatAppearance.BorderSize = 0;
        return button;
    }
}
