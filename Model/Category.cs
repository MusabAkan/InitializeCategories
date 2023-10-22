namespace InitializeCategories.Model
{

    public class Category
    {
        public string Name { get; set; }
        public int Votes { get; private set; }

        public Category(string name)
        {
            Name = name;
        }

        public void Vote()
        {
            Votes++;
        }

        public double GetPercentage(List<User> users)
        {
            return (Votes / (double)users.Count) * 100;
        }
    }
}
