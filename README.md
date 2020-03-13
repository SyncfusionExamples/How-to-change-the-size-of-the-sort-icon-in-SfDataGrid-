# How-to-change-the-size-of-the-sort-icon-in-SfDataGrid-
How to change the size of the sort icon in SfDataGrid?

## About the sample
This example illustrates how to enable the MultiSelection in GridComboBoxColumn of DataGrid SfDataGrid

SfDataGrid allows you to modify the size of the SortIcon header. This can be achieved by overriding OnInitializeDisplayView method in custom [SfDataGrid.GridHeaderCellRenderer](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfDataGrid.XForms~Syncfusion.SfDataGrid.XForms.GridHeaderCellRenderer.html) and changing the size of its parent element.

```c#
public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            dataGrid.CellRenderers.Remove("HeaderView");
            dataGrid.CellRenderers.Add("HeaderView", new HeaderCellRenderer());
        }
    }

    public class HeaderCellRenderer: GridHeaderCellRenderer
    {
        public override void OnInitializeDisplayView(DataColumnBase dataColumn, ContentView view)
        {
            base.OnInitializeDisplayView(dataColumn, view);
            ((view as BorderView).Content as Grid).ColumnDefinitions[1].Width = new GridLength(20, GridUnitType.Absolute);
        }
    }

```

## Requirements to run the demo
Visual Studio 2015 and above versions

