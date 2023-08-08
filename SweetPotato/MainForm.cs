using sweet_potato.SweetPotato;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;

namespace sweet_potato;

public partial class MainForm : Form
{
    public string currentColor = "";
    private string mintFilePath = "";
    private string codeFilePath = "";

    public static MainForm instance;

    public MainForm()
    {
        InitializeComponent();

        instance = this;
        this.btnSettings.Click += new EventHandler(this.btnSettings_Click);
        this.btnAbout.Click += new EventHandler(this.btnAbout_Click);
        this.CenterToScreen();

        InitializeSavedSettings();

        FloatToHex(71.81f);
    }

    void InitializeSavedSettings()
    {
        string settingsFilePath = Path.Combine(Application.StartupPath, "config.ini");
        SettingsIniFile iniFile = new SettingsIniFile(settingsFilePath);

        //Theme
        currentColor = iniFile.ReadValue("BaseSettings", "ColorMode");
        if (currentColor == "")
        {
            iniFile.WriteValue("BaseSettings", "ColorMode", "Dark");
            currentColor = "Dark";
        }
        UpdateColor(true);
    }

    public void UpdateColor(bool isStartup)
    {
        if (!isStartup)
        {
            Form[] forms = FormHelper.GetAllOpenedForms();

            switch (currentColor)
            {
                case "Dark":
                    foreach (Form form in forms)
                    {
                        form.BackColor = SystemColors.ControlDarkDark;
                    }
                    break;

                case "Light":
                    foreach (Form form in forms)
                    {
                        form.BackColor = Color.White;
                    }
                    break;

                case "Green":
                    foreach (Form form in forms)
                    {
                        form.BackColor = Color.Green;
                    }
                    break;

                default:
                    System.Diagnostics.Debug.WriteLine("No match found, setting the color to ControlDarkDark.");
                    foreach (Form form in forms)
                    {
                        form.BackColor = SystemColors.ControlDarkDark;
                    }
                    break;
            }
        }
        else
        {
            switch (currentColor)
            {
                case "Dark":
                    this.BackColor = SystemColors.ControlDarkDark;
                    break;

                case "Light":
                    this.BackColor = Color.White;
                    break;

                case "Green":
                    this.BackColor = Color.Green;
                    break;

                default:
                    System.Diagnostics.Debug.WriteLine("No match found, setting the color to ControlDarkDark.");
                    this.BackColor = SystemColors.ControlDarkDark;
                    break;
            }
        }
    }

    string IntToHex(int input)
    {
        string hexValue = "0x" + input.ToString("x");
        System.Diagnostics.Debug.WriteLine(hexValue); return hexValue;
    }

    int HexToInt(string input)
    {
        input = input.Substring(2);

        if (int.TryParse(input, System.Globalization.NumberStyles.HexNumber, null, out int output))
        {
            System.Diagnostics.Debug.WriteLine(output);
            return output;
        }
        else
        {
            MessageBox.Show("Could not convert hex value to a 32-bit integer value. The function will return 0 by default.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return 0;
        }
    }

    string FloatToHex(float input)
    {
        byte[] bytes = BitConverter.GetBytes(input);

        if (BitConverter.IsLittleEndian)
            Array.Reverse(bytes);

        string output = BitConverter.ToString(bytes).Replace("-", "");
        return output;
    }

    float HexToFloat(string input)
    {
        byte[] bytes = Enumerable.Range(0, input.Length / 2)
                         .Select(x => Convert.ToByte(input.Substring(x * 2, 2), 16))
                         .ToArray();

        Array.Reverse(bytes);

        float floatValue = BitConverter.ToSingle(bytes, 0);
        return floatValue;
    }

    string GetKeyName(string correspondingValue)
    {
        //Yes yes I know this is not optimized at all, shut up nerd

        string filePath = Path.Combine(Application.StartupPath, "functions.ini");
        INIFile iniFile = new INIFile(filePath);
        string[] sections = iniFile.GetSections().ToArray();

        foreach (string section in sections)
        {
            string[] keys = iniFile.GetKeys(section).ToArray();

            foreach (string key in keys)
            {
                string value = iniFile.ReadValue(section, key);

                if (value == correspondingValue)
                {
                    string keyName = key;
                    return keyName;
                }
            }
        }

        MessageBox.Show("An error occured during the conversion : Couldn't find a valid key, you may have made a typo.", "Conversion error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return "";
    }

    string GetPrefix(string input)
    {
        int startIndex = 0;
        int endIndex = input.IndexOf("(");
        try
        {
            return input.Substring(startIndex, endIndex - startIndex);
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occured when getting the prefix of the function : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Converting.instance.Close();
            return "";
        }
    }

    static int CountSubstringOccurrences(string mainString, string substring)
    {
        int count = Regex.Matches(mainString, Regex.Escape(substring)).Count;
        return count;
    }

    void btnSettings_Click(object sender, EventArgs e)
    {
        Settings form = FormSingleton.Instance;
        form.ShowDialog();
    }

    void btnAbout_Click(object sender, EventArgs e)
    {
        About form = FormSingletonAbout.Instance;
        form.ShowDialog();
    }

    private void openMintToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
            openFileDialog.Title = "Select a text file.";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mintFilePath = openFileDialog.FileName;

                try
                {
                    string fileContents = File.ReadAllText(mintFilePath);

                    richTextBox2.Text = fileContents;
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error reading the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void openCodeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
            openFileDialog.Title = "Select a text file.";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                codeFilePath = openFileDialog.FileName;

                try
                {
                    string fileContents = File.ReadAllText(codeFilePath);

                    richTextBox1.Text = fileContents;
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error reading the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void saveMintToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(mintFilePath))
        {
            MessageBox.Show("Please open a file first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            File.WriteAllText(mintFilePath, richTextBox2.Text);
        }
        catch (IOException ex)
        {
            MessageBox.Show("Error occured when saving the file : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void saveCodeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(codeFilePath))
        {
            MessageBox.Show("Please open a file first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            File.WriteAllText(codeFilePath, richTextBox1.Text);
        }
        catch (IOException ex)
        {
            MessageBox.Show("Error occured when saving the file : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void saveMintToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
            saveFileDialog.Filter = "Text File (*.txt)|All Files (*.*)";
            saveFileDialog.Title = "Choose a location to save the file";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                mintFilePath = saveFileDialog.FileName;

                try
                {
                    File.WriteAllText(mintFilePath + ".txt", richTextBox2.Text);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error occured when saving the file : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void saveCodeToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
            saveFileDialog.Filter = "Text File (*.txt)|All Files (*.*)";
            saveFileDialog.Title = "Choose a location to save the file";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                codeFilePath = saveFileDialog.FileName;

                try
                {
                    File.WriteAllText(codeFilePath + ".txt", richTextBox1.Text);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error occured when saving the file : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void toMint_Click(object sender, EventArgs e)
    {
        if (richTextBox1.Text == "")
        {
            MessageBox.Show("No code to convert!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Converting form = new Converting();
        form.Show();
        string[] instructions = richTextBox1.Lines;
        string iniFilePath = Path.Combine(Application.StartupPath, "functions.ini");
        INIFile iniFile = new INIFile(iniFilePath);
        int currentLine = 1;
        bool isFirstLine = true;
        richTextBox2.Text = "";

        foreach (string line in instructions)
        {
            if (!isFirstLine)
            {
                richTextBox2.Text += "\n";
            }
            else
            {
                isFirstLine = false;
            }

            int argCount = 0;

            if (line.EndsWith("()") == false)
            {
                argCount = 1;
                char targetChar = ',';
                foreach (char c in line)
                {
                    if (c == targetChar)
                    {
                        argCount++;
                    }
                }

                string patternInt = @"\b\d+\b";
                string patternBool = @"\b(true|false)\b";
                string patternFloat = @"\b\d+(\.\d+)?\b";
                Regex regexInt = new Regex(patternInt);
                MatchCollection matchInt = regexInt.Matches(line);
                Regex regexBool = new Regex(patternBool);
                MatchCollection matchBool = regexBool.Matches(line);
                Regex regexFloat = new Regex(patternFloat);
                MatchCollection matchFloat = regexFloat.Matches(line);

                if (matchInt.Count > 0 || matchBool.Count > 0 || matchFloat.Count > 0)
                {
                    string output = iniFile.ReadValue("Main", GetPrefix(line));

                    //Enticipate possible arguments based on ReadValue
                    int intCount = CountSubstringOccurrences(output, "IA");
                    int boolCount = CountSubstringOccurrences(output, "BA");
                    int floatCount = CountSubstringOccurrences(output, "FA");
                    int excludedMatchFloatCount = 0;
                    foreach(Match match in matchFloat)
                    {
                        if (match.Value.Contains('.'))
                        {
                            excludedMatchFloatCount++;
                        }
                    }

                    if (argCount >= 1 && floatCount == excludedMatchFloatCount)
                    {
                        if (output != null)
                        {
                            int currentArgValue = 1;

                            //Int conversion
                            if (output.Contains("IA"))
                            {
                                foreach (Match matchI in matchInt)
                                {
                                    int arg;
                                    if (int.TryParse(matchI.Value, out arg))
                                    {
                                        output = output.Replace("IA" + currentArgValue.ToString(), IntToHex(arg).Substring(2));
                                        currentArgValue++;
                                        System.Diagnostics.Debug.WriteLine("Replaced");

                                        if (output.Contains("IA") == false)
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Could not parse int! (Line " + currentLine + " ; Argument " + (currentArgValue - 1) + ")", "Conversion error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        form.Close();
                                        return;
                                    }
                                }
                            }

                            //Bool conversion
                            if (output.Contains("BA"))
                            {
                                foreach (Match matchB in matchBool)
                                {
                                    bool arg;
                                    if (bool.TryParse(matchB.Value, out arg))
                                    {
                                        output = output.Replace("BA" + currentArgValue.ToString(), arg.ToString());
                                        currentArgValue++;

                                        if (output.Contains("BA") == false)
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Could not parse bool! (Line " + currentLine + " ; Argument " + (currentArgValue - 1) + ")", "Conversion error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        form.Close();
                                        return;
                                    }
                                }
                            }

                            //Float conversion
                            if (output.Contains("FA"))
                            {
                                foreach (Match matchF in matchFloat)
                                {
                                    System.Diagnostics.Debug.WriteLine(matchF.Value);

                                    if (matchF.Value.Contains('.'))
                                    {
                                        CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                                        ci.NumberFormat.CurrencyDecimalSeparator = ".";
                                        float arg;
                                        if (float.TryParse(matchF.Value, NumberStyles.Any, ci, out arg))
                                        {
                                            output = output.Replace("FA" + currentArgValue.ToString(), FloatToHex(arg));
                                            currentArgValue++;

                                            if (output.Contains("FA") == false)
                                            {
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Could not parse float! (Line " + currentLine + " ; Argument " + (currentArgValue - 1) + ")", "Conversion error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            form.Close();
                                            return;
                                        }
                                    }
                                }
                            }

                            System.Diagnostics.Debug.WriteLine(currentArgValue.ToString());
                        }
                        else
                        {
                            MessageBox.Show("An error occured when loading the output! You might have made a typo. (Line : " + currentLine + ")");
                            form.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("A problem occured when initializing the conversion. The number of variable occurences generated by the Regex did not match the estimations. Make sure the float values have a decimal number! Even if it's a whole number. (Line " + currentLine + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        form.Close();
                        return;
                    }

                    richTextBox2.Text += output;
                }
                else
                {
                    MessageBox.Show("No match found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    form.Close();
                    return;
                }
            }
            else
            {
                currentLine++;
                richTextBox2.Text += iniFile.ReadValue("Main", GetPrefix(line));
            }
        }

        form.Close();
    }

    void toCode_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Not available yet.", "Sorry :(", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}

public class INIFile
{
    string path;

    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

    public INIFile(string INIPath)
    {
        path = INIPath;
    }

    // Reads all the sections in the .ini file
    public List<string> GetSections()
    {
        var sections = new List<string>();
        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Trim().StartsWith("[") && line.Trim().EndsWith("]"))
                {
                    sections.Add(line.Trim().Substring(1, line.Length - 2));
                }
            }
        }
        return sections;
    }

    // Reads all the keys in a section
    public List<string> GetKeys(string section)
    {
        var keys = new List<string>();
        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            bool isInSection = false;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Trim().Equals("[" + section + "]"))
                {
                    isInSection = true;
                    continue;
                }
                if (isInSection && line.Trim().StartsWith("["))
                {
                    break;
                }
                if (isInSection && line.Contains("="))
                {
                    keys.Add(line.Substring(0, line.IndexOf("=")).Trim());
                }
            }
        }
        return keys;
    }

    public void WriteValue(string section, string key, string value)
    {
        WritePrivateProfileString(section, key, value, path);
    }

    // Reads the value of a key in a section and handles string variables
    public string ReadValue(string section, string prefix)
    {
        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            bool isInSection = false;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Trim().Equals("[" + section + "]"))
                {
                    isInSection = true;
                    continue;
                }
                if (isInSection && line.Trim().StartsWith("["))
                {
                    break;
                }
                if (isInSection && line.Contains("="))
                {
                    string key = line.Substring(0, line.IndexOf("=")).Trim();
                    if (key.StartsWith(prefix + "(") && key.EndsWith(")"))
                    {
                        string output = line.Substring(line.IndexOf("=") + 1).Trim();
                        output = output.Replace("##", "\n");
                        return output;
                    }
                }
            }
        }
        return null; // Key not found
    }
}

public class SettingsIniFile
{
    string path;

    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);

    public SettingsIniFile(string INIPath)
    {
        path = INIPath;
    }

    public void WriteValue(string section, string key, string value)
    {
        WritePrivateProfileString(section, key, value, path);
    }

    public string ReadValue(string section, string key)
    {
        var retVal = new StringBuilder(255);
        GetPrivateProfileString(section, key, "", retVal, 255, path);
        return retVal.ToString();
    }
}

public static class FormHelper
{
    public static Form[] GetAllOpenedForms()
    {
        Form[] formsArray = new Form[Application.OpenForms.Count];
        int i = 0;

        foreach (Form form in Application.OpenForms)
        {
            formsArray[i] = form;
            i++;
        }

        return formsArray;
    }
}
