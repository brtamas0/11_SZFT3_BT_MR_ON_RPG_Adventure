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
            { "Életerő ital", 50 },
            { "Mana ital", 30 }
        };
        fegyverek = new Dictionary<string, int>
        {
            { "Kard", 100 },
            { "Fejsze", 120 }
        };
        fegyverFejlesztesek = new Dictionary<string, int>
        {
            { "Kard fejlesztés", 70 },
            { "Fejsze fejlesztés", 80 }
        };
        ruhak = new Dictionary<string, int>
        {
            { "Bőrpáncél", 150 },
            { "Vaspáncél", 200 }
        };
        ruhaFejlesztesek = new Dictionary<string, int>
        {
            { "Bőrpáncél fejlesztés", 100 },
            { "Vaspáncél fejlesztés", 120 }
        };
        jatekosArany = kezdetiArany;
    }
     }
