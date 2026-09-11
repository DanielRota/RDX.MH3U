using RDX.MH3U.Forms;

namespace RDX.MH3U;

public partial class BoxFormBase : Form
{
    public BoxFormBase()
    {
        InitializeComponent();
    }

    private void BoxFormBase_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            this.Close();
        }
    }
}

public class BoxForm<TItem> : BoxFormBase
{
    private readonly int _columns;
    private readonly int _rows;

    private readonly IReadOnlyList<TItem> _items;
    private readonly Func<TItem, int, ItemCell<TItem>> _cellFactory;

    private readonly int _cellsPerPage;
    private readonly int _pages;

    private int _page;

    public BoxForm(
        int columns,
        int rows,
        IReadOnlyList<TItem> items,
        Func<TItem, int, ItemCell<TItem>> cellFactory)
    {
        _columns = columns;
        _rows = rows;
        _items = items;
        _cellFactory = cellFactory;

        _cellsPerPage = columns * rows;
        _pages = Math.Max(1, (int)Math.Ceiling(items.Count / (double)_cellsPerPage));

        Load += (_, _) => DrawPage();
        btnPreviousPage.Click += (_, _) => ChangePage(-1);
        btnNextPage.Click += (_, _) => ChangePage(1);
    }

    private void ChangePage(int delta)
    {
        var page = Math.Clamp(_page + delta, 0, _pages - 1);

        if (page == _page)
        {
            return;
        }

        _page = page;
        DrawPage();
    }

    private void DrawPage()
    {
        UpdateNavigation();

        table.SuspendLayout();

        try
        {
            ClearTable();
            ConfigureTable();
            PopulateTable();
        }
        finally
        {
            table.ResumeLayout();
            table.PerformLayout();
        }
    }

    private void UpdateNavigation()
    {
        lblPage.Text = $"Page {_page + 1} / {_pages}";

        btnPreviousPage.Enabled = _page > 0;
        btnNextPage.Enabled = _page < _pages - 1;
    }

    private void ClearTable()
    {
        foreach (Control control in table.Controls)
        {
            control.Dispose();
        }

        table.Controls.Clear();
        table.ColumnStyles.Clear();
        table.RowStyles.Clear();
    }

    private void ConfigureTable()
    {
        table.Padding = new Padding(5);
        table.ColumnCount = _columns;
        table.RowCount = _rows;

        for (int i = 0; i < _columns; i++)
        {
            table.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100f / _columns));
        }

        for (int i = 0; i < _rows; i++)
        {
            table.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100f / _rows));
        }
    }

    private void PopulateTable()
    {
        int start = _page * _cellsPerPage;
        int end = Math.Min(start + _cellsPerPage, _items.Count);

        for (int i = start; i < end; i++)
        {
            int relative = i - start;
            int row = relative / _columns;
            int column = relative % _columns;

            var cell = _cellFactory(_items[i], i);

            cell.Dock = DockStyle.Fill;
            cell.Margin = new Padding(2);

            table.Controls.Add(cell, column, row);
        }
    }
}
