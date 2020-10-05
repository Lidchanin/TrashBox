using System;
using System.Threading.Tasks;
using TrashBox.Models;
using Xamarin.Forms;

namespace TrashBox.Views.DesignsViews.MKDemo
{
    public partial class MKDemoCell
    {
        #region Bindable Property

        #region Character Property

        public static readonly BindableProperty CharacterProperty = BindableProperty.Create(
            nameof(Character),
            typeof(MKCharacter),
            typeof(MKDemoCell));

        public MKCharacter Character
        {
            get => (MKCharacter) GetValue(CharacterProperty);
            set => SetValue(CharacterProperty, value);
        }

        #endregion Character Property

        #endregion Bindable Property

        private bool _isDetailsVisible;
        private bool _isBusy;

        public MKDemoCell()
        {
            InitializeComponent();
        }

        private async void OnTapped(object sender, EventArgs e)
        {
            if (_isBusy)
            {
                return;
            }

            _isBusy = true;

            await FlipViewAsync();

            _isBusy = false;
        }

        private async Task FlipViewAsync()
        {
            VisualElement visibleElement, hiddenElement;

            if (!_isDetailsVisible)
            {
                visibleElement = FrontOfCard;
                hiddenElement = BackOfCard;
            }
            else
            {
                visibleElement = BackOfCard;
                hiddenElement = FrontOfCard;
            }

            visibleElement.RotationY = 0;
            hiddenElement.RotationY = -90;

            const uint animationLength = 1000;

            var animation = new Animation
            {
                {0, 0.5, new Animation(rotation => visibleElement.RotationY = rotation, 0, -90, Easing.Linear)},
                {0.5, 1, new Animation(rotation => hiddenElement.RotationY = rotation, -270, -360, Easing.Linear)}
            };

            animation.Commit(this, new Random().Next(0, int.MaxValue).ToString(), 10, animationLength,
                repeat: () => false);

            await Task.Delay((int) animationLength);

            visibleElement.RotationY %= 360;
            hiddenElement.RotationY %= 360;

            _isDetailsVisible = !_isDetailsVisible;
        }
    }
}