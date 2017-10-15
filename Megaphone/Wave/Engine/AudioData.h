/* ----------------------------------------------------------------------------
LibTransWave : a library for playing, editing and storing audio wave data
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

#if !defined(AUDIODATA_H)
#define AUDIODATA_H

class Waverly;
class Transport;

class AudioData
{
	public:
	AudioData(Waverly* AWaverly);
	~AudioData();

	Waverly* AWaverly;
	Transport* transport;

	//for all channels
	int sampleRate;
	int sampleCount;		//samples stored as floats
	int duration;			//in seconds

	//for each channel
	float* level;
	float* leftPan;
	float* rightPan;
		
	inline float getLevel(int channelNum) { return level[channelNum]; }
	void setLevel(int channelNum, float _level) {level[channelNum] = _level; }
	inline float getLeftPan(int channelNum) { return leftPan[channelNum]; }
	inline float getRightPan(int channelNum) { return rightPan[channelNum]; }
	void setPan(int channelNum, float _pan) { rightPan[channelNum] = _pan; leftPan[channelNum] = 1.0f - rightPan[channelNum]; }

	//channel data
	int channelCount;
	void setchannelCount(int count);
	void getchannelData(int channelNum, float* dataBuf, int dataSize);
};

#endif // AUDIODATA_H
