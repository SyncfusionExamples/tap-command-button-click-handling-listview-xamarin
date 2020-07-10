# How to handle click action with tap command in Xamarin.Forms ListView (SfListView)

You can add button inside [ListViewItem](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.ListViewItem.html) and handle both ItemTapped and Button click action in Xamarin.Forms [SfListView](https://help.syncfusion.com/xamarin/listview/overview).

**XAML**

Load Button control inside the [SfListView.ItemTemplate](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~ItemTemplate.html) and bind [SfListView.TapCommand](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~TapCommand.html) and [Button.Command](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/button#using-the-command-interface).

``` xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:ListViewXamarin"
             xmlns:sflistview="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms"
             x:Class="ListViewXamarin.MainPage">
    <ContentPage.BindingContext>
        <local:AccordionViewModel/>
    </ContentPage.BindingContext>
    <ContentPage.Content>
        <Grid x:Name="mainGrid" BackgroundColor="#F0F0F0" Padding="4">
            <sflistview:SfListView x:Name="listView" AutoFitMode="DynamicHeight" ItemsSource="{Binding ContactsInfo}" SelectionMode ="None" TapCommand="{Binding ItemTappedCommand}" IsScrollBarVisible="False">
                <sflistview:SfListView.ItemTemplate>
                    <DataTemplate>
                        <Grid Padding="2" Margin="1" x:Name="viewCell" BackgroundColor="#F0F0F0" >
                            <Frame x:Name="frame" CornerRadius="2" Padding="1" Margin="1" OutlineColor="White">
                                    ...
                                                <Label Grid.Row="0" LineBreakMode="NoWrap" TextColor="#474747" Text="{Binding ContactName}" FontSize="16"/>
                                                <Label Grid.Row="1" TextColor="#474747" LineBreakMode="NoWrap" Text="{Binding CallTime}" FontSize="12"/>
                                                <Button Grid.Row="2" Text="Details" x:Name="button" Command="{Binding Source={x:Reference listView}, Path=BindingContext.ButtonCommand}" CommandParameter="{Binding .}"/>
                                            </Grid>
                                            <Grid Grid.Row="0" Grid.Column="2" HorizontalOptions="Center" VerticalOptions="Center">
                                                <Image Source="{Binding PhoneImage}" Opacity="0.60" HeightRequest="20" WidthRequest="20" HorizontalOptions="Center" VerticalOptions="Center" />
                                            </Grid>
                                        </Grid>
                                    </Grid>
                                    <Grid IsVisible="{Binding IsVisible, Mode=TwoWay}" ColumnSpacing="0" RowSpacing="0" Grid.Row="1" BackgroundColor="White"
                            HorizontalOptions="FillAndExpand" Padding="5" VerticalOptions="FillAndExpand">
                                    ...
                                    </Grid>
                                </Grid>
                            </Frame>
                        </Grid>
                    </DataTemplate>
                </sflistview:SfListView.ItemTemplate>
            </sflistview:SfListView>
        </Grid>
    </ContentPage.Content>
</ContentPage>
```

**C#**

Expand the Accordion view in the **TapCommand** method and display the contact details in the **ButtonCommand** method.
``` c#
public class AccordionViewModel
{
    public ObservableCollection<Contact> ContactsInfo { get; set; }
    internal Contact TappedItem { get; set; }
    public Command<object> ButtonCommand { get; set; }
    public Command<object> ItemTappedCommand { get; set; }

    public AccordionViewModel()
    {
        ButtonCommand = new Command<object>(OnButtonTapped);
        ItemTappedCommand = new Command<object>(OnItemTapped);
    }

    private void OnItemTapped(object obj)
    {
        var ItemData = (obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData as Contact;
        if (this.TappedItem == null)
        {
            //Expands when tap on the item at first.
            ItemData.IsVisible = true;
            this.TappedItem = ItemData;
        }
        else
        {
            if (ItemData != this.TappedItem)
            {
                //Expands when tap on the another item.
                this.TappedItem.IsVisible = false;
                ItemData.IsVisible = true;
                this.TappedItem = ItemData;
            }
            else
            {
                this.TappedItem.IsVisible = false;
                this.TappedItem = null;
            }
        }
    }

    private void OnButtonTapped(object obj)
    {
        var item = obj as Contact;
        App.Current.MainPage.DisplayAlert(""+item.ContactName, "" + item.CallTime, "Ok");
    }
}
```

**Output**

![AccordionListView](https://github.com/SyncfusionExamples/tap-command-button-click-handling-listview-xamarin/blob/master/ScreenShot/AccordionListView.gif)


