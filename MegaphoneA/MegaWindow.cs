/* ----------------------------------------------------------------------------
Megaphone : an audio player
Copyright (C) 2005-2017  George E Greaney

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
----------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Megaphone.Audio;
using Megaphone.IO;
using Megaphone.Widgets;
using Megaphone.Dialogs;

namespace Megaphone
{
    public partial class MegaWindow : Form
    {
        //model
        public AudioFile currentAudio;
        public Megaphone megaphoneA;

        //view
        public ControlPanel controlPanel;

        bool isPaused;
        int playSpeed;

        //cons
        public MegaWindow()
        {
            InitializeComponent();
            megaphoneA = new Megaphone(this);
            currentAudio = null;

            //control panel
            controlPanel = new ControlPanel(this);
            controlPanel.Location = new Point(0, SignalsMenu.Height);
            this.Controls.Add(controlPanel);

            isPaused = false;
            playSpeed = 0;
        }

        private void SignalsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //close open file if we have one
            if (currentAudio != null)
            {
                currentAudio.close();
            }
        }


//- actions -------------------------------------------------------------------

        //audio file actions
        public void setCurrentAudio(AudioFile audioFile)
        {
            currentAudio = audioFile;
            this.Text = "Signals X-1 [" + audioFile.filename + "]";
            controlPanel.setAudio(audioFile);
            enableWithAudio(true);
        }

        public bool closeCurrentAudio()
        {
            //close open file if we have one
            if (currentAudio != null)
            {
                currentAudio.close();
            }

            controlPanel.clearAudio();
            enableWithAudio(false);
            this.Text = "Signals X-1 [none]";
            currentAudio = null;
            return true;
        }

        //transport actions
        public void playTransport()
        {
            megaphoneA.playTransport();
            masterTimer.Start();
        }

        public void pauseTransport(bool _isPaused)
        {
            megaphoneA.pauseTransport();
            if (_isPaused)
            {
                masterTimer.Stop();
            }
            else
            {
                masterTimer.Start();
            }
        }

        public void stopTransport()
        {
            megaphoneA.stopTransport();
            masterTimer.Stop();
            controlPanel.timerTick(0);
        }

        public void fastForwardTransport()
        {
            //doesn't work for now!
            //playSpeed++;
            //if (playSpeed > 3) playSpeed = 3;
            //signalsA.fastForwardTransport(playSpeed);
        }


//- file events ---------------------------------------------------------------

        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            if (!closeCurrentAudio()) return;

            //call get new project filename dialog box
            String filename = "";
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.DefaultExt = "*.wav";
            openFileDialog.Filter = "audio wave files|*.wav|All files|*.*";                
            openFileDialog.ShowDialog();
            filename = openFileDialog.FileName;
            if (filename.Length == 0) return;

            AudioFile audioFile = AudioFile.open(this, filename);
            setCurrentAudio(audioFile);
        }

        private void closeFileMenuItem_Click(object sender, EventArgs e)
        {
            closeCurrentAudio();
        }

        private void exitFileMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

//-transport events -----------------------------------------------------------

        private void settingsTransportMenuItem_Click(object sender, EventArgs e)
        {
            //call get import filename dialog box
            TransportSettingsDialog transDialog = new TransportSettingsDialog(megaphoneA.getOutputDeviceList());
            transDialog.ShowDialog();
            if (transDialog.DialogResult == DialogResult.Cancel) return;

            //not wired up yet
            int outDeviceNum = transDialog.outputDeviceNum;
            int inputLatency = transDialog.inputLatency;
            int outputLatency = transDialog.outputLatency;
        }

//- help events ---------------------------------------------------------------

        private void aboutHelpMenuItem_Click(object sender, EventArgs e)
        {
            String msg = "Megaphone\nversion 1.0.0\n" + "\xA9 Transonic Software 2005-2017\n" + "http://transonic.kohoutech.com";
            MessageBox.Show(msg, "About");
        }

//- updating ------------------------------------------------------------------

        private void masterTimer_Tick(object sender, EventArgs e)
        {
            int curPos = megaphoneA.getCurrentPos();                                //in samples
            int msTime = (int)((curPos * 1000.0f) / currentAudio.sampleRate);       //in msec

            controlPanel.timerTick(msTime);
        }

        public void setCurrentTime(int msTime)
        {
            int curPos = (int)((msTime / 1000.0f) * currentAudio.sampleRate);
            megaphoneA.setCurrentPos(curPos);

            controlPanel.timerTick(msTime);
        }

        public void setTooltip(Control child, String tipText)
        {
            signalsToolTip.SetToolTip(child, tipText);
        }

        //enable controls that only are valid with a current project
        public void enableWithAudio(bool on) {

            closeFileMenuItem.Enabled = on;
            controlPanel.enableTransport(on);
        }
    }
}
