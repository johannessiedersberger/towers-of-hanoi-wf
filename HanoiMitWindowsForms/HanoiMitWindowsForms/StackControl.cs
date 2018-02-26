using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hanoi_mit_Stacks;

namespace HanoiMitWindowsForms
{
  public partial class StackControl : UserControl
  {
    public int[] Stack { get; set; }
    public bool IstStartStapel { get; set; }
    public bool IstAblageStapel { get; set; }

    public StackControl()
    {
      InitializeComponent();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (IstStartStapel)
        BackColor = Color.LightBlue;
      else
        BackColor = Color.Khaki;

     
      if (Stack == null)
        return;

      base.OnPaint(e);
      int stiftStärke = 5;
      Pen pen = new Pen(Color.CornflowerBlue, stiftStärke);

      for (int aktuelleScheibe = Stack.Length - 1; aktuelleScheibe >= 0; aktuelleScheibe--)
      {
        if (Stack[aktuelleScheibe] != 0)
        {
          int längenUnterschied = ClientSize.Width / Stack.Length;
          int höhe = (ClientSize.Height - stiftStärke) / Stack.Length;
          int scheibenBreite = ClientSize.Width - (längenUnterschied * (Stack.Length-Stack[aktuelleScheibe])) - stiftStärke;
          int y = ClientSize.Height + (aktuelleScheibe * höhe) - (höhe*Stack.Length) - stiftStärke;
          int x = (ClientSize.Width - scheibenBreite) / 2;

          e.Graphics.DrawRectangle(pen, new Rectangle(x, y, scheibenBreite, höhe));
        }
      }
    }
  }
}
