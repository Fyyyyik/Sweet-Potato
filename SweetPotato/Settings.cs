using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sweet_potato.SweetPotato
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            this.btnApply.Click += new EventHandler(this.btnApply_Click);
            this.CenterToScreen();
            this.Load += this.ld_Settings;
        }

        void ld_Settings(object sender, EventArgs e)
        {
            MainForm.instance.UpdateColor(false);
            this.CenterToScreen();
        }

        void btnApply_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedItem != null)
            {
                MainForm.instance.currentColor = this.comboBox1.SelectedItem.ToString();
                string settingsFilePath = Path.Combine(Application.StartupPath, "config.ini");
                INIFile iniFile = new INIFile(settingsFilePath);
                iniFile.WriteValue("BaseSettings", "ColorMode", this.comboBox1.SelectedItem.ToString());
                MainForm.instance.UpdateColor(false);
            }
            else
            {
                MessageBox.Show("Unrecognized color mode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string settingsFilePath = Path.Combine(Application.StartupPath, "config.ini");
            SettingsIniFile iniFile = new SettingsIniFile(settingsFilePath);
            if(checkBox1.Checked)
            {
                iniFile.WriteValue("BaseSettings", "StartupPopup", "True");
            }
            else
            {
                iniFile.WriteValue("BaseSettings", "StartupPopup", "False");
            }
        }
    }

    public class FormSingleton
    {
        private static Settings instance;

        public static Settings Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Settings();
                }
                return instance;
            }
        }
    }
}
