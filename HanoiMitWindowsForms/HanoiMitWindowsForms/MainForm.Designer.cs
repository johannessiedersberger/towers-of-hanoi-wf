namespace HanoiMitWindowsForms
{
  partial class MainForm
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.AnzahlScheibenTextBox = new System.Windows.Forms.TextBox();
      this.startButton = new System.Windows.Forms.Button();
      this.stackControlAblageStapel = new HanoiMitWindowsForms.StackControl();
      this.stackControlHilfsStapel = new HanoiMitWindowsForms.StackControl();
      this.stackControlStartStapel = new HanoiMitWindowsForms.StackControl();
      this.SuspendLayout();
      // 
      // AnzahlScheibenTextBox
      // 
      this.AnzahlScheibenTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.AnzahlScheibenTextBox.Location = new System.Drawing.Point(226, 12);
      this.AnzahlScheibenTextBox.Name = "AnzahlScheibenTextBox";
      this.AnzahlScheibenTextBox.Size = new System.Drawing.Size(80, 20);
      this.AnzahlScheibenTextBox.TabIndex = 4;
      // 
      // startButton
      // 
      this.startButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.startButton.Location = new System.Drawing.Point(226, 36);
      this.startButton.Name = "startButton";
      this.startButton.Size = new System.Drawing.Size(80, 23);
      this.startButton.TabIndex = 5;
      this.startButton.Text = "Start";
      this.startButton.UseVisualStyleBackColor = true;
      this.startButton.Click += new System.EventHandler(this.StartButtonClicked);
      this.startButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startButton_KeyDown);
      // 
      // stackControlAblageStapel
      // 
      this.stackControlAblageStapel.BackColor = System.Drawing.SystemColors.ActiveBorder;
      this.stackControlAblageStapel.Location = new System.Drawing.Point(360, 80);
      this.stackControlAblageStapel.Name = "stackControlAblageStapel";
      this.stackControlAblageStapel.Size = new System.Drawing.Size(150, 150);
      this.stackControlAblageStapel.Stack = null;
      this.stackControlAblageStapel.TabIndex = 3;
      this.stackControlAblageStapel.Click += new System.EventHandler(this.StackThreeClicked);
      this.stackControlAblageStapel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stackControlAblageStapel_KeyDown);
      // 
      // stackControlHilfsStapel
      // 
      this.stackControlHilfsStapel.BackColor = System.Drawing.SystemColors.ActiveBorder;
      this.stackControlHilfsStapel.Location = new System.Drawing.Point(190, 80);
      this.stackControlHilfsStapel.Name = "stackControlHilfsStapel";
      this.stackControlHilfsStapel.Size = new System.Drawing.Size(150, 150);
      this.stackControlHilfsStapel.Stack = null;
      this.stackControlHilfsStapel.TabIndex = 2;
      this.stackControlHilfsStapel.Click += new System.EventHandler(this.StackTwoClicked);
      this.stackControlHilfsStapel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stackControlHilfsStapel_KeyDown);
      // 
      // stackControlStartStapel
      // 
      this.stackControlStartStapel.BackColor = System.Drawing.SystemColors.ActiveBorder;
      this.stackControlStartStapel.Location = new System.Drawing.Point(20, 80);
      this.stackControlStartStapel.Name = "stackControlStartStapel";
      this.stackControlStartStapel.Size = new System.Drawing.Size(150, 150);
      this.stackControlStartStapel.Stack = null;
      this.stackControlStartStapel.TabIndex = 1;
      this.stackControlStartStapel.Click += new System.EventHandler(this.StackeOneClicked);
      this.stackControlStartStapel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stackControlStartStapel_KeyDown);
      // 
      // Form1
      // 
      this.ClientSize = new System.Drawing.Size(524, 245);
      this.Controls.Add(this.startButton);
      this.Controls.Add(this.AnzahlScheibenTextBox);
      this.Controls.Add(this.stackControlAblageStapel);
      this.Controls.Add(this.stackControlHilfsStapel);
      this.Controls.Add(this.stackControlStartStapel);
      this.Name = "Form1";
      this.Resize += new System.EventHandler(this.Form1_Resize);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private StackControl stackControlStartStapel;
    private StackControl stackControlHilfsStapel;
    private StackControl stackControlAblageStapel;
    private System.Windows.Forms.TextBox AnzahlScheibenTextBox;
    private System.Windows.Forms.Button startButton;
  }
}

