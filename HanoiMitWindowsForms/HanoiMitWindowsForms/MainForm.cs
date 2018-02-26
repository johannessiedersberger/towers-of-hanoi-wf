using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hanoi_mit_Stacks;
using System.Diagnostics;

namespace HanoiMitWindowsForms
{
  public partial class MainForm : Form
  {
    private HanoiSpiel _hanoiSpiel;
    public MainForm()
    {
      InitializeComponent();
      KeyPreview = true;
    }

    private void StartButtonClicked(object sender, EventArgs e)
    {
      NeuesSpiel();
    }

    private void StackeOneClicked(object sender, EventArgs e)
    {
      Zug(1);
    }

    private void StackTwoClicked(object sender, EventArgs e)
    {
      Zug(2);
    }

    private void StackThreeClicked(object sender, EventArgs e)
    {
      Zug(3);
    }

    private void startButton_KeyDown(object sender, KeyEventArgs e)
    {
      RufeZugAuf(e);
    }

    private void stackControlStartStapel_KeyDown(object sender, KeyEventArgs e)
    {
      RufeZugAuf(e);
    }

    private void stackControlHilfsStapel_KeyDown(object sender, KeyEventArgs e)
    {
      RufeZugAuf(e);
    }

    private void stackControlAblageStapel_KeyDown(object sender, KeyEventArgs e)
    {
      RufeZugAuf(e);
    }

    private void RufeZugAuf(KeyEventArgs e)
    {
      switch (e.KeyData)
      {
        case Keys.D1:
          Zug(1);
          break;
        case Keys.D2:
          Zug(2);
          break;
        case Keys.D3:
          Zug(3);
          break;
      }
    }

    private void Zug(int geklickterStapel)
    {
      Debug.Assert(_hanoiSpiel != null, "Spiel muss gestartet sein, bevor ein Zug durchgeführt werden kann");
      //Nutzereingabe
      int ablageStapel = 0;
      if (IstStartStapelGesucht())
      {
        StackControl(geklickterStapel).IstStartStapel = true;
        ZeichneFelderNeu();
      }
      else
      {
        ablageStapel = geklickterStapel;
      }
      //Zug ausführen
      if (ablageStapel == 0)
        return;
      try {_hanoiSpiel.Zug(GetStartStapel(), ablageStapel);} catch(InvalidOperationException) {}
      EntferneMarkierung();
      AktualisiereStapelInhalt();
      ZeichneFelderNeu();
      //Gewonnen
      if (_hanoiSpiel.ÜberprüfeObGewonnen())
      {
        MessageBox.Show("GEWONNEN!!!");
        NeuesSpiel();
      }
    }

    private int GetStartStapel()
    {
      for (int i = 1; i <= 3; i++)
      {
        if (StackControl(i).IstStartStapel)
          return i;
      }
      return 0;
    }

    private bool IstStartStapelGesucht()
    {
      bool istStartStapelGesucht = true;
      for (int i = 1; i <= 3; i++)
      {
        if (StackControl(i).IstStartStapel)
          istStartStapelGesucht = false;
      }
      return istStartStapelGesucht;
    }

    private StackControl StackControl(int stackControl)
    {
      if (stackControl == 1)
        return stackControlStartStapel;
      if (stackControl == 2)
        return stackControlHilfsStapel;
      if (stackControl == 3)
        return stackControlAblageStapel;
      throw new Exception("Das Control ist nicht vorhanden!");
    }

    private void EntferneMarkierung()
    {
      for (int i = 1; i <= 3; i++)
      {
        StackControl(i).IstStartStapel = false;
        StackControl(i).Refresh();
      }
    }

    private void AktualisiereStapelInhalt()
    {
      stackControlStartStapel.Stack = _hanoiSpiel.GibStapelKopiertZurück(1);
      stackControlHilfsStapel.Stack = _hanoiSpiel.GibStapelKopiertZurück(2);
      stackControlAblageStapel.Stack = _hanoiSpiel.GibStapelKopiertZurück(3);
    }

    /// <summary>
    /// Zeichnet jedes Feld Neu
    /// </summary>
    public void ZeichneFelderNeu()
    {
      stackControlStartStapel.Refresh();
      stackControlHilfsStapel.Refresh();
      stackControlAblageStapel.Refresh();
    }

    private void NeuesSpiel()
    {
      try
      {
        _hanoiSpiel = new HanoiSpiel(int.Parse(AnzahlScheibenTextBox.Text));
        AktualisiereStapelInhalt();
        ZeichneFelderNeu();
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }
    }

    /// <summary>
    /// Gibt die Höhe des Startstapels zurück
    /// </summary>
    public int StartStapelHöhe
    {
      get
      {
        return stackControlStartStapel.Height;
      }
    }

    /// <summary>
    /// Gibt die Breite des Startstapels zurück
    /// </summary>
    public int StartStapelBreite
    {
      get
      {
        return stackControlStartStapel.Width;
      }
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
      int abstandStackControls = 20;

      //Breite der Felder Anpassen
      int stackControlBreite = (ClientSize.Width - 4 * abstandStackControls) / 3;
      stackControlStartStapel.Width = stackControlBreite;
      stackControlHilfsStapel.Width = stackControlBreite;
      stackControlAblageStapel.Width = stackControlBreite;

      //X Position der Felder Anpassen
      stackControlHilfsStapel.Location = new Point(stackControlBreite + abstandStackControls * 2, stackControlStartStapel.Location.Y);
      stackControlAblageStapel.Location = new Point(stackControlBreite * 2 + abstandStackControls * 3, stackControlStartStapel.Location.Y);

      //Höhe der Felder Anpassen
      int höhe = ClientSize.Height - (startButton.Location.Y + startButton.Height + abstandStackControls * 2);
      stackControlStartStapel.Height = höhe;
      stackControlHilfsStapel.Height = höhe;
      stackControlAblageStapel.Height = höhe;

      ZeichneFelderNeu();
    }
  }
}
