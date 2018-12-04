﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppControl_Escolar.WS_Grupo_Reference {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WS_Grupo_Reference.WS_GrupoSoap")]
    public interface WS_GrupoSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Grupo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SELECT_Grupo(string id, string nombre, string idperiodo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Grupo", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SELECT_GrupoAsync(string id, string nombre, string idperiodo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DELETE_Grupo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void DELETE_Grupo(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DELETE_Grupo", ReplyAction="*")]
        System.Threading.Tasks.Task DELETE_GrupoAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE_Grupo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void UPDATE_Grupo(int IdGrupo, int IdMateria, int IdProfesor, int IdPeriodo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE_Grupo", ReplyAction="*")]
        System.Threading.Tasks.Task UPDATE_GrupoAsync(int IdGrupo, int IdMateria, int IdProfesor, int IdPeriodo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT_Grupo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void INSERT_Grupo(int IdMateria, int IdProfesor, int IdPeriodo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT_Grupo", ReplyAction="*")]
        System.Threading.Tasks.Task INSERT_GrupoAsync(int IdMateria, int IdProfesor, int IdPeriodo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WS_GrupoSoapChannel : AppControl_Escolar.WS_Grupo_Reference.WS_GrupoSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WS_GrupoSoapClient : System.ServiceModel.ClientBase<AppControl_Escolar.WS_Grupo_Reference.WS_GrupoSoap>, AppControl_Escolar.WS_Grupo_Reference.WS_GrupoSoap {
        
        public WS_GrupoSoapClient() {
        }
        
        public WS_GrupoSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WS_GrupoSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_GrupoSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_GrupoSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet SELECT_Grupo(string id, string nombre, string idperiodo) {
            return base.Channel.SELECT_Grupo(id, nombre, idperiodo);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SELECT_GrupoAsync(string id, string nombre, string idperiodo) {
            return base.Channel.SELECT_GrupoAsync(id, nombre, idperiodo);
        }
        
        public void DELETE_Grupo(int id) {
            base.Channel.DELETE_Grupo(id);
        }
        
        public System.Threading.Tasks.Task DELETE_GrupoAsync(int id) {
            return base.Channel.DELETE_GrupoAsync(id);
        }
        
        public void UPDATE_Grupo(int IdGrupo, int IdMateria, int IdProfesor, int IdPeriodo) {
            base.Channel.UPDATE_Grupo(IdGrupo, IdMateria, IdProfesor, IdPeriodo);
        }
        
        public System.Threading.Tasks.Task UPDATE_GrupoAsync(int IdGrupo, int IdMateria, int IdProfesor, int IdPeriodo) {
            return base.Channel.UPDATE_GrupoAsync(IdGrupo, IdMateria, IdProfesor, IdPeriodo);
        }
        
        public void INSERT_Grupo(int IdMateria, int IdProfesor, int IdPeriodo) {
            base.Channel.INSERT_Grupo(IdMateria, IdProfesor, IdPeriodo);
        }
        
        public System.Threading.Tasks.Task INSERT_GrupoAsync(int IdMateria, int IdProfesor, int IdPeriodo) {
            return base.Channel.INSERT_GrupoAsync(IdMateria, IdProfesor, IdPeriodo);
        }
    }
}
