# BleBoxNetSdk

This SDK allows you to quickly connect, read data and control all supported types of [BleBox.eu](https://technical.blebox.eu/) devices.

## Requirements and technologies

Project is based on .NET 8 with no external dependencies.   

It uses:

* Microsoft.Extensions.DependencyInjection.Abstractions 8+
* Microsoft.Extensions.Logging.Abstractions 8+

## Supported devices

SDK supports common features for all BleBox devices. (since v.1.0.0)  

Full support:

* airSensor (since v1.0.0)

## Get started

* Use the IServiceCollection extension method **RegisterSdkServices()** to register all necessary dependencies for the internal services
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

## Contributing

Feel free to add features, features requests and issues.