﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webAppClient.WSAppTTSCP {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="WSAppTTSCP", ConfigurationName="WSAppTTSCP.WSAppTTSCPSoap")]
    public interface WSAppTTSCPSoap {
        
        // CODEGEN: Generating message contract since element name email from namespace WSAppTTSCP is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="WSAppTTSCP/autenticaMembro", ReplyAction="*")]
        webAppClient.WSAppTTSCP.autenticaMembroResponse autenticaMembro(webAppClient.WSAppTTSCP.autenticaMembroRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="WSAppTTSCP/autenticaMembro", ReplyAction="*")]
        System.Threading.Tasks.Task<webAppClient.WSAppTTSCP.autenticaMembroResponse> autenticaMembroAsync(webAppClient.WSAppTTSCP.autenticaMembroRequest request);
        
        // CODEGEN: Generating message contract since element name listaTurmasResult from namespace WSAppTTSCP is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="WSAppTTSCP/listaTurmas", ReplyAction="*")]
        webAppClient.WSAppTTSCP.listaTurmasResponse listaTurmas(webAppClient.WSAppTTSCP.listaTurmasRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="WSAppTTSCP/listaTurmas", ReplyAction="*")]
        System.Threading.Tasks.Task<webAppClient.WSAppTTSCP.listaTurmasResponse> listaTurmasAsync(webAppClient.WSAppTTSCP.listaTurmasRequest request);
        
        // CODEGEN: Generating message contract since element name turma from namespace WSAppTTSCP is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="WSAppTTSCP/criarTurma", ReplyAction="*")]
        webAppClient.WSAppTTSCP.criarTurmaResponse criarTurma(webAppClient.WSAppTTSCP.criarTurmaRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="WSAppTTSCP/criarTurma", ReplyAction="*")]
        System.Threading.Tasks.Task<webAppClient.WSAppTTSCP.criarTurmaResponse> criarTurmaAsync(webAppClient.WSAppTTSCP.criarTurmaRequest request);
        
        // CODEGEN: Generating message contract since element name turma from namespace WSAppTTSCP is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="WSAppTTSCP/criarMembro", ReplyAction="*")]
        webAppClient.WSAppTTSCP.criarMembroResponse criarMembro(webAppClient.WSAppTTSCP.criarMembroRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="WSAppTTSCP/criarMembro", ReplyAction="*")]
        System.Threading.Tasks.Task<webAppClient.WSAppTTSCP.criarMembroResponse> criarMembroAsync(webAppClient.WSAppTTSCP.criarMembroRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class autenticaMembroRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="autenticaMembro", Namespace="WSAppTTSCP", Order=0)]
        public webAppClient.WSAppTTSCP.autenticaMembroRequestBody Body;
        
        public autenticaMembroRequest() {
        }
        
        public autenticaMembroRequest(webAppClient.WSAppTTSCP.autenticaMembroRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="WSAppTTSCP")]
    public partial class autenticaMembroRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string email;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string pass;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string turma;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public int tipoMembro;
        
        public autenticaMembroRequestBody() {
        }
        
        public autenticaMembroRequestBody(string email, string pass, string turma, int tipoMembro) {
            this.email = email;
            this.pass = pass;
            this.turma = turma;
            this.tipoMembro = tipoMembro;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class autenticaMembroResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="autenticaMembroResponse", Namespace="WSAppTTSCP", Order=0)]
        public webAppClient.WSAppTTSCP.autenticaMembroResponseBody Body;
        
        public autenticaMembroResponse() {
        }
        
        public autenticaMembroResponse(webAppClient.WSAppTTSCP.autenticaMembroResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="WSAppTTSCP")]
    public partial class autenticaMembroResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool autenticaMembroResult;
        
        public autenticaMembroResponseBody() {
        }
        
        public autenticaMembroResponseBody(bool autenticaMembroResult) {
            this.autenticaMembroResult = autenticaMembroResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class listaTurmasRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="listaTurmas", Namespace="WSAppTTSCP", Order=0)]
        public webAppClient.WSAppTTSCP.listaTurmasRequestBody Body;
        
        public listaTurmasRequest() {
        }
        
        public listaTurmasRequest(webAppClient.WSAppTTSCP.listaTurmasRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class listaTurmasRequestBody {
        
        public listaTurmasRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class listaTurmasResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="listaTurmasResponse", Namespace="WSAppTTSCP", Order=0)]
        public webAppClient.WSAppTTSCP.listaTurmasResponseBody Body;
        
        public listaTurmasResponse() {
        }
        
        public listaTurmasResponse(webAppClient.WSAppTTSCP.listaTurmasResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="WSAppTTSCP")]
    public partial class listaTurmasResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string listaTurmasResult;
        
        public listaTurmasResponseBody() {
        }
        
        public listaTurmasResponseBody(string listaTurmasResult) {
            this.listaTurmasResult = listaTurmasResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class criarTurmaRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="criarTurma", Namespace="WSAppTTSCP", Order=0)]
        public webAppClient.WSAppTTSCP.criarTurmaRequestBody Body;
        
        public criarTurmaRequest() {
        }
        
        public criarTurmaRequest(webAppClient.WSAppTTSCP.criarTurmaRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="WSAppTTSCP")]
    public partial class criarTurmaRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string turma;
        
        public criarTurmaRequestBody() {
        }
        
        public criarTurmaRequestBody(string turma) {
            this.turma = turma;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class criarTurmaResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="criarTurmaResponse", Namespace="WSAppTTSCP", Order=0)]
        public webAppClient.WSAppTTSCP.criarTurmaResponseBody Body;
        
        public criarTurmaResponse() {
        }
        
        public criarTurmaResponse(webAppClient.WSAppTTSCP.criarTurmaResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="WSAppTTSCP")]
    public partial class criarTurmaResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string criarTurmaResult;
        
        public criarTurmaResponseBody() {
        }
        
        public criarTurmaResponseBody(string criarTurmaResult) {
            this.criarTurmaResult = criarTurmaResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class criarMembroRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="criarMembro", Namespace="WSAppTTSCP", Order=0)]
        public webAppClient.WSAppTTSCP.criarMembroRequestBody Body;
        
        public criarMembroRequest() {
        }
        
        public criarMembroRequest(webAppClient.WSAppTTSCP.criarMembroRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="WSAppTTSCP")]
    public partial class criarMembroRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string turma;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string nomeMembro;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string emailMembro;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public int tipoMembro;
        
        public criarMembroRequestBody() {
        }
        
        public criarMembroRequestBody(string turma, string nomeMembro, string emailMembro, int tipoMembro) {
            this.turma = turma;
            this.nomeMembro = nomeMembro;
            this.emailMembro = emailMembro;
            this.tipoMembro = tipoMembro;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class criarMembroResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="criarMembroResponse", Namespace="WSAppTTSCP", Order=0)]
        public webAppClient.WSAppTTSCP.criarMembroResponseBody Body;
        
        public criarMembroResponse() {
        }
        
        public criarMembroResponse(webAppClient.WSAppTTSCP.criarMembroResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="WSAppTTSCP")]
    public partial class criarMembroResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string criarMembroResult;
        
        public criarMembroResponseBody() {
        }
        
        public criarMembroResponseBody(string criarMembroResult) {
            this.criarMembroResult = criarMembroResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WSAppTTSCPSoapChannel : webAppClient.WSAppTTSCP.WSAppTTSCPSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WSAppTTSCPSoapClient : System.ServiceModel.ClientBase<webAppClient.WSAppTTSCP.WSAppTTSCPSoap>, webAppClient.WSAppTTSCP.WSAppTTSCPSoap {
        
        public WSAppTTSCPSoapClient() {
        }
        
        public WSAppTTSCPSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WSAppTTSCPSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSAppTTSCPSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSAppTTSCPSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        webAppClient.WSAppTTSCP.autenticaMembroResponse webAppClient.WSAppTTSCP.WSAppTTSCPSoap.autenticaMembro(webAppClient.WSAppTTSCP.autenticaMembroRequest request) {
            return base.Channel.autenticaMembro(request);
        }
        
        public bool autenticaMembro(string email, string pass, string turma, int tipoMembro) {
            webAppClient.WSAppTTSCP.autenticaMembroRequest inValue = new webAppClient.WSAppTTSCP.autenticaMembroRequest();
            inValue.Body = new webAppClient.WSAppTTSCP.autenticaMembroRequestBody();
            inValue.Body.email = email;
            inValue.Body.pass = pass;
            inValue.Body.turma = turma;
            inValue.Body.tipoMembro = tipoMembro;
            webAppClient.WSAppTTSCP.autenticaMembroResponse retVal = ((webAppClient.WSAppTTSCP.WSAppTTSCPSoap)(this)).autenticaMembro(inValue);
            return retVal.Body.autenticaMembroResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<webAppClient.WSAppTTSCP.autenticaMembroResponse> webAppClient.WSAppTTSCP.WSAppTTSCPSoap.autenticaMembroAsync(webAppClient.WSAppTTSCP.autenticaMembroRequest request) {
            return base.Channel.autenticaMembroAsync(request);
        }
        
        public System.Threading.Tasks.Task<webAppClient.WSAppTTSCP.autenticaMembroResponse> autenticaMembroAsync(string email, string pass, string turma, int tipoMembro) {
            webAppClient.WSAppTTSCP.autenticaMembroRequest inValue = new webAppClient.WSAppTTSCP.autenticaMembroRequest();
            inValue.Body = new webAppClient.WSAppTTSCP.autenticaMembroRequestBody();
            inValue.Body.email = email;
            inValue.Body.pass = pass;
            inValue.Body.turma = turma;
            inValue.Body.tipoMembro = tipoMembro;
            return ((webAppClient.WSAppTTSCP.WSAppTTSCPSoap)(this)).autenticaMembroAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        webAppClient.WSAppTTSCP.listaTurmasResponse webAppClient.WSAppTTSCP.WSAppTTSCPSoap.listaTurmas(webAppClient.WSAppTTSCP.listaTurmasRequest request) {
            return base.Channel.listaTurmas(request);
        }
        
        public string listaTurmas() {
            webAppClient.WSAppTTSCP.listaTurmasRequest inValue = new webAppClient.WSAppTTSCP.listaTurmasRequest();
            inValue.Body = new webAppClient.WSAppTTSCP.listaTurmasRequestBody();
            webAppClient.WSAppTTSCP.listaTurmasResponse retVal = ((webAppClient.WSAppTTSCP.WSAppTTSCPSoap)(this)).listaTurmas(inValue);
            return retVal.Body.listaTurmasResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<webAppClient.WSAppTTSCP.listaTurmasResponse> webAppClient.WSAppTTSCP.WSAppTTSCPSoap.listaTurmasAsync(webAppClient.WSAppTTSCP.listaTurmasRequest request) {
            return base.Channel.listaTurmasAsync(request);
        }
        
        public System.Threading.Tasks.Task<webAppClient.WSAppTTSCP.listaTurmasResponse> listaTurmasAsync() {
            webAppClient.WSAppTTSCP.listaTurmasRequest inValue = new webAppClient.WSAppTTSCP.listaTurmasRequest();
            inValue.Body = new webAppClient.WSAppTTSCP.listaTurmasRequestBody();
            return ((webAppClient.WSAppTTSCP.WSAppTTSCPSoap)(this)).listaTurmasAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        webAppClient.WSAppTTSCP.criarTurmaResponse webAppClient.WSAppTTSCP.WSAppTTSCPSoap.criarTurma(webAppClient.WSAppTTSCP.criarTurmaRequest request) {
            return base.Channel.criarTurma(request);
        }
        
        public string criarTurma(string turma) {
            webAppClient.WSAppTTSCP.criarTurmaRequest inValue = new webAppClient.WSAppTTSCP.criarTurmaRequest();
            inValue.Body = new webAppClient.WSAppTTSCP.criarTurmaRequestBody();
            inValue.Body.turma = turma;
            webAppClient.WSAppTTSCP.criarTurmaResponse retVal = ((webAppClient.WSAppTTSCP.WSAppTTSCPSoap)(this)).criarTurma(inValue);
            return retVal.Body.criarTurmaResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<webAppClient.WSAppTTSCP.criarTurmaResponse> webAppClient.WSAppTTSCP.WSAppTTSCPSoap.criarTurmaAsync(webAppClient.WSAppTTSCP.criarTurmaRequest request) {
            return base.Channel.criarTurmaAsync(request);
        }
        
        public System.Threading.Tasks.Task<webAppClient.WSAppTTSCP.criarTurmaResponse> criarTurmaAsync(string turma) {
            webAppClient.WSAppTTSCP.criarTurmaRequest inValue = new webAppClient.WSAppTTSCP.criarTurmaRequest();
            inValue.Body = new webAppClient.WSAppTTSCP.criarTurmaRequestBody();
            inValue.Body.turma = turma;
            return ((webAppClient.WSAppTTSCP.WSAppTTSCPSoap)(this)).criarTurmaAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        webAppClient.WSAppTTSCP.criarMembroResponse webAppClient.WSAppTTSCP.WSAppTTSCPSoap.criarMembro(webAppClient.WSAppTTSCP.criarMembroRequest request) {
            return base.Channel.criarMembro(request);
        }
        
        public string criarMembro(string turma, string nomeMembro, string emailMembro, int tipoMembro) {
            webAppClient.WSAppTTSCP.criarMembroRequest inValue = new webAppClient.WSAppTTSCP.criarMembroRequest();
            inValue.Body = new webAppClient.WSAppTTSCP.criarMembroRequestBody();
            inValue.Body.turma = turma;
            inValue.Body.nomeMembro = nomeMembro;
            inValue.Body.emailMembro = emailMembro;
            inValue.Body.tipoMembro = tipoMembro;
            webAppClient.WSAppTTSCP.criarMembroResponse retVal = ((webAppClient.WSAppTTSCP.WSAppTTSCPSoap)(this)).criarMembro(inValue);
            return retVal.Body.criarMembroResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<webAppClient.WSAppTTSCP.criarMembroResponse> webAppClient.WSAppTTSCP.WSAppTTSCPSoap.criarMembroAsync(webAppClient.WSAppTTSCP.criarMembroRequest request) {
            return base.Channel.criarMembroAsync(request);
        }
        
        public System.Threading.Tasks.Task<webAppClient.WSAppTTSCP.criarMembroResponse> criarMembroAsync(string turma, string nomeMembro, string emailMembro, int tipoMembro) {
            webAppClient.WSAppTTSCP.criarMembroRequest inValue = new webAppClient.WSAppTTSCP.criarMembroRequest();
            inValue.Body = new webAppClient.WSAppTTSCP.criarMembroRequestBody();
            inValue.Body.turma = turma;
            inValue.Body.nomeMembro = nomeMembro;
            inValue.Body.emailMembro = emailMembro;
            inValue.Body.tipoMembro = tipoMembro;
            return ((webAppClient.WSAppTTSCP.WSAppTTSCPSoap)(this)).criarMembroAsync(inValue);
        }
    }
}