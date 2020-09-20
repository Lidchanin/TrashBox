using TrashBox.Views.ControlsPages.DonutChartPages;
using TrashBox.Views.ControlsPages.GradientProgressBarPages;
using TrashBox.Views.ControlsPages.GradientRadialProgressBarPages;
using TrashBox.Views.DesignsPages;
using Xamarin.Forms;

namespace TrashBox
{
    public partial class AppShell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        public override void RegisterRoutes()
        {
            #region Controls Routes

            Routing.RegisterRoute(nameof(DonutChartTabbedPage), typeof(DonutChartTabbedPage));
            Routing.RegisterRoute(nameof(DonutChartExperimentPage), typeof(DonutChartExperimentPage));

            Routing.RegisterRoute(nameof(GradientRadialProgressBarTabbedPage), typeof(GradientRadialProgressBarTabbedPage));
            Routing.RegisterRoute(nameof(GradientRadialProgressBarVariant1Page), typeof(GradientRadialProgressBarVariant1Page));
            Routing.RegisterRoute(nameof(GradientRadialProgressBarVariant2Page), typeof(GradientRadialProgressBarVariant2Page));
            Routing.RegisterRoute(nameof(GradientRadialProgressBarVariant3Page), typeof(GradientRadialProgressBarVariant3Page));
            Routing.RegisterRoute(nameof(GradientRadialProgressBarExperimentPage), typeof(GradientRadialProgressBarExperimentPage));

            Routing.RegisterRoute(nameof(GradientProgressBarTabbedPage), typeof(GradientProgressBarTabbedPage));
            Routing.RegisterRoute(nameof(GradientProgressBarVariant1Page), typeof(GradientProgressBarVariant1Page));
            Routing.RegisterRoute(nameof(GradientProgressBarVariant2Page), typeof(GradientProgressBarVariant2Page));
            Routing.RegisterRoute(nameof(GradientProgressBarExperiment1Page), typeof(GradientProgressBarExperiment1Page));
            Routing.RegisterRoute(nameof(GradientProgressBarExperiment2Page), typeof(GradientProgressBarExperiment2Page));

            #endregion Controls Routes

            #region Designs Rotes

            Routing.RegisterRoute(nameof(HorizontalParallaxCarouselPage), typeof(HorizontalParallaxCarouselPage));

            #endregion Designs Rotes
        }

        public override void UnRegisterRoutes()
        {
            #region Controls Routes

            Routing.UnRegisterRoute(nameof(DonutChartTabbedPage));
            Routing.UnRegisterRoute(nameof(DonutChartExperimentPage));

            Routing.UnRegisterRoute(nameof(GradientRadialProgressBarTabbedPage));
            Routing.UnRegisterRoute(nameof(GradientRadialProgressBarVariant1Page));
            Routing.UnRegisterRoute(nameof(GradientRadialProgressBarVariant2Page));
            Routing.UnRegisterRoute(nameof(GradientRadialProgressBarVariant3Page));
            Routing.UnRegisterRoute(nameof(GradientRadialProgressBarExperimentPage));

            Routing.UnRegisterRoute(nameof(GradientProgressBarTabbedPage));
            Routing.UnRegisterRoute(nameof(GradientProgressBarVariant1Page));
            Routing.UnRegisterRoute(nameof(GradientProgressBarVariant2Page));
            Routing.UnRegisterRoute(nameof(GradientProgressBarExperiment1Page));
            Routing.UnRegisterRoute(nameof(GradientProgressBarExperiment2Page));

            #endregion Controls Routes

            #region Designs Routes

            Routing.UnRegisterRoute(nameof(HorizontalParallaxCarouselPage));

            #endregion Designs Routes
        }
    }
}