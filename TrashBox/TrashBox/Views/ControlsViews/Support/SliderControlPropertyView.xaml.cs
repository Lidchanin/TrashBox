using Xamarin.Forms;

namespace TrashBox.Views.ControlsViews.Support
{
    public partial class SliderControlPropertyView
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

        #region Maximum Property

        public static readonly BindableProperty MaximumProperty = BindableProperty.Create(
            nameof(Maximum),
            typeof(double),
            typeof(SliderControlPropertyView),
            1d);

        public double Maximum
        {
            get => (double) GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        #endregion Maximum Property

        #region Minimum Property

        public static readonly BindableProperty MinimumProperty = BindableProperty.Create(
            nameof(Minimum),
            typeof(double),
            typeof(SliderControlPropertyView),
            0d);

        public double Minimum
        {
            get => (double) GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }

        #endregion Minimum Property

        #region Value Property

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            nameof(Value),
            typeof(double),
            typeof(SliderControlPropertyView),
            0d,
            BindingMode.TwoWay);

        public double Value
        {
            get => (double) GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        #endregion Value Property

        #endregion Bindable Properties

        public SliderControlPropertyView()
        {
            InitializeComponent();
        }
    }
}