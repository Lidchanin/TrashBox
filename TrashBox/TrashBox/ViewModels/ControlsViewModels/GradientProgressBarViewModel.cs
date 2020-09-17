using TrashBox.Abstractions;

namespace TrashBox.ViewModels.ControlsViewModels
{
    public class GradientProgressBarViewModel : BaseViewModel
    {
        public float PercentageValue { get; set; } = 0.75f;
        public float FontSize { get; set; } = 40f;
        public float OuterCornerRadius { get; set; } = 10f;
        public float InnerCornerRadius { get; set; } = 10f;
    }
}