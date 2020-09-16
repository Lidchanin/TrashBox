using SkiaSharp.Views.Forms;
using System;
using Xamarin.Forms;

namespace TrashBox.Controls.GradientProgressBar
{
    public class HorizontalProgressBar : SKCanvasView
    {
        #region Bindable Properties

        #region PecentageValue Property

        public static readonly BindableProperty PercentageValueProperty = BindableProperty.Create(
            nameof(PercentageValue),
            typeof(float),
            typeof(HorizontalProgressBar),
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
            typeof(HorizontalProgressBar),
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
            typeof(HorizontalProgressBar),
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

        #region LeftColor Property

        public static readonly BindableProperty LeftColorProperty = BindableProperty.Create(
            nameof(LeftColor),
            typeof(Color),
            typeof(HorizontalProgressBar),
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
            typeof(HorizontalProgressBar),
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
            typeof(HorizontalProgressBar),
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
            typeof(HorizontalProgressBar),
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

        #endregion Bindable Properties

        private static void OnPropertyChangedInvalidate(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (HorizontalProgressBar) bindable;

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

            canvas.Clear();

            ProgressBarHelper.SetClip(canvas, info, outerCornerRadius);

            ProgressBarHelper.DrawBackground(canvas, ProgressBarOrientation.Horizontal, e.Info, outerCornerRadius,
                LeftBackgroundColor.ToSKColor(), RightBackgroundColor.ToSKColor());
            ProgressBarHelper.DrawProgress(canvas, ProgressBarOrientation.Horizontal, e.Info, percentageWidth,
                innerCornerRadius, LeftColor.ToSKColor(), RightColor.ToSKColor());
        }
    }
}