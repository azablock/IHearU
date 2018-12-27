using NAudio.Midi;

namespace Models.Voice.Util {

  public static class MidiDeviceFinder {

    public static MidiOut MidiOutByDeviceName(string name) {
      var midiOutDeviceNo = 0;
      
      for (var deviceNo = 0; deviceNo < MidiOut.NumberOfDevices; deviceNo++) {
        if (MidiOut.DeviceInfo(deviceNo).ProductName.Equals(name)) {
          break;
        }
        midiOutDeviceNo++;
      }

      return new MidiOut(midiOutDeviceNo);
    }
  }
}