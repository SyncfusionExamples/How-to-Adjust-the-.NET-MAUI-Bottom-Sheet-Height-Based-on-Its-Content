using Syncfusion.Maui.Toolkit.BottomSheet;

namespace BottomSheetSample
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemTapped(object? sender, ItemTappedEventArgs e)
        {
            bottomSheet.BottomSheetContent.BindingContext = e.Item;
            double contentHeight;
            double ratio = CalculateExpandRatio(bottomSheet.BottomSheetContent, this.Height, out contentHeight);

            if (bottomSheet.State == BottomSheetState.Collapsed)
            {
                bottomSheet.CollapsedHeight = contentHeight;
            }
            else
            {
                bottomSheet.HalfExpandedRatio = bottomSheet.FullExpandedRatio = ratio;
            }

            bottomSheet.Show();
        }

        public double CalculateExpandRatio(View content, double screenHeight, out double contentHeight)
        {
            contentHeight = 0;

            if (content is ScrollView scrollView && scrollView.Content != null)
            {
                contentHeight = scrollView.Content.Measure(this.Width, double.PositiveInfinity).Height +
                                bottomSheet.ContentPadding.Top + bottomSheet.ContentPadding.Bottom;
            }
            else
            {
                contentHeight = content.Measure(this.Width, double.PositiveInfinity).Height +
                                bottomSheet.ContentPadding.Top + bottomSheet.ContentPadding.Bottom;
            }

            if (bottomSheet.ShowGrabber)
            {
                contentHeight += bottomSheet.GrabberAreaHeight;
            }

            double ratio = contentHeight / screenHeight;
            return Math.Clamp(ratio, 0.1, 1);
        }
    }
}