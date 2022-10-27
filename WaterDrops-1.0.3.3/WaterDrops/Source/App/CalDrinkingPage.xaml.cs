using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.Toolkit.Extensions;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.ApplicationModel.Resources;

namespace WaterDrops
{
    public sealed partial class CalDrinkingPage : Page
    {
        public CalDrinkingPage()
        {
            this.InitializeComponent();

            this.Loaded += (sender, e) =>
            {
                WeightTextBox.Text = App.User.Person.Weight.ToString("0.#");
                App.User.Drink.Amount = Convert.ToInt32(App.User.Person.Weight / 2 * 2.2 * 30);
                App.User.Drink.Save();
                WaterTextBlock.Text = App.User.Drink.Amount.ToString("0.#");
            };
        }
    }
}
