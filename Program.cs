namespace SearchForTheCriminalTask;
class Program
{
    static void Main(string[] args)
    {
        List<Criminal> criminals = new List<Criminal>
        {
            new Criminal("Данилова А.Я.", Nationalities.Belarusian, 160, 55, false),
            new Criminal("Волкова Е.Д.", Nationalities.Russian, 173, 60, false),
            new Criminal("Савельева Е.С.", Nationalities.Ukrainian, 150, 48, false),
            new Criminal("Никитина К.А.", Nationalities.Belarusian, 184, 68, true),
            new Criminal("Попова С.М.", Nationalities.Russian, 159, 48, false),
            new Criminal("Васильева А.О.", Nationalities.Russian, 173, 69, true),
            new Criminal("Тихонова В.Т.", Nationalities.Ukrainian, 184, 70, false),
            new Criminal("Ефимова С.Ю.", Nationalities.Belarusian, 158, 60, true)
        };
        
        SearchSystem searchSystem = new SearchSystem(criminals);
        
        searchSystem.Work();
    }
}

public class Nationalities
{
    public const string Belarusian = "беларус";
    public const string Russian = "русский";
    public const string Ukrainian = "украинец";
}

class Criminal
{
    public Criminal(string name, string nationality, int height, int weight, bool isImprisoned)
    {
        Name = name;
        Nationality = nationality;
        Height = height;
        Weight = weight;
        IsImprisoned = isImprisoned;
    }
    
    public string Name { get; private set; }
    public string Nationality { get; private set; }
    public int Height { get; private set; }
    public int Weight { get; private set; }
    public bool IsImprisoned { get; private set; }
}

class SearchSystem
{
    private List<Criminal> _criminals;
    

    public SearchSystem(List<Criminal> criminals)
    {
        _criminals = criminals;
    }

    public void Work()
    {
        bool isWorking = true;

        while (isWorking)
        {
            int height;
            int weight;
            string nationality;

            Console.Clear();
            Console.WriteLine("Программа поиска преступников.\nЗдравствуйте, детектив.\n");
            
            Console.Write("Введите рост: ");
            height = HandleNumberInput();
            
            Console.Write("Введите вес: ");
            weight = HandleNumberInput();
            
            Console.Write("Введите национальность в мужском роде: ");
            nationality = Console.ReadLine();

            var foundCriminals = _criminals.Where(criminal => (criminal.Height == height)
                && (criminal.Weight == weight)
                && (criminal.Nationality == nationality)
                && (criminal.IsImprisoned == false)).ToList();
            
            Console.WriteLine();
            ShowResult(foundCriminals);
            
            Console.WriteLine("\nНажмите любую кнопку для продолжения...");
            Console.ReadKey();
        }
    }

    private void ShowResult(List<Criminal> foundCriminals)
    {
        if (foundCriminals.Count == 0)
            Console.WriteLine("Ничего не найдено.");
        
        foreach (Criminal criminal in foundCriminals)
        {
            Console.WriteLine($"{criminal.Name} Рост: {criminal.Height}. Вес {criminal.Weight}. " +
                              $"Национальность: {criminal.Nationality}.");
        }
    }

    private int HandleNumberInput()
    {
        int number;

        while (int.TryParse(Console.ReadLine(), out number) == false)
            Console.Write("Ошибка! Ввод должен содержать только цифры: ");

        return number;
    }
}