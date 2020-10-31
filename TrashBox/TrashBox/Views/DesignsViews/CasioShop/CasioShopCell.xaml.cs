using System;
using TrashBox.Models;
using Xamarin.Forms;

namespace TrashBox.Views.DesignsViews.CasioShop
{
    public partial class CasioShopCell
    {
        #region Bindable Properties

        #region WatchInfo Property

        public static readonly BindableProperty WatchInfoProperty = BindableProperty.Create(
            nameof(WatchInfo),
            typeof(WatchInfo),
            typeof(CasioShopCell));

        public WatchInfo WatchInfo
        {
            get => (WatchInfo) GetValue(WatchInfoProperty);
            set => SetValue(WatchInfoProperty, value);
        }

        #endregion WatchInfo Property

        #endregion Bindable Properties

        public CasioShopCell()
        {
            InitializeComponent();
        }

        private void CartOperationsButtonOnClicked(object sender, EventArgs e)
        {
            WatchInfo.IsInCart = !WatchInfo.IsInCart;
        }
    }
}