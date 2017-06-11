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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using Megaphone.Audio;

namespace Megaphone.Widgets
{
    public class ControlPanel : UserControl
    {
        private Button btnPlay;
        private Button btnPause;
        private Button btnStop;
        private Button btnRewind;
        private Button btnFastForward;
        private Label lblPosCounter;
        private HScrollBar hsbPosSelector;
        private HScrollBar hsbVolume;
        private HScrollBar hsbBalance;
        private Label lblVolume;
        private Label lblBalance;

        public MegaWindow megaWindow;
        public Megaphone megaphoneA;
        public AudioFile audioFile;

        public bool isPlaying;
        public bool isPaused;

        public ControlPanel(MegaWindow _megaWindow)
        {
            InitializeComponent();
            megaWindow = _megaWindow;
            megaphoneA = megaWindow.megaphoneA;

            isPlaying = false;
            isPaused = false;
        }
    
        private void InitializeComponent()
        {
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRewind = new System.Windows.Forms.Button();
            this.btnFastForward = new System.Windows.Forms.Button();
            this.lblPosCounter = new System.Windows.Forms.Label();
            this.hsbPosSelector = new System.Windows.Forms.HScrollBar();
            this.hsbVolume = new System.Windows.Forms.HScrollBar();
            this.hsbBalance = new System.Windows.Forms.HScrollBar();
            this.lblVolume = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPlay.Enabled = false;
            this.btnPlay.Location = new System.Drawing.Point(14, 12);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(52, 50);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(73, 12);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(52, 50);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Gainsboro;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(132, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(52, 50);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRewind
            // 
            this.btnRewind.BackColor = System.Drawing.Color.Gainsboro;
            this.btnRewind.Enabled = false;
            this.btnRewind.Location = new System.Drawing.Point(191, 12);
            this.btnRewind.Name = "btnRewind";
            this.btnRewind.Size = new System.Drawing.Size(52, 50);
            this.btnRewind.TabIndex = 3;
            this.btnRewind.Text = "Rewind";
            this.btnRewind.UseVisualStyleBackColor = false;
            this.btnRewind.Click += new System.EventHandler(this.btnRewind_Click);
            // 
            // btnFastForward
            // 
            this.btnFastForward.BackColor = System.Drawing.Color.Gainsboro;
            this.btnFastForward.Enabled = false;
            this.btnFastForward.Location = new System.Drawing.Point(250, 12);
            this.btnFastForward.Name = "btnFastForward";
            this.btnFastForward.Size = new System.Drawing.Size(52, 50);
            this.btnFastForward.TabIndex = 4;
            this.btnFastForward.Text = "FF";
            this.btnFastForward.UseVisualStyleBackColor = false;
            this.btnFastForward.Click += new System.EventHandler(this.btnFastForward_Click);
            // 
            // lblPosCounter
            // 
            this.lblPosCounter.BackColor = System.Drawing.Color.Black;
            this.lblPosCounter.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.lblPosCounter.ForeColor = System.Drawing.Color.Lime;
            this.lblPosCounter.Location = new System.Drawing.Point(309, 12);
            this.lblPosCounter.Name = "lblPosCounter";
            this.lblPosCounter.Size = new System.Drawing.Size(150, 25);
            this.lblPosCounter.TabIndex = 6;
            this.lblPosCounter.Text = "00:00:00.000";
            this.lblPosCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hsbPosSelector
            // 
            this.hsbPosSelector.Location = new System.Drawing.Point(309, 42);
            this.hsbPosSelector.Maximum = 1009;
            this.hsbPosSelector.Name = "hsbPosSelector";
            this.hsbPosSelector.Size = new System.Drawing.Size(150, 20);
            this.hsbPosSelector.TabIndex = 7;
            this.hsbPosSelector.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbPosSelector_Scroll);
            // 
            // hsbVolume
            // 
            this.hsbVolume.Location = new System.Drawing.Point(522, 12);
            this.hsbVolume.Maximum = 109;
            this.hsbVolume.Name = "hsbVolume";
            this.hsbVolume.Size = new System.Drawing.Size(150, 20);
            this.hsbVolume.TabIndex = 8;
            this.hsbVolume.Value = 100;
            this.hsbVolume.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbVolume_Scroll);
            // 
            // hsbBalance
            // 
            this.hsbBalance.Location = new System.Drawing.Point(522, 42);
            this.hsbBalance.Maximum = 109;
            this.hsbBalance.Name = "hsbBalance";
            this.hsbBalance.Size = new System.Drawing.Size(150, 20);
            this.hsbBalance.TabIndex = 9;
            this.hsbBalance.Value = 50;
            this.hsbBalance.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbBalance_Scroll);
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolume.ForeColor = System.Drawing.Color.White;
            this.lblVolume.Location = new System.Drawing.Point(466, 15);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(49, 15);
            this.lblVolume.TabIndex = 10;
            this.lblVolume.Text = "Volume";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.White;
            this.lblBalance.Location = new System.Drawing.Point(466, 45);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(52, 15);
            this.lblBalance.TabIndex = 11;
            this.lblBalance.Text = "Balance";
            // 
            // ControlPanel
            // 
            this.BackColor = System.Drawing.Color.DarkOrchid;
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.hsbBalance);
            this.Controls.Add(this.hsbVolume);
            this.Controls.Add(this.hsbPosSelector);
            this.Controls.Add(this.lblPosCounter);
            this.Controls.Add(this.btnFastForward);
            this.Controls.Add(this.btnRewind);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnPlay);
            this.MaximumSize = new System.Drawing.Size(690, 75);
            this.MinimumSize = new System.Drawing.Size(690, 75);
            this.Name = "ControlPanel";
            this.Size = new System.Drawing.Size(690, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void setAudio(AudioFile _audioFile)
        {
            audioFile = _audioFile;
        }

        public void clearAudio()
        {
            audioFile = null;
            hsbPosSelector.Value = 0;
            lblPosCounter.Text = "00:00:00.000";
        }

//-----------------------------------------------------------------------------

        //these buttons only make sense if we have audio to play
        public void enableTransport(Boolean on)
        {
            btnPlay.Enabled = on;
            setPlayButton(false);
            btnPause.Enabled = on;
            setPauseButton(false);
            btnStop.Enabled = on;            
        }

        public void setPlayButton(Boolean on)
        {
            isPlaying = on;
            btnPlay.BackColor = (on) ? Color.Blue : Color.Gainsboro;
            btnPlay.ForeColor = (on) ? Color.White : Color.Black;
        }

        public void setPauseButton(Boolean on)
        {
            isPaused = on;
            btnPause.BackColor = (on) ? Color.Black : Color.Gainsboro;
            btnPause.ForeColor = (on) ? Color.White : Color.Black;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            megaWindow.playTransport();
            setPlayButton(true);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            megaWindow.pauseTransport(!isPaused);
            setPauseButton(!isPaused);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            megaWindow.stopTransport();
            setPlayButton(false);
            setPauseButton(false);
        }

        private void btnRewind_Click(object sender, EventArgs e)
        {

        }

        private void btnFastForward_Click(object sender, EventArgs e)
        {
            megaWindow.fastForwardTransport();       //yikes!!
        }

        private void hsbPosSelector_Scroll(object sender, ScrollEventArgs e)
        {
            int msTime = hsbPosSelector.Value * audioFile.duration;     //duration in seconds, msTime = msec
            megaWindow.setCurrentTime(msTime);
        }

        private void hsbVolume_Scroll(object sender, ScrollEventArgs e)
        {
            float volume = hsbVolume.Value / 100.0f;
            megaphoneA.setVolume(volume);
        }

        private void hsbBalance_Scroll(object sender, ScrollEventArgs e)
        {
            float balance = hsbBalance.Value / 100.0f;
            megaphoneA.setBalance(balance);
        }
        public void timerTick(int msTime)
        {
            int msVal = msTime % 1000;
            int secPos = msTime / 1000;
            int secVal = secPos % 60;
            int minPos = secPos / 60;
            int minVal = minPos % 60;
            int hrVal = minPos / 60;
            lblPosCounter.Text = hrVal.ToString("D2") + ":" + minVal.ToString("D2") + ":" +
                secVal.ToString("D2") + "." + msVal.ToString("D3");

            int sliderPos = msTime / audioFile.duration;        //slider max val = 1000, duration in sec
            hsbPosSelector.Value = sliderPos;

            lblPosCounter.Invalidate();
            hsbPosSelector.Invalidate();
        }

    }
}
