public void HarcInditasa()
    {
        Console.WriteLine("Harc kezdődik!");

        while (Jatekos.Elet > 0 && Szornyek.Count > 0)
        {
            // Játékos támad
            Karakter celpont = Szornyek[0];
            if (Jatekos.Tamad(celpont))
            {
                Console.WriteLine($"{celpont.Nev} legyőzve!");
                Szornyek.RemoveAt(0);
            }

            // Szörnyek támadnak
            if (Szornyek.Count > 0)
            {
                foreach (var szorny in Szornyek)
                {
                    if (szorny.Tamad(Jatekos))
                    {
                        Console.WriteLine($"{Jatekos.Nev} legyőzve! A szörnyek győztek.");
                        return;
                    }
                }
            }
        }

        if (Jatekos.Elet > 0)
        {
            Console.WriteLine("A játékos győzött minden szörny felett!");
        }
        else
        {
            Console.WriteLine("A játékos vereséget szenvedett.");
        }
    }
