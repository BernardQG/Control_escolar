﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppControl_Escolar.WSControl_Escolar_Reference {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WSControl_Escolar_Reference.WSControl_EscolarSoap")]
    public interface WSControl_EscolarSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/conexionMysql", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool conexionMysql();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/conexionMysql", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> conexionMysqlAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/conexionDataBase", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool conexionDataBase();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/conexionDataBase", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> conexionDataBaseAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UsuarioLog", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet UsuarioLog(string Usuario, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UsuarioLog", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> UsuarioLogAsync(string Usuario, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Usuario", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet Usuario([System.ServiceModel.MessageParameterAttribute(Name="Usuario")] string Usuario1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Usuario", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> UsuarioAsync(string Usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Admin", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SELECT_Admin();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Admin", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SELECT_AdminAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Pais", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SELECT_Pais();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Pais", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SELECT_PaisAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Estado", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SELECT_Estado(int IdPais);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Estado", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SELECT_EstadoAsync(int IdPais);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Municipio", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SELECT_Municipio(int IdEstado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Municipio", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SELECT_MunicipioAsync(int IdEstado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Acentamiento", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SELECT_Acentamiento(int IdMunicipio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Acentamiento", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SELECT_AcentamientoAsync(int IdMunicipio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_CP", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SELECT_CP(string cp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_CP", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SELECT_CPAsync(string cp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Alumno", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SELECT_Alumno(string id, string nombre, string inscripcion, string pagado, string carrera);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Alumno", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SELECT_AlumnoAsync(string id, string nombre, string inscripcion, string pagado, string carrera);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Carrera", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SELECT_Carrera();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Carrera", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SELECT_CarreraAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_IAlumno", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SELECT_IAlumno(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_IAlumno", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SELECT_IAlumnoAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Periodo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet SELECT_Periodo(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SELECT_Periodo", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> SELECT_PeriodoAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DELETE_Alumno", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void DELETE_Alumno(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DELETE_Alumno", ReplyAction="*")]
        System.Threading.Tasks.Task DELETE_AlumnoAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE_Sesion", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void UPDATE_Sesion(int IdUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE_Sesion", ReplyAction="*")]
        System.Threading.Tasks.Task UPDATE_SesionAsync(int IdUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE_Inscripcion", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void UPDATE_Inscripcion(int IdAlumno, int Estatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE_Inscripcion", ReplyAction="*")]
        System.Threading.Tasks.Task UPDATE_InscripcionAsync(int IdAlumno, int Estatus);
        
        // CODEGEN: Parameter 'Telefono' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE_Alumno", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        AppControl_Escolar.WSControl_Escolar_Reference.UPDATE_AlumnoResponse UPDATE_Alumno(AppControl_Escolar.WSControl_Escolar_Reference.UPDATE_AlumnoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE_Alumno", ReplyAction="*")]
        System.Threading.Tasks.Task<AppControl_Escolar.WSControl_Escolar_Reference.UPDATE_AlumnoResponse> UPDATE_AlumnoAsync(AppControl_Escolar.WSControl_Escolar_Reference.UPDATE_AlumnoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE_Periodo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void UPDATE_Periodo(int IdPeriodo, string Fecha_inicio, string Fecha_fin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UPDATE_Periodo", ReplyAction="*")]
        System.Threading.Tasks.Task UPDATE_PeriodoAsync(int IdPeriodo, string Fecha_inicio, string Fecha_fin);
        
        // CODEGEN: Parameter 'Telefono' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT_Alumno", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        AppControl_Escolar.WSControl_Escolar_Reference.INSERT_AlumnoResponse INSERT_Alumno(AppControl_Escolar.WSControl_Escolar_Reference.INSERT_AlumnoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT_Alumno", ReplyAction="*")]
        System.Threading.Tasks.Task<AppControl_Escolar.WSControl_Escolar_Reference.INSERT_AlumnoResponse> INSERT_AlumnoAsync(AppControl_Escolar.WSControl_Escolar_Reference.INSERT_AlumnoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT_Periodo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void INSERT_Periodo(string Fecha_inicio, string Fecha_fin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INSERT_Periodo", ReplyAction="*")]
        System.Threading.Tasks.Task INSERT_PeriodoAsync(string Fecha_inicio, string Fecha_fin);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UPDATE_Alumno", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class UPDATE_AlumnoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int IdAlumno;
        
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
        public int IdAcentamiento;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=12)]
        public int IdCarrera;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=13)]
        public string Fecha_inscripcion;
        
        public UPDATE_AlumnoRequest() {
        }
        
        public UPDATE_AlumnoRequest(int IdAlumno, string Nombre, string APaterno, string AMaterno, string Fecha_nacimiento, string Sexo, string Calle, string Numero, System.Nullable<int> Telefono, System.Nullable<int> Celular, string Correo, int IdAcentamiento, int IdCarrera, string Fecha_inscripcion) {
            this.IdAlumno = IdAlumno;
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
            this.IdCarrera = IdCarrera;
            this.Fecha_inscripcion = Fecha_inscripcion;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UPDATE_AlumnoResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class UPDATE_AlumnoResponse {
        
        public UPDATE_AlumnoResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="INSERT_Alumno", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class INSERT_AlumnoRequest {
        
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
        public int IdAcentamiento;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=11)]
        public int IdCarrera;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=12)]
        public string Fecha_inscripcion;
        
        public INSERT_AlumnoRequest() {
        }
        
        public INSERT_AlumnoRequest(string Nombre, string APaterno, string AMaterno, string Fecha_nacimiento, string Sexo, string Calle, string Numero, System.Nullable<int> Telefono, System.Nullable<int> Celular, string Correo, int IdAcentamiento, int IdCarrera, string Fecha_inscripcion) {
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
            this.IdCarrera = IdCarrera;
            this.Fecha_inscripcion = Fecha_inscripcion;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="INSERT_AlumnoResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class INSERT_AlumnoResponse {
        
        public INSERT_AlumnoResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WSControl_EscolarSoapChannel : AppControl_Escolar.WSControl_Escolar_Reference.WSControl_EscolarSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WSControl_EscolarSoapClient : System.ServiceModel.ClientBase<AppControl_Escolar.WSControl_Escolar_Reference.WSControl_EscolarSoap>, AppControl_Escolar.WSControl_Escolar_Reference.WSControl_EscolarSoap {
        
        public WSControl_EscolarSoapClient() {
        }
        
        public WSControl_EscolarSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WSControl_EscolarSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSControl_EscolarSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSControl_EscolarSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool conexionMysql() {
            return base.Channel.conexionMysql();
        }
        
        public System.Threading.Tasks.Task<bool> conexionMysqlAsync() {
            return base.Channel.conexionMysqlAsync();
        }
        
        public bool conexionDataBase() {
            return base.Channel.conexionDataBase();
        }
        
        public System.Threading.Tasks.Task<bool> conexionDataBaseAsync() {
            return base.Channel.conexionDataBaseAsync();
        }
        
        public System.Data.DataSet UsuarioLog(string Usuario, string Password) {
            return base.Channel.UsuarioLog(Usuario, Password);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> UsuarioLogAsync(string Usuario, string Password) {
            return base.Channel.UsuarioLogAsync(Usuario, Password);
        }
        
        public System.Data.DataSet Usuario(string Usuario1) {
            return base.Channel.Usuario(Usuario1);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> UsuarioAsync(string Usuario) {
            return base.Channel.UsuarioAsync(Usuario);
        }
        
        public System.Data.DataSet SELECT_Admin() {
            return base.Channel.SELECT_Admin();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SELECT_AdminAsync() {
            return base.Channel.SELECT_AdminAsync();
        }
        
        public System.Data.DataSet SELECT_Pais() {
            return base.Channel.SELECT_Pais();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SELECT_PaisAsync() {
            return base.Channel.SELECT_PaisAsync();
        }
        
        public System.Data.DataSet SELECT_Estado(int IdPais) {
            return base.Channel.SELECT_Estado(IdPais);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SELECT_EstadoAsync(int IdPais) {
            return base.Channel.SELECT_EstadoAsync(IdPais);
        }
        
        public System.Data.DataSet SELECT_Municipio(int IdEstado) {
            return base.Channel.SELECT_Municipio(IdEstado);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SELECT_MunicipioAsync(int IdEstado) {
            return base.Channel.SELECT_MunicipioAsync(IdEstado);
        }
        
        public System.Data.DataSet SELECT_Acentamiento(int IdMunicipio) {
            return base.Channel.SELECT_Acentamiento(IdMunicipio);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SELECT_AcentamientoAsync(int IdMunicipio) {
            return base.Channel.SELECT_AcentamientoAsync(IdMunicipio);
        }
        
        public System.Data.DataSet SELECT_CP(string cp) {
            return base.Channel.SELECT_CP(cp);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SELECT_CPAsync(string cp) {
            return base.Channel.SELECT_CPAsync(cp);
        }
        
        public System.Data.DataSet SELECT_Alumno(string id, string nombre, string inscripcion, string pagado, string carrera) {
            return base.Channel.SELECT_Alumno(id, nombre, inscripcion, pagado, carrera);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SELECT_AlumnoAsync(string id, string nombre, string inscripcion, string pagado, string carrera) {
            return base.Channel.SELECT_AlumnoAsync(id, nombre, inscripcion, pagado, carrera);
        }
        
        public System.Data.DataSet SELECT_Carrera() {
            return base.Channel.SELECT_Carrera();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SELECT_CarreraAsync() {
            return base.Channel.SELECT_CarreraAsync();
        }
        
        public System.Data.DataSet SELECT_IAlumno(int id) {
            return base.Channel.SELECT_IAlumno(id);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SELECT_IAlumnoAsync(int id) {
            return base.Channel.SELECT_IAlumnoAsync(id);
        }
        
        public System.Data.DataSet SELECT_Periodo(string id) {
            return base.Channel.SELECT_Periodo(id);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SELECT_PeriodoAsync(string id) {
            return base.Channel.SELECT_PeriodoAsync(id);
        }
        
        public void DELETE_Alumno(int id) {
            base.Channel.DELETE_Alumno(id);
        }
        
        public System.Threading.Tasks.Task DELETE_AlumnoAsync(int id) {
            return base.Channel.DELETE_AlumnoAsync(id);
        }
        
        public void UPDATE_Sesion(int IdUsuario) {
            base.Channel.UPDATE_Sesion(IdUsuario);
        }
        
        public System.Threading.Tasks.Task UPDATE_SesionAsync(int IdUsuario) {
            return base.Channel.UPDATE_SesionAsync(IdUsuario);
        }
        
        public void UPDATE_Inscripcion(int IdAlumno, int Estatus) {
            base.Channel.UPDATE_Inscripcion(IdAlumno, Estatus);
        }
        
        public System.Threading.Tasks.Task UPDATE_InscripcionAsync(int IdAlumno, int Estatus) {
            return base.Channel.UPDATE_InscripcionAsync(IdAlumno, Estatus);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AppControl_Escolar.WSControl_Escolar_Reference.UPDATE_AlumnoResponse AppControl_Escolar.WSControl_Escolar_Reference.WSControl_EscolarSoap.UPDATE_Alumno(AppControl_Escolar.WSControl_Escolar_Reference.UPDATE_AlumnoRequest request) {
            return base.Channel.UPDATE_Alumno(request);
        }
        
        public void UPDATE_Alumno(int IdAlumno, string Nombre, string APaterno, string AMaterno, string Fecha_nacimiento, string Sexo, string Calle, string Numero, System.Nullable<int> Telefono, System.Nullable<int> Celular, string Correo, int IdAcentamiento, int IdCarrera, string Fecha_inscripcion) {
            AppControl_Escolar.WSControl_Escolar_Reference.UPDATE_AlumnoRequest inValue = new AppControl_Escolar.WSControl_Escolar_Reference.UPDATE_AlumnoRequest();
            inValue.IdAlumno = IdAlumno;
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
            inValue.IdCarrera = IdCarrera;
            inValue.Fecha_inscripcion = Fecha_inscripcion;
            AppControl_Escolar.WSControl_Escolar_Reference.UPDATE_AlumnoResponse retVal = ((AppControl_Escolar.WSControl_Escolar_Reference.WSControl_EscolarSoap)(this)).UPDATE_Alumno(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<AppControl_Escolar.WSControl_Escolar_Reference.UPDATE_AlumnoResponse> AppControl_Escolar.WSControl_Escolar_Reference.WSControl_EscolarSoap.UPDATE_AlumnoAsync(AppControl_Escolar.WSControl_Escolar_Reference.UPDATE_AlumnoRequest request) {
            return base.Channel.UPDATE_AlumnoAsync(request);
        }
        
        public System.Threading.Tasks.Task<AppControl_Escolar.WSControl_Escolar_Reference.UPDATE_AlumnoResponse> UPDATE_AlumnoAsync(int IdAlumno, string Nombre, string APaterno, string AMaterno, string Fecha_nacimiento, string Sexo, string Calle, string Numero, System.Nullable<int> Telefono, System.Nullable<int> Celular, string Correo, int IdAcentamiento, int IdCarrera, string Fecha_inscripcion) {
            AppControl_Escolar.WSControl_Escolar_Reference.UPDATE_AlumnoRequest inValue = new AppControl_Escolar.WSControl_Escolar_Reference.UPDATE_AlumnoRequest();
            inValue.IdAlumno = IdAlumno;
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
            inValue.IdCarrera = IdCarrera;
            inValue.Fecha_inscripcion = Fecha_inscripcion;
            return ((AppControl_Escolar.WSControl_Escolar_Reference.WSControl_EscolarSoap)(this)).UPDATE_AlumnoAsync(inValue);
        }
        
        public void UPDATE_Periodo(int IdPeriodo, string Fecha_inicio, string Fecha_fin) {
            base.Channel.UPDATE_Periodo(IdPeriodo, Fecha_inicio, Fecha_fin);
        }
        
        public System.Threading.Tasks.Task UPDATE_PeriodoAsync(int IdPeriodo, string Fecha_inicio, string Fecha_fin) {
            return base.Channel.UPDATE_PeriodoAsync(IdPeriodo, Fecha_inicio, Fecha_fin);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        AppControl_Escolar.WSControl_Escolar_Reference.INSERT_AlumnoResponse AppControl_Escolar.WSControl_Escolar_Reference.WSControl_EscolarSoap.INSERT_Alumno(AppControl_Escolar.WSControl_Escolar_Reference.INSERT_AlumnoRequest request) {
            return base.Channel.INSERT_Alumno(request);
        }
        
        public void INSERT_Alumno(string Nombre, string APaterno, string AMaterno, string Fecha_nacimiento, string Sexo, string Calle, string Numero, System.Nullable<int> Telefono, System.Nullable<int> Celular, string Correo, int IdAcentamiento, int IdCarrera, string Fecha_inscripcion) {
            AppControl_Escolar.WSControl_Escolar_Reference.INSERT_AlumnoRequest inValue = new AppControl_Escolar.WSControl_Escolar_Reference.INSERT_AlumnoRequest();
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
            inValue.IdCarrera = IdCarrera;
            inValue.Fecha_inscripcion = Fecha_inscripcion;
            AppControl_Escolar.WSControl_Escolar_Reference.INSERT_AlumnoResponse retVal = ((AppControl_Escolar.WSControl_Escolar_Reference.WSControl_EscolarSoap)(this)).INSERT_Alumno(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<AppControl_Escolar.WSControl_Escolar_Reference.INSERT_AlumnoResponse> AppControl_Escolar.WSControl_Escolar_Reference.WSControl_EscolarSoap.INSERT_AlumnoAsync(AppControl_Escolar.WSControl_Escolar_Reference.INSERT_AlumnoRequest request) {
            return base.Channel.INSERT_AlumnoAsync(request);
        }
        
        public System.Threading.Tasks.Task<AppControl_Escolar.WSControl_Escolar_Reference.INSERT_AlumnoResponse> INSERT_AlumnoAsync(string Nombre, string APaterno, string AMaterno, string Fecha_nacimiento, string Sexo, string Calle, string Numero, System.Nullable<int> Telefono, System.Nullable<int> Celular, string Correo, int IdAcentamiento, int IdCarrera, string Fecha_inscripcion) {
            AppControl_Escolar.WSControl_Escolar_Reference.INSERT_AlumnoRequest inValue = new AppControl_Escolar.WSControl_Escolar_Reference.INSERT_AlumnoRequest();
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
            inValue.IdCarrera = IdCarrera;
            inValue.Fecha_inscripcion = Fecha_inscripcion;
            return ((AppControl_Escolar.WSControl_Escolar_Reference.WSControl_EscolarSoap)(this)).INSERT_AlumnoAsync(inValue);
        }
        
        public void INSERT_Periodo(string Fecha_inicio, string Fecha_fin) {
            base.Channel.INSERT_Periodo(Fecha_inicio, Fecha_fin);
        }
        
        public System.Threading.Tasks.Task INSERT_PeriodoAsync(string Fecha_inicio, string Fecha_fin) {
            return base.Channel.INSERT_PeriodoAsync(Fecha_inicio, Fecha_fin);
        }
    }
}
