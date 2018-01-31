using System.ServiceModel;
namespace SimpleDiscovery
{
    [ServiceContract(Namespace = "http://WCFDiscovery", ConfigurationName = "IEmployeeService")]
    public interface IEmployeeService
    {
        [OperationContract(ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Action = "http://WCFDiscovery/IEmployeeService/GetEmployeeInfo", ReplyAction = "http://WCFDiscovery/IEmployeeService/GetEmployeeInfoResponse")]
        string GetEmployeeInfo(int id);      
    }

    public partial class EmployeeServiceClient :ClientBase<IEmployeeService>, IEmployeeService
    {

        public EmployeeServiceClient()
        {
        }

        public EmployeeServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public EmployeeServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public EmployeeServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public EmployeeServiceClient(System.ServiceModel.Channels.Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

       
        public string GetEmployeeInfo(int id)
        {
           return Channel.GetEmployeeInfo(id);
        }
    }
}
