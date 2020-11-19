using System.ComponentModel;

namespace TrashBox.Controls.SegmentedView
{
    public sealed class InnerSegmentedViewItem : INotifyPropertyChanged
    {
        public SegmentedViewItem SegmentedViewItem { get; set; }

        public bool IsSelected { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}