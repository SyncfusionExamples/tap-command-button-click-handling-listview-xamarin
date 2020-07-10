using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class AccordionViewModel
    {
        #region Fields

        int counter = 11;     

        #endregion

        #region Properties

        public ObservableCollection<Contact> ContactsInfo { get; set; }
        internal Contact TappedItem { get; set; }
        public Command<object> ButtonCommand { get; set; }
        public Command<object> ItemTappedCommand { get; set; }

        #endregion

        #region Constructor

        public AccordionViewModel()
        {
            ButtonCommand = new Command<object>(OnButtonTapped);
            ItemTappedCommand = new Command<object>(OnItemTapped);
            ContactsInfo = new ObservableCollection<Contact>();
            Assembly assembly = typeof(ListViewXamarin.MainPage).GetTypeInfo().Assembly;
            int i = 0;
            foreach (var cusName in CustomerNames)
            {
                if (counter == 13)
                    counter = 1;
                var contact = new Contact(cusName);
                contact.CallTime = CallTime[i];
                contact.PhoneImage = ImageSource.FromResource("ListViewXamarin.Images.PhoneImage.png", assembly);
                contact.ContactImage = ImageSource.FromResource("ListViewXamarin.Images.Image" + counter + ".png", assembly);
                contact.AddContact = ImageSource.FromResource("ListViewXamarin.Images.AddContact.png", assembly);
                contact.NewContact = ImageSource.FromResource("ListViewXamarin.Images.NewContact.png", assembly);
                contact.SendMessage = ImageSource.FromResource("ListViewXamarin.Images.SendMessage.png", assembly);
                contact.BlockSpan = ImageSource.FromResource("ListViewXamarin.Images.BlockSpan.png", assembly);
                contact.CallDetails = ImageSource.FromResource("ListViewXamarin.Images.CallDetails.png", assembly);
                i++;
                ContactsInfo.Add(contact);
                counter++;
            }
        }

        #endregion

        #region Methods

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
        #endregion

        #region Fields

        string[] CustomerNames = new string[] {
            "Kyle",
            "Gina",
            "Irene",
            "Katie",
            "Oscar",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Daniel",
            "Frank",
            "Brenda",
            "Danielle",
            "Fiona",
            "Howard",
            "Jack",
            "Larry",
            "Holly",
            "Liz",
            "Pete",
            "Steve",
            "Vince",
            "Katherin",
            "Aliza",
            "Masona" ,
            "Lia" ,
            "Jacob  " ,
            "Jayden " ,
            "Ethani  " ,
            "Noah   " ,
            "Lucas  " ,
            "Logan  " ,
            "John  " ,
        };

        string[] CallTime = new string[]
        {
            "India, 1 days ago",
            "India, 1 days ago",
            "India, 1 days ago",
            "India, 1 days ago",
            "India, 1 days ago",
            "India, 2 days ago",
            "India, 2 days ago",
            "India, 2 days ago",
            "India, 2 days ago",
            "India, 2 days ago",
            "India, 3 days ago",
            "India, 3 days ago",
            "India, 3 days ago",
            "India, 3 days ago",
            "India, 3 days ago",
            "India, 4 days ago",
            "India, 4 days ago",
            "India, 4 days ago",
            "India, 4 days ago",
            "India, 4 days ago",
            "India, 5 days ago",
            "India, 5 days ago",
            "India, 5 days ago",
            "India, 5 days ago",
            "India, 5 days ago",
            "India, 6 days ago",
            "India, 6 days ago",
            "India, 6 days ago",
            "India, 6 days ago",
            "India, 6 days ago",
            "India, 1 week ago",
            "India, 1 week ago",
            "India, 1 week ago"
        };

        #endregion
    }
}
