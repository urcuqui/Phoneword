using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Phoneword
{
    public class MainPage : ContentPage
    {
        Entry phoneNumberText;
        Button btnTranslate;
        Button btnCall;
        string translatedNumber;

        public MainPage()
        {
            StackLayout panel = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation =  StackOrientation.Vertical,
                Spacing = 15,
            };
            panel.Children.Add(new Label
            {
                Text = "Enter a Phoneword:",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });
            panel.Children.Add(phoneNumberText = new Entry
            {
                Text = "1-855-XAMARIN"
            });
            panel.Children.Add(btnTranslate = new Button
            {
                Text = "Translate"
            });
            panel.Children.Add(btnCall = new Button
            {
                Text = "Call",
                IsEnabled = false,
            });
            btnTranslate.Clicked += OnTranslate;

            this.Content = panel;

        }
        private void OnTranslate(object sender, EventArgs e)
        {
            translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
            if (!string.IsNullOrEmpty(translatedNumber))
            {
                btnCall.IsEnabled = true;
                btnCall.Text = "Call " + translatedNumber;
            }
            else
            {
                btnCall.IsEnabled = false;
                btnCall.Text = "Call";
            }
        }
    }
}
