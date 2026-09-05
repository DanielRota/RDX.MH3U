using System.ComponentModel;

namespace RDX.MH3U.Forms;

public abstract class ItemCell<TItem> : UserControl
{
    private readonly Action<TItem, int> _addHandler;

    private TItem _item;
    private bool _selected;
    private int _index;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TItem Item
    {
        get => _item;
        set
        {
            if (EqualityComparer<TItem?>.Default.Equals(_item, value))
            {
                return;
            }

            _item = value;
            Invalidate();
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Selected
    {
        get => _selected;
        set
        {
            if (_selected == value)
            {
                return;
            }

            _selected = value;
            Invalidate();
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Index
    {
        get => _index;
        set
        {
            if (_index == value)
            {
                return;
            }

            _index = value;
            Invalidate();
        }
    }

    protected ItemCell(TItem item, Action<TItem, int> addHandler, int index)
    {
        _addHandler = addHandler;
        _item = item;
        _index = index;

        DoubleBuffered = true;

        SetStyle(ControlStyles.ResizeRedraw, true);

        Cursor = Cursors.Hand;
        ForeColor = Color.Black;
        Margin = new Padding(2);
    }

    public void AddItem(TItem item) => _addHandler(item, _index);

    protected abstract string GetHeaderText();
    protected abstract string GetBodyText();

    protected abstract void OnItemClick();

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);

        Selected = !Selected;
        OnItemClick();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        DrawBackground(e.Graphics);
        DrawContent(e.Graphics);
        DrawBorder(e.Graphics);
    }

    private void DrawBackground(Graphics graphics)
    {
        var color = Selected
            ? SystemColors.Highlight
            : SystemColors.Window;

        using var brush = new SolidBrush(color);

        graphics.FillRectangle(brush, ClientRectangle);
    }

    private void DrawContent(Graphics graphics)
    {
        var header = GetHeaderText();
        var body = GetBodyText();

        var textColor = Selected
            ? SystemColors.HighlightText
            : ForeColor;

        if (!string.IsNullOrEmpty(header))
        {
            var rectangle = new Rectangle(2, 2, Width - 4, 14);

            using var font = new Font(Font.FontFamily, 7f, FontStyle.Bold);

            TextRenderer.DrawText(graphics,
                header.ToUpperInvariant(), font, rectangle,
                Selected ? textColor : SystemColors.GrayText,
                TextFormatFlags.HorizontalCenter |
                TextFormatFlags.Top |
                TextFormatFlags.EndEllipsis);
        }

        if (!string.IsNullOrEmpty(body))
        {
            var rectangle = new Rectangle(2, 16, Width - 4, Height - 18);

            DrawText(graphics, body, rectangle, textColor);
        }
    }

    private void DrawBorder(Graphics graphics)
    {
        using var pen = new Pen(SystemColors.ControlDark);

        graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
    }

    private void DrawText(Graphics graphics, string text, Rectangle rectangle, Color color)
    {
        const float MinimumFontSize = 6f;

        const TextFormatFlags Format =
            TextFormatFlags.HorizontalCenter |
            TextFormatFlags.VerticalCenter |
            TextFormatFlags.WordBreak;

        var fontSize = Font.Size;
        Font? font = null;

        try
        {
            while (fontSize >= MinimumFontSize)
            {
                font?.Dispose();

                font = new Font(Font.FontFamily, fontSize, Font.Style);

                var measured = TextRenderer.MeasureText(graphics,
                    text, font, rectangle.Size, Format);

                if (measured.Height <= rectangle.Height)
                {
                    break;
                }

                fontSize -= 0.5f;
            }

            TextRenderer.DrawText(graphics, text, font!, rectangle, color, Format);
        }
        finally
        {
            font?.Dispose();
        }
    }
}
