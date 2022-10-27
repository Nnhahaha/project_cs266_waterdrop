namespace WaterDrops
{
    public sealed class UserData
    {
        public Person Person;
        public Water Water;
        public Day Drink;


        public UserData()
        {
            Person = new Person();
            Water = new Water();
            Drink = new Day();
        }

        /// <summary>
        /// Loads the user data from the application's LocalSettings
        /// </summary>
        public void Load()
        {
            Person.Load();
            Water.Load();
            Drink.Load();
        }

        /// <summary>
        /// Saves the user data to the application's LocalSettings
        /// </summary>
        public void Save()
        {
            Person.Save();
            Water.Save();
            Drink.Save();
        }
    }
}
