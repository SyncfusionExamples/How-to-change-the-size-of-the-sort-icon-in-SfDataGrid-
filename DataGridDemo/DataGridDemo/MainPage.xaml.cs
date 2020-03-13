using Syncfusion.SfDataGrid.XForms.DataPager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.SfDataGrid.XForms;
using Syncfusion.Data;
using System.Reflection;
using System.Globalization;
using System.IO;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections;
using Syncfusion.XForms.ComboBox;

namespace DataGridDemo
{
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
}
