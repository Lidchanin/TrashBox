using SkiaSharp.Views.Forms;
using System;
using Xamarin.Forms;

namespace TrashBox.Controls.GradientProgressBar
{
    public class VerticalDetailedProgressBar : SKCanvasView
    {
        #region Bindable Properties

        #region PecentageValue Property

        public static readonly BindableProperty PercentageValueProperty = BindableProperty.Create(
            nameof(PercentageValue),
            typeof(float),
            typeof(VerticalDetailedProgressBar),
            0f,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public float PercentageValue
        {
            get => (float) GetValue(PercentageValueProperty);
            set => SetValue(PercentageValueProperty, value);
        }

        #endregion PecentageValue Property

        #region OuterCornerRadius Property

        public static readonly BindableProperty OuterCornerRadiusProperty = BindableProperty.Create(
            nameof(OuterCornerRadius),
            typeof(float),
            typeof(VerticalDetailedProgressBar),
            5f,
            BindingMode.OneWay,
            (bindable, value) => value != null && (float) value >= 0,
            OnPropertyChangedInvalidate);

        public float OuterCornerRadius
        {
            get => (float) GetValue(OuterCornerRadiusProperty);
            set => SetValue(OuterCornerRadiusProperty, value);
        }

        #endregion OuterCornerRadius Property

        #region InnerCornerRadiusProperty

        public static readonly BindableProperty InnerCornerRadiusProperty = BindableProperty.Create(
            nameof(InnerCornerRadius),
            typeof(float),
            typeof(VerticalDetailedProgressBar),
            5f,
            BindingMode.OneWay,
            (bindable, value) => value != null && (float) value >= 0,
            OnPropertyChangedInvalidate);

        public float InnerCornerRadius
        {
            get => (float) GetValue(InnerCornerRadiusProperty);
            set => SetValue(InnerCornerRadiusProperty, value);
        }

        #endregion InnerCornerRadiusProperty

        #region FontSize Property

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            nameof(FontSize),
            typeof(float),
            typeof(VerticalDetailedProgressBar),
            12f,
            BindingMode.OneWay,
            (bindable, value) => value != null && (float) value >= 0,
            OnPropertyChangedInvalidate);

        public float FontSize
        {
            get => (float) GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        #endregion FontSize Property

        #region StringFormat Property

        public static readonly BindableProperty StringFormatProperty = BindableProperty.Create(
            nameof(StringFormat),
            typeof(string),
            typeof(VerticalDetailedProgressBar),
            "{0:0%}",
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public string StringFormat
        {
            get => (string) GetValue(StringFormatProperty);
            set => SetValue(StringFormatProperty, value);
        }

        #endregion StringFormat Property

        #region StartProgressColor Property

        public static readonly BindableProperty StartProgressColorProperty = BindableProperty.Create(
            nameof(StartProgressColor),
            typeof(Color),
            typeof(VerticalDetailedProgressBar),
            Color.White,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color StartProgressColor
        {
            get => (Color) GetValue(StartProgressColorProperty);
            set => SetValue(StartProgressColorProperty, value);
        }

        #endregion StartProgressColor Property

        #region EndProgressColor Property

        public static readonly BindableProperty EndProgressColorProperty = BindableProperty.Create(
            nameof(EndProgressColor),
            typeof(Color),
            typeof(VerticalDetailedProgressBar),
            Color.White,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color EndProgressColor
        {
            get => (Color) GetValue(EndProgressColorProperty);
            set => SetValue(EndProgressColorProperty, value);
        }

        #endregion EndProgressColor Property

        #region StartBackgroundColor Property

        public static readonly BindableProperty StartBackgroundColorProperty = BindableProperty.Create(
            nameof(StartBackgroundColor),
            typeof(Color),
            typeof(VerticalDetailedProgressBar),
            Color.Blue,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color StartBackgroundColor
        {
            get => (Color) GetValue(StartBackgroundColorProperty);
            set => SetValue(StartBackgroundColorProperty, value);
        }

        #endregion StartBackgroundColor Property

        #region EndBackgroundColor Property

        public static readonly BindableProperty EndBackgroundColorProperty = BindableProperty.Create(
            nameof(EndBackgroundColor),
            typeof(Color),
            typeof(VerticalDetailedProgressBar),
            Color.Blue,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color EndBackgroundColor
        {
            get => (Color) GetValue(EndBackgroundColorProperty);
            set => SetValue(EndBackgroundColorProperty, value);
        }

        #endregion EndBackgroundColor Property

        #region PrimaryTextColor Property

        public static readonly BindableProperty PrimaryTextColorProperty = BindableProperty.Create(
            nameof(PrimaryTextColor),
            typeof(Color),
            typeof(VerticalDetailedProgressBar),
            Color.White,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color PrimaryTextColor
        {
            get => (Color) GetValue(PrimaryTextColorProperty);
            set => SetValue(PrimaryTextColorProperty, value);
        }

        #endregion PrimaryTextColor Property

        #region SecondaryTextColor Property

        public static readonly BindableProperty SecondaryTextColorProperty = BindableProperty.Create(
            nameof(SecondaryTextColor),
            typeof(Color),
            typeof(VerticalDetailedProgressBar),
            Color.Blue,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color SecondaryTextColor
        {
            get => (Color) GetValue(SecondaryTextColorProperty);
            set => SetValue(SecondaryTextColorProperty, value);
        }

        #endregion SecondaryTextColor Property

        #endregion Bindable Properties

        private static void OnPropertyChangedInvalidate(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (VerticalDetailedProgressBar) bindable;

            if (oldValue != newValue)
            {
                control.InvalidateSurface();
            }
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            var info = e.Info;

            var scale = CanvasSize.Width / (float) Width;
            var outerCornerRadius = OuterCornerRadius * scale;
            var innerCornerRadius = InnerCornerRadius * scale;

            var percentageHeight = (int) Math.Floor(info.Height * PercentageValue);
            var textSize = FontSize * scale;

            canvas.Clear();

            ProgressBarHelper.SetClip(canvas, info, outerCornerRadius);

            ProgressBarHelper.DrawBackground(canvas, ProgressBarOrientation.Vertical, e.Info, outerCornerRadius,
                EndBackgroundColor.ToSKColor(), StartBackgroundColor.ToSKColor());
            ProgressBarHelper.DrawProgress(canvas, ProgressBarOrientation.Vertical, e.Info, percentageHeight,
                innerCornerRadius, EndProgressColor.ToSKColor(), StartProgressColor.ToSKColor());
            ProgressBarHelper.DrawText(canvas, ProgressBarOrientation.Vertical, e.Info, percentageHeight, textSize,
                PercentageValue, StringFormat, PrimaryTextColor.ToSKColor(), SecondaryTextColor.ToSKColor());
        }
    }
}