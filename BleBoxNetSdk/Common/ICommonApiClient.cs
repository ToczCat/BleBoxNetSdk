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
        /// <returns>Nullable object that contains all information about the device</returns>
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
        /// <returns>TimeSpan of desired device uptime</returns>
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
    }
}