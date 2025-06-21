namespace BottomSheetSample
{
    public partial class MainPage : ContentPage
    {
        bool flagCollapsedState;
        public MainPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemTapped(object? sender, ItemTappedEventArgs e)
        {
            flagCollapsedState = false;
            bottomSheet.BottomSheetContent.BindingContext = e.Item;
            double ratio = CalculateExpandRatio(bottomSheet.BottomSheetContent, this.Height);

            if(bottomSheet.State != Syncfusion.Maui.Toolkit.BottomSheet.BottomSheetState.Collapsed)
            {
                bottomSheet.HalfExpandedRatio = bottomSheet.FullExpandedRatio = ratio;
            }
            
            bottomSheet.Show(); 
        }

        public double CalculateExpandRatio(View bottomSheetContent, double screenHeight)
        {
            double contentHeight = 0;
           
            // Measure the content height      
            if (bottomSheetContent is ScrollView scrollView)
            {
               // For ScrollView, we need to measure its content
               var content = scrollView.Content;
                if (content != null)
                {
                    contentHeight = content.Measure(double.PositiveInfinity, double.PositiveInfinity).Height + bottomSheet.ContentPadding.Top+ bottomSheet.ContentPadding.Bottom;
                }
            }
            else
            {
                contentHeight = bottomSheetContent.Measure(double.PositiveInfinity, double.PositiveInfinity).Height + bottomSheet.ContentPadding.Top+ bottomSheet.ContentPadding.Bottom;
            }

            if(bottomSheet.ShowGrabber)
            {
                contentHeight += bottomSheet.GrabberAreaHeight;
            }

            // Calculate the ratio based on content height relative to screen height
            double calculatedRatio = contentHeight / screenHeight;

            double finalRatio =0;
            finalRatio = Math.Clamp(calculatedRatio, 0.1, 1);

            if (bottomSheet.State == Syncfusion.Maui.Toolkit.BottomSheet.BottomSheetState.Collapsed)
            {
                bottomSheet.CollapsedHeight = contentHeight;
            }

            return finalRatio;

        }
    }

}
