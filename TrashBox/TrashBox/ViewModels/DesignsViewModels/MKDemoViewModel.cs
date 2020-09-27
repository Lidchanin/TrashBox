using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TrashBox.Abstractions;
using TrashBox.Helpers;
using TrashBox.Models;
using Xamarin.Forms;

namespace TrashBox.ViewModels.DesignsViewModels
{
    public class MKDemoViewModel : BaseViewModel
    {
        public ICommand GoBackCommand { get; }
        public ICommand SelectCharacterCommand { get; }

        public ObservableCollection<MKCharacter> MKCharacters { get; }
        public MKCharacter CurrentMKCharacter { get; set; }

        public MKDemoViewModel()
        {
            GoBackCommand = new Command(async () => await GoBackAsync());
            SelectCharacterCommand = new Command(async () => await SelectCharacterAsync());

            MKCharacters = new ObservableCollection<MKCharacter>
            {
                new MKCharacter(Constants.Texts.Scorpion, Constants.Texts.ScorpionInfo,
                    Constants.EmbeddedImages.MKScorpion),
                new MKCharacter(Constants.Texts.SubZero, Constants.Texts.SubZeroInfo,
                    Constants.EmbeddedImages.MKSubZero),
                new MKCharacter(Constants.Texts.JohnnyCage, Constants.Texts.JohnnyCageInfo,
                    Constants.EmbeddedImages.MKJohnnyCage),
                new MKCharacter(Constants.Texts.ErronBlack, Constants.Texts.ErronBlackInfo,
                    Constants.EmbeddedImages.MKErronBlack),
                new MKCharacter(Constants.Texts.Raiden, Constants.Texts.RaidenInfo, Constants.EmbeddedImages.MKRaiden),
                new MKCharacter(Constants.Texts.QuanChi, Constants.Texts.QuanChiInfo,
                    Constants.EmbeddedImages.MKQuanChi),
                new MKCharacter(Constants.Texts.LiuKang, Constants.Texts.LiuKangInfo,
                    Constants.EmbeddedImages.MKLiuKang),
                new MKCharacter(Constants.Texts.KungLao, Constants.Texts.KungLaoInfo,
                    Constants.EmbeddedImages.MKKungLao),
                new MKCharacter(Constants.Texts.Kitana, Constants.Texts.KitanaInfo, Constants.EmbeddedImages.MKKitana),
                new MKCharacter(Constants.Texts.Kenshi, Constants.Texts.KenshiInfo, Constants.EmbeddedImages.MKKenshi),
                new MKCharacter(Constants.Texts.Kano, Constants.Texts.KanoInfo, Constants.EmbeddedImages.MKKano),
                new MKCharacter(Constants.Texts.Ermak, Constants.Texts.ErmakInfo, Constants.EmbeddedImages.MKErmak),
            };
        }

        private static async Task GoBackAsync()
        {
            await ShellNavigationHelper.PopAsync();
        }

        private async Task SelectCharacterAsync()
        {
            var t = CurrentMKCharacter;
        }
    }
}