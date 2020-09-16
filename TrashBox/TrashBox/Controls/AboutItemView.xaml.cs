using Xamarin.Forms;

namespace TrashBox.Controls
{
    public partial class AboutItemView
    {
        #region Bindable Properties

        #region Filename Property

        public static readonly BindableProperty FilenameProperty = BindableProperty.Create(
            nameof(Filename),
            typeof(string),
            typeof(AboutItemView));

        public string Filename
        {
            get => (string) GetValue(FilenameProperty);
            set => SetValue(FilenameProperty, value);
        }

        #endregion Filename Property

        #region Text Property

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(AboutItemView));

        public string Text
        {
            get => (string) GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        #endregion Text Property

        #endregion Bindable Properties

        public AboutItemView()
        {
            InitializeComponent();
        }
    }
}