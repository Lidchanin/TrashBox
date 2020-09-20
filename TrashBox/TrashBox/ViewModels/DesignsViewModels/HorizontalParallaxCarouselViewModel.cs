using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TrashBox.Abstractions;
using TrashBox.Helpers;
using TrashBox.Models;
using Xamarin.Forms;

namespace TrashBox.ViewModels.DesignsViewModels
{
    public class HorizontalParallaxCarouselViewModel : BaseViewModel
    {
        public ICommand GoBackCommand { get; }

        public ObservableCollection<MKItem> MKCards { get; }

        public HorizontalParallaxCarouselViewModel()
        {
            GoBackCommand = new Command(async () => await GoBackAsync());

            MKCards = new ObservableCollection<MKItem>
            {
                new MKItem
                {
                    CharacterName = Constants.Texts.Scorpion,
                    CharacterImage = Constants.EmbeddedImages.MKScorpion,
                    BackgroundImage = Constants.EmbeddedImages.MKBackground1
                },
                new MKItem
                {
                    CharacterName = Constants.Texts.SubZero,
                    CharacterImage = Constants.EmbeddedImages.MKSubZero,
                    BackgroundImage = Constants.EmbeddedImages.MKBackground2
                },
                new MKItem
                {
                    CharacterName = Constants.Texts.Raiden,
                    CharacterImage = Constants.EmbeddedImages.MKRaiden,
                    BackgroundImage = Constants.EmbeddedImages.MKBackground3
                },
                new MKItem
                {
                    CharacterName = Constants.Texts.QuanChi,
                    CharacterImage = Constants.EmbeddedImages.MKQuanChi,
                    BackgroundImage = Constants.EmbeddedImages.MKBackground1
                },
                new MKItem
                {
                    CharacterName = Constants.Texts.LiuKang,
                    CharacterImage = Constants.EmbeddedImages.MKLiuKang,
                    BackgroundImage = Constants.EmbeddedImages.MKBackground2
                },
                new MKItem
                {
                    CharacterName = Constants.Texts.Kitana,
                    CharacterImage = Constants.EmbeddedImages.MKKitana,
                    BackgroundImage = Constants.EmbeddedImages.MKBackground3
                },
                new MKItem
                {
                    CharacterName = Constants.Texts.Kenshi,
                    CharacterImage = Constants.EmbeddedImages.MKKenshi,
                    BackgroundImage = Constants.EmbeddedImages.MKBackground1
                },
                new MKItem
                {
                    CharacterName = Constants.Texts.Kano,
                    CharacterImage = Constants.EmbeddedImages.MKKano,
                    BackgroundImage = Constants.EmbeddedImages.MKBackground2
                },
                new MKItem
                {
                    CharacterName = Constants.Texts.Ermak,
                    CharacterImage = Constants.EmbeddedImages.MKErmak,
                    BackgroundImage = Constants.EmbeddedImages.MKBackground3
                },
                new MKItem
                {
                    CharacterName = Constants.Texts.Goro,
                    CharacterImage = Constants.EmbeddedImages.MKGoro,
                    BackgroundImage = Constants.EmbeddedImages.MKBackground4
                },
            };
        }

        private static async Task GoBackAsync() =>
            await ShellNavigationHelper.PopAsync();
    }
}