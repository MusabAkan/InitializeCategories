using InitializeCategories.Model;

class Program
{
    static List<Category> categories = new();
    static List<User> users = new();

    static void Main()
    {
        InitializeCategories();

        while (true)
        {
            Console.WriteLine("1. Giriş Yap");
            Console.WriteLine("2. Kayıt Ol");
            Console.WriteLine("3. Çıkış");
            Console.Write("Seçiminizi yapın: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Login();
            }
            else if (choice == "2")
            {
                Register();
            }
            else if (choice == "3")
            {
                ShowResults();
                break;
            }
            else
            {
                Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
            }
        }
    }

    static void InitializeCategories()
    {
        categories.Add(new Category("Film Kategorileri"));
        categories.Add(new Category("Tech Stack Kategorileri"));
        categories.Add(new Category("Spor Kategorileri"));
    }

    static void Register()
    {
        Console.Write("Kullanıcı Adı: ");
        string username = Console.ReadLine();

        User userAdd = new(username);
        foreach (var user in users)
        {
            if (user.Username == userAdd.Username)
            {
                Console.WriteLine("Kullanıcı daha önce eklenmiştir.");
                return;
            }
        }
        users.Add(userAdd);
        Console.WriteLine("Kullanıcı eklenmiştir.");
    }

    static void Login()
    {
        Console.Write("Kullanıcı Adı: ");
        string username = Console.ReadLine();

        User user = users.Find(u => u.Username == username);

        if (user == null)
        {
            Console.WriteLine("Kullanıcı bulunamadı. Kayıt olun.");
            Register();
        }
        else
        {
            Vote(user);
        }
    }

    static void Vote(User user)
    {
        Console.WriteLine("Kategoriler:");
        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {categories[i].Name}");
        }

        Console.Write("Oy vermek istediğiniz kategoriyi seçin (1-3): ");
        int categoryIndex;
        if (int.TryParse(Console.ReadLine(), out categoryIndex) && categoryIndex >= 1 && categoryIndex <= 3)
        {
            categories[categoryIndex - 1].Vote();
            Console.WriteLine("Oyunuz alındı, teşekkür ederiz!");
        }
        else
        {
            Console.WriteLine("Geçersiz kategori seçimi.");
        }
    }

    static void ShowResults()
    {
        Console.WriteLine("Oylama Sonuçları:");
        foreach (Category category in categories)
            Console.WriteLine($"{category.Name}: {category.Votes} oy, %{category.GetPercentage(users):F2}");
    }
}



