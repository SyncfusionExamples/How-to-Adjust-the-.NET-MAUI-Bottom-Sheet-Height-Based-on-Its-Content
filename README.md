# How-to-Adjust-the-.NET-MAUI-Bottom-Sheet-Height-Based-on-Its-Content
This repository provides a sample that demonstrates how to adjust the height of the Syncfusion® .NET MAUI Bottom Sheet dynamically based on its content.

**Adjust the Height of the .NET MAUI Bottom Sheet Based on Its Content**

The height is computed at runtime by measuring the actual size of the content presented inside the bottom sheet. Based on the bottom sheet’s current state—FullExpanded, Halfexpanded, or Collapsed—the corresponding value is applied either as a ratio relative to the screen height or as an exact height measurement.

Below are code examples that illustrate how to set these properties dynamically.

**XAML: FullExpanded State**
```
<bottomSheet:SfBottomSheet x:Name="bottomSheet" State="FullExpanded" ContentPadding="10">
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

 ![fullexpanded-bottomsheet-content.gif](https://support.syncfusion.com/kb/agent/attachment/article/20445/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjQyMTc0Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.oouzkx0Hn1hgIsom2upDVuSkIQODEnefEQNAeHg85OQ)

**XAML: HalfExpanded State**
```
<bottomSheet:SfBottomSheet x:Name="bottomSheet" State="HalfExpanded" ContentPadding="10">
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
 
 ![halfexpanded-bottomsheet-content.gif](https://support.syncfusion.com/kb/agent/attachment/article/20445/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjQyMTc1Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.ZF58PxjBOT820mpUF0ywj0ijVeY1HaqZCu6k-qfkCjM)
 
**XAML: Collapsed State**
```
<bottomSheet:SfBottomSheet x:Name="bottomSheet" State="Collapsed" ContentPadding="10">
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

 ![collapsed-bottomsheet-content-he.gif](https://support.syncfusion.com/kb/agent/attachment/article/20445/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjQyMTc2Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.4erQht30C6c3cRyFcoP-d4GR3oh0cNgd7vTvycYenO4)
