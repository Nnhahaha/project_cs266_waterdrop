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
using System.Collections.Generic;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

namespace WaterDrops
{
    public sealed partial class GraphPage : Page
    {

        public class WaterTemp
        {
            public int Amount { get; set; }
            public String Name { get; set; }
        }

        public GraphPage()
        {
            this.InitializeComponent();

            List<WaterTemp> waters = new List<WaterTemp>();
            List<WaterTemp> days = new List<WaterTemp>();

            this.Loaded += (sender, e) =>
            {
                WaterTemp w = new WaterTemp();
                w.Amount = App.User.Water.Amount;
                w.Name = App.User.Water.Timestamp.ToString();
                waters.Add(w);

                WaterTemp day = new WaterTemp();
                day.Amount = App.User.Drink.Amount;
                day.Name = DateTime.Now.ToString();
                days.Add((day));

                (lineChart.Series[0] as BarSeries).ItemsSource = waters;
                (lineChart.Series[1] as BarSeries).ItemsSource = days;
            };
        }
    }
}
