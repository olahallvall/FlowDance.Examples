﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookingService.CarService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CarService.ICar")]
    public interface ICar {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICar/BookCar", ReplyAction="http://tempuri.org/ICar/BookCarResponse")]
        int BookCar(string passportNumber, System.Guid traceId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICar/BookCar", ReplyAction="http://tempuri.org/ICar/BookCarResponse")]
        System.Threading.Tasks.Task<int> BookCarAsync(string passportNumber, System.Guid traceId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICarChannel : BookingService.CarService.ICar, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CarClient : System.ServiceModel.ClientBase<BookingService.CarService.ICar>, BookingService.CarService.ICar {
        
        public CarClient() {
        }
        
        public CarClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CarClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CarClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CarClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int BookCar(string passportNumber, System.Guid traceId) {
            return base.Channel.BookCar(passportNumber, traceId);
        }
        
        public System.Threading.Tasks.Task<int> BookCarAsync(string passportNumber, System.Guid traceId) {
            return base.Channel.BookCarAsync(passportNumber, traceId);
        }
    }
}
