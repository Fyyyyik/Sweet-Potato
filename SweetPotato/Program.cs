using System;
using System.Windows.Forms;
using System.IO;

namespace sweet_potato;

static class Program
{
    static string iniFilePath = Path.Combine(Application.StartupPath, "functions.ini");
    static string settingsPath = Path.Combine(Application.StartupPath, "config.ini");

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(true);
        ApplicationConfiguration.Initialize();
        LoadIniFile();
        LoadSettingsIniFile();
        SettingsIniFile iniFile = new SettingsIniFile(settingsPath);
        if (iniFile.ReadValue("BaseSettings", "StartupPopup") == "True")
        {
            DialogResult result = MessageBox.Show("This program is not finished so it would be really nice of you to report any bugs or suggestion to @fyyyyik on Discord. Enjoy!\n(Click 'Yes' to disable this popup)", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                iniFile.WriteValue("BaseSettings", "StartupPopup", "False");
            }
        }
        Application.Run(new MainForm());
    }

    static void LoadIniFile()
    {
        if (File.Exists(iniFilePath))
        {
            INIFile iniFile = new INIFile(iniFilePath);
            string value = iniFile.ReadValue("SectionName", "KeyName");
            System.Diagnostics.Debug.WriteLine("Found ini file");
        }
        else
        {
            INIFile iniFile = new INIFile(iniFilePath);
            iniFile.WriteValue("SectionName", "KeyName", "DefaultValue");
            System.Diagnostics.Debug.WriteLine("Did not find ini file so created one");
        }
    }

    static void LoadSettingsIniFile()
    {
        if (File.Exists(settingsPath))
        {
            INIFile iniFile = new INIFile(settingsPath);
        }
        else
        {
            INIFile iniFile = new INIFile(settingsPath);
            iniFile.WriteValue("SectionName", "KeyName", "DefaultValue");
            iniFile.WriteValue("BaseSettings", "ColorMode", "Dark");
            iniFile.WriteValue("BaseSettings", "StartupPopup", "True");
        }
    }
}