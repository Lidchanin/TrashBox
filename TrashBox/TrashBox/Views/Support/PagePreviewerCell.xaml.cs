using System.Windows.Input;
using TrashBox.Helpers;
using TrashBox.Models;
using Xamarin.Forms;

namespace TrashBox.Views.Support
{
    public partial class PagePreviewerCell
    {
        #region Bindable Properties

        #region PageInfo Property

        public static readonly BindableProperty PageInfoProperty = BindableProperty.Create(
            nameof(PageInfo),
            typeof(PageInfo),
            typeof(PagePreviewerCell));

        public PageInfo PageInfo
        {
            get => (PageInfo) GetValue(PageInfoProperty);
            set => SetValue(PageInfoProperty, value);
        }

        #endregion PageInfo Property

        #region Command Property

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(PagePreviewerCell));

        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        #endregion Command Property

        #region TitleFontFamily Property

        public static readonly BindableProperty TitleFontFamilyProperty = BindableProperty.Create(
            nameof(TitleFontFamily),
            typeof(string),
            typeof(PagePreviewerCell),
            Constants.EmbeddedFonts.September22);

        public string TitleFontFamily
        {
            get => (string) GetValue(TitleFontFamilyProperty);
            set => SetValue(TitleFontFamilyProperty, value);
        }

        #endregion TitleFontFamily Property

        #region DescriptionFontFamily Property

        public static readonly BindableProperty DescriptionFontFamilyProperty = BindableProperty.Create(
            nameof(DescriptionFontFamily),
            typeof(string),
            typeof(PagePreviewerCell),
            Constants.EmbeddedFonts.September22);

        public string DescriptionFontFamily
        {
            get => (string) GetValue(DescriptionFontFamilyProperty);
            set => SetValue(DescriptionFontFamilyProperty, value);
        }

        #endregion DescriptionFontFamily Property

        #endregion Bindable Properties

        public PagePreviewerCell()
        {
            InitializeComponent();
        }
    }
}