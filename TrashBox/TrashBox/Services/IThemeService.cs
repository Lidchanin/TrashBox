namespace TrashBox.Services
{
    public interface IThemeService
    {
        void Init();

        void SetTheme(Enums.Themes theme);
    }
}