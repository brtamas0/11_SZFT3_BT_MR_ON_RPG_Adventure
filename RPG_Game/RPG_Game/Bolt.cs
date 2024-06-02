public class Bolt
{
    private Dictionary<string, int> egyszerHasznalatosTargyak;
    private Dictionary<string, int> fegyverek;
    private Dictionary<string, int> fegyverFejlesztesek;
    private Dictionary<string, int> ruhak;
    private Dictionary<string, int> ruhaFejlesztesek;
    private int jatekosArany;

    public Bolt(int kezdetiArany)
    {
        egyszerHasznalatosTargyak = new Dictionary<string, int>
        {
            { "Energia ital", 50 },
            { "Gyógyítás ital", 30 }
            { "Ellenállás ital", 30 }

        };
        fegyverek = new Dictionary<string, int>
        {
            { "Kard", 100 },
            { "Tőr", 120 }
            { "Kés", 150 },
            { "Bárd", 200 }
        };
        fegyverFejlesztesek = new Dictionary<string, int>
        {
            { "Kard fejlesztés", 70 },
            { "Tőr fejlesztés", 80 }
            { "Kés fejlesztés", 100 },
            { "Bárd fejlesztés", 120 }
        };
        
        jatekosArany = kezdetiArany;
    }
        public void BoltElemekMegjelenitese()
    {
        Console.WriteLine("Üdvözöllek a boltban! Itt vannak a vásárolható elemek:");
        Console.WriteLine("Egyszer használatos tárgyak:");
        foreach (var item in egyszerHasznalatosTargyak)
        {
            Console.WriteLine($"{item.Key}: {item.Value} arany");
        }
        Console.WriteLine("\nFegyverek:");
        foreach (var fegyver in fegyverek)
        {
            Console.WriteLine($"{fegyver.Key}: {fegyver.Value} arany");
        }
        Console.WriteLine("\nFegyver fejlesztések:");
        foreach (var fejlesztes in fegyverFejlesztesek)
        {
            Console.WriteLine($"{fejlesztes.Key}: {fejlesztes.Value} arany");
        }
        
    }
     }
