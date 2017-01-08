﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prog6_Eindopdracht.ASP.TamagotchiService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Tamagotchi", Namespace="http://schemas.datacontract.org/2004/07/TamagotchiService.Data")]
    [System.SerializableAttribute()]
    public partial class Tamagotchi : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int BoredomField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateOfLastAccesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HealthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HungerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SleepField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Age {
            get {
                return this.AgeField;
            }
            set {
                if ((this.AgeField.Equals(value) != true)) {
                    this.AgeField = value;
                    this.RaisePropertyChanged("Age");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Boredom {
            get {
                return this.BoredomField;
            }
            set {
                if ((this.BoredomField.Equals(value) != true)) {
                    this.BoredomField = value;
                    this.RaisePropertyChanged("Boredom");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DateOfLastAcces {
            get {
                return this.DateOfLastAccesField;
            }
            set {
                if ((this.DateOfLastAccesField.Equals(value) != true)) {
                    this.DateOfLastAccesField = value;
                    this.RaisePropertyChanged("DateOfLastAcces");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Health {
            get {
                return this.HealthField;
            }
            set {
                if ((this.HealthField.Equals(value) != true)) {
                    this.HealthField = value;
                    this.RaisePropertyChanged("Health");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Hunger {
            get {
                return this.HungerField;
            }
            set {
                if ((this.HungerField.Equals(value) != true)) {
                    this.HungerField = value;
                    this.RaisePropertyChanged("Hunger");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Sleep {
            get {
                return this.SleepField;
            }
            set {
                if ((this.SleepField.Equals(value) != true)) {
                    this.SleepField = value;
                    this.RaisePropertyChanged("Sleep");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TamagotchiService.ITamagotchiService")]
    public interface ITamagotchiService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetTamagotchis", ReplyAction="http://tempuri.org/ITamagotchiService/GetTamagotchisResponse")]
        Prog6_Eindopdracht.ASP.TamagotchiService.Tamagotchi[] GetTamagotchis();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetTamagotchis", ReplyAction="http://tempuri.org/ITamagotchiService/GetTamagotchisResponse")]
        System.Threading.Tasks.Task<Prog6_Eindopdracht.ASP.TamagotchiService.Tamagotchi[]> GetTamagotchisAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/CreateTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/CreateTamagotchiResponse")]
        void CreateTamagotchi(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/CreateTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/CreateTamagotchiResponse")]
        System.Threading.Tasks.Task CreateTamagotchiAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/DeleteTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/DeleteTamagotchiResponse")]
        void DeleteTamagotchi(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/DeleteTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/DeleteTamagotchiResponse")]
        System.Threading.Tasks.Task DeleteTamagotchiAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GeTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/GeTamagotchiResponse")]
        Prog6_Eindopdracht.ASP.TamagotchiService.Tamagotchi GeTamagotchi(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GeTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/GeTamagotchiResponse")]
        System.Threading.Tasks.Task<Prog6_Eindopdracht.ASP.TamagotchiService.Tamagotchi> GeTamagotchiAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetCurrentTamagotchiStatus", ReplyAction="http://tempuri.org/ITamagotchiService/GetCurrentTamagotchiStatusResponse")]
        string GetCurrentTamagotchiStatus(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetCurrentTamagotchiStatus", ReplyAction="http://tempuri.org/ITamagotchiService/GetCurrentTamagotchiStatusResponse")]
        System.Threading.Tasks.Task<string> GetCurrentTamagotchiStatusAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/CanActionBePerformed", ReplyAction="http://tempuri.org/ITamagotchiService/CanActionBePerformedResponse")]
        bool CanActionBePerformed(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/CanActionBePerformed", ReplyAction="http://tempuri.org/ITamagotchiService/CanActionBePerformedResponse")]
        System.Threading.Tasks.Task<bool> CanActionBePerformedAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/CountdownAndPerformingAction", ReplyAction="http://tempuri.org/ITamagotchiService/CountdownAndPerformingActionResponse")]
        System.Collections.Generic.KeyValuePair<int, string> CountdownAndPerformingAction(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/CountdownAndPerformingAction", ReplyAction="http://tempuri.org/ITamagotchiService/CountdownAndPerformingActionResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.KeyValuePair<int, string>> CountdownAndPerformingActionAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/FeedTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/FeedTamagotchiResponse")]
        void FeedTamagotchi(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/FeedTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/FeedTamagotchiResponse")]
        System.Threading.Tasks.Task FeedTamagotchiAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/PlayWithTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/PlayWithTamagotchiResponse")]
        void PlayWithTamagotchi(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/PlayWithTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/PlayWithTamagotchiResponse")]
        System.Threading.Tasks.Task PlayWithTamagotchiAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/SleepWithTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/SleepWithTamagotchiResponse")]
        void SleepWithTamagotchi(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/SleepWithTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/SleepWithTamagotchiResponse")]
        System.Threading.Tasks.Task SleepWithTamagotchiAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/CleanTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/CleanTamagotchiResponse")]
        void CleanTamagotchi(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/CleanTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/CleanTamagotchiResponse")]
        System.Threading.Tasks.Task CleanTamagotchiAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/DoRotation", ReplyAction="http://tempuri.org/ITamagotchiService/DoRotationResponse")]
        void DoRotation();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/DoRotation", ReplyAction="http://tempuri.org/ITamagotchiService/DoRotationResponse")]
        System.Threading.Tasks.Task DoRotationAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetUpdateFrequency", ReplyAction="http://tempuri.org/ITamagotchiService/GetUpdateFrequencyResponse")]
        int GetUpdateFrequency();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetUpdateFrequency", ReplyAction="http://tempuri.org/ITamagotchiService/GetUpdateFrequencyResponse")]
        System.Threading.Tasks.Task<int> GetUpdateFrequencyAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/ChangeUpdateFrequency", ReplyAction="http://tempuri.org/ITamagotchiService/ChangeUpdateFrequencyResponse")]
        void ChangeUpdateFrequency(int amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/ChangeUpdateFrequency", ReplyAction="http://tempuri.org/ITamagotchiService/ChangeUpdateFrequencyResponse")]
        System.Threading.Tasks.Task ChangeUpdateFrequencyAsync(int amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/ResetTamagotchis", ReplyAction="http://tempuri.org/ITamagotchiService/ResetTamagotchisResponse")]
        void ResetTamagotchis();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/ResetTamagotchis", ReplyAction="http://tempuri.org/ITamagotchiService/ResetTamagotchisResponse")]
        System.Threading.Tasks.Task ResetTamagotchisAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITamagotchiServiceChannel : Prog6_Eindopdracht.ASP.TamagotchiService.ITamagotchiService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TamagotchiServiceClient : System.ServiceModel.ClientBase<Prog6_Eindopdracht.ASP.TamagotchiService.ITamagotchiService>, Prog6_Eindopdracht.ASP.TamagotchiService.ITamagotchiService {
        
        public TamagotchiServiceClient() {
        }
        
        public TamagotchiServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TamagotchiServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TamagotchiServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TamagotchiServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Prog6_Eindopdracht.ASP.TamagotchiService.Tamagotchi[] GetTamagotchis() {
            return base.Channel.GetTamagotchis();
        }
        
        public System.Threading.Tasks.Task<Prog6_Eindopdracht.ASP.TamagotchiService.Tamagotchi[]> GetTamagotchisAsync() {
            return base.Channel.GetTamagotchisAsync();
        }
        
        public void CreateTamagotchi(string name) {
            base.Channel.CreateTamagotchi(name);
        }
        
        public System.Threading.Tasks.Task CreateTamagotchiAsync(string name) {
            return base.Channel.CreateTamagotchiAsync(name);
        }
        
        public void DeleteTamagotchi(int id) {
            base.Channel.DeleteTamagotchi(id);
        }
        
        public System.Threading.Tasks.Task DeleteTamagotchiAsync(int id) {
            return base.Channel.DeleteTamagotchiAsync(id);
        }
        
        public Prog6_Eindopdracht.ASP.TamagotchiService.Tamagotchi GeTamagotchi(int id) {
            return base.Channel.GeTamagotchi(id);
        }
        
        public System.Threading.Tasks.Task<Prog6_Eindopdracht.ASP.TamagotchiService.Tamagotchi> GeTamagotchiAsync(int id) {
            return base.Channel.GeTamagotchiAsync(id);
        }
        
        public string GetCurrentTamagotchiStatus(int id) {
            return base.Channel.GetCurrentTamagotchiStatus(id);
        }
        
        public System.Threading.Tasks.Task<string> GetCurrentTamagotchiStatusAsync(int id) {
            return base.Channel.GetCurrentTamagotchiStatusAsync(id);
        }
        
        public bool CanActionBePerformed(int id) {
            return base.Channel.CanActionBePerformed(id);
        }
        
        public System.Threading.Tasks.Task<bool> CanActionBePerformedAsync(int id) {
            return base.Channel.CanActionBePerformedAsync(id);
        }
        
        public System.Collections.Generic.KeyValuePair<int, string> CountdownAndPerformingAction(int id) {
            return base.Channel.CountdownAndPerformingAction(id);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.KeyValuePair<int, string>> CountdownAndPerformingActionAsync(int id) {
            return base.Channel.CountdownAndPerformingActionAsync(id);
        }
        
        public void FeedTamagotchi(int id) {
            base.Channel.FeedTamagotchi(id);
        }
        
        public System.Threading.Tasks.Task FeedTamagotchiAsync(int id) {
            return base.Channel.FeedTamagotchiAsync(id);
        }
        
        public void PlayWithTamagotchi(int id) {
            base.Channel.PlayWithTamagotchi(id);
        }
        
        public System.Threading.Tasks.Task PlayWithTamagotchiAsync(int id) {
            return base.Channel.PlayWithTamagotchiAsync(id);
        }
        
        public void SleepWithTamagotchi(int id) {
            base.Channel.SleepWithTamagotchi(id);
        }
        
        public System.Threading.Tasks.Task SleepWithTamagotchiAsync(int id) {
            return base.Channel.SleepWithTamagotchiAsync(id);
        }
        
        public void CleanTamagotchi(int id) {
            base.Channel.CleanTamagotchi(id);
        }
        
        public System.Threading.Tasks.Task CleanTamagotchiAsync(int id) {
            return base.Channel.CleanTamagotchiAsync(id);
        }
        
        public void DoRotation() {
            base.Channel.DoRotation();
        }
        
        public System.Threading.Tasks.Task DoRotationAsync() {
            return base.Channel.DoRotationAsync();
        }
        
        public int GetUpdateFrequency() {
            return base.Channel.GetUpdateFrequency();
        }
        
        public System.Threading.Tasks.Task<int> GetUpdateFrequencyAsync() {
            return base.Channel.GetUpdateFrequencyAsync();
        }
        
        public void ChangeUpdateFrequency(int amount) {
            base.Channel.ChangeUpdateFrequency(amount);
        }
        
        public System.Threading.Tasks.Task ChangeUpdateFrequencyAsync(int amount) {
            return base.Channel.ChangeUpdateFrequencyAsync(amount);
        }
        
        public void ResetTamagotchis() {
            base.Channel.ResetTamagotchis();
        }
        
        public System.Threading.Tasks.Task ResetTamagotchisAsync() {
            return base.Channel.ResetTamagotchisAsync();
        }
    }
}
