using Xamarin.Forms;

namespace TrashBox.Views.ControlsViews.Support
{
    public partial class BaseControlPropertyView
    {
        #region Bindable Properties

        #region InnerView Property

        public static readonly BindableProperty InnerViewProperty = BindableProperty.Create(
            nameof(InnerView),
            typeof(View),
            typeof(BaseControlPropertyView),
            propertyChanged: InnerView_OnPropertyChanged);

        public View InnerView
        {
            get => (View) GetValue(InnerViewProperty);
            set => SetValue(InnerViewProperty, value);
        }

        private static void InnerView_OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is BaseControlPropertyView view) || !(newValue is View innerView))
            {
                return;
            }

            view.InnerViewGrid.Children.Clear();
            view.InnerViewGrid.Children.Add(innerView);
        }

        #endregion InnerView Property

        #region Title Property

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(BaseControlPropertyView));

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        #endregion Title Property

        #endregion Bindable Properties

        public BaseControlPropertyView()
        {
            InitializeComponent();
        }
    }
}