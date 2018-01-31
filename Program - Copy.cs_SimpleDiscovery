//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.ServiceModel.Description;

namespace Microsoft.Samples.Discovery
{
    class Client
    {
        public static void Main()
        {
            // Create DiscoveryClient
            DiscoveryClient discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());

            Console.WriteLine("Finding IEmployeeService endpoints...");

            FindCriteria findCriteria = new FindCriteria(typeof(IEmployeeService));
            findCriteria.Duration = TimeSpan.FromSeconds(5);

            // Find IEmployeeService endpoints            
            FindResponse findResponse = discoveryClient.Find(findCriteria);
            Console.WriteLine("Found {0} IEmployeeService endpoint(s).", findResponse.Endpoints.Count);

            // Check to see if endpoints were found
            if (findResponse.Endpoints.Count > 0)
            {
                EndpointDiscoveryMetadata discoveredEndpoint = findResponse.Endpoints[0];

                // Check to see if the endpoint has a listenUri and if it differs from the Address URI
                if (discoveredEndpoint.ListenUris.Count > 0 && discoveredEndpoint.Address.Uri != discoveredEndpoint.ListenUris[0])
                {
                    // Since the service is using a unique ListenUri, it needs to be invoked at the correct ListenUri 
                    InvokeService(discoveredEndpoint.Address, discoveredEndpoint.ListenUris[0]);
                }
                else
                {
                    // Endpoint was found, however it doesn't have a unique ListenUri, hence invoke the service with only the Address URI
                    InvokeService(discoveredEndpoint.Address, null);
                }
            }

            Console.WriteLine("Press <ENTER> to exit.");
            Console.ReadLine();
        }

        static void InvokeService(EndpointAddress endpointAddress, Uri viaUri)
        {
            // Create a client
            EmployeeServiceClient client = new EmployeeServiceClient(new NetTcpBinding(), endpointAddress);
            Console.WriteLine("Invoking Service at {0}", endpointAddress.Uri);

            // if viaUri is not null then add the appropriate ClientViaBehavior.
            if (viaUri != null)
            {
                client.Endpoint.Behaviors.Add(new ClientViaBehavior(viaUri));
                Console.WriteLine("Using the viaUri {0}", viaUri);
            }

            Console.WriteLine();

            // Call the service operation.
            int employeeId = 5;
            string result = client.GetEmployeeInfo(employeeId);
            Console.WriteLine($"Employee Name for employee id {employeeId} is {result}");

            client.Close();
        }
    }
}
