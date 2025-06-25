# How-to-Adjust-the-.NET-MAUI-Bottom-Sheet-Height-Based-on-Its-Content
This repository provides a sample that demonstrates how to adjust the height of the Syncfusion® .NET MAUI Bottom Sheet dynamically based on its content.

**Adjust the Height of the .NET MAUI Bottom Sheet Based on Its Content**

The height is computed at runtime by measuring the actual size of the content presented inside the bottom sheet. Based on the bottom sheet’s current state—FullExpanded, Halfexpanded, or Collapsed—the corresponding value is applied either as a ratio relative to the screen height or as an exact height measurement.

Below are code examples that illustrate how to set these properties dynamically.

**XAML: FullExpanded State**
```
<bottomSheet:SfBottomSheet x:Name="bottomSheet" State="FullExpanded">
    <bottomSheet:SfBottomSheet.BottomSheetContent>
        <ScrollView x:Name="bottomSheetContent">
            <VerticalStackLayout>
               <!--Your content--> 
            </VerticalStackLayout>
        </ScrollView>
    </bottomSheet:SfBottomSheet.BottomSheetContent>
</bottomSheet:SfBottomSheet>
```

**Output:**

![fullexpanded-bottomsheet-content (1)](https://github.com/user-attachments/assets/5c013765-2e00-4f1a-b352-25a586948dea)


**XAML: HalfExpanded State**
```
<bottomSheet:SfBottomSheet x:Name="bottomSheet" State="HalfExpanded">
    <bottomSheet:SfBottomSheet.BottomSheetContent>
        <ScrollView x:Name="bottomSheetContent">
            <VerticalStackLayout>
               <!--Your content--> 
            </VerticalStackLayout>
        </ScrollView>
    </bottomSheet:SfBottomSheet.BottomSheetContent>
</bottomSheet:SfBottomSheet>
```

**Output:**
 
![halfexpanded-bottomsheet-content (1)](https://github.com/user-attachments/assets/c8d636c2-9c17-4144-8d8e-9adf0a702e74)

 
**XAML: Collapsed State**
```
<bottomSheet:SfBottomSheet x:Name="bottomSheet" State="Collapsed">
    <bottomSheet:SfBottomSheet.BottomSheetContent>
        <ScrollView x:Name="bottomSheetContent">
            <VerticalStackLayout>
               <!--Your content--> 
            </VerticalStackLayout>
        </ScrollView>
    </bottomSheet:SfBottomSheet.BottomSheetContent>
</bottomSheet:SfBottomSheet>
```

**Output:**

![collapsed-bottomsheet-content-he (1)](https://github.com/user-attachments/assets/22dbfd6a-d8e1-4e92-9770-c486d11a6c30)


 **C#:**

To calculate and apply the BottomSheet height during runtime:

```
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
```

The **CalculateExpandRatio** method handles content measurement based on whether the layout is inside a ScrollView or not:

```
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
```
