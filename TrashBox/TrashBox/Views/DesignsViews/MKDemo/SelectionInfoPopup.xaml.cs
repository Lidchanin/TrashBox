using System;

namespace TrashBox.Views.DesignsViews.MKDemo
{
    public partial class SelectionInfoPopup
    {
        public string CharacterName { get; }

        public SelectionInfoPopup(string characterName)
        {
            CharacterName = characterName;

            InitializeComponent();
        }

        private async void OkButton_OnClicked(object sender, EventArgs e)
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                await HideAsync();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}