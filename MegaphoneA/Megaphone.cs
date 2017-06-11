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
using System.Runtime.InteropServices;
using Megaphone.IO;

namespace Megaphone
{
    public class Megaphone
    {
        //communication with signalsB
        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MegaphoneInit();

        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MegaphoneShutDown();

        //transport calls -----------------------------------------------------

        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TransportPlay();

        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TransportStop();

        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TransportPause();

        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TransportRewind();

        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TransportFastForward(int speed);

        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TransportSetVolume(float volume);

        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TransportSetBalance(float balance);

        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TransportGetCurrentPos();

        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TransportSetCurrentPos(int pos);

        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TransportSetWaveOut(int deviceIdx);

        //project calls -------------------------------------------------------

        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AudioOpen(string filename);

        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AudioClose();

        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern int AudioGetSampleRate();

        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern int AudioGetDuration();

        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern float AudioGetLeftLevel();

        [DllImport("MegaphoneB.DLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern float AudioGetRightLevel();


//- signals methods -----------------------------------------------------------

        MegaWindow megaphoneWindow;        
        public WaveDevices waveDevices;

        public Megaphone(MegaWindow _mw)
        {
            megaphoneWindow = _mw;
            waveDevices = new WaveDevices(this);
            MegaphoneInit();
        }

        public void shutDown() 
        {
            MegaphoneShutDown();
        }

//- transport methods ---------------------------------------------------------

        public void playTransport()
        {
            TransportPlay();
        }

        public void pauseTransport()
        {
            TransportPause();
        }

        public void stopTransport()
        {
            TransportStop();
        }

        public void rewindTransport()
        {
            TransportRewind();
        }

        public void fastForwardTransport(int speed)
        {
            //TransportFastForward(speed);      //doesn't work!
        }

        public void setVolume(float volume)
        {
            TransportSetVolume(volume);
        }

        public void setBalance(float balance)
        {
            TransportSetBalance(balance);
        }

        public int getCurrentPos()
        {
            return TransportGetCurrentPos();    //in samples
        }

        public void setCurrentPos(int pos)
        {
            TransportSetCurrentPos(pos);		//in samples
        }

        public void setWaveOutDevice(int devIdx)
        {
            TransportSetWaveOut(devIdx);
        }
        
//- audio data methods --------------------------------------------------------

        public void openAudioFile(String filename)
        {
            AudioOpen(filename);
        }

        public void closeAudioFile()
        {
            AudioClose();
        }

        public int getAudioSampleRate()
        {
            return AudioGetSampleRate();
        }

        public int getAudioDuration()
        {
            return AudioGetDuration();
        }

        public List<String> getInputDeviceList()
        {
            return waveDevices.getInDevNameList();
        }

        public List<String> getOutputDeviceList()
        {
            return waveDevices.getOutDevNameList();
        }

        public float getAudioLeftLevel()
        {
            return AudioGetLeftLevel();
        }

        public float getAudioRightLevel()
        {
            return AudioGetRightLevel();
        }
    }
}

//  Console.WriteLine(" there's no sun in the shadow of the wizard");
