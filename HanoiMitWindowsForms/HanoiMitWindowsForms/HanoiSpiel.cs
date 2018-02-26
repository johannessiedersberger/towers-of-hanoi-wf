using System;

namespace Hanoi_mit_Stacks
{
  public class HanoiSpiel
  {
    private MyStack _startStapel = new MyStack();
    private MyStack _hilfsStapel = new MyStack();
    private MyStack _ablageStapel = new MyStack();

    /// <summary>
    /// Initialisiert ein neues Spielfeld
    /// </summary>
    /// <param name="anzahlScheiben"></param>
    public HanoiSpiel(int anzahlScheiben)
    {
      if (anzahlScheiben < 2 || anzahlScheiben > 10)
      {
        throw new ArgumentOutOfRangeException("Die Anzahl der Scheiben muss zwischen 2 und 10 liegen");
      }
      InitialisiereSpielfeld(anzahlScheiben);
    }

    private void InitialisiereSpielfeld(int anzahlScheiben)
    {
      for (int i = anzahlScheiben; i > 0; i--)
      {
        _startStapel.Push(i);
      }
    }

    /// <summary>
    /// Überprüft Zug, Verschiebt scheibe und Zeichnet neu
    /// </summary>
    /// <param name="start"></param>
    /// <param name="ablage"></param>
    public void Zug(int start, int ablage)
    {
      MyStack zugStapel = GetStapel(start);
      MyStack ablageStapel = GetStapel(ablage);

      UeberpruefeZug(start, ablage);
      ablageStapel.Push(zugStapel.Pop());
    }

    /// <summary>
    /// Überprüft ob der zug möglich ist
    /// </summary>
    /// <param name="zugStapel"></param>
    /// <param name="ablageStapel"></param>
    /// <returns></returns>
    public void UeberpruefeZug(int zug, int ablage)
    {
      if (zug == ablage)
        throw new InvalidOperationException("Der Zugstapel kann nicht den selben wert wie der ablagestapel haben");

      MyStack zugStapel = GetStapel(zug);
      MyStack ablageStapel = GetStapel(ablage);
      if (zugStapel.IsEmpty)
        throw new InvalidOperationException("Auf dem zugstapel liegt keine scheibe");

      if (!ablageStapel.IsEmpty
        && (zugStapel.Peek() > ablageStapel.Peek()))
        throw new InvalidOperationException("Die scheibe auf dem Zugstapel ist größer als vom Ablagestapel");
    }

    /// <summary>
    /// Checkt ob das Spiel gewonnen wurde.
    /// </summary>
    /// <returns>True wenn gewonnen, false wenn nicht.</returns>
    public bool ÜberprüfeObGewonnen()
    {
      return GibStapelKopiertZurück(3)[0] == 1;
    }

    /// <summary>
    /// Gibt einen Stapel des Spiels Kopiert zurück
    /// </summary>
    /// <param name="eingabe"></param>
    /// <returns></returns>
    public int[] GibStapelKopiertZurück(int eingabe)
    {
      int[] kopie = GetStapel(eingabe).ToArray();

      Array.Resize(ref kopie, kopie.Length + (AnzahlScheiben - kopie.Length));
      Array.Sort(kopie);
      return kopie;
    }

    public int AnzahlScheiben
    {
      get
      {
        return _startStapel.Count() + _hilfsStapel.Count() + _ablageStapel.Count();
      }
    }

    private MyStack GetStapel(int eingabe)
    {
      switch (eingabe)
      {
        default:
          throw new ArgumentOutOfRangeException("Ungültiger Stapel! Muss 1, 2 oder 3 sein!");
        case 1:
          return _startStapel;
        case 2:
          return _hilfsStapel;
        case 3:
          return _ablageStapel;
      }
    }
  }
}
