using System.ComponentModel;

namespace TrashBox.Controls.SegmentedView
{
    public abstract class SegmentedViewItem : INotifyPropertyChanged
    {
        public virtual string Text { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}