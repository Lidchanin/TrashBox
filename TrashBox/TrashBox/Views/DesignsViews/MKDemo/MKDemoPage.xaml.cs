using System.IO;
using System.Reflection;
using TrashBox.DependencyServices;
using TrashBox.Helpers;
using TrashBox.ViewModels.DesignsViewModels;
using Xamarin.Forms;

namespace TrashBox.Views.DesignsViews.MKDemo
{
    public partial class MKDemoPage
    {
        private static IAudioPlayerService _audioPlayerService;

        public MKDemoPage()
        {
            BindingContext = new MKDemoViewModel();

            InitializeComponent();

            InitBackgroundAudio();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            App.AdditionalOnResume += _audioPlayerService.Play;
            App.AdditionalOnSleep += _audioPlayerService.Pause;
        }

        protected override void OnDisappearing()
        {
            _audioPlayerService.Dispose();

            App.AdditionalOnResume -= _audioPlayerService.Play;
            App.AdditionalOnSleep -= _audioPlayerService.Pause;

            base.OnDisappearing();
        }

        private static void InitBackgroundAudio()
        {
            _audioPlayerService = DependencyService.Get<IAudioPlayerService>();
            _audioPlayerService.Init(GetStreamFromFile(Constants.EmbeddedAudios.MKBackground));
            _audioPlayerService.Volume = 0.75f;
            _audioPlayerService.IsLooped = true;

            _audioPlayerService.Play();
        }

        private static Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            var stream = assembly.GetManifestResourceStream(filename);

            return stream;
        }
    }
}