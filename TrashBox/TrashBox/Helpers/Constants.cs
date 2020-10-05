namespace TrashBox.Helpers
{
    public static class Constants
    {
        public static class Texts
        {
            public const string TrashBox = "TrashBox";
            public const string Variant1 = "Variant 1";
            public const string Variant2 = "Variant 2";
            public const string Variant3 = "Variant 3";
            public const string Experiment = "Experiment";
            public const string Experiment1Short = "Exp 1";
            public const string Experiment2Short = "Exp 2";
            public const string Controls = "Controls";
            public const string Designs = "Designs";
            public const string About = "About";
            public const string DonutChartPages = "Donut Chart Pages";
            public const string DonutCharts = "Donut Charts";
            public const string ProgressBarPages = "Progress Bar Pages";
            public const string ProgressBars = "Progress Bars";
            public const string RadialProgressBarPages = "Radial Progress Bar Pages";
            public const string RadialProgressBars = "Radial Progress Bars";
            public const string HorizontalParallaxCarousel = "Horizontal Parallax Carousel";
            public const string Back = "Back";
            public const string Select = "Select";
            public const string Add = "Add";
            public const string Remove = "Remove";
            public const string DoYouWantToGoOut = "Do you want to go out?";

            #region MKDemo

            public const string MKDemo = "MK Demo";
            public const string Ermak = "Ermak";
            public const string ErmakInfo = "When a teammate is defeated, gain 40% of their attack and toughness. Max once per match.";
            public const string ErronBlack = "Erron Black";
            public const string ErronBlackInfo = "+30% attack vs Spec Ops. Archieving 80%+ on Stand Off (special attack 2) makes it unblockable and a critical hit.";
            public const string JohnnyCage = "Johnny Cage";
            public const string JohnnyCageInfo = "Stunt double attacks on tag-in, stunning the opponent.";
            public const string Kano = "Kano";
            public const string KanoInfo = "+30% attack if the opponent has 40% or lower health.";
            public const string Kenshi = "Kenshi";
            public const string KenshiInfo = "All Spec Ops teammates start with +1 bar of power.";
            public const string Kitana = "Kitana";
            public const string KitanaInfo = "Ambushes opponent on tag-in with vicious stabs cousing bleed for 15 seconds. Assassin Characters generate 30% more power.";
            public const string KungLao = "Kung Lao";
            public const string KungLaoInfo = "All Bronze teammates receive +300% attack, health, toughness, and recovery.";
            public const string LiuKang = "Liu Kang";
            public const string LiuKangInfo = "On tag-in, Liu Kang receives a speed increase. +100% basic attack damage, and +25% critical hit chance for 5 seconds.";
            public const string QuanChi = "Quan Chi";
            public const string QuanChiInfo = "Re-animates a dead teammate with 25% health. Usable once per fight.";
            public const string Raiden = "Raiden";
            public const string RaidenInfo = "When Raiden tags-in, lightning strikes the opponent removing 20% of their current health.";
            public const string Scorpion = "Scorpion";
            public const string ScorpionInfo = "Each time Inferno Scorpion tags-in, he gets +200% basic attack damage for 6 seconds.";
            public const string SubZero = "Sub-Zero";
            public const string SubZeroInfo = "+30% health for Martial Artist teammates.";
            public const string ChooseYourFighter = "Choose Your Fighter";

            #endregion MKDemo
        }

        public static class Filenames
        {
            public const string AppIcon = "ic_launcher.png";
            public const string DonutChart = "donut_chart_icon.png";
            public const string AboutUs = "about_us_icon.png";
            public const string BrokenFile = "broken_file_icon.png";
            public const string Car = "car_icon.png";
            public const string Meal = "meal_icon.png";
            public const string Shirt = "shirt_icon.png";
            public const string Cocktail = "cocktail_icon.png";
            public const string Plane = "plane_icon.png";
            public const string NoBorder = "no_border_icon.png";
            public const string ProgressBar = "progress_bar_icon.png";
            public const string VerticalProgressBar = "vertical_progress_bar_icon.png";
            public const string RadialProgressBar = "radial_progress_bar_icon.png";
        }

        public static class EmbeddedImages
        {
            private const string BasePath = "TrashBox.EmbeddedFiles.Images.";

            public const string BackboardBackground = BasePath + "backboard_background.jpg";

            #region MKDemo

            public const string MKErmak = BasePath + "mk_ermak.png";
            public const string MKErronBlack = BasePath + "mk_erron_black.png";
            public const string MKJohnnyCage = BasePath + "mk_johnny_cage.png";
            public const string MKKano = BasePath + "mk_kano.png";
            public const string MKKenshi = BasePath + "mk_kenshi.png";
            public const string MKKitana = BasePath + "mk_kitana.png";
            public const string MKKungLao = BasePath + "mk_kung_lao.png";
            public const string MKLiuKang = BasePath + "mk_liu_kang.png";
            public const string MKQuanChi = BasePath + "mk_quan_chi.png";
            public const string MKRaiden = BasePath + "mk_raiden.png";
            public const string MKScorpion = BasePath + "mk_scorpion.png";
            public const string MKSubZero = BasePath + "mk_sub_zero.png";
            public const string MKLogo = BasePath + "mk_logo.png";

            #endregion MKDemo
        }

        public static class EmbeddedFonts
        {
            private const string BasePath = "TrashBox.EmbeddedFiles.Fonts.";

            public const string MKTitle = BasePath + "mk_title.ttf";
            public const string MK4 = BasePath + "mk_4.ttf";
            public const string FontAwesomeSolid = BasePath + "font_awesome_5_free_solid_900.otf";
        }

        public static class FontAwesomeIcons
        {
            public const string Skull = "\uf54c";
            public const string Question = "\uf128";
        }

        public static class Links
        {
            public const string IconsGenerator = "https://www.iconsgenerator.com/Home/AppIcons";
            public const string PngOptimizer = "https://tinypng.com/";
            public const string SvgPathBuilder = "https://mavo.io/demos/svgpath/";
        }
    }
}