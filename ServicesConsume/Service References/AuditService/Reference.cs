﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicesConsume.AuditService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Audit_IUDFormUI", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class Audit_IUDFormUI : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Tbl_Audit_IUDIdField;
        
        private System.DateTime CreatedOnField;
        
        private long CreatedOn_HijriField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CreatedByField;
        
        private System.DateTime ModifiedOnField;
        
        private long ModifiedOn_HijriField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ModifiedByField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Tbl_OrganizationIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TableNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Tbl_UserIdField;
        
        private int OperationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Tbl_RecordIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OldValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NewValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IPAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BrowserField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Tbl_Audit_IUDId {
            get {
                return this.Tbl_Audit_IUDIdField;
            }
            set {
                if ((object.ReferenceEquals(this.Tbl_Audit_IUDIdField, value) != true)) {
                    this.Tbl_Audit_IUDIdField = value;
                    this.RaisePropertyChanged("Tbl_Audit_IUDId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public System.DateTime CreatedOn {
            get {
                return this.CreatedOnField;
            }
            set {
                if ((this.CreatedOnField.Equals(value) != true)) {
                    this.CreatedOnField = value;
                    this.RaisePropertyChanged("CreatedOn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public long CreatedOn_Hijri {
            get {
                return this.CreatedOn_HijriField;
            }
            set {
                if ((this.CreatedOn_HijriField.Equals(value) != true)) {
                    this.CreatedOn_HijriField = value;
                    this.RaisePropertyChanged("CreatedOn_Hijri");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string CreatedBy {
            get {
                return this.CreatedByField;
            }
            set {
                if ((object.ReferenceEquals(this.CreatedByField, value) != true)) {
                    this.CreatedByField = value;
                    this.RaisePropertyChanged("CreatedBy");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public System.DateTime ModifiedOn {
            get {
                return this.ModifiedOnField;
            }
            set {
                if ((this.ModifiedOnField.Equals(value) != true)) {
                    this.ModifiedOnField = value;
                    this.RaisePropertyChanged("ModifiedOn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public long ModifiedOn_Hijri {
            get {
                return this.ModifiedOn_HijriField;
            }
            set {
                if ((this.ModifiedOn_HijriField.Equals(value) != true)) {
                    this.ModifiedOn_HijriField = value;
                    this.RaisePropertyChanged("ModifiedOn_Hijri");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string ModifiedBy {
            get {
                return this.ModifiedByField;
            }
            set {
                if ((object.ReferenceEquals(this.ModifiedByField, value) != true)) {
                    this.ModifiedByField = value;
                    this.RaisePropertyChanged("ModifiedBy");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string Tbl_OrganizationId {
            get {
                return this.Tbl_OrganizationIdField;
            }
            set {
                if ((object.ReferenceEquals(this.Tbl_OrganizationIdField, value) != true)) {
                    this.Tbl_OrganizationIdField = value;
                    this.RaisePropertyChanged("Tbl_OrganizationId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string TableName {
            get {
                return this.TableNameField;
            }
            set {
                if ((object.ReferenceEquals(this.TableNameField, value) != true)) {
                    this.TableNameField = value;
                    this.RaisePropertyChanged("TableName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string Tbl_UserId {
            get {
                return this.Tbl_UserIdField;
            }
            set {
                if ((object.ReferenceEquals(this.Tbl_UserIdField, value) != true)) {
                    this.Tbl_UserIdField = value;
                    this.RaisePropertyChanged("Tbl_UserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=10)]
        public int Operation {
            get {
                return this.OperationField;
            }
            set {
                if ((this.OperationField.Equals(value) != true)) {
                    this.OperationField = value;
                    this.RaisePropertyChanged("Operation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=11)]
        public string Tbl_RecordId {
            get {
                return this.Tbl_RecordIdField;
            }
            set {
                if ((object.ReferenceEquals(this.Tbl_RecordIdField, value) != true)) {
                    this.Tbl_RecordIdField = value;
                    this.RaisePropertyChanged("Tbl_RecordId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public string OldValue {
            get {
                return this.OldValueField;
            }
            set {
                if ((object.ReferenceEquals(this.OldValueField, value) != true)) {
                    this.OldValueField = value;
                    this.RaisePropertyChanged("OldValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string NewValue {
            get {
                return this.NewValueField;
            }
            set {
                if ((object.ReferenceEquals(this.NewValueField, value) != true)) {
                    this.NewValueField = value;
                    this.RaisePropertyChanged("NewValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=14)]
        public string IPAddress {
            get {
                return this.IPAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.IPAddressField, value) != true)) {
                    this.IPAddressField = value;
                    this.RaisePropertyChanged("IPAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=15)]
        public string Browser {
            get {
                return this.BrowserField;
            }
            set {
                if ((object.ReferenceEquals(this.BrowserField, value) != true)) {
                    this.BrowserField = value;
                    this.RaisePropertyChanged("Browser");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AuditService.AuditWSSoap")]
    public interface AuditWSSoap {
        
        // CODEGEN: Generating message contract since element name HelloWorldResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        ServicesConsume.AuditService.HelloWorldResponse HelloWorld(ServicesConsume.AuditService.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<ServicesConsume.AuditService.HelloWorldResponse> HelloWorldAsync(ServicesConsume.AuditService.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Add", ReplyAction="*")]
        int Add(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Add", ReplyAction="*")]
        System.Threading.Tasks.Task<int> AddAsync(int a, int b);
        
        // CODEGEN: Generating message contract since element name audit_IUDFormUI from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddAudit_IUD", ReplyAction="*")]
        ServicesConsume.AuditService.AddAudit_IUDResponse AddAudit_IUD(ServicesConsume.AuditService.AddAudit_IUDRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddAudit_IUD", ReplyAction="*")]
        System.Threading.Tasks.Task<ServicesConsume.AuditService.AddAudit_IUDResponse> AddAudit_IUDAsync(ServicesConsume.AuditService.AddAudit_IUDRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public ServicesConsume.AuditService.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(ServicesConsume.AuditService.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServicesConsume.AuditService.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(ServicesConsume.AuditService.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddAudit_IUDRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddAudit_IUD", Namespace="http://tempuri.org/", Order=0)]
        public ServicesConsume.AuditService.AddAudit_IUDRequestBody Body;
        
        public AddAudit_IUDRequest() {
        }
        
        public AddAudit_IUDRequest(ServicesConsume.AuditService.AddAudit_IUDRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AddAudit_IUDRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ServicesConsume.AuditService.Audit_IUDFormUI audit_IUDFormUI;
        
        public AddAudit_IUDRequestBody() {
        }
        
        public AddAudit_IUDRequestBody(ServicesConsume.AuditService.Audit_IUDFormUI audit_IUDFormUI) {
            this.audit_IUDFormUI = audit_IUDFormUI;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddAudit_IUDResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddAudit_IUDResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServicesConsume.AuditService.AddAudit_IUDResponseBody Body;
        
        public AddAudit_IUDResponse() {
        }
        
        public AddAudit_IUDResponse(ServicesConsume.AuditService.AddAudit_IUDResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class AddAudit_IUDResponseBody {
        
        public AddAudit_IUDResponseBody() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AuditWSSoapChannel : ServicesConsume.AuditService.AuditWSSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuditWSSoapClient : System.ServiceModel.ClientBase<ServicesConsume.AuditService.AuditWSSoap>, ServicesConsume.AuditService.AuditWSSoap {
        
        public AuditWSSoapClient() {
        }
        
        public AuditWSSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuditWSSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuditWSSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuditWSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServicesConsume.AuditService.HelloWorldResponse ServicesConsume.AuditService.AuditWSSoap.HelloWorld(ServicesConsume.AuditService.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            ServicesConsume.AuditService.HelloWorldRequest inValue = new ServicesConsume.AuditService.HelloWorldRequest();
            inValue.Body = new ServicesConsume.AuditService.HelloWorldRequestBody();
            ServicesConsume.AuditService.HelloWorldResponse retVal = ((ServicesConsume.AuditService.AuditWSSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServicesConsume.AuditService.HelloWorldResponse> ServicesConsume.AuditService.AuditWSSoap.HelloWorldAsync(ServicesConsume.AuditService.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServicesConsume.AuditService.HelloWorldResponse> HelloWorldAsync() {
            ServicesConsume.AuditService.HelloWorldRequest inValue = new ServicesConsume.AuditService.HelloWorldRequest();
            inValue.Body = new ServicesConsume.AuditService.HelloWorldRequestBody();
            return ((ServicesConsume.AuditService.AuditWSSoap)(this)).HelloWorldAsync(inValue);
        }
        
        public int Add(int a, int b) {
            return base.Channel.Add(a, b);
        }
        
        public System.Threading.Tasks.Task<int> AddAsync(int a, int b) {
            return base.Channel.AddAsync(a, b);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServicesConsume.AuditService.AddAudit_IUDResponse ServicesConsume.AuditService.AuditWSSoap.AddAudit_IUD(ServicesConsume.AuditService.AddAudit_IUDRequest request) {
            return base.Channel.AddAudit_IUD(request);
        }
        
        public void AddAudit_IUD(ServicesConsume.AuditService.Audit_IUDFormUI audit_IUDFormUI) {
            ServicesConsume.AuditService.AddAudit_IUDRequest inValue = new ServicesConsume.AuditService.AddAudit_IUDRequest();
            inValue.Body = new ServicesConsume.AuditService.AddAudit_IUDRequestBody();
            inValue.Body.audit_IUDFormUI = audit_IUDFormUI;
            ServicesConsume.AuditService.AddAudit_IUDResponse retVal = ((ServicesConsume.AuditService.AuditWSSoap)(this)).AddAudit_IUD(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServicesConsume.AuditService.AddAudit_IUDResponse> ServicesConsume.AuditService.AuditWSSoap.AddAudit_IUDAsync(ServicesConsume.AuditService.AddAudit_IUDRequest request) {
            return base.Channel.AddAudit_IUDAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServicesConsume.AuditService.AddAudit_IUDResponse> AddAudit_IUDAsync(ServicesConsume.AuditService.Audit_IUDFormUI audit_IUDFormUI) {
            ServicesConsume.AuditService.AddAudit_IUDRequest inValue = new ServicesConsume.AuditService.AddAudit_IUDRequest();
            inValue.Body = new ServicesConsume.AuditService.AddAudit_IUDRequestBody();
            inValue.Body.audit_IUDFormUI = audit_IUDFormUI;
            return ((ServicesConsume.AuditService.AuditWSSoap)(this)).AddAudit_IUDAsync(inValue);
        }
    }
}