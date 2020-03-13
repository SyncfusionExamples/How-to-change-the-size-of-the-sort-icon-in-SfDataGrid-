using Syncfusion.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DataGridDemo
{
    public class ViewModel : NotificationObject
    {
        internal OrderInfoRepository order;
        private object dataGridSelectedItem;
        private Color headerTextColor = Color.Black;
        private Color headerindicatorColor = Color.Transparent;

        public Color HeaderTextColor
        {
            get
            {
                return headerTextColor;
            }

            set
            {
                this.headerTextColor = value;
                RaisePropertyChanged("HeaderTextColor");
            }
        }
        public Color HeaderIndicatorColor
        {
            get
            {
                return headerindicatorColor;
            }

            set
            {
                this.headerindicatorColor = value;
                RaisePropertyChanged("HeaderIndicatorColor");
            }
        }
        public ICommand TapCommand { private set; get; }

        public object DataGridSelectedItem
        {
            get
            {
                return dataGridSelectedItem;
            }
            set
            {
                this.dataGridSelectedItem = value;
                RaisePropertyChanged("DataGridSelectedItem");
            }
        }
        public ViewModel()
        {
            order = new OrderInfoRepository();
            SetRowstoGenerate(50);
            TapCommand = new Command(OnTapped);
        }

        public void OnTapped(object selectedItem)
        {
            this.DataGridSelectedItem = (selectedItem as OrderInfo);
        }
        #region ItemsSource


        private ObservableCollection<OrderInfo> ordersInfo;
        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return ordersInfo; }
            set
            {
                this.ordersInfo = value;
                RaiseCollectionChanged("OrdersInfo");
            }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            OrdersInfo = order.GetOrderDetails(count);
        }

        #endregion
    }

    public class NotificationObject : INotifyPropertyChanged, INotifyCollectionChanged
    {
        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaiseCollectionChanged(string propName)
        {
            if (this.CollectionChanged != null)
                this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
