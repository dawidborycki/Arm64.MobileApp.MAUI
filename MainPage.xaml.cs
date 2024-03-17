using Arm64.MobileApp.MAUI.Helpers;
using System.Collections.ObjectModel;

namespace Arm64.MobileApp.MAUI
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<string> items { get; set; } = [];

        public MainPage()
        {
            InitializeComponent();

            // Update ProcessorArchitecture Label
            LabelProcessorArchitecture.Text =
                $"{Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE")}";

            ListViewResults.ItemsSource = items;
        }

        private void ButtonRunCalculations_Clicked(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(EntryVectorSize.Text);
            int executionCount = Convert.ToInt32(EntryExecutionCount.Text);

            var executionTime = PerformanceHelper.MeasurePerformance(
                () => VectorHelper.AdditionOfProduct(size),
                executionCount);

            items.Add($"Size: {size}, Count: {executionCount}, " + $"Time: {executionTime} ms");
        }

        private void ButtonClearResults_Clicked(object sender, EventArgs e)
        {
            items.Clear();
        }
    }
}
