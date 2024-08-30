# BleBoxNetSdk

This SDK allows you to quickly connect, read data and control all supported types of [BleBox.eu](https://technical.blebox.eu/) devices.

## Requirements and technologies

Project is based on .NET 8.    

It uses:

* Microsoft.Extensions.DependencyInjection.Abstractions 8+
* Microsoft.Extensions.Logging.Abstractions 8+
* BleBoxModels 1.0.0

## Supported devices

SDK supports common features for all BleBox devices. (since v.1.0.0)  

Full support:

* airSensor (since v1.0.0)
* wLightBox (since v1.1.0)

## Get started

* Use the IServiceCollection extension method **AddBleBoxSdk()** to register all necessary dependencies for the internal services
* Register **ILogger** from Microsoft.Extensions.Logging.Abstractions to provide logging service for SDK
* Resolve api client for your BleBox device
* Use provided methods with device address, additional parameters (if needed) and optionally with your own cancellation token

## Features

All clients are registered via interface that needs to be resolved. Each method has summary and parameters description. Each method takes at least deviceAddress in the form of Uri and optionally cancellationToken: **(Uri deviceAddress, CancellationToken cancellationToken = default)**.   

All models deserialization and serialization is 100% tested with examples provided by blebox.eu

### ICommonApiClient (20200831)

[Common REST API](https://technical.blebox.eu/openapi_airsensor/openAPI_airSensor_20200831.html#tag/General)

* Info() - Returns general information about device
* GetDeviceUptime() - Returns information about number of seconds from boot
* PerformDeviceUpdate() - Perform firmware update. Return conflict if update is in progress
* SetInternalAPSettings(bool apEnable, string? apSSID, string? apPassword) - Allows to set internal access Point's ssid and password. Allows also to turn off internal AP
* PerformWiFiScan() - Perform WiFi scan and return list of found WiFi networks. Return conflict if scanning is in progress
* PerformWiFiConnect(string? ssid, string? password) - Perform connect to local WiFi network
* PerformWiFiDisconnect() - Perform disconnect from current local WiFi network

### IAirSensorApiClient (20200831)

[airSensor REST API](https://technical.blebox.eu/openapi_airsensor/openAPI_airSensor_20200831.html#tag/State)

* ForceSensorMeasurement() - Allows to force measurement immediately
* GetDeviceState() - Returns information about sensors
* GetExtendedDeviceState() - Returns extended information about sensors
* GetSensorRuntime() - Returns information about run time of internal air quality sensor
* ReadSettings() - Return device's specific settings
* WriteSettings(string deviceName, Toggle tunnelEnabled, Toggle tunnelLogEnabled, Toggle statusLed, Geolocation geolocation, Mounting mounting, Toggle detailedView) - Allow to set device's specific settings

### IWLightBoxApiClient (20200229)

[wLightBox REST API](https://technical.blebox.eu/openapi_wlightbox/openAPI_wLightBox_20200229.html#tag/Control-and-State)

* ReadStateOfLighting() - Returns information about mode, selected effect, color and transition times
* WriteSettingsSetStateOfLighting(int effectId, string desiredColor, uint colorFade, uint effectFade, uint effectStep) - Allows to set desired color, effect and transition times
* ReadExtendedStateOfLighting() - Returns information about mode, selected effect, color, transition times. Additionaly returns favorite colors and effects names
* WriteSettingsSetStateOfLighting(int effectId, string desiredColor, uint colorFade, uint effectFade, uint effectStep, Dictionary favColors) - Allows to set state of lighting - effect, color, transition times. Additionaly allows to set extended parameters - favorite colors
* Toggle() - Turning ON/OFF (toggle) last color or effect
* SetLastState() - Setting last color or effect
* SetColor(string channels) - Set color
* AdjustBrightness(Adjust adjust, string channels) - Adjust brightness
* SetEffect(int effectId) - Turning ON effect with given ID
* SetColorWithFadeTime(string channels, uint timeMs) - Set color with color fade time in milliseconds
* SetColorForATime(string channels, int timeS) - Set color for given time
* SetEffectForATime(int effectId, int timeS) - Turning ON effect with given ID
* SetColorWithFadeForATime(string channels, uint timeMs, int timeS) - Set color with color fade time for given time
* ReadSettings() - Return device's specific settings
* WriteSettings(string deviceName, Toggle tunnelEnabled, Toggle statusLed, PwmFrequency pwmFrequency, ColorMode? colorMode = null, OutputMode? outputMode = null, ButtonMode? buttonMode = null) - Allow to set device's specific settings

## Contributing

Feel free to add features requests and report issues.