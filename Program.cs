using System;
using System.Windows.Forms;
using STM.BLayer;
using STM.BLayer.Parameters;
using STM.BLayer.StmTest;
using STM.Sensor;
using STM.BLayer.Configurations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Xml;
using STM.Properties;

namespace STM
{
    static class Program
    {
        public static bool FullCreepAvailable
#if DEBUG
            = true;
#else
            = false;
#endif
        private static Dictionary<String, bool> AccessPermissionGrants = new Dictionary<string, bool>(8);
        private static Dictionary<String, String> AccessPermissionsPasswords = new Dictionary<string, String>(8);

        public static bool MoveToScreen(this Form form, int screenNumber)
        {
            var screens = Screen.AllScreens;

            if (screenNumber >= 0 && screenNumber < screens.Length)
            {
                var maximized = false;
                if (form.WindowState == FormWindowState.Maximized)
                {
                    form.WindowState = FormWindowState.Normal;
                    maximized = true;
                }
                form.Location = screens[screenNumber].WorkingArea.Location;
                if (maximized)
                {
                    form.WindowState = FormWindowState.Maximized;
                }
                return true;
            }

            return false;
        }

        static Program()
        {
            //AccessPermissionGrants["TestSettings.Information"] = true;
            //AccessPermissionGrants["TestSettings.Sample"] = true;
        }

        internal static bool GrantAccess(IWin32Window owner, string key)
        {
            if (AccessPermissionGrants.ContainsKey(key))
                return AccessPermissionGrants[key];

            if (!AccessPermissionsPasswords.ContainsKey(key))
                AccessPermissionsPasswords[key] = GetPassword(key, "tAmAs");

            var frm = new AccessPermissionForm
            {
                RequiredPassword = AccessPermissionsPasswords[key],
                RetryCount = 1
            };

            if (AccessPermissionsPasswords[key] == string.Empty || frm.ShowDialog(owner) == DialogResult.OK)
            {
                Program.AccessPermissionGrants[key] = true;
                return true;
            }

            return false;
        }

        private static string GetPassword(string key, string defaultValue)
        {
            try
            {
                var xml = new XmlDocument();
                xml.Load(SettingLoader.XmlPath);
                var node = xml.SelectSingleNode("/root/optiongrants/" + key);
                if (node != null)
                {
                    if (node.HasChildNodes)
                        defaultValue = node.InnerText;
                    else
                        return "";
                }
                return defaultValue;  
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SettingLoader.XmlPath = Application.StartupPath + "\\Configurations\\Settings.xml";

            //	SplashScreen.ShowSplashScreen();
            Application.DoEvents();

            LoadDefaults();
#if !DEBUG
            Lock.Check(SettingLoader.Current.GetUser());
#endif
            Options.ActiveLanguage = SettingLoader.Current.GetLanguge();
            LanguageFrm.LanguageName = Options.ActiveLanguage;

            if (Options.ShowLanguageForm || Options.ActiveLanguage == null)
            {
                if ((new LanguageFrm()).ShowDialog() == DialogResult.OK)
                    SettingLoader.Current.SetLanguge(LanguageFrm.LanguageName);
                else
	                return;
            }

            Application.Run(new MainFrm());
        }

		private static void LoadDefaults()
        {
            try
            {
                UnitManager.LoadUnits();
                SettingLoader.Current.LoadColors();
                SettingLoader.Current.LoadOption();
                SettingLoader.Current.LoadPortSetting();
                Sensors.SetLoadcells(SettingLoader.Current.GetLoadcells());
                Sensors.SetExtensometers(SettingLoader.Current.GetExtensometers());
                Sensors.SetTemperatureSensors(SettingLoader.Current.GetTemperatureSensors());
                SettingLoader.Current.LoadSpeedCtrlSetting();
                TestInitializer.TimeQuantom = SerialPortParameters.ReadInterval;
            }
            catch(Exception exception)
            {
                MessageBox.Show(Resources.Program_LoadDefaults_Error_in_the_config_file_ + Environment.NewLine + exception.Message, AboutBox.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }


        public static void SetCulture(Control.ControlCollection controls, ComponentResourceManager rcm, CultureInfo cultureInfo)
        {
            foreach (Control control in controls)
            {
                if (control.HasChildren)
                    SetCulture(control.Controls, rcm, cultureInfo);
                else
                {
                    rcm.ApplyResources(control, control.Name, cultureInfo);

                    if (control is MenuStrip)
                        SetMenuCulture(((MenuStrip)control).Items, rcm, cultureInfo);
                }
            }
        }
        public static void SetMenuCulture(ContextMenuStrip menuItem, ComponentResourceManager rcm, CultureInfo cultureInfo)
        {
            if (menuItem.Items.Count > 0)
                foreach (ToolStripItem toolStripMenuItem in menuItem.Items)
                {
                    if (toolStripMenuItem.GetType() == typeof(ToolStripMenuItem))
                    {
                        rcm.ApplyResources(toolStripMenuItem, toolStripMenuItem.Name, cultureInfo);
                    }
                    if (toolStripMenuItem.GetType() == typeof(ToolStripMenuItem) && ((ToolStripMenuItem)toolStripMenuItem).DropDownItems.Count > 0)
                    {
                        SetMenuCulture(((ToolStripMenuItem)toolStripMenuItem).DropDownItems, rcm, cultureInfo);
                    }
                }
        }
        public static void SetMenuCulture(ToolStripItemCollection toolStripItemCollection, ComponentResourceManager rcm, CultureInfo cultureInfo)
        {
            for (int i = 0; i < toolStripItemCollection.Count; i++)
            {
                if (toolStripItemCollection[i].GetType() == typeof(ToolStripMenuItem))
                {
                    rcm.ApplyResources(toolStripItemCollection[i], toolStripItemCollection[i].Name, cultureInfo);
                }
                if (toolStripItemCollection[i].GetType() == typeof(ToolStripMenuItem) && ((ToolStripMenuItem)toolStripItemCollection[i]).DropDownItems.Count > 0)
                {
                    SetMenuCulture(((ToolStripMenuItem)toolStripItemCollection[i]).DropDownItems, rcm, cultureInfo);
                }
            }
        }


    }
}
