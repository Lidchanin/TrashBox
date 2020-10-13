using System;
using System.Globalization;
using Xamarin.Forms;

namespace TrashBox.Controls.BorderlessControls
{
    public partial class BorderlessDateTimePicker
    {
        #region Bindable Properties

        #region DateTime Property

        public static readonly BindableProperty DateTimeProperty = BindableProperty.Create(
            nameof(DateTime),
            typeof(DateTime),
            typeof(BorderlessDateTimePicker),
            DateTime.Today,
            BindingMode.TwoWay,
            (bindable, value) => value is DateTime);

        public DateTime DateTime
        {
            get => (DateTime) GetValue(DateTimeProperty);
            set => SetValue(DateTimeProperty, value);
        }

        #endregion DateTime Property

        #region MaximumDate Property

        public static readonly BindableProperty MaximumDateProperty = BindableProperty.Create(
            nameof(MaximumDate),
            typeof(DateTime),
            typeof(DatePicker),
            new DateTime(2100, 12, 31),
            validateValue: ValidateMaximumDate,
            coerceValue: CoerceMaximumDate);

        public DateTime MaximumDate
        {
            get => (DateTime) GetValue(MaximumDateProperty);
            set => SetValue(MaximumDateProperty, value);
        }

        private static bool ValidateMaximumDate(BindableObject bindable, object value)
        {
            return ((DateTime) value).Date >= ((BorderlessDateTimePicker) bindable).MinimumDate.Date;
        }

        private static object CoerceMaximumDate(BindableObject bindable, object value)
        {
            if ((!(bindable is BorderlessDateTimePicker picker)))
            {
                throw new ArgumentException();
            }

            var dateValue = ((DateTime) value).Date;

            if (picker.DateTime > dateValue)
            {
                picker.DateTime = dateValue;
            }

            return dateValue;
        }

        #endregion MaximumDate Property

        #region MininumDate Property

        public static readonly BindableProperty MinimumDateProperty = BindableProperty.Create(
            nameof(MinimumDate),
            typeof(DateTime),
            typeof(DatePicker),
            new DateTime(1900, 1, 1),
            validateValue: ValidateMinimumDate,
            coerceValue: CoerceMinimumDate);

        public DateTime MinimumDate
        {
            get => (DateTime) GetValue(MinimumDateProperty);
            set => SetValue(MinimumDateProperty, value);
        }

        private static bool ValidateMinimumDate(BindableObject bindable, object value)
        {
            return ((DateTime) value).Date <= ((BorderlessDateTimePicker) bindable).MaximumDate.Date;
        }

        private static object CoerceMinimumDate(BindableObject bindable, object value)
        {
            if (!(bindable is BorderlessDateTimePicker picker))
            {
                throw new ArgumentException();
            }

            var dateValue = ((DateTime) value).Date;

            if (picker.DateTime < dateValue)
            {
                picker.DateTime = dateValue;
            }

            return dateValue;
        }

        #endregion MininumDate Property

        #region Format Property

        public static readonly BindableProperty FormatProperty = BindableProperty.Create(
            nameof(Format),
            typeof(string),
            typeof(BorderlessDateTimePicker));

        public string Format
        {
            get => (string) GetValue(FormatProperty);
            set => SetValue(FormatProperty, value);
        }

        #endregion Format Property

        #region TextColor Property

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            nameof(TextColor),
            typeof(Color),
            typeof(BorderlessDateTimePicker),
            Color.Default);

        public Color TextColor
        {
            get => (Color) GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        #endregion TextColor Property

        #region FontFamily Property

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            nameof(FontFamily),
            typeof(string),
            typeof(BorderlessDateTimePicker),
            DatePicker.FontFamilyProperty.DefaultValue);

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
            typeof(BorderlessDateTimePicker),
            DatePicker.FontSizeProperty.DefaultValue);

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
            typeof(BorderlessDateTimePicker),
            FontAttributes.None);

        public FontAttributes FontAttributes
        {
            get => (FontAttributes) GetValue(FontAttributesProperty);
            set => SetValue(FontAttributesProperty, value);
        }

        #endregion FontAttributes Property

        #endregion Bindable Properties

        public string DateTimeString => DateTime.ToString(Format, CultureInfo.CurrentCulture);

        public TimeSpan Time
        {
            get => DateTime.TimeOfDay;
            set => DateTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, value.Hours, value.Minutes,
                value.Seconds);
        }

        public BorderlessDateTimePicker()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.Android)
            {
                DatePicker.DateSelected += DatePicker_OnDateSelected;
            }
            else
            {
                DatePicker.Unfocused += DatePicker_OnUnfocused;
            }
        }

        ~BorderlessDateTimePicker()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                DatePicker.DateSelected -= DatePicker_OnDateSelected;
            }
            else
            {
                DatePicker.Unfocused -= DatePicker_OnUnfocused;
            }
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e) => DatePicker?.Focus();

        private void DatePicker_OnDateSelected(object sender, DateChangedEventArgs e) => TimePicker?.Focus();

        private void DatePicker_OnUnfocused(object sender, FocusEventArgs e) => TimePicker?.Focus();
    }
}