﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppControl_Escolar.WS_Profesor_Reference {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WS_Profesor_Reference.WS_ProfesorSoap")]
    public interface WS_ProfesorSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Profesor", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SELECT_Profesor(string id, string nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Profesor", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SELECT_ProfesorAsync(string id, string nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_IProfesor", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SELECT_IProfesor(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_IProfesor", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SELECT_IProfesorAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DELETE_Profesor", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void DELETE_Profesor(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DELETE_Profesor", ReplyAction="*")]
        System.Threading.Tasks.Task DELETE_ProfesorAsync(int id);
        
        // CODEGEN: Parameter 'Telefono' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE_Profesor", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        AppControl_Escolar.WS_Profesor_Reference.UPDATE_ProfesorResponse UPDATE_Profesor(AppControl_Escolar.WS_Profesor_Reference.UPDATE_ProfesorRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE_Profesor", ReplyAction="*")]
        System.Threading.Tasks.Task<AppControl_Escolar.WS_Profesor_Reference.UPDATE_ProfesorResponse> UPDATE_ProfesorAsync(AppControl_Escolar.WS_Profesor_Reference.UPDATE_ProfesorRequest request);
        
        // CODEGEN: Parameter 'Telefono' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT_Profesor", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        AppControl_Escolar.WS_Profesor_Reference.INSERT_ProfesorResponse INSERT_Profesor(AppControl_Escolar.WS_Profesor_Reference.INSERT_ProfesorRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT_Profesor", ReplyAction="*")]
        System.Threading.Tasks.Task<AppControl_Escolar.WS_Profesor_Reference.INSERT_ProfesorResponse> INSERT_ProfesorAsync(AppControl_Escolar.WS_Profesor_Reference.INSERT_ProfesorRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UPDATE_Profesor", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class UPDATE_ProfesorRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int IdProfesor;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string Nombre;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string APaterno;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string AMaterno;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=4)]
        public string Fecha_nacimiento;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=5)]
        public string Sexo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=6)]
        public string Calle;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=7)]
        public string Numero;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=8)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Telefono;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=9)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Celular;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=10)]
        public string Correo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=11)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> IdAcentamiento;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=12)]
        public string Grado_estudios;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=13)]
        public string Especialidad;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=14)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Folio_titulo;
        
        public UPDATE_ProfesorRequest() {
        }
        
        public UPDATE_ProfesorRequest(int IdProfesor, string Nombre, string APaterno, string AMaterno, string Fecha_nacimiento, string Sexo, string Calle, string Numero, System.Nullable<int> Telefono, System.Nullable<int> Celular, string Correo, System.Nullable<int> IdAcentamiento, string Grado_estudios, string Especialidad, System.Nullable<int> Folio_titulo) {
            this.IdProfesor = IdProfesor;
            this.Nombre = Nombre;
            this.APaterno = APaterno;
            this.AMaterno = AMaterno;
            this.Fecha_nacimiento = Fecha_nacimiento;
            this.Sexo = Sexo;
            this.Calle = Calle;
            this.Numero = Numero;
            this.Telefono = Telefono;
            this.Celular = Celular;
            this.Correo = Correo;
            this.IdAcentamiento = IdAcentamiento;
            this.Grado_estudios = Grado_estudios;
            this.Especialidad = Especialidad;
            this.Folio_titulo = Folio_titulo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UPDATE_ProfesorResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class UPDATE_ProfesorResponse {
        
        public UPDATE_ProfesorResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="INSERT_Profesor", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class INSERT_ProfesorRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string Nombre;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string APaterno;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string AMaterno;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string Fecha_nacimiento;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=4)]
        public string Sexo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=5)]
        public string Calle;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=6)]
        public string Numero;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=7)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Telefono;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=8)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Celular;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=9)]
        public string Correo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=10)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> IdAcentamiento;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=11)]
        public string Grado_estudios;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=12)]
        public string Especialidad;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=13)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Folio_titulo;
        
        public INSERT_ProfesorRequest() {
        }
        
        public INSERT_ProfesorRequest(string Nombre, string APaterno, string AMaterno, string Fecha_nacimiento, string Sexo, string Calle, string Numero, System.Nullable<int> Telefono, System.Nullable<int> Celular, string Correo, System.Nullable<int> IdAcentamiento, string Grado_estudios, string Especialidad, System.Nullable<int> Folio_titulo) {
            this.Nombre = Nombre;
            this.APaterno = APaterno;
            this.AMaterno = AMaterno;
            this.Fecha_nacimiento = Fecha_nacimiento;
            this.Sexo = Sexo;
            this.Calle = Calle;
            this.Numero = Numero;
            this.Telefono = Telefono;
            this.Celular = Celular;
            this.Correo = Correo;
            this.IdAcentamiento = IdAcentamiento;
            this.Grado_estudios = Grado_estudios;
            this.Especialidad = Especialidad;
            this.Folio_titulo = Folio_titulo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="INSERT_ProfesorResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class INSERT_ProfesorResponse {
        
        public INSERT_ProfesorResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WS_ProfesorSoapChannel : AppControl_Escolar.WS_Profesor_Reference.WS_ProfesorSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WS_ProfesorSoapClient : System.ServiceModel.ClientBase<AppControl_Escolar.WS_Profesor_Reference.WS_ProfesorSoap>, AppControl_Escolar.WS_Profesor_Reference.WS_ProfesorSoap {
        
        public WS_ProfesorSoapClient() {
        }
        
        public WS_ProfesorSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WS_ProfesorSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_ProfesorSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WS_ProfesorSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet SELECT_Profesor(string id, string nombre) {
            return base.Channel.SELECT_Profesor(id, nombre);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SELECT_ProfesorAsync(string id, string nombre) {
            return base.Channel.SELECT_ProfesorAsync(id, nombre);
        }
        
        public System.Data.DataSet SELECT_IProfesor(int id) {
            return base.Channel.SELECT_IProfesor(id);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SELECT_IProfesorAsync(int id) {
            return base.Channel.SELECT_IProfesorAsync(id);
        }
        
        public void DELETE_Profesor(int id) {
            base.Channel.DELETE_Profesor(id);
        }
        
        public System.Threading.Tasks.Task DELETE_ProfesorAsync(int id) {
            return base.Channel.DELETE_ProfesorAsync(id);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AppControl_Escolar.WS_Profesor_Reference.UPDATE_ProfesorResponse AppControl_Escolar.WS_Profesor_Reference.WS_ProfesorSoap.UPDATE_Profesor(AppControl_Escolar.WS_Profesor_Reference.UPDATE_ProfesorRequest request) {
            return base.Channel.UPDATE_Profesor(request);
        }
        
        public void UPDATE_Profesor(int IdProfesor, string Nombre, string APaterno, string AMaterno, string Fecha_nacimiento, string Sexo, string Calle, string Numero, System.Nullable<int> Telefono, System.Nullable<int> Celular, string Correo, System.Nullable<int> IdAcentamiento, string Grado_estudios, string Especialidad, System.Nullable<int> Folio_titulo) {
            AppControl_Escolar.WS_Profesor_Reference.UPDATE_ProfesorRequest inValue = new AppControl_Escolar.WS_Profesor_Reference.UPDATE_ProfesorRequest();
            inValue.IdProfesor = IdProfesor;
            inValue.Nombre = Nombre;
            inValue.APaterno = APaterno;
            inValue.AMaterno = AMaterno;
            inValue.Fecha_nacimiento = Fecha_nacimiento;
            inValue.Sexo = Sexo;
            inValue.Calle = Calle;
            inValue.Numero = Numero;
            inValue.Telefono = Telefono;
            inValue.Celular = Celular;
            inValue.Correo = Correo;
            inValue.IdAcentamiento = IdAcentamiento;
            inValue.Grado_estudios = Grado_estudios;
            inValue.Especialidad = Especialidad;
            inValue.Folio_titulo = Folio_titulo;
            AppControl_Escolar.WS_Profesor_Reference.UPDATE_ProfesorResponse retVal = ((AppControl_Escolar.WS_Profesor_Reference.WS_ProfesorSoap)(this)).UPDATE_Profesor(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<AppControl_Escolar.WS_Profesor_Reference.UPDATE_ProfesorResponse> AppControl_Escolar.WS_Profesor_Reference.WS_ProfesorSoap.UPDATE_ProfesorAsync(AppControl_Escolar.WS_Profesor_Reference.UPDATE_ProfesorRequest request) {
            return base.Channel.UPDATE_ProfesorAsync(request);
        }
        
        public System.Threading.Tasks.Task<AppControl_Escolar.WS_Profesor_Reference.UPDATE_ProfesorResponse> UPDATE_ProfesorAsync(int IdProfesor, string Nombre, string APaterno, string AMaterno, string Fecha_nacimiento, string Sexo, string Calle, string Numero, System.Nullable<int> Telefono, System.Nullable<int> Celular, string Correo, System.Nullable<int> IdAcentamiento, string Grado_estudios, string Especialidad, System.Nullable<int> Folio_titulo) {
            AppControl_Escolar.WS_Profesor_Reference.UPDATE_ProfesorRequest inValue = new AppControl_Escolar.WS_Profesor_Reference.UPDATE_ProfesorRequest();
            inValue.IdProfesor = IdProfesor;
            inValue.Nombre = Nombre;
            inValue.APaterno = APaterno;
            inValue.AMaterno = AMaterno;
            inValue.Fecha_nacimiento = Fecha_nacimiento;
            inValue.Sexo = Sexo;
            inValue.Calle = Calle;
            inValue.Numero = Numero;
            inValue.Telefono = Telefono;
            inValue.Celular = Celular;
            inValue.Correo = Correo;
            inValue.IdAcentamiento = IdAcentamiento;
            inValue.Grado_estudios = Grado_estudios;
            inValue.Especialidad = Especialidad;
            inValue.Folio_titulo = Folio_titulo;
            return ((AppControl_Escolar.WS_Profesor_Reference.WS_ProfesorSoap)(this)).UPDATE_ProfesorAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AppControl_Escolar.WS_Profesor_Reference.INSERT_ProfesorResponse AppControl_Escolar.WS_Profesor_Reference.WS_ProfesorSoap.INSERT_Profesor(AppControl_Escolar.WS_Profesor_Reference.INSERT_ProfesorRequest request) {
            return base.Channel.INSERT_Profesor(request);
        }
        
        public void INSERT_Profesor(string Nombre, string APaterno, string AMaterno, string Fecha_nacimiento, string Sexo, string Calle, string Numero, System.Nullable<int> Telefono, System.Nullable<int> Celular, string Correo, System.Nullable<int> IdAcentamiento, string Grado_estudios, string Especialidad, System.Nullable<int> Folio_titulo) {
            AppControl_Escolar.WS_Profesor_Reference.INSERT_ProfesorRequest inValue = new AppControl_Escolar.WS_Profesor_Reference.INSERT_ProfesorRequest();
            inValue.Nombre = Nombre;
            inValue.APaterno = APaterno;
            inValue.AMaterno = AMaterno;
            inValue.Fecha_nacimiento = Fecha_nacimiento;
            inValue.Sexo = Sexo;
            inValue.Calle = Calle;
            inValue.Numero = Numero;
            inValue.Telefono = Telefono;
            inValue.Celular = Celular;
            inValue.Correo = Correo;
            inValue.IdAcentamiento = IdAcentamiento;
            inValue.Grado_estudios = Grado_estudios;
            inValue.Especialidad = Especialidad;
            inValue.Folio_titulo = Folio_titulo;
            AppControl_Escolar.WS_Profesor_Reference.INSERT_ProfesorResponse retVal = ((AppControl_Escolar.WS_Profesor_Reference.WS_ProfesorSoap)(this)).INSERT_Profesor(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<AppControl_Escolar.WS_Profesor_Reference.INSERT_ProfesorResponse> AppControl_Escolar.WS_Profesor_Reference.WS_ProfesorSoap.INSERT_ProfesorAsync(AppControl_Escolar.WS_Profesor_Reference.INSERT_ProfesorRequest request) {
            return base.Channel.INSERT_ProfesorAsync(request);
        }
        
        public System.Threading.Tasks.Task<AppControl_Escolar.WS_Profesor_Reference.INSERT_ProfesorResponse> INSERT_ProfesorAsync(string Nombre, string APaterno, string AMaterno, string Fecha_nacimiento, string Sexo, string Calle, string Numero, System.Nullable<int> Telefono, System.Nullable<int> Celular, string Correo, System.Nullable<int> IdAcentamiento, string Grado_estudios, string Especialidad, System.Nullable<int> Folio_titulo) {
            AppControl_Escolar.WS_Profesor_Reference.INSERT_ProfesorRequest inValue = new AppControl_Escolar.WS_Profesor_Reference.INSERT_ProfesorRequest();
            inValue.Nombre = Nombre;
            inValue.APaterno = APaterno;
            inValue.AMaterno = AMaterno;
            inValue.Fecha_nacimiento = Fecha_nacimiento;
            inValue.Sexo = Sexo;
            inValue.Calle = Calle;
            inValue.Numero = Numero;
            inValue.Telefono = Telefono;
            inValue.Celular = Celular;
            inValue.Correo = Correo;
            inValue.IdAcentamiento = IdAcentamiento;
            inValue.Grado_estudios = Grado_estudios;
            inValue.Especialidad = Especialidad;
            inValue.Folio_titulo = Folio_titulo;
            return ((AppControl_Escolar.WS_Profesor_Reference.WS_ProfesorSoap)(this)).INSERT_ProfesorAsync(inValue);
        }
    }
}
