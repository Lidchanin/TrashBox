using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TrashBox.Controls.DonutChart
{
    public class DonutChartView : SKCanvasView
    {
        #region Bindable Properties

        #region ItemsSource Property

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            nameof(ItemsSource),
            typeof(IList<DonutChartItem>),
            typeof(DonutChartView),
            propertyChanged: OnChartChanged);

        public ObservableCollection<DonutChartItem> ItemsSource
        {
            get => (ObservableCollection<DonutChartItem>) GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        #endregion ItemsSource Property

        #region SectorCommand Property

        public static readonly BindableProperty SectorCommandProperty = BindableProperty.Create(
            nameof(SectorCommand),
            typeof(ICommand),
            typeof(DonutChartView));

        public ICommand SectorCommand
        {
            get => (ICommand) GetValue(SectorCommandProperty);
            set => SetValue(SectorCommandProperty, value);
        }

        #endregion SectorCommand Property

        #region HoleCommand Property

        public static readonly BindableProperty HoleCommandProperty = BindableProperty.Create(
            nameof(HoleCommand),
            typeof(ICommand),
            typeof(DonutChartView));

        public ICommand HoleCommand
        {
            get => (ICommand) GetValue(HoleCommandProperty);
            set => SetValue(HoleCommandProperty, value);
        }

        #endregion HoleCommand Property

        #region EmptyStateColor Property

        public static readonly BindableProperty EmptyStateColorProperty = BindableProperty.Create(
            nameof(EmptyStateColor),
            typeof(Color),
            typeof(DonutChartView),
            Color.Transparent,
            propertyChanged: OnChartChanged);

        public Color EmptyStateColor
        {
            get => (Color) GetValue(EmptyStateColorProperty);
            set => SetValue(EmptyStateColorProperty, value);
        }

        #endregion EmptyStateColor Property

        #region HoleRadius Property

        public static readonly BindableProperty HoleRadiusProperty = BindableProperty.Create(
            nameof(HoleRadius),
            typeof(float),
            typeof(DonutChartView),
            0.5f,
            propertyChanged: OnChartChanged);

        public float HoleRadius
        {
            get
            {
                var holeRadius = (float) GetValue(HoleRadiusProperty);

                if (holeRadius < 0)
                {
                    holeRadius = 0;
                }
                else if (holeRadius > 1)
                {
                    holeRadius = 1;
                }

                return holeRadius;
            }
            set => SetValue(HoleRadiusProperty, value);
        }

        #endregion HoleRadius Property

        #region HolePrimaryText Property

        public static readonly BindableProperty HolePrimaryTextProperty = BindableProperty.Create(
            nameof(HolePrimaryText),
            typeof(string),
            typeof(DonutChartView),
            string.Empty,
            propertyChanged: OnChartChanged);

        public string HolePrimaryText
        {
            get => (string) GetValue(HolePrimaryTextProperty);
            set => SetValue(HolePrimaryTextProperty, value);
        }

        #endregion HolePrimaryText Property

        #region HoleSecondaryText Property

        public static readonly BindableProperty HoleSecondaryTextProperty = BindableProperty.Create(
            nameof(HoleSecondaryText),
            typeof(string),
            typeof(DonutChartView),
            string.Empty,
            propertyChanged: OnChartChanged);

        public string HoleSecondaryText
        {
            get => (string) GetValue(HoleSecondaryTextProperty);
            set => SetValue(HoleSecondaryTextProperty, value);
        }

        #endregion HoleSecondaryText Property

        #region HolePrimaryTextScale Property

        public static readonly BindableProperty HolePrimaryTextScaleProperty = BindableProperty.Create(
            nameof(HolePrimaryTextScale),
            typeof(float),
            typeof(DonutChartView),
            1f,
            propertyChanged: OnChartChanged);

        public float HolePrimaryTextScale
        {
            get
            {
                var textScale = (float) GetValue(HolePrimaryTextScaleProperty);

                if (textScale < 0)
                {
                    textScale = 0;
                }
                else if (textScale > 1)
                {
                    textScale = 1;
                }

                return textScale;
            }
            set => SetValue(HolePrimaryTextScaleProperty, value);
        }

        #endregion HolePrimaryTextScale Property

        #region HoleSecondaryTextScale Property

        public static readonly BindableProperty HoleSecondaryTextScaleProperty = BindableProperty.Create(
            nameof(HoleSecondaryTextScale),
            typeof(float),
            typeof(DonutChartView),
            1f,
            propertyChanged: OnChartChanged);

        public float HoleSecondaryTextScale
        {
            get
            {
                var textScale = (float) GetValue(HoleSecondaryTextScaleProperty);

                if (textScale < 0)
                {
                    textScale = 0;
                }
                else if (textScale > 1)
                {
                    textScale = 1;
                }

                return textScale;
            }
            set => SetValue(HoleSecondaryTextScaleProperty, value);
        }

        #endregion HoleSecondaryTextScale Property

        #region HoleColor Property

        public static readonly BindableProperty HoleColorProperty = BindableProperty.Create(
            nameof(HoleColor),
            typeof(Color),
            typeof(DonutChartView),
            Color.Transparent,
            propertyChanged: OnChartChanged);

        public Color HoleColor
        {
            get => (Color) GetValue(HoleColorProperty);
            set => SetValue(HoleColorProperty, value);
        }

        #endregion HoleColor Property

        #region HolePrimaryTextColor Property

        public static readonly BindableProperty HolePrimaryTextColorProperty = BindableProperty.Create(
            nameof(HolePrimaryTextColor),
            typeof(Color),
            typeof(DonutChartView),
            Color.Black,
            propertyChanged: OnChartChanged);

        public Color HolePrimaryTextColor
        {
            get => (Color) GetValue(HolePrimaryTextColorProperty);
            set => SetValue(HolePrimaryTextColorProperty, value);
        }

        #endregion HolePrimaryTextColor Property

        #region HoleSecondaryTextColor Property

        public static readonly BindableProperty HoleSecondaryTextColorProperty = BindableProperty.Create(
            nameof(HoleSecondaryTextColor),
            typeof(Color),
            typeof(DonutChartView),
            Color.Black,
            propertyChanged: OnChartChanged);

        public Color HoleSecondaryTextColor
        {
            get => (Color) GetValue(HoleSecondaryTextColorProperty);
            set => SetValue(HoleSecondaryTextColorProperty, value);
        }

        #endregion HoleSecondaryTextColor Property

        #region InnerMargin Property

        public static readonly BindableProperty InnerMarginProperty = BindableProperty.Create(
            nameof(InnerMargin),
            typeof(float),
            typeof(DonutChartView),
            100f,
            propertyChanged: OnChartChanged);

        public float InnerMargin
        {
            get
            {
                var innerMargin = (float) GetValue(InnerMarginProperty);

                innerMargin *= (float) DeviceDisplay.MainDisplayInfo.Density;

                return innerMargin;
            }
            set => SetValue(InnerMarginProperty, value);
        }

        #endregion InnerMargin Property

        #region LineToCircleLength Property

        public static readonly BindableProperty LineToCircleLengthProperty = BindableProperty.Create(
            nameof(LineToCircleLength),
            typeof(float),
            typeof(DonutChartView),
            10f,
            propertyChanged: OnChartChanged);

        public float LineToCircleLength
        {
            get
            {
                var lineToCircleLength = (float) GetValue(LineToCircleLengthProperty);

                lineToCircleLength *= (float) DeviceDisplay.MainDisplayInfo.Density;

                return lineToCircleLength;
            }
            set => SetValue(LineToCircleLengthProperty, value);
        }

        #endregion LineToCircleLength Property

        #region DescriptionCircleRadius Property

        public static readonly BindableProperty DescriptionCircleRadiusProperty = BindableProperty.Create(
            nameof(DescriptionCircleRadius),
            typeof(float),
            typeof(DonutChartView),
            20f,
            propertyChanged: OnChartChanged);

        public float DescriptionCircleRadius
        {
            get
            {
                var circleRadius = (float) GetValue(DescriptionCircleRadiusProperty);

                circleRadius *= (float) DeviceDisplay.MainDisplayInfo.Density;

                if (circleRadius < 0)
                {
                    circleRadius = 0;
                }

                return circleRadius;
            }
            set => SetValue(DescriptionCircleRadiusProperty, value);
        }

        #endregion DescriptionCircleRadius Property

        #region SeparatorsWidth Property

        public static readonly BindableProperty SeparatorsWidthProperty = BindableProperty.Create(
            nameof(SeparatorsWidth),
            typeof(float),
            typeof(DonutChartView),
            2f,
            propertyChanged: OnChartChanged);

        public float SeparatorsWidth
        {
            get
            {
                var separatorsWidth = (float) GetValue(SeparatorsWidthProperty);

                separatorsWidth *= (float) DeviceDisplay.MainDisplayInfo.Density;

                if (separatorsWidth < 0)
                {
                    separatorsWidth = 0;
                }

                return separatorsWidth;
            }
            set => SetValue(SeparatorsWidthProperty, value);
        }

        #endregion SeparatorsWidth Property

        #region SeparatorsColor Property

        public static readonly BindableProperty SeparatorsColorProperty = BindableProperty.Create(
            nameof(SeparatorsColor),
            typeof(Color),
            typeof(DonutChartView),
            Color.Black,
            propertyChanged: OnChartChanged);

        public Color SeparatorsColor
        {
            get => (Color) GetValue(SeparatorsColorProperty);
            set => SetValue(SeparatorsColorProperty, value);
        }

        #endregion SeparatorsColor Property

        #endregion Bindable Properties

        private readonly List<long> _touchIds = new List<long>();

        public DonutChartView()
        {
            PaintSurface += OnPaintCanvas;

            EnableTouchEvents = true;
            Touch += DonutChartView_Touch;
        }

        #region Private methods

        private static void OnChartChanged(BindableObject bindable, object oldValue, object newValue)
        {
            InvalidateSurface((SKCanvasView) bindable);
        }

        private void OnPaintCanvas(object sender, SKPaintSurfaceEventArgs e)
        {
            DrawContent(e.Surface.Canvas, e.Info.Width, e.Info.Height);

            if (ItemsSource != null)
            {
                ItemsSource.CollectionChanged += (o, args) => InvalidateSurface((SKCanvasView) sender);
            }
        }

        private static void InvalidateSurface(SKCanvasView skCanvasView)
        {
            skCanvasView.InvalidateSurface();
            DonutChartHelper.SectorsPaths.Clear();
            DonutChartHelper.DescriptionsPaths.Clear();
        }

        private void DonutChartView_Touch(object sender, SKTouchEventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            e.Handled = true;

            var touchLocation = e.Location;

            switch (e.ActionType)
            {
                case SKTouchAction.Pressed:
                {
                    if (DonutChartHelper.HitTest(touchLocation, CanvasSize.Width, CanvasSize.Height))
                    {
                        _touchIds.Add(e.Id);
                    }

                    break;
                }
                case SKTouchAction.Released:
                {
                    if (_touchIds.Contains(e.Id))
                    {
                        _touchIds.Remove(e.Id);
                    }

                    OnTouched(touchLocation);

                    break;
                }
                case SKTouchAction.Cancelled:
                case SKTouchAction.Exited:
                {
                    if (_touchIds.Contains(e.Id))
                    {
                        _touchIds.Remove(e.Id);
                    }

                    break;
                }
            }
        }

        private void OnTouched(SKPoint touchLocation)
        {
            var translatedLocation = new SKPoint(touchLocation.X - CanvasSize.Width / 2,
                touchLocation.Y - CanvasSize.Height / 2);

            if (DonutChartHelper.HolePath.Contains(translatedLocation.X, translatedLocation.Y))
            {
                HoleCommand?.Execute(null);

                return;
            }

            for (var i = 0; i < DonutChartHelper.SectorsPaths.Count; i++)
            {
                if (DonutChartHelper.SectorsPaths[i].Contains(translatedLocation.X, translatedLocation.Y) ||
                    DonutChartHelper.DescriptionsPaths[i] != null &&
                    DonutChartHelper.DescriptionsPaths[i].Contains(translatedLocation.X, translatedLocation.Y))
                {
                    SectorCommand?.Execute(ItemsSource?[i]);

                    return;
                }
            }
        }

        private void DrawContent(SKCanvas canvas, int width, int height)
        {
            canvas.Clear();

            using (new SKAutoCanvasRestore(canvas))
            {
                canvas.Translate(width / 2f, height / 2f);

                var outerRadius = (Math.Min(width, height) - 2 * InnerMargin) / 2;
                var innerRadius = outerRadius * HoleRadius;

                if (ItemsSource == null || ItemsSource.Count == 0)
                {
                    DrawEmptyState(canvas, outerRadius, innerRadius);
                }
                else
                {
                    DrawSectors(canvas, outerRadius, innerRadius);
                }

                DrawHole(canvas, innerRadius);

                DrawTextInHole(canvas, innerRadius);

                DrawSeparators(canvas, outerRadius, innerRadius);

                if (DescriptionCircleRadius > 0)
                {
                    DrawDescriptions(canvas, outerRadius);
                }
            }
        }

        private void DrawEmptyState(SKCanvas canvas, float outerRadius, float innerRadius) =>
            DonutChartHelper.DrawEmptyState(canvas, outerRadius, innerRadius, EmptyStateColor.ToSKColor());

        private void DrawSectors(SKCanvas canvas, float outerRadius, float innerRadius) =>
            DonutChartHelper.DrawSectors(canvas, outerRadius, innerRadius, ItemsSource);

        private void DrawSeparators(SKCanvas canvas, float outerRadius, float innerRadius) =>
            DonutChartHelper.DrawSeparators(canvas, outerRadius, innerRadius, SeparatorsColor.ToSKColor(),
                SeparatorsWidth, ItemsSource);

        private void DrawHole(SKCanvas canvas, float innerRadius) =>
            DonutChartHelper.DrawHole(canvas, innerRadius, HoleColor.ToSKColor());

        private void DrawTextInHole(SKCanvas canvas, float innerRadius) =>
            DonutChartHelper.DrawTextInHole(canvas, innerRadius, HolePrimaryTextScale, HoleSecondaryTextScale,
                HolePrimaryText, HoleSecondaryText, HolePrimaryTextColor.ToSKColor(),
                HoleSecondaryTextColor.ToSKColor());

        private void DrawDescriptions(SKCanvas canvas, float outerRadius) =>
            DonutChartHelper.DrawDescriptions(canvas, outerRadius, SeparatorsColor.ToSKColor(), SeparatorsWidth,
                ItemsSource, DescriptionCircleRadius, LineToCircleLength);

        #endregion Private methods
    }
}