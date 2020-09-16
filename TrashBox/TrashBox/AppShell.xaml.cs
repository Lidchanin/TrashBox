using TrashBox.Views.ControlsPages.DonutChartPages;
using TrashBox.Views.ControlsPages.GradientProgressBarPages;
using TrashBox.Views.ControlsPages.GradientRadialProgressBarPages;
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
            Routing.RegisterRoute(nameof(DonutChartTabbedPage), typeof(DonutChartTabbedPage));
            Routing.RegisterRoute(nameof(DonutChartExperimentPage), typeof(DonutChartExperimentPage));

            Routing.RegisterRoute(nameof(GradientRadialProgressBarTabbedPage), typeof(GradientRadialProgressBarTabbedPage));
            Routing.RegisterRoute(nameof(GradientRadialProgressBarExperimentPage), typeof(GradientRadialProgressBarExperimentPage));

            Routing.RegisterRoute(nameof(GradientProgressBarTabbedPage), typeof(GradientProgressBarTabbedPage));
            Routing.RegisterRoute(nameof(GradientProgressBarVariant1Page), typeof(GradientProgressBarVariant1Page));
            Routing.RegisterRoute(nameof(GradientProgressBarVariant2Page), typeof(GradientProgressBarVariant2Page));
            Routing.RegisterRoute(nameof(GradientProgressBarExperiment1Page), typeof(GradientProgressBarExperiment1Page));
            Routing.RegisterRoute(nameof(GradientProgressBarExperiment2Page), typeof(GradientProgressBarExperiment2Page));
        }

        public override void UnRegisterRoutes()
        {
            Routing.UnRegisterRoute(nameof(DonutChartTabbedPage));
            Routing.UnRegisterRoute(nameof(DonutChartExperimentPage));

            Routing.UnRegisterRoute(nameof(GradientRadialProgressBarTabbedPage));
            Routing.UnRegisterRoute(nameof(GradientRadialProgressBarExperimentPage));

            Routing.UnRegisterRoute(nameof(GradientProgressBarTabbedPage));
            Routing.UnRegisterRoute(nameof(GradientProgressBarVariant1Page));
            Routing.UnRegisterRoute(nameof(GradientProgressBarVariant2Page));
            Routing.UnRegisterRoute(nameof(GradientProgressBarExperiment1Page));
            Routing.UnRegisterRoute(nameof(GradientProgressBarExperiment2Page));
        }
    }
}