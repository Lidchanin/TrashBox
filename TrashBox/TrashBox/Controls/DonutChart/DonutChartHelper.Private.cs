using SkiaSharp;
using System;
using System.Reflection;
using Xamarin.Forms;

namespace TrashBox.Controls.DonutChart
{
    internal static partial class DonutChartHelper
    {
        private static SKPath CreateHolePath(float innerRadius)
        {
            var skPath = new SKPath();

            if (innerRadius > 0)
            {
                skPath.AddCircle(0, 0, innerRadius);
                skPath.FillType = SKPathFillType.EvenOdd;
            }

            skPath.Close();

            return skPath;
        }

        private static SKPath CreateEmptyStatePath(float outerRadius, float innerRadius)
        {
            var skPath = new SKPath();

            skPath.AddCircle(0, 0, outerRadius);

            if (innerRadius > 0)
            {
                skPath.AddCircle(0, 0, innerRadius);
            }

            skPath.FillType = SKPathFillType.EvenOdd;

            skPath.Close();

            return skPath;
        }

        private static SKPath CreateRadiusSeparatorsPath(float outerRadius, float innerRadius)
        {
            var skPath = new SKPath();

            skPath.AddCircle(0, 0, outerRadius);

            if (innerRadius > 0)
            {
                skPath.AddCircle(0, 0, innerRadius);
            }

            skPath.Close();

            return skPath;
        }

        private static SKPath CreateSectorSeparatorPath(float start, float end, float outerRadius, float innerRadius)
        {
            var skPath = new SKPath();

            if (start.Equals(end))
            {
                skPath.Close();

                return skPath;
            }

            if ((end - start).Equals(1))
            {
                skPath.AddCircle(0, 0, outerRadius);
                skPath.AddCircle(0, 0, innerRadius);
                skPath.FillType = SKPathFillType.EvenOdd;

                skPath.Close();

                return skPath;
            }

            var angle = (TotalAngle * start - UprightAngle);

            var circlePoint1 = GetCirclePoint(outerRadius, angle);
            var circlePoint2 = GetCirclePoint(innerRadius, angle);

            skPath.MoveTo(circlePoint1);
            skPath.LineTo(circlePoint2);

            skPath.Close();

            return skPath;
        }

        private static SKPath CreateSectorPath(float start, float end, float outerRadius, float innerRadius)
        {
            var skPath = new SKPath();

            if (start.Equals(end))
            {
                skPath.Close();

                return skPath;
            }

            if ((end - start).Equals(1))
            {
                skPath.AddCircle(0, 0, outerRadius);
                skPath.AddCircle(0, 0, innerRadius);
                skPath.FillType = SKPathFillType.EvenOdd;

                skPath.Close();

                return skPath;
            }

            var angle1 = TotalAngle * start - UprightAngle;
            var angle2 = TotalAngle * end - UprightAngle;
            var arcSize = angle2 - angle1 > Math.PI
                ? SKPathArcSize.Large
                : SKPathArcSize.Small;

            var circlePoint1 = GetCirclePoint(outerRadius, angle1);
            var circlePoint2 = GetCirclePoint(outerRadius, angle2);
            var circlePoint3 = GetCirclePoint(innerRadius, angle2);
            var circlePoint4 = GetCirclePoint(innerRadius, angle1);

            skPath.MoveTo(circlePoint1);
            skPath.ArcTo(outerRadius, outerRadius, 0, arcSize, SKPathDirection.Clockwise, circlePoint2.X,
                circlePoint2.Y);
            skPath.LineTo(circlePoint3);

            if (innerRadius.Equals(0))
            {
                skPath.LineTo(circlePoint4);
            }
            else
            {
                skPath.ArcTo(innerRadius, innerRadius, 0, arcSize, SKPathDirection.CounterClockwise, circlePoint4.X,
                    circlePoint4.Y);
            }

            skPath.Close();

            return skPath;
        }

        private static SKPath CreateDescriptionSeparatorPath(float circleRadius, SKPoint circlePoint1,
            SKPoint circlePoint2, SKPoint circlePoint3)
        {
            var skPath = new SKPath();

            skPath.MoveTo(circlePoint1);
            skPath.LineTo(circlePoint2);
            skPath.AddCircle(circlePoint3.X, circlePoint3.Y, circleRadius);

            skPath.Close();

            return skPath;
        }

        private static SKPoint GetCirclePoint(float radius, float angle) =>
            new SKPoint(radius * (float) Math.Cos(angle), radius * (float) Math.Sin(angle));

        private static double GetInnerRectSideOfCircle(float circleRadius) =>
            Math.Sqrt(2) * circleRadius;

        private static float GetTextSize(float textScale, float textSquareSide, float textWidth) =>
            // 12 is default SKPaint.TextSize
            textScale * textSquareSide * 12 / textWidth;

        private static float GetEmptySectorHeight(float squareSide, float prTextHeight, float secTextHeight) =>
            (squareSide - prTextHeight - secTextHeight) / 3;

        private static void ReduceTextSize(ref float textScale, ref SKPaint skPaint, float squareSide,
            float startTextWidth, string text, out float textHeight, out float textWidth)
        {
            textScale -= 0.1f;
            skPaint.TextSize = GetTextSize(textScale, squareSide, startTextWidth);
            textHeight = skPaint.FontMetrics.CapHeight;
            textWidth = skPaint.MeasureText(text);
        }

        private static SKBitmap GetSKBitmap(string resourceId)
        {
            var assembly = Application.Current.GetType().GetTypeInfo().Assembly;

            using var stream = assembly.GetManifestResourceStream(resourceId);

            return SKBitmap.Decode(stream);
        }
    }
}