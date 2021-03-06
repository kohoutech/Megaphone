﻿/* ----------------------------------------------------------------------------
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

using Transonic.Wave;

namespace Megaphone.Audio
{
    public class AudioFile
    {
        MegaWindow megaWindow;
        Waverly waverly;

        public String filename;
        public int sampleRate;
        public int duration;

        static public AudioFile open(MegaWindow _megaWindow, String _filename)
        {
            return new AudioFile(_megaWindow, _filename);
        }

        public AudioFile(MegaWindow _megaWindow, String _filename)
        {
            megaWindow = _megaWindow;
            waverly = megaWindow.waverly;

            filename = _filename;
            waverly.openAudioFile(filename);
            sampleRate = waverly.getAudioSampleRate();
            duration = waverly.getAudioDuration();
        }

        public void close()
        {
            waverly.closeAudioFile();
        }
    }
}
