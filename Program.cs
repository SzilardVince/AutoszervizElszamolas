using AutoszervizElszamolas;
string[] G = File.ReadAllLines("Szerviz.txt");
Szerviz[] yv;
int fizu;
int c=0;
int j=0;
int s = 0;
int max = 0;
string lk="";
Console.WriteLine("Szerelők napi bérének elszámolása:");
foreach (string z in G)
{
    Szerviz h = new Szerviz();
    string[] d = z.Split(";");
    h.Nev = d[0];
    fizu=0;
    h.JavitottAutok = int.Parse(d[1]);
    h.Munkaora = int.Parse(d[2]);
    h.GarancialisJavitasok = int.Parse(d[3]);
    if (h.JavitottAutok>=6)
    {
        if (h.GarancialisJavitasok <= 1)
        {
            fizu += 15000;
        }
    }
    if (h.GarancialisJavitasok > 2)
    {
        fizu = fizu- 10000;
    }
    fizu = (h.Munkaora * 4000) + (h.JavitottAutok * 5000) + fizu;
    Console.WriteLine($"{h.Nev}: {h.JavitottAutok} autó, {h.Munkaora} óra (Garanciális: {h.GarancialisJavitasok}) - Munkabér: {fizu}");
    c += fizu;
    j += h.Munkaora;
    if (fizu > max)
    {
        max = fizu;
        lk = h.Nev;
    }
    if (h.GarancialisJavitasok == 0)
    {
        s += 1;
    }
}
Console.WriteLine("");
Console.WriteLine("Összesített statisztika:");
Console.WriteLine($"Szerviz által kifizettet teljes munkabér: {c} Ft");
Console.WriteLine($"Átlagos munkaóra szerelőként: {j / (double)G.Length:F0} óra");
Console.WriteLine($"Legmagasabb napi bér: {lk} ({max} Ft)");
Console.WriteLine($"Garanciális hiba nélkül dolgozo szerelők száma: {s} fő");