using BleBoxNetSdk.Common.Models;

namespace BleBoxNetSdk.Common
{
    public interface ICommonApiClient
    {
        /// <summary>
        /// Returns general information about device
        /// </summary>
        /// <param name="deviceAddress">Url to desired device</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <exception cref="ArgumentNullException">Received json is null</exception>
        /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
        /// <exception cref="NotSupportedException">There is no compatible converter</exception>
        /// <exception cref="Exception">Request to API failed</exception>
        Task<Device?> Info(Uri deviceAddress, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns information about number of seconds from boot
        /// </summary>
        /// <param name="deviceAddress">Url to desired device</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <exception cref="ArgumentNullException">Received json is null</exception>
        /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
        /// <exception cref="NotSupportedException">There is no compatible converter</exception>
        /// <exception cref="Exception">Request to API failed</exception>
        Task<TimeSpan> GetDeviceUptime(Uri deviceAddress, CancellationToken cancellationToken = default);

        /// <summary>
        /// Perform firmware update. Return conflict if update is in progress
        /// </summary>
        /// <param name="deviceAddress">Url to desired device</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <exception cref="ArgumentNullException">Received json is null</exception>
        /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
        /// <exception cref="NotSupportedException">There is no compatible converter</exception>
        /// <exception cref="Exception">Request to API failed. Device update may be in progress</exception>
        Task PerformDeviceUpdate(Uri deviceAddress, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns information about internal WiFi AP or about connected local WiFi network
        /// </summary>
        /// <param name="deviceAddress">Url to desired device</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <exception cref="ArgumentNullException">Received json is null</exception>
        /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
        /// <exception cref="NotSupportedException">There is no compatible converter</exception>
        /// <exception cref="Exception">Request to API failed. Device update may be in progress</exception>
        Task<Network?> GetNetworkInformation(Uri deviceAddress, CancellationToken cancellationToken = default);

        /// <summary>
        /// Allows to set internal access Point's ssid and password. Allows also to turn off internal AP
        /// </summary>
        /// <param name="deviceAddress">Url to desired device</param>
        /// <param name="apEnable">Parameter that show if internal WiFi Access Point is enabled</param>
        /// <param name="apSSID">SSID of internal WiFi access Point</param>
        /// <param name="apPassword">Password of internal WiFi Access Point</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <exception cref="ArgumentNullException">Received json is null</exception>
        /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
        /// <exception cref="NotSupportedException">There is no compatible converter</exception>
        /// <exception cref="Exception">Request to API failed. Device update may be in progress</exception>
        Task<(Device? device, Network? network)> SetInternalAPSettings(
            Uri deviceAddress,
            bool apEnable,
            string? apSSID,
            string? apPassword,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Perform WiFi scan and return list of found WiFi networks. Return conflict if scanning is in progress
        /// </summary>
        /// <param name="deviceAddress">Url to desired device</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <exception cref="ArgumentNullException">Received json is null</exception>
        /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
        /// <exception cref="NotSupportedException">There is no compatible converter</exception>
        /// <exception cref="Exception">Request to API failed. Device update may be in progress</exception>
        Task<AccessPoint[]?> PerformWiFiScan(Uri deviceAddress, CancellationToken cancellationToken = default);

        /// <summary>
        /// Perform connect to local WiFi network
        /// </summary>
        /// <param name="deviceAddress">Url to desired device</param>
        /// <param name="ssid">SSID of WiFi network, empty string will disconnect from WiFi network</param>
        /// <param name="password">Password to WiFi network, empty string or 'null' indicates open mode (without password)</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <exception cref="ArgumentNullException">Received json is null</exception>
        /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
        /// <exception cref="NotSupportedException">There is no compatible converter</exception>
        /// <exception cref="Exception">Request to API failed. Device update may be in progress</exception>
        Task<Network?> PerformWiFiConnect(
            Uri deviceAddress,
            string? ssid,
            string? password,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Perform disconnect from current local WiFi network
        /// </summary>
        /// <param name="deviceAddress">Url to desired device</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <exception cref="ArgumentNullException">Received json is null</exception>
        /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
        /// <exception cref="NotSupportedException">There is no compatible converter</exception>
        /// <exception cref="Exception">Request to API failed. Device update may be in progress</exception>
        Task<Network?> PerformWiFiDisconnect(Uri deviceAddress, CancellationToken cancellationToken = default);
    }
}