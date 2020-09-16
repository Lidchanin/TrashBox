using TrashBox.Abstractions;

namespace TrashBox.ViewModels
{
    public class GradientRadialProgressBarViewModel : BaseViewModel
    {
        public float StartAngle { get; set; } = 180;
        public float SweepAngle { get; set; } = 360;
        public float PercentageValue { get; set; }
        public float BarWidth { get; set; } = 50f;
    }
}