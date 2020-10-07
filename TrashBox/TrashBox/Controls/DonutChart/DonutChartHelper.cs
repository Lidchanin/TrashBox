using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TrashBox.Models;

namespace TrashBox.Controls.DonutChart
{
    internal static partial class DonutChartHelper
    {
        private const float UprightAngle = 1.57079637050629f;
        private const float TotalAngle = 6.28318548202515f;

        internal static SKPath DrawHole(SKCanvas canvas, float innerRadius, SKColor holeColor)
        {
            var holePath = CreateHolePath(innerRadius);

            using var paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = holeColor,
                IsAntialias = true
            };

            canvas.DrawPath(holePath, paint);

            return holePath;
        }

        internal static void DrawEmptyState(SKCanvas canvas, float outerRadius, float innerRadius,
            SKColor emptyStateColor)
        {
            using var paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = emptyStateColor,
                IsAntialias = true
            };

            var emptyStatePath = CreateEmptyStatePath(outerRadius, innerRadius);

            canvas.DrawPath(emptyStatePath, paint);
        }

        internal static void DrawSeparators(SKCanvas canvas, float outerRadius, float innerRadius,
            SKColor separatorsColor, float separatorsWidth, ObservableCollection<ExpenseChartItem> itemsSource)
        {
            if (separatorsWidth <= 0 || separatorsColor == SKColors.Transparent)
            {
                return;
            }

            using var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = separatorsWidth,
                Color = separatorsColor,
                IsAntialias = true
            };

            var radiusSeparatorsPath = CreateRadiusSeparatorsPath(outerRadius, innerRadius);

            canvas.DrawPath(radiusSeparatorsPath, paint);

            if (itemsSource == null)
            {
                return;
            }

            var sumValues = itemsSource.Sum(x => Math.Abs(x.Value));
            var start = 0f;

            for (var index = 0; index < itemsSource.Count; ++index)
            {
                var chartItem = itemsSource.ElementAt(index);
                var end = start + Math.Abs(chartItem.Value) / sumValues;

                var sectorSeparatorPath = CreateSectorSeparatorPath(start, end, outerRadius, innerRadius);

                canvas.DrawPath(sectorSeparatorPath, paint);

                start = end;
            }
        }

        internal static IList<SKPath> DrawSectors(SKCanvas canvas, float outerRadius, float innerRadius,
            ObservableCollection<ExpenseChartItem> itemsSource)
        {
            if (itemsSource == null)
            {
                return null;
            }

            var sectorsPaths = new List<SKPath>();

            var sumValues = itemsSource.Sum(x => Math.Abs(x.Value));
            var start = 0f;

            for (var index = 0; index < itemsSource.Count; ++index)
            {
                var chartItem = itemsSource.ElementAt(index);
                var end = start + Math.Abs(chartItem.Value) / sumValues;

                var sectorPath = CreateSectorPath(start, end, outerRadius, innerRadius);

                using (var paint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = SKColor.Parse(chartItem.SectionHexColor),
                    IsAntialias = true
                })
                {
                    canvas.DrawPath(sectorPath, paint);
                }

                start = end;

                sectorsPaths.Add(sectorPath);
            }

            return sectorsPaths;
        }

        internal static IList<SKPath> DrawDescriptions(SKCanvas canvas, float outerRadius, SKColor separatorsColor,
            float separatorsWidth, ObservableCollection<ExpenseChartItem> itemsSource, float circleRadius,
            float lineToCircleLength)
        {
            if (itemsSource == null || circleRadius <= 0)
            {
                return null;
            }

            var descriptionsPaths = new List<SKPath>();

            var sumValues = itemsSource.Sum(x => Math.Abs(x.Value));
            var resizedBitmapSide = (int) GetInnerRectSideOfCircle(circleRadius);
            var separatorPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = separatorsWidth,
                Color = separatorsColor,
                IsAntialias = true
            };
            var descPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                IsAntialias = true
            };

            var start = 0f;

            for (var index = 0; index < itemsSource.Count; ++index)
            {
                var chartItem = itemsSource.ElementAt(index);

                var end = start + Math.Abs(chartItem.Value) / sumValues;

                if (!string.IsNullOrEmpty(chartItem.IconResourceName) && !end.Equals(start))
                {
                    var angle1 = TotalAngle * start - UprightAngle;
                    var angle2 = TotalAngle * end - UprightAngle;
                    var angle = (angle1 + angle2) / 2;

                    var circlePoint1 = GetCirclePoint(outerRadius, angle);
                    var circlePoint2 = GetCirclePoint(outerRadius + lineToCircleLength, angle);
                    var circlePoint3 = GetCirclePoint(outerRadius + lineToCircleLength + circleRadius, angle);

                    var descriptionSeparatorPath =
                        CreateDescriptionSeparatorPath(circleRadius, circlePoint1, circlePoint2, circlePoint3);

                    descPaint.Color = SKColor.Parse(chartItem.SectionHexColor);

                    var skBitmap = GetSKBitmap(chartItem.IconResourceName);

                    var resizedBitmap = skBitmap.Resize(new SKImageInfo(resizedBitmapSide, resizedBitmapSide),
                        SKFilterQuality.Medium);

                    if (resizedBitmap != null)
                    {
                        if (separatorsWidth > 0)
                        {
                            canvas.DrawPath(descriptionSeparatorPath, separatorPaint);
                        }

                        canvas.DrawCircle(circlePoint3.X, circlePoint3.Y, circleRadius - separatorsWidth / 2,
                            descPaint);

                        canvas.DrawBitmap(resizedBitmap, circlePoint3.X - resizedBitmap.Width / 2f,
                            circlePoint3.Y - resizedBitmap.Height / 2f);
                    }

                    descriptionsPaths.Add(descriptionSeparatorPath);
                }
                else
                {
                    descriptionsPaths.Add(null);
                }

                start = end;
            }

            descPaint.Dispose();
            separatorPaint.Dispose();

            return descriptionsPaths;
        }

        internal static void DrawTextInHole(SKCanvas canvas, float innerRadius, float holePrimaryTextScale,
            float holeSecondaryTextScale, string holePrimaryText, string holeSecondaryText,
            SKColor holePrimaryTextColor, SKColor holeSecondaryTextColor)
        {
            if (innerRadius <= 0)
            {
                return;
            }

            if (string.IsNullOrEmpty(holePrimaryText) &&
                string.IsNullOrEmpty(holeSecondaryText))
            {
                return;
            }

            var squareSide = (float) GetInnerRectSideOfCircle(innerRadius);

            if (string.IsNullOrEmpty(holeSecondaryText))
            {
                var textPaint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = holePrimaryTextColor,
                    IsAntialias = true
                };

                var startTextWidth = textPaint.MeasureText(holePrimaryText);
                textPaint.TextSize = GetTextSize(holePrimaryTextScale, squareSide, startTextWidth);

                var textHeight = textPaint.FontMetrics.CapHeight;
                var textWidth = textPaint.MeasureText(holePrimaryText);

                while (textHeight > textWidth &&
                       textHeight > squareSide)
                {
                    ReduceTextSize(ref holePrimaryTextScale, ref textPaint, squareSide, startTextWidth, holePrimaryText,
                        out textHeight, out textWidth);
                }

                canvas.DrawText(holePrimaryText, -textWidth / 2, textHeight / 2, textPaint);

                textPaint.Dispose();
            }
            else if (string.IsNullOrEmpty(holePrimaryText))
            {
                var textPaint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = holeSecondaryTextColor,
                    IsAntialias = true
                };

                var startTextWidth = textPaint.MeasureText(holeSecondaryText);
                textPaint.TextSize = GetTextSize(holeSecondaryTextScale, squareSide, startTextWidth);

                var textHeight = textPaint.FontMetrics.CapHeight;
                var textWidth = textPaint.MeasureText(holeSecondaryText);

                while (textHeight > textWidth &&
                       textHeight > squareSide)
                {
                    ReduceTextSize(ref holeSecondaryTextScale, ref textPaint, squareSide, startTextWidth,
                        holeSecondaryText, out textHeight, out startTextWidth);
                }

                canvas.DrawText(holeSecondaryText, -textWidth / 2, textHeight / 2, textPaint);

                textPaint.Dispose();
            }
            else
            {
                var prTextPaint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = holePrimaryTextColor
                };

                var startPrTextWidth = prTextPaint.MeasureText(holePrimaryText);
                prTextPaint.TextSize = GetTextSize(holePrimaryTextScale, squareSide, startPrTextWidth);

                var prTextHeight = prTextPaint.FontMetrics.CapHeight;
                var prTextWidth = prTextPaint.MeasureText(holePrimaryText);

                var secTextPaint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = holeSecondaryTextColor
                };

                var startSecTextWidth = secTextPaint.MeasureText(holeSecondaryText);
                secTextPaint.TextSize = GetTextSize(holeSecondaryTextScale, squareSide, startSecTextWidth);

                var secTextHeight = secTextPaint.FontMetrics.CapHeight;
                var secTextWidth = secTextPaint.MeasureText(holeSecondaryText);

                var emptySectorHeight = GetEmptySectorHeight(squareSide, prTextHeight, secTextHeight);

                while (prTextHeight > squareSide || secTextHeight > squareSide ||
                       prTextHeight + secTextHeight > squareSide)
                {
                    if (prTextHeight > secTextHeight)
                    {
                        ReduceTextSize(ref holePrimaryTextScale, ref prTextPaint, squareSide, startPrTextWidth,
                            holePrimaryText, out prTextHeight, out prTextWidth);
                    }
                    else if (prTextHeight < secTextHeight)
                    {
                        ReduceTextSize(ref holeSecondaryTextScale, ref secTextPaint, squareSide, startSecTextWidth,
                            holeSecondaryText, out secTextHeight, out secTextWidth);
                    }
                    else
                    {
                        ReduceTextSize(ref holePrimaryTextScale, ref prTextPaint, squareSide, startPrTextWidth,
                            holePrimaryText, out prTextHeight, out prTextWidth);
                        ReduceTextSize(ref holeSecondaryTextScale, ref secTextPaint, squareSide, startSecTextWidth,
                            holeSecondaryText, out secTextHeight, out secTextWidth);
                    }

                    emptySectorHeight = GetEmptySectorHeight(squareSide, prTextHeight, secTextHeight);
                }

                var prTemp = -(squareSide / 2 - emptySectorHeight - prTextHeight);
                var secTemp = (squareSide / 2 - emptySectorHeight);

                canvas.DrawText(holePrimaryText, -prTextWidth / 2, prTemp, prTextPaint);
                canvas.DrawText(holeSecondaryText, -secTextWidth / 2, secTemp, secTextPaint);

                prTextPaint.Dispose();
                secTextPaint.Dispose();
            }
        }

        internal static bool HitTest(SKPoint touchLocation, float canvasWidth, float canvasHeight) =>
            new SKRect(0, 0, canvasWidth, canvasHeight).Contains(touchLocation);
    }
}