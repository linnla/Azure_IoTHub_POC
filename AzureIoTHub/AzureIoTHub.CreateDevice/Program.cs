using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;

namespace AzureIoTHub.CreateDevice
{
    class Program
    {

        static RegistryManager registryManager;
        static string connectionString = "HostName=AzureIoTHubPOC.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=maxvsCzNfkLU+9s0/MeQp8ldRrI5cjTP3X5ATgHglHI=";

        static void Main(string[] args)
        {

            Console.WriteLine("Creating Device");

            registryManager = RegistryManager.CreateFromConnectionString(connectionString);
            AddDeviceAsync().Wait();
            
            Console.WriteLine("Device Created");
            Console.ReadLine();

        }

        private static async Task AddDeviceAsync()
        {
            string deviceId = "laureFirstDevice";
            Device device;
            try
            {
                device = await registryManager.AddDeviceAsync(new Device(deviceId));
            }
            catch (DeviceAlreadyExistsException)
            {
                device = await registryManager.GetDeviceAsync(deviceId);
            }
            Console.WriteLine("Generated device key: {0}", device.Authentication.SymmetricKey.PrimaryKey);
        }
    }
}
