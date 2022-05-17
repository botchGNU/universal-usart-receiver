# Universal USART Measurement Receiver

A universal GUI measurement tool for various devices data via USART

## Usage

1. Run application
2. Plug in your measurement device (driver may be needed)
3. Import device settings (see below)
4. Start measurement
5. Export as... (see below)
   1. Excel + Graph
   2. Xaml
   3. JSON
   4. SQLite Database
   5. Binary
   6. CSV


## How do I set up the application for my device?
This tool uses json files in order to store device-settings. The following is an example for the device settings used for testing.

````json
{
  "BaudRate": 57600,
  "StopBits": 1,
  "Parity": 0,
  "Handshake": 0
}
````

These setting-files can be imported in the 2nd step of the startup-configuration

## Export Examples

- Excel

  ![](Documentation\Images\excel.png)

- CSV

  ![](Documentation\Images\csv.png)

- SQLite Database

  ![](Documentation\Images\sqlite.png)
  
- JSON

  ````json
  [
    {
      "TimeStamp": "30:711",
      "Value": 157
    },
    {
      "TimeStamp": "30:711",
      "Value": 157
    },
    {
      "TimeStamp": "30:711",
      "Value": 161
    },
    {
      "TimeStamp": "30:711",
      "Value": 167
    },
    {
      "TimeStamp": "30:711",
      "Value": 175
    },
    {
      "TimeStamp": "30:711",
      "Value": 185
    }
  ]
  ````

## Used libraries

- [.NET Core 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1)
- [WPF](https://docs.microsoft.com/de-de/visualstudio/designers/getting-started-with-wpf?view=vs-2022)
- [HandyControls](https://github.com/ghost1372/HandyControls)
- [Notifications.Wpf](https://github.com/Federerer/Notifications.Wpf)
