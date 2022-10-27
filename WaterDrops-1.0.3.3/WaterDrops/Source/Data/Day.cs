using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace WaterDrops
{
    public class Day
    {
        private const int DEFAULT_DRINK_AMOUNT = 0;
        private int amount = DEFAULT_DRINK_AMOUNT;
        public int Amount
        {
            get => amount;
            set
            {
                int delta = value - amount;

                amount = value;
                this.Save();
            }
        }

        public void Save()
        {

            try
            {
                ApplicationDataCompositeValue drink = new ApplicationDataCompositeValue()
                {
                    ["Amount"] = this.amount
                };

                ApplicationData.Current.LocalSettings.Values["Drink"] = drink;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        public void Load()
        {
            try
            {
                ApplicationDataCompositeValue container = (ApplicationDataCompositeValue)
                    ApplicationData.Current.LocalSettings.Values["Drink"];

                // Load values from LocalSettings (if not available default to 0)
                if (container != null)
                {
                    this.amount = (container["Amount"] as int?).Value;
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);

                this.amount = DEFAULT_DRINK_AMOUNT;
            }
        }
    }
}
