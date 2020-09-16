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

        #region TopColor Property

        public static readonly BindableProperty TopColorProperty = BindableProperty.Create(
            nameof(TopColor),
            typeof(Color),
            typeof(VerticalDetailedProgressBar),
            Color.White,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color TopColor
        {
            get => (Color) GetValue(TopColorProperty);
            set => SetValue(TopColorProperty, value);
        }

        #endregion TopColor Property

        #region BottomColor Property

        public static readonly BindableProperty BottomColorProperty = BindableProperty.Create(
            nameof(BottomColor),
            typeof(Color),
            typeof(VerticalDetailedProgressBar),
            Color.White,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color BottomColor
        {
            get => (Color) GetValue(BottomColorProperty);
            set => SetValue(BottomColorProperty, value);
        }

        #endregion BottomColor Property

        #region TopBackgroundColor Property

        public static readonly BindableProperty TopBackgroundColorProperty = BindableProperty.Create(
            nameof(TopBackgroundColor),
            typeof(Color),
            typeof(VerticalDetailedProgressBar),
            Color.Blue,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color TopBackgroundColor
        {
            get => (Color) GetValue(TopBackgroundColorProperty);
            set => SetValue(TopBackgroundColorProperty, value);
        }

        #endregion LeftBackgroundColor Property

        #region BottomBackgroundColor Property

        public static readonly BindableProperty BottomBackgroundColorProperty = BindableProperty.Create(
            nameof(BottomBackgroundColor),
            typeof(Color),
            typeof(VerticalDetailedProgressBar),
            Color.Blue,
            BindingMode.OneWay,
            (bindable, value) => value != null,
            OnPropertyChangedInvalidate);

        public Color BottomBackgroundColor
        {
            get => (Color) GetValue(BottomBackgroundColorProperty);
            set => SetValue(BottomBackgroundColorProperty, value);
        }

        #endregion RightBackgroundColor Property

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
                TopBackgroundColor.ToSKColor(), BottomBackgroundColor.ToSKColor());
            ProgressBarHelper.DrawProgress(canvas, ProgressBarOrientation.Vertical, e.Info, percentageHeight,
                innerCornerRadius, TopColor.ToSKColor(), BottomColor.ToSKColor());
            ProgressBarHelper.DrawText(canvas, ProgressBarOrientation.Vertical, e.Info, percentageHeight, textSize,
                PercentageValue, StringFormat, PrimaryTextColor.ToSKColor(), SecondaryTextColor.ToSKColor());
        }
    }
}