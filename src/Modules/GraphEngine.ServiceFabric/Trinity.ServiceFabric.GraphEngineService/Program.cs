﻿using System.Threading;
using Trinity.Diagnostics;
using Trinity.DynamicCluster.Storage;
using Trinity.ServiceFabric;

namespace Trinity.SampleApplication.ServiceFabric
{
    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            // Workaround: extension assembly will be removed by the
            // compiler if it is not explicitly used in the code.
            Trinity.Azure.Storage.BlobStorageConfig.Instance.ToString();

            // The ServiceManifest.XML file defines one or more service type names.
            // Registering a service maps a service type name to a .NET type.
            // When Service Fabric creates an instance of this service type,
            // an instance of the class is created in this host process.

            // When StartService returns, it is guaranteed that Global.CloudStorage
            // is fully operational, and Global.CommunicationInstance is successfully
            // started.
            GraphEngineService.StartServiceAsync("Trinity.ServiceFabric.GraphEngineServiceType").GetAwaiter().GetResult();

            // Also, pay attention that, only *master replicas of the partitions* reach here.
            // When the cluster is shutting down, it is possible that the secondary replicas
            // become the master. However, these "transient" masters will be blocked, and
            // do not reach this point.
            Log.WriteLine("Hello world from GE-SF integration!");
            var memcloud = Global.CloudStorage as DynamicMemoryCloud;

            // Prevents this host process from terminating so services keep running.
            Thread.Sleep(Timeout.Infinite);
        }
    }
}