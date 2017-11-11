using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VideoApplication
{
    public partial class PlayForm : Form
    {
        public PlayForm(string ss, string duration, string playurl)
        {
            InitializeComponent();
            string[] s = ss.Split(':');
            int starttime=int.Parse(s[0]) * 3600 + int.Parse(s[1]) * 60 + int.Parse(s[2]);
            axWindowsMediaPlayer1.URL = playurl;
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = starttime;//int.Parse(duration);
            axWindowsMediaPlayer1.Ctlcontrols.play();

        }

        private void PlayForm_Load(object sender, EventArgs e)
        {

        }

        private void PlayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            this.Close();
        }

        private void axWindowsMediaPlayer1_StatusChange(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1)
            {
                this.Close();
            }
        }
    }
}
