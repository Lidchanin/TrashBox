using SkiaSharp.Views.Forms;
using System;
using Xamarin.Forms;

namespace TrashBox.Controls.GradientProgressBar
{
    public class HorizontalDetailedProgressBar : SKCanvasView
    {
        #region Bindable Properties

        #region PecentageValue Property

        public static readonly BindableProperty PercentageValueProperty = BindableProperty.Create(
            nameof(PercentageValue),
            typeof(float),
            typeof(HorizontalDetailedProgressBar),
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
            typeof(HorizontalDetailedProgressBar),
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
            typeof(HorizontalDetailedProgressBar),
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
            typeof(HorizontalDetailedProgressBar),
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
            typeof(HorizontalDetailedProgressBar),
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

        #region LeftColor Property

        public static readonly BindableProperty LeftColorProperty = BindableProperty.Create(
            nameof(LeftColor),
            typeof(Color),
            typeof(HorizontalDetailedProgressBar),
            Color.White,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color LeftColor
        {
            get => (Color) GetValue(LeftColorProperty);
            set => SetValue(LeftColorProperty, value);
        }

        #endregion LeftColor Property

        #region RightColor Property

        public static readonly BindableProperty RightColorProperty = BindableProperty.Create(
            nameof(RightColor),
            typeof(Color),
            typeof(HorizontalDetailedProgressBar),
            Color.White,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color RightColor
        {
            get => (Color) GetValue(RightColorProperty);
            set => SetValue(RightColorProperty, value);
        }

        #endregion RightColor Property

        #region LeftBackgroundColor Property

        public static readonly BindableProperty LeftBackgroundColorProperty = BindableProperty.Create(
            nameof(LeftBackgroundColor),
            typeof(Color),
            typeof(HorizontalDetailedProgressBar),
            Color.Blue,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color LeftBackgroundColor
        {
            get => (Color) GetValue(LeftBackgroundColorProperty);
            set => SetValue(LeftBackgroundColorProperty, value);
        }

        #endregion LeftBackgroundColor Property

        #region RightBackgroundColor Property

        public static readonly BindableProperty RightBackgroundColorProperty = BindableProperty.Create(
            nameof(RightBackgroundColor),
            typeof(Color),
            typeof(HorizontalDetailedProgressBar),
            Color.Blue,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color RightBackgroundColor
        {
            get => (Color) GetValue(RightBackgroundColorProperty);
            set => SetValue(RightBackgroundColorProperty, value);
        }

        #endregion RightBackgroundColor Property

        #region PrimaryTextColor Property

        public static readonly BindableProperty PrimaryTextColorProperty = BindableProperty.Create(
            nameof(PrimaryTextColor),
            typeof(Color),
            typeof(HorizontalDetailedProgressBar),
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
            typeof(HorizontalDetailedProgressBar),
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
            var control = (HorizontalDetailedProgressBar) bindable;

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

            var percentageWidth = (int) Math.Floor(info.Width * PercentageValue);
            var textSize = FontSize * scale;

            canvas.Clear();

            ProgressBarHelper.SetClip(canvas, info, outerCornerRadius);

            ProgressBarHelper.DrawBackground(canvas, ProgressBarOrientation.Horizontal, e.Info, outerCornerRadius,
                LeftBackgroundColor.ToSKColor(), RightBackgroundColor.ToSKColor());
            ProgressBarHelper.DrawProgress(canvas, ProgressBarOrientation.Horizontal, e.Info, percentageWidth,
                innerCornerRadius, LeftColor.ToSKColor(), RightColor.ToSKColor());
            ProgressBarHelper.DrawText(canvas, ProgressBarOrientation.Horizontal, e.Info, percentageWidth, textSize,
                PercentageValue, StringFormat, PrimaryTextColor.ToSKColor(), SecondaryTextColor.ToSKColor());
        }
    }
}