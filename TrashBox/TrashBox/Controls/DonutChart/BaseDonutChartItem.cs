using System.ComponentModel;

namespace TrashBox.Controls.DonutChart
{
    public abstract class BaseDonutChartItem : INotifyPropertyChanged
    {
        public float Value { get; set; }

        public string SectionHexColor { get; set; }

        public string IconResourceName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}