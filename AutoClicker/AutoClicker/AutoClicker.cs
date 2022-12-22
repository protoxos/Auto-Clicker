using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using AutoClicker.Properties;

namespace AutoClicker
{
    public partial class AutoClicker : Form
    {
        int currentCoord = 0;
        bool reverse = false;
        bool ends = false;

        List<int[]> coords = new List<int[]>();

        int startKey = 118;
        int stopKey = 119;
        int capKey = 120;
        string setKeyTo = "";

        Dictionary<int, string> validKeys = new Dictionary<int, string> {
            { 8, "[Back]"},
            { 9, "[TAB]" },
            { 13, "[Enter]" },
            { 19, "[Pause]" },
            { 20, "[Caps Lock]" },
            { 27, "[Esc]" },
            { 32, "[Space]" },
            { 33, "[Page Up]" },
            { 34, "[Page Down]" },
            { 35, "[End]" },
            { 36, "[Home]" },
            { 37, "Left]" },
            { 38, "[Up]" },
            { 39, "[Right]" },
            { 40, "[Down]" },
            { 44, "[Print Screen]" },
            { 45, "[Insert]" },
            { 46, "[Delete]" },
            { 48, "0" },
            { 49, "1" },
            { 50, "2" },
            { 51, "3" },
            { 52, "4" },
            { 53, "5" },
            { 54, "6" },
            { 55, "7" },
            { 56, "8" },
            { 57, "9" },
            { 65, "a" },
            { 66, "b" },
            { 67, "c" },
            { 68, "d" },
            { 69, "e" },
            { 70, "f" },
            { 71, "g" },
            { 72, "h" },
            { 73, "i" },
            { 74, "j" },
            { 75, "k" },
            { 76, "l" },
            { 77, "m" },
            { 78, "n" },
            { 79, "o" },
            { 80, "p" },
            { 81, "q" },
            { 82, "r" },
            { 83, "s" },
            { 84, "t" },
            { 85, "u" },
            { 86, "v" },
            { 87, "w" },
            { 88, "x" },
            { 89, "y" },
            { 90, "z" },
            { 96, "0" },
            { 97, "1" },
            { 98, "2" },
            { 99, "3" },
            { 100, "4" },
            { 101, "5" },
            { 102, "6" },
            { 103, "7" },
            { 104, "8" },
            { 105, "9" },
            { 106, "*" },
            { 107, "+" },
            { 109, "-" },
            { 110, "," },
            { 111, "/" },
            { 112, "[F1]" },
            { 113, "[F2]" },
            { 114, "[F3]" },
            { 115, "[F4]" },
            { 116, "[F5]" },
            { 117, "[F6]" },
            { 118, "[F7]" },
            { 119, "[F8]" },
            { 120, "[F9]" },
            { 121, "[F10]" },
            { 122, "[F11]" },
            { 123, "[F12]" }
        };
        int[] vk = new int[] { };

        System.Timers.Timer TKeys;
        System.Timers.Timer TClick;
        Settings S = Settings.Default;

        public AutoClicker()
        {
            InitializeComponent();
            

            // Carga del intervalo...
            int interval = Settings.Default.ClickInterval;
            TKeys = new System.Timers.Timer();
            TKeys.Interval = 10;
            TKeys.Elapsed += TKeys_Elapsed;
            TKeys.Enabled = true;

            TClick = new System.Timers.Timer();
            TClick.Elapsed += TClick_Elapsed;
            TClick.Interval = interval;

            txtTickInterval.Text = interval.ToString();

            // Carga de teclas
            capKey = Settings.Default.CapKey;
            startKey = Settings.Default.StartKey;
            stopKey = Settings.Default.StopKey;

            //  Top most
            TopMost = chkAlwaysOnTop.Checked = Settings.Default.AlwaysOnTop;

            if (Settings.Default.WindowPoint.X != 0 && Settings.Default.WindowPoint.Y != 0)
                Location = Settings.Default.WindowPoint;

            // Cargamos el ultimo archivo
            if (File.Exists(Settings.Default.LastFile))
                LoadClicksFromFile(Settings.Default.LastFile);

            CapKeyButton.Text = validKeys[capKey];
            StartKeyButton.Text = validKeys[startKey];
            StopKeyButton.Text = validKeys[stopKey];

            setComboBox(Settings.Default.Mode);
            canChange = true;
        }

        void setComboBox(int index)
        {
            cbxMode.SelectedIndex = index >= 0 && index < cbxMode.Items.Count
                ? index : 0;

            index = cbxMode.SelectedIndex;

            helpTooltip.SetToolTip(cbxMode,
                index == 1 ? "Se ejecuta en orden y al llegar al final, se ejecuta en reversa"
                : index == 2 ? "Se ejecuta en orden y al llegar al final se detiene"
                : index == 3 ? "Se ejecuta en orden y al llegar al final, se ejecuta en reversa hasta el comienzo y se detiene"
                : "Se ejecuta en orden y al finalizar vuelve al inicio de la lista"
                );
        }
        private void TClick_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            TClick.Enabled = false;
            bool enabled = true;
            if (coords.Count > 0)
            {
                int x = coords[currentCoord][0];
                int y = coords[currentCoord][1];

                //Win32.POINT p = new Win32.POINT();

                //Win32.ClientToScreen(CapKeyButton.Handle, ref p);
                Win32.SetCursorPos(x, y);
                Invoke((MethodInvoker)delegate { enabled = analizeNextStep(); });
                
            }
            DoMouseClick();
            TClick.Enabled = enabled;
        }

        /// <summary>
        /// Analiza el paso siguiente y retorna true o false para el reloj...
        /// </summary>
        /// <returns></returns>
        bool analizeNextStep()
        {
            int i = cbxMode.SelectedIndex;
            // Bucle orden // and stop
            if (i == 0 || i == 2) {
                currentCoord++;
                if (currentCoord >= coords.Count)
                {
                    currentCoord = 0;

                    if (i == 2)
                        return false;
                }
            }

            // Bucle ida y vuelta
            else if (i == 1 || i == 3) {
                if (reverse)
                {
                    currentCoord--;
                    if (currentCoord < 0)
                    {
                        reverse = false;
                        currentCoord = coords.Count > 1 ? 1 : 0;
                        if (i == 3)
                            return false;
                    }
                }
                else
                {
                    currentCoord++;
                    if (currentCoord > coords.Count)
                    {
                        reverse = true;
                        currentCoord = coords.Count - 1;
                    }
                }
            }
            
            return true;
        }

        private void TKeys_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            TKeys.Enabled = false;
            try
            {
                Invoke((MethodInvoker)delegate { setRunningState(); });
                foreach (int i in vk)
                {
                    int state = Win32.GetAsyncKeyState((Keys)i);
                    if (state == -32767)
                    {
                        if (setKeyTo != "")
                            setKey(i);
                        else
                        {
                            if (i == capKey) Invoke((MethodInvoker)delegate { addCoords(); });
                            else if (i == startKey)
                            {
                                Invoke((MethodInvoker)delegate {
                                    currentCoord = 0;
                                    reverse = false;
                                    coords.Clear();
                                    foreach (ListViewItem it in ClickList.Items)
                                        coords.Add((int[])it.Tag);
                                });
                                TClick.Enabled = true;
                                TClick_Elapsed(null, null);
                            }
                            else if (i == stopKey) {
                                currentCoord = 0;
                                TClick.Enabled = false;
                                BringToFront();
                                Focus();
                            }
                        }
                        Debug.WriteLine(((Keys)i).ToString());
                        break;
                    }
                }
            }
            catch { }

            TKeys.Enabled = true;
        }

        private void setKey_clic(object sender, EventArgs e)
        {
            CapKeyButton.Text = validKeys[capKey];
            StartKeyButton.Text = validKeys[startKey];
            StopKeyButton.Text = validKeys[stopKey];

            if (sender == CapKeyButton)
            {
                CapKeyButton.Text = "...";
                setKeyTo = "cap";
            }

            if (sender == StartKeyButton)
            {
                StartKeyButton.Text = "...";
                setKeyTo = "start";
            }
            if (sender == StopKeyButton)
            {
                StopKeyButton.Text = "...";
                setKeyTo = "stop";
            }
        }
        private void setKey(int key)
        {
            if (setKeyTo == "cap")
            {
                CapKeyButton.Text = validKeys[key];
                capKey = key;
                Settings.Default.CapKey = key;
            }
            if (setKeyTo == "start")
            {
                StartKeyButton.Text = validKeys[key];
                Settings.Default.StartKey = key;
                startKey = key;
            }
            if (setKeyTo == "stop")
            {
                StopKeyButton.Text = validKeys[key];
                Settings.Default.StopKey = key;
                stopKey = key;
            }
            Settings.Default.Save();
            setKeyTo = "";
        }
        private void setRunningState()
        {
            CapKeyButton.Enabled =
                StartKeyButton.Enabled =
                StopKeyButton.Enabled =
                cbxMode.Enabled =
                !TClick.Enabled;

            vk = (setKeyTo == ""
                ? validKeys.Where(d => d.Key == capKey || d.Key == startKey || d.Key == stopKey)
                : validKeys)
                .Select(d => d.Key).ToArray();
            //vk = validKeys.Select(d => d.Key).ToArray();
        }
        private void addCoords()
        {
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;

            ListViewItem it = new ListViewItem();
            it.Tag = new int[] { x, y };
            it.Text = (ClickList.Items.Count + 1).ToString();
            it.SubItems.Add(x + " ," + y);
            it.SubItems.Add("Click en (" + x + " ," + y + ")");

            ClickList.Items.Add(it);
        }

        /// <summary>
        /// Simulates a click at the cursor's current location
        /// </summary>
        private void DoMouseClick()
        {

            //Call the imported function with the cursor's current position
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            Win32.mouse_event(Win32.MOUSEEVENTF_LEFTDOWN | Win32.MOUSEEVENTF_LEFTUP, X, Y, 0, 0);

        }

        public class Win32
        {
            [DllImport("User32.Dll")]
            public static extern long SetCursorPos(int x, int y);

            [DllImport("User32.Dll")]
            public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

            [DllImport("user32.dll")]
            public static extern short GetAsyncKeyState(Keys Key);

            [DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

            //Mouse actions
            public const int MOUSEEVENTF_LEFTDOWN = 0x02;
            public const int MOUSEEVENTF_LEFTUP = 0x04;
            public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
            public const int MOUSEEVENTF_RIGHTUP = 0x10;

            [StructLayout(LayoutKind.Sequential)]
            public struct POINT
            {
                public int x;
                public int y;
            }
        }

        private void TxtTickIntervalChange(object sender, EventArgs e)
        {
            int tick;
            if (int.TryParse(txtTickInterval.Text, out tick))
            {
                TClick.Interval = tick;
                Settings.Default.ClickInterval = tick;
                Settings.Default.Save();
            }
         
        }

        private void SaveListToFile(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = "Clicks " + DateTime.Now.ToString("yyMMdd-HHmmss");
            sf.DefaultExt = ".txt";
            sf.Filter = "Archivos de texto|*.txt";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                List<string> fileLines = new List<string>();
                foreach (ListViewItem it in ClickList.Items)
                {
                    int[] coord = (int[])it.Tag;
                    fileLines.Add(
                        "[" + coord[0] + "," + coord[1] + "]\t" +
                        it.SubItems[0].Text + "\t" +
                        it.SubItems[1].Text + "\t" +
                        it.SubItems[2].Text
                    );
                }
                File.WriteAllLines(sf.FileName, fileLines);
                Settings.Default.LastFile = sf.FileName;
                Settings.Default.Save();
            }
        }

        private void OpeningMenu(object sender, CancelEventArgs e)
        {
            if (ClickList.SelectedItems.Count > 0)
                txtClickChangeName.Text = ClickList.SelectedItems[0].SubItems[2].Text;

            txtClickChangeName.Visible = 
                btnBorrarClick.Visible =
                ctxSeparator1.Visible =
                ClickList.SelectedItems.Count > 0;
        }

        private void ChangingClickName(object sender, EventArgs e)
        {
            if (ClickList.SelectedItems.Count > 0)
                ClickList.SelectedItems[0].SubItems[2].Text = txtClickChangeName.Text.Replace("\t", ".");
        }

        private void LoadClicksFromFile(string filename)
        {
            ClickList.Items.Clear();
            string[] lines = File.ReadAllLines(filename);
            string message = "";
            foreach (string line in lines)
            {
                try
                {
                    string[] items = line.Split("\t".ToCharArray());
                    ListViewItem it = new ListViewItem(items.Skip(1).ToArray());
                    items[0] = items[0].Replace("[", "").Replace("]", "");
                    int[] coords = items[0].Split(",".ToCharArray()).Select(s => int.Parse(s)).ToArray();
                    it.Tag = coords;
                    ClickList.Items.Add(it);
                }
                catch
                {
                    message += "No se pudo cargar el elemento" + Environment.NewLine + "<" + line + ">" + Environment.NewLine;
                }
            }
            if (message != "")
                MessageBox.Show(message, "Advertencia...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void LoadClicksFromFile(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.DefaultExt = ".txt";
            of.Filter = "Archivos de texto|*.txt";
            if (of.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(of.FileName))
                {
                    LoadClicksFromFile(of.FileName);
                    Settings.Default.LastFile = of.FileName;
                    Settings.Default.Save();
                }

            }

        }

        private void btnBorrarClick_Click(object sender, EventArgs e)
        {
            if (ClickList.SelectedItems.Count > 0)
                ClickList.Items.Remove(ClickList.SelectedItems[0]);
        }

        private void ClickList_DoubleClick(object sender, EventArgs e)
        {
            if (ClickList.SelectedItems.Count > 0)
            {
                int[] c = (int[])ClickList.SelectedItems[0].Tag;
                Win32.SetCursorPos(c[0], c[1]);
                DoMouseClick();
            }
        }

        private void onClicksKeyUp(object sender, KeyEventArgs e)
        {

        }

        bool canChange = false;
        private void cbxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (canChange && Settings.Default.Mode != cbxMode.SelectedIndex)
            {
                Settings.Default.Mode = cbxMode.SelectedIndex;
                Settings.Default.Save();
            }
        }

        private void chkAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = chkAlwaysOnTop.Checked;
            Settings.Default.AlwaysOnTop = TopMost;
            Settings.Default.Save();
        }

        private void AutoClicker_LocationChanged(object sender, EventArgs e)
        {
            Settings.Default.WindowPoint = Location;
        }

        private void AutoClicker_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
