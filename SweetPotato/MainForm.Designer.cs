namespace sweet_potato;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        btnSettings = new Button();
        btnAbout = new Button();
        richTextBox1 = new RichTextBox();
        richTextBox2 = new RichTextBox();
        toMint = new Button();
        toCode = new Button();
        menuStrip1 = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        openToolStripMenuItem = new ToolStripMenuItem();
        openMintToolStripMenuItem = new ToolStripMenuItem();
        openCodeToolStripMenuItem = new ToolStripMenuItem();
        saveToolStripMenuItem = new ToolStripMenuItem();
        saveMintToolStripMenuItem = new ToolStripMenuItem();
        saveCodeToolStripMenuItem = new ToolStripMenuItem();
        saveAsToolStripMenuItem = new ToolStripMenuItem();
        saveMintToolStripMenuItem1 = new ToolStripMenuItem();
        saveCodeToolStripMenuItem1 = new ToolStripMenuItem();
        panel1 = new Panel();
        panel2 = new Panel();
        label1 = new Label();
        label2 = new Label();
        pictureBox1 = new PictureBox();
        menuStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // btnSettings
        // 
        btnSettings.Location = new Point(502, 27);
        btnSettings.Name = "btnSettings";
        btnSettings.Size = new Size(58, 24);
        btnSettings.TabIndex = 0;
        btnSettings.Text = "Settings";
        btnSettings.UseVisualStyleBackColor = true;
        // 
        // btnAbout
        // 
        btnAbout.Location = new Point(576, 27);
        btnAbout.Name = "btnAbout";
        btnAbout.RightToLeft = RightToLeft.No;
        btnAbout.Size = new Size(58, 23);
        btnAbout.TabIndex = 1;
        btnAbout.Text = "About";
        btnAbout.UseVisualStyleBackColor = true;
        // 
        // richTextBox1
        // 
        richTextBox1.Location = new Point(28, 75);
        richTextBox1.Name = "richTextBox1";
        richTextBox1.Size = new Size(384, 523);
        richTextBox1.TabIndex = 2;
        richTextBox1.Text = "";
        // 
        // richTextBox2
        // 
        richTextBox2.Location = new Point(713, 75);
        richTextBox2.Name = "richTextBox2";
        richTextBox2.Size = new Size(384, 523);
        richTextBox2.TabIndex = 3;
        richTextBox2.Text = "";
        // 
        // toMint
        // 
        toMint.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
        toMint.Location = new Point(509, 532);
        toMint.Name = "toMint";
        toMint.Size = new Size(115, 39);
        toMint.TabIndex = 4;
        toMint.Text = "→";
        toMint.UseVisualStyleBackColor = true;
        toMint.Click += toMint_Click;
        // 
        // toCode
        // 
        toCode.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
        toCode.Location = new Point(509, 118);
        toCode.Name = "toCode";
        toCode.Size = new Size(115, 39);
        toCode.TabIndex = 5;
        toCode.Text = "←";
        toCode.UseVisualStyleBackColor = true;
        toCode.Click += toCode_Click;
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(1132, 24);
        menuStrip1.TabIndex = 6;
        menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(37, 20);
        fileToolStripMenuItem.Text = "File";
        // 
        // openToolStripMenuItem
        // 
        openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openMintToolStripMenuItem, openCodeToolStripMenuItem });
        openToolStripMenuItem.Name = "openToolStripMenuItem";
        openToolStripMenuItem.Size = new Size(114, 22);
        openToolStripMenuItem.Text = "Open";
        // 
        // openMintToolStripMenuItem
        // 
        openMintToolStripMenuItem.Name = "openMintToolStripMenuItem";
        openMintToolStripMenuItem.Size = new Size(134, 22);
        openMintToolStripMenuItem.Text = "Open Mint";
        openMintToolStripMenuItem.Click += openMintToolStripMenuItem_Click;
        // 
        // openCodeToolStripMenuItem
        // 
        openCodeToolStripMenuItem.Name = "openCodeToolStripMenuItem";
        openCodeToolStripMenuItem.Size = new Size(134, 22);
        openCodeToolStripMenuItem.Text = "Open Code";
        openCodeToolStripMenuItem.Click += openCodeToolStripMenuItem_Click;
        // 
        // saveToolStripMenuItem
        // 
        saveToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveMintToolStripMenuItem, saveCodeToolStripMenuItem });
        saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        saveToolStripMenuItem.Size = new Size(114, 22);
        saveToolStripMenuItem.Text = "Save";
        // 
        // saveMintToolStripMenuItem
        // 
        saveMintToolStripMenuItem.Name = "saveMintToolStripMenuItem";
        saveMintToolStripMenuItem.Size = new Size(129, 22);
        saveMintToolStripMenuItem.Text = "Save Mint";
        saveMintToolStripMenuItem.Click += saveMintToolStripMenuItem_Click;
        // 
        // saveCodeToolStripMenuItem
        // 
        saveCodeToolStripMenuItem.Name = "saveCodeToolStripMenuItem";
        saveCodeToolStripMenuItem.Size = new Size(129, 22);
        saveCodeToolStripMenuItem.Text = "Save Code";
        saveCodeToolStripMenuItem.Click += saveCodeToolStripMenuItem_Click;
        // 
        // saveAsToolStripMenuItem
        // 
        saveAsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveMintToolStripMenuItem1, saveCodeToolStripMenuItem1 });
        saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
        saveAsToolStripMenuItem.Size = new Size(114, 22);
        saveAsToolStripMenuItem.Text = "Save As";
        // 
        // saveMintToolStripMenuItem1
        // 
        saveMintToolStripMenuItem1.Name = "saveMintToolStripMenuItem1";
        saveMintToolStripMenuItem1.Size = new Size(129, 22);
        saveMintToolStripMenuItem1.Text = "Save Mint";
        saveMintToolStripMenuItem1.Click += saveMintToolStripMenuItem1_Click;
        // 
        // saveCodeToolStripMenuItem1
        // 
        saveCodeToolStripMenuItem1.Name = "saveCodeToolStripMenuItem1";
        saveCodeToolStripMenuItem1.Size = new Size(129, 22);
        saveCodeToolStripMenuItem1.Text = "Save Code";
        saveCodeToolStripMenuItem1.Click += saveCodeToolStripMenuItem1_Click;
        // 
        // panel1
        // 
        panel1.Location = new Point(12, 64);
        panel1.Name = "panel1";
        panel1.Size = new Size(413, 545);
        panel1.TabIndex = 7;
        // 
        // panel2
        // 
        panel2.Location = new Point(702, 64);
        panel2.Name = "panel2";
        panel2.Size = new Size(409, 545);
        panel2.TabIndex = 8;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 18F, FontStyle.Underline, GraphicsUnit.Point);
        label1.Location = new Point(12, 29);
        label1.Name = "label1";
        label1.Size = new Size(70, 32);
        label1.TabIndex = 9;
        label1.Text = "Code";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 18F, FontStyle.Underline, GraphicsUnit.Point);
        label2.Location = new Point(702, 29);
        label2.Name = "label2";
        label2.Size = new Size(64, 32);
        label2.TabIndex = 10;
        label2.Text = "Mint";
        // 
        // pictureBox1
        // 
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.Location = new Point(502, 268);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(144, 140);
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 11;
        pictureBox1.TabStop = false;
        // 
        // MainForm
        // 
        BackColor = SystemColors.ControlDarkDark;
        ClientSize = new Size(1132, 621);
        Controls.Add(pictureBox1);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(toCode);
        Controls.Add(toMint);
        Controls.Add(richTextBox2);
        Controls.Add(richTextBox1);
        Controls.Add(btnAbout);
        Controls.Add(btnSettings);
        Controls.Add(menuStrip1);
        Controls.Add(panel1);
        Controls.Add(panel2);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MainMenuStrip = menuStrip1;
        Name = "MainForm";
        Text = "Sweet Potato+";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnSettings;
    private Button btnAbout;
    private RichTextBox richTextBox1;
    private RichTextBox richTextBox2;
    private Button toMint;
    private Button toCode;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripMenuItem saveToolStripMenuItem;
    private ToolStripMenuItem saveAsToolStripMenuItem;
    private ToolStripMenuItem saveMintToolStripMenuItem;
    private ToolStripMenuItem saveCodeToolStripMenuItem;
    private ToolStripMenuItem saveMintToolStripMenuItem1;
    private ToolStripMenuItem saveCodeToolStripMenuItem1;
    private Panel panel1;
    private Panel panel2;
    private Label label1;
    private Label label2;
    private PictureBox pictureBox1;
    private ToolStripMenuItem openMintToolStripMenuItem;
    private ToolStripMenuItem openCodeToolStripMenuItem;
}

