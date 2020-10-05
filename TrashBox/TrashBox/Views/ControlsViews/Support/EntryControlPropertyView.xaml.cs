using Xamarin.Forms;

namespace TrashBox.Views.ControlsViews.Support
{
    public partial class EntryControlPropertyView
    {
        #region Bindable Properties

        #region Title Property

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(SliderControlPropertyView));

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        #endregion Title Property

        #region Value Property

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            nameof(Value),
            typeof(string),
            typeof(SliderControlPropertyView),
            defaultBindingMode: BindingMode.TwoWay);

        public string Value
        {
            get => (string) GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        #endregion Value Property

        #region Placeholder Property

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            nameof(Placeholder),
            typeof(string),
            typeof(SliderControlPropertyView));

        public string Placeholder
        {
            get => (string) GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        #endregion Placeholder Property

        #endregion Bindable Properties

        public EntryControlPropertyView()
        {
            InitializeComponent();
        }
    }
}