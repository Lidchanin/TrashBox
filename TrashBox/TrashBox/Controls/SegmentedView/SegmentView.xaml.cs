using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace TrashBox.Controls.SegmentedView
{
    public partial class SegmentView
    {
        #region Bindable Properties

        #region Item Property

        public static readonly BindableProperty ItemProperty = BindableProperty.Create(
            nameof(Item),
            typeof(InnerSegmentedViewItem),
            typeof(SegmentView),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnItemPropertyChanged);

        public InnerSegmentedViewItem Item
        {
            get => (InnerSegmentedViewItem) GetValue(ItemProperty);
            set => SetValue(ItemProperty, value);
        }

        private static void OnItemPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is SegmentView view) || !(newValue is InnerSegmentedViewItem item))
            {
                return;
            }

            item.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName.Equals(nameof(InnerSegmentedViewItem.IsSelected)))
                {
                    view.ChangeVisualState();
                }
            };

            view.ChangeVisualState();
        }

        #endregion Item Property

        #region IsNullableSelectionSupported Property

        public static readonly BindableProperty IsNullableSelectionSupportedProperty = BindableProperty.Create(
            nameof(IsNullableSelectionSupported),
            typeof(bool),
            typeof(SegmentView),
            false);

        public bool IsNullableSelectionSupported
        {
            get => (bool) GetValue(IsNullableSelectionSupportedProperty);
            set => SetValue(IsNullableSelectionSupportedProperty, value);
        }

        #endregion IsNullableSelectionSupported Property

        #region FontFamily Property

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            nameof(FontFamily),
            typeof(string),
            typeof(SegmentView));

        public string FontFamily
        {
            get => (string) GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        #endregion FontFamily Property

        #region FontSize Property

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            nameof(FontSize),
            typeof(double),
            typeof(SegmentView));

        [TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            get => (double) GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        #endregion FontSize Property

        #region FontAttributes Property

        public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create(
            nameof(FontAttributes),
            typeof(FontAttributes),
            typeof(SegmentView),
            FontAttributes.None);

        public FontAttributes FontAttributes
        {
            get => (FontAttributes) GetValue(FontAttributesProperty);
            set => SetValue(FontAttributesProperty, value);
        }

        #endregion FontAttributes Property

        #region TextColor Property

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            nameof(TextColor),
            typeof(Color),
            typeof(SegmentView));

        public Color TextColor
        {
            get => (Color) GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        #endregion TextColor Property

        #region SelectedTextColor Property

        public static readonly BindableProperty SelectedTextColorProperty = BindableProperty.Create(
            nameof(SelectedTextColor),
            typeof(Color),
            typeof(SegmentView));

        public Color SelectedTextColor
        {
            get => (Color) GetValue(SelectedTextColorProperty);
            set => SetValue(SelectedTextColorProperty, value);
        }

        #endregion SelectedTextColor Property

        #region SelectedBackgroundColor Property

        public static readonly BindableProperty SelectedBackgroundColorProperty = BindableProperty.Create(
            nameof(SelectedBackgroundColor),
            typeof(Color),
            typeof(SegmentView));

        public Color SelectedBackgroundColor
        {
            get => (Color) GetValue(SelectedBackgroundColorProperty);
            set => SetValue(SelectedBackgroundColorProperty, value);
        }

        #endregion SelectedBackgroundColor Property

        #region CornerRadius Property

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
            nameof(CornerRadius),
            typeof(float),
            typeof(SegmentView));

        public float CornerRadius
        {
            get => (float) GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        #endregion CornerRadius Property

        #endregion Bindable Properties

        public event EventHandler<InnerSegmentedViewItem> SelectionChanged;

        public SegmentView()
        {
            InitializeComponent();
        }

        private void OnItemTapped(object sender, EventArgs e)
        {
            if (Item == null)
            {
                return;
            }

            if (!IsNullableSelectionSupported && Item.IsSelected)
            {
                return;
            }

            Item.IsSelected = !Item.IsSelected;

            SelectionChanged?.Invoke(this, Item.IsSelected ? Item : null);
        }

        protected override void ChangeVisualState()
        {
            base.ChangeVisualState();

            VisualStateManager.GoToState(this, Item?.IsSelected == true ? "Selected" : "Normal");
        }
    }
}