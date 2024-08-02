namespace BleBoxNetSdk.Common.Endpoints;

internal class DeviceUptime
{
    internal class Request() : RequestBase(HttpMethod.Get, "/api/device/uptime") { }

    internal record ResponseResult
    {
        public TimeSpan UpTimeS { get; set; }
    }
}
