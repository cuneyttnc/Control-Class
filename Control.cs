using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

public class Control
    {
        #region KelimeKontrol

        private static bool IsMailValidated(string strTextEntry)
        {
            string MatchEmailPattern = @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$";
            return !Regex.IsMatch(strTextEntry, MatchEmailPattern);
        }
        private static bool IsNumberValidated(string strTextEntry)
        {
            return !Regex.IsMatch(strTextEntry, "^\\d+$");
        }
        private static bool IsPasswordValidated(string strTextEntry)
        {
            Regex objNotWholePattern = new Regex(@"^[a-zA-Z0-9\s\-\*\.\?\,\/\\\+%\$#_=]*$");
            return objNotWholePattern.IsMatch(strTextEntry);
        }

        private static bool IsTextValidated(string strTextEntry)
        {
            Regex objNotWholePattern = new Regex(@"^\w+$");
            return objNotWholePattern.IsMatch(strTextEntry);
        }

        private static bool IsIntager(string strTextEntry)
        {
            try
            {
                int.Parse(strTextEntry);
                return true;
            }
            catch
            {
                return false;
            }

        }
        private static bool IsDecimal(string strTextEntry)
        {
            try
            {
                Convert.ToDecimal(strTextEntry);
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region hata

        // 
        // errorProvider1
        // 
        private ErrorProvider errorProvider;

        public static bool Empty(string value)
        {
            if (value == null || value == "")
            {
                return true;
            }
            return false;
        }

        public bool Empty(object sender)
        {
            this.errorProvider = new System.Windows.Forms.ErrorProvider();
            switch (sender.GetType().Name.ToString())
            {
                case "TextBox":
                    {
                        TextBox Send = ((TextBox)sender);
                        if (Send.Text == null || Send.Text == "" || string.IsNullOrEmpty(Send.Text))
                        {
                            errorProvider.SetError(Send, "Boş Girilemez.");
                            Send.Focus();
                            return false;
                        }
                        break;
                    }
                case "Button":
                    {
                        break;
                    }
                case "CheckBox":
                    {
                        break;
                    }
                default:
                    {

                        break;
                    }
            }

            return true;

        }

        public bool Empty(object sender, string message)
        {
            this.errorProvider = new System.Windows.Forms.ErrorProvider();
            switch (sender.GetType().Name.ToString())
            {
                case "TextBox":
                    {
                        TextBox Send = ((TextBox)sender);
                        if (Send.Text == null || Send.Text == "")
                        {
                            errorProvider.SetError(Send, message);
                            Send.Focus();
                            return false;
                        }
                        break;
                    }
                case "Button":
                    {
                        break;
                    }
                case "CheckBox":
                    {
                        break;
                    }
                default:
                    {

                        break;
                    }
            }

            return true;

        }
      
        public static void hata(object who, object which, string mesaji)
        {
            switch (which.GetType().Name.ToString())
            {
                case "TextBox":
                    {
                        
                        ((ErrorProvider)who).SetError(((TextBox)which), mesaji);
                        ((TextBox)which).Focus();
                        break;
                    }
                case "MaskedTextBox":
                    {
                        ((ErrorProvider)who).SetError(((MaskedTextBox)which), mesaji);
                        ((MaskedTextBox)which).Focus();
                        break;
                    }
            }
        }

        public static Boolean hata(object who, object which, string mesaji, int min, int max)
        {
            switch (which.GetType().Name.ToString())
            {
                case "TextBox":
                    {
                        int len = ((TextBox)which).Text.Trim().Length;
                        if (len >= min && len <= max)
                        {
                            return true;
                        }
                        else
                        {
                            ((ErrorProvider)who).SetError(((TextBox)which), mesaji);
                            ((TextBox)which).Focus();
                            return false;
                        }

                        
                    }
                case "MaskedTextBox":
                    {
                        int len = ((MaskedTextBox)which).Text.Trim().Length;
                        if (len >= min && len <= max)
                        {
                            return true;
                        }
                        else
                        {
                            ((ErrorProvider)who).SetError(((MaskedTextBox)which), mesaji);
                            ((MaskedTextBox)which).Focus();
                            return false;
                        }
                       
                    }
                default:
                    { return true; }

            }
        }

        public static Boolean hata(object who, object which, object whichagain, string mesaji)
        {
            if (((TextBox)which).Text == ((TextBox)whichagain).Text)
            {
                return true;
            }
            else
            {
                ((ErrorProvider)who).SetError(((TextBox)whichagain), mesaji);
                ((TextBox)which).Focus();
                return false;
            }
        }

        public static Boolean hata(object who, object which, string whichagain, string mesaji)
        {
            if (((TextBox)which).Text == whichagain)
            {
                return true;
            }
            else
            {
                ((ErrorProvider)who).SetError(((TextBox)which), mesaji);
                ((TextBox)which).Focus();
                return false;
            }
        }

        public static Boolean hata(object who, object which, string mesaji, int sart)
        {
            string text = ((TextBox)which).Text;
            switch (sart)
            {
                case 0:
                    {
                        if (text == "")
                        {
                            ((ErrorProvider)who).SetError(((TextBox)which), mesaji);
                            ((TextBox)which).Focus();
                            return false;
                        }

                        break;
                    }
                case 1:
                    {

                        if (IsIntager(text)==false)
                        {
                            ((ErrorProvider)who).SetError(((TextBox)which), mesaji);
                            ((TextBox)which).Focus();
                            return false;
                        }
                        break;
                    }
                case 2:
                    {
                        if (IsDecimal(text) == false)
                        {
                            ((ErrorProvider)who).SetError(((TextBox)which), mesaji);
                            ((TextBox)which).Focus();
                            return false;
                        }
                        break;
                    }
                case 3:
                    {

                        break;
                    }
                case 10:
                    {
                        if (IsNumberValidated(text) == false)
                        {
                            ((ErrorProvider)who).SetError(((TextBox)which), mesaji);
                            ((TextBox)which).Focus();
                            return false;
                        }
                        break;
                    }
                case 11:
                    {
                        if (IsTextValidated(text) == false)
                        {
                            ((ErrorProvider)who).SetError(((TextBox)which), mesaji);
                            ((TextBox)which).Focus();
                            return false;
                        }
                        break;
                    }
                case 12:
                    {
                        if (IsPasswordValidated(text) == false)
                        {
                            ((ErrorProvider)who).SetError(((TextBox)which), mesaji);
                            ((TextBox)which).Focus();
                            return false;
                        }
                        break;
                    }
                case 13:
                    {
                        if (IsMailValidated(text) == false)
                        {
                            ((ErrorProvider)who).SetError(((TextBox)which), mesaji);
                            ((TextBox)which).Focus();
                            return false;
                        }
                        break;
                    }
            }
            return true;
        }
        #endregion

        #region ClearyQuery

        public static string ClearyQuery(string Query)
        {
            Query = Regex.Replace(Query, "%", "%25");
            Query = Regex.Replace(Query, " ", "%22");
            Query = Regex.Replace(Query, ">", "%3E");
            Query = Regex.Replace(Query, "<", "%3C");

            Query = Regex.Replace(Query, " ", "%20");
            Query = Regex.Replace(Query, "&", "%26");
            Query = Regex.Replace(Query, ":", "%3A");
            Query = Regex.Replace(Query, ";", "%3B");
            Query = Regex.Replace(Query, "!", "%21");
            Query = Regex.Replace(Query, "'", "%27");
            Query = Regex.Replace(Query, "/", "%2F");

            Query = Regex.Replace(Query, "=", "%3D");
            Query = Regex.Replace(Query, "{", "%7B");
            Query = Regex.Replace(Query, "}", "%7D");
            //Query = Regex.Replace(Query,"(","%28");
            //Query = Regex.Replace(Query,")","%29");
            //Query = Regex.Replace(Query,"\\","%5C");
            //Query = Regex.Replace(Query,"?","%3F");
            //Query = Regex.Replace(Query,"+","%2B");

            Query = Regex.Replace(Query, "SELECT", "&#83elect ");
            Query = Regex.Replace(Query, "DROP", "&#68rop ");
            Query = Regex.Replace(Query, ";", "&#59 ");
            Query = Regex.Replace(Query, "--", "&#45- ");
            Query = Regex.Replace(Query, "INSERT", "&#73nsert ");
            Query = Regex.Replace(Query, "DELETE", "&#68elete ");
            Query = Regex.Replace(Query, "xp_", "&#120p&#95 ");
            Query = Regex.Replace(Query, "UNION", "&#85nion ");
            return Query;

        }

        #endregion

        #region Change Location,Size

        public static void Change_Location(object sender, int x, int y)
        {
            int X = 0, Y = 0;
            switch (sender.GetType().Name.ToString())
            {
                case "Form":
                    {
                        X = Convert.ToInt16(((Form)sender).Location.X.ToString());
                        Y = Convert.ToInt16(((Form)sender).Location.Y.ToString());
                        ((Form)sender).Location = new Point(X + x, Y + y);
                        break;
                    }
                case "Login":
                    {
                        X = Convert.ToInt16(((Form)sender).Size.Width.ToString());
                        Y = Convert.ToInt16(((Form)sender).Size.Height.ToString());
                        ((Form)sender).Size = new Size(X + x, Y + y);
                        break;
                    }
                case "Button":
                    {
                        X = Convert.ToInt16(((Button)sender).Location.X.ToString());
                        Y = Convert.ToInt16(((Button)sender).Location.Y.ToString());
                        ((PictureBox)sender).Location = new Point(X + x, Y + y);
                        break;
                    }
                case "TextBox":
                    {
                        X = Convert.ToInt16(((TextBox)sender).Location.X.ToString());
                        Y = Convert.ToInt16(((TextBox)sender).Location.Y.ToString());
                        ((TextBox)sender).Location = new Point(X + x, Y + y);
                        break;
                    }
                case "Label":
                    {
                        X = Convert.ToInt16(((Label)sender).Location.X.ToString());
                        Y = Convert.ToInt16(((Label)sender).Location.Y.ToString());
                        ((Label)sender).Location = new Point(X + x, Y + y);
                        break;
                    }
                case "PictureBox":
                    {
                        X = Convert.ToInt16(((PictureBox)sender).Location.X.ToString());
                        Y = Convert.ToInt16(((PictureBox)sender).Location.Y.ToString());
                        ((PictureBox)sender).Location = new Point(X + x, Y + y);
                        break;
                    }
            }
        }
        public static void Change_Size(object sender, int x, int y)
        {
            int X = 0, Y = 0;
            switch (sender.GetType().Name.ToString())
            {
                case "Form":
                    {
                        X = Convert.ToInt16(((Form)sender).Size.Width.ToString());
                        Y = Convert.ToInt16(((Form)sender).Size.Height.ToString());
                        ((Form)sender).Size = new Size(X + x, Y + y);
                        break;
                    }
                case "Login":
                    {
                        X = Convert.ToInt16(((Form)sender).Size.Width.ToString());
                        Y = Convert.ToInt16(((Form)sender).Size.Height.ToString());
                        ((Form)sender).Size = new Size(X + x, Y + y);
                        break;
                    }
                case "Button":
                    {
                        X = Convert.ToInt16(((Button)sender).Size.Width.ToString());
                        Y = Convert.ToInt16(((Button)sender).Size.Height.ToString());
                        ((PictureBox)sender).Size = new Size(X + x, Y + y);
                        break;
                    }
                case "TextBox":
                    {
                        X = Convert.ToInt16(((TextBox)sender).Size.Width.ToString());
                        Y = Convert.ToInt16(((TextBox)sender).Size.Height.ToString());
                        ((TextBox)sender).Size = new Size(X + x, Y + y);
                        break;
                    }
                case "Label":
                    {
                        X = Convert.ToInt16(((Label)sender).Size.Width.ToString());
                        Y = Convert.ToInt16(((Label)sender).Size.Height.ToString());
                        ((Label)sender).Size = new Size(X + x, Y + y);
                        break;
                    }
                case "PictureBox":
                    {
                        X = Convert.ToInt16(((PictureBox)sender).Size.Width.ToString());
                        Y = Convert.ToInt16(((PictureBox)sender).Size.Height.ToString());
                        ((PictureBox)sender).Size = new Size(X + x, Y + y);
                        break;
                    }
            }

        }

        #endregion

        #region File Delete

        public static void DeleteFile(string targetFile)
        {
            try
            {
                string yol = Application.StartupPath.ToString() + "\\" + targetFile;
                if (File.Exists(@yol))
                    File.Delete(@yol);
            }
            catch
            {

            }
        }
        public static void DeleteFile(string targetPath, string targetFile)
        {
            try
            {
                string yol = targetPath + "\\" + targetFile;
                if (File.Exists(@yol))
                    File.Delete(@yol);
            }
            catch
            {

            }
        }

        #endregion

        #region Add Event

        public static void AddEvent(object sender, EventHandler EvClick, EventHandler EvChange, EventHandler EvLeave)
        {
            switch (sender.GetType().Name.ToString())
            {
                case "Form":
                    {
                        break;
                    }
                case "Login":
                    {
                        break;
                    }
                case "Button":
                    {
                        break;
                    }
                case "TextBox":
                    {
                        ((TextBox)sender).Click += new System.EventHandler(EvClick);
                        ((TextBox)sender).Enter += new System.EventHandler(EvChange);
                        ((TextBox)sender).Leave += new System.EventHandler(EvLeave);
                        break;
                    }
                case "Label":
                    {
                        break;
                    }
                case "PictureBox":
                    {
                        break;
                    }
            }

        }

        public static void textLeave(object sender, EventArgs e)
        {

            ((TextBox)sender).BackColor = Color.White;
        }

        public static void textEnter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.LightYellow;
        }

        public static void EventNull(object sender, EventArgs e)
        {

        }

        #endregion

        #region RandomPassword

        public static string RandomPassword(int Charlength)
        {
            string sKey = string.Empty;
            Random oRand = new Random();
            int iChar;

            for (int i = 0; i < Charlength; i++)
            {
                iChar = oRand.Next(48, 91);
                if (iChar > 57 && iChar < 65)
                {
                    i--;
                    continue;
                }
                sKey += (char)iChar;
            }
            return sKey;
        }

        #endregion

        #region Control

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr window, int index, int value);
        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr window, int index);

        const int GWL_EXSTYLE = -20;
        const int WS_EX_TOOLWINDOW = 0x00000080;
        const int WS_EX_APPWINDOW = 0x00040000;

        
        public bool CancelClosed
        {
            get { return CancelCloser; }
            set { CancelCloser = value; }
        }
        private static bool CancelCloser = true;

        public static void CancelClose(FormClosingEventArgs e)
        {
            if (CancelCloser)
            {
                if (MessageBox.Show("Uygulamadan Çıkmak İstiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                { e.Cancel = true; }
            }
            else
                Application.Exit();
        }

        public static void ParentCancelClose(FormClosingEventArgs e)
        {
            if (CancelCloser)
            {
                if (MessageBox.Show("Uygulamadan Çıkmak İstiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                { e.Cancel = true; CancelCloser = true; }
                else
                { CancelCloser = false; Application.Exit(); }
            }
        }

    

        public static void CancelModalClose(object sender,FormClosingEventArgs e)
        {
            if (CancelCloser)
            {
                ((Form)sender).Hide();
                e.Cancel = true;
            }    
        }

        public static void AddMause(Form me, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(((Form)me).Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public static void EscClose(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        #endregion
    }