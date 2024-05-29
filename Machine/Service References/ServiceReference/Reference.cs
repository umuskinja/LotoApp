﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Machine.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.ILotoService")]
    public interface ILotoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILotoService/Start", ReplyAction="http://tempuri.org/ILotoService/StartResponse")]
        void Start(int[] numbers);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILotoService/Start", ReplyAction="http://tempuri.org/ILotoService/StartResponse")]
        System.Threading.Tasks.Task StartAsync(int[] numbers);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILotoServiceChannel : Machine.ServiceReference.ILotoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LotoServiceClient : System.ServiceModel.ClientBase<Machine.ServiceReference.ILotoService>, Machine.ServiceReference.ILotoService {
        
        public LotoServiceClient() {
        }
        
        public LotoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LotoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LotoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LotoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Start(int[] numbers) {
            base.Channel.Start(numbers);
        }
        
        public System.Threading.Tasks.Task StartAsync(int[] numbers) {
            return base.Channel.StartAsync(numbers);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IPlayer", CallbackContract=typeof(Machine.ServiceReference.IPlayerCallback))]
    public interface IPlayer {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPlayer/NewTicket")]
        void NewTicket(string name, Library.Ticket ticket);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPlayer/NewTicket")]
        System.Threading.Tasks.Task NewTicketAsync(string name, Library.Ticket ticket);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPlayerCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPlayer/MessageRecieved")]
        void MessageRecieved(string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPlayerChannel : Machine.ServiceReference.IPlayer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PlayerClient : System.ServiceModel.DuplexClientBase<Machine.ServiceReference.IPlayer>, Machine.ServiceReference.IPlayer {
        
        public PlayerClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public PlayerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public PlayerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public PlayerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public PlayerClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void NewTicket(string name, Library.Ticket ticket) {
            base.Channel.NewTicket(name, ticket);
        }
        
        public System.Threading.Tasks.Task NewTicketAsync(string name, Library.Ticket ticket) {
            return base.Channel.NewTicketAsync(name, ticket);
        }
    }
}