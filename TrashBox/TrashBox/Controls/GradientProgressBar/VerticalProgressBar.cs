using SkiaSharp.Views.Forms;
using System;
using Xamarin.Forms;

namespace TrashBox.Controls.GradientProgressBar
{
    public class VerticalProgressBar : SKCanvasView
    {
        #region Bindable Properties

        #region PecentageValue Property

        public static readonly BindableProperty PercentageValueProperty = BindableProperty.Create(
            nameof(PercentageValue),
            typeof(float),
            typeof(VerticalProgressBar),
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
            typeof(VerticalProgressBar),
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
            typeof(VerticalProgressBar),
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

        #region TopColor Property

        public static readonly BindableProperty TopColorProperty = BindableProperty.Create(
            nameof(TopColor),
            typeof(Color),
            typeof(VerticalProgressBar),
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
            typeof(VerticalProgressBar),
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
            typeof(VerticalProgressBar),
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
            typeof(VerticalProgressBar),
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

        #endregion Bindable Properties

        private static void OnPropertyChangedInvalidate(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (VerticalProgressBar) bindable;

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

            canvas.Clear();

            ProgressBarHelper.SetClip(canvas, info, outerCornerRadius);

            ProgressBarHelper.DrawBackground(canvas, ProgressBarOrientation.Vertical, e.Info, outerCornerRadius,
                TopBackgroundColor.ToSKColor(), BottomBackgroundColor.ToSKColor());
            ProgressBarHelper.DrawProgress(canvas, ProgressBarOrientation.Vertical, e.Info, percentageHeight,
                innerCornerRadius, TopColor.ToSKColor(), BottomColor.ToSKColor());
        }
    }
}