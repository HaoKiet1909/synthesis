﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#pragma warning disable 1591

namespace ReportForm {
    
    
    /// <summary>
    ///Represents a strongly typed in-memory cache of data.
    ///</summary>
    [global::System.Serializable()]
    [global::System.ComponentModel.DesignerCategoryAttribute("code")]
    [global::System.ComponentModel.ToolboxItem(true)]
    [global::System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
    [global::System.Xml.Serialization.XmlRootAttribute("DataSet1234")]
    [global::System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class DataSet1234 : global::System.Data.DataSet {
        
        private global::System.Data.SchemaSerializationMode _schemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        public DataSet1234() {
            this.BeginInit();
            this.InitClass();
            global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        protected DataSet1234(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : 
                base(info, context, false) {
            if ((this.IsBinarySerialized(info, context) == true)) {
                this.InitVars(false);
                global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += schemaChangedHandler1;
                this.Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((this.DetermineSchemaSerializationMode(info, context) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
            }
            this.GetSerializationData(info, context);
            global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        [global::System.ComponentModel.BrowsableAttribute(true)]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public override global::System.Data.SchemaSerializationMode SchemaSerializationMode {
            get {
                return this._schemaSerializationMode;
            }
            set {
                this._schemaSerializationMode = value;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new global::System.Data.DataTableCollection Tables {
            get {
                return base.Tables;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new global::System.Data.DataRelationCollection Relations {
            get {
                return base.Relations;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        protected override void InitializeDerivedDataSet() {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        public override global::System.Data.DataSet Clone() {
            DataSet1234 cln = ((DataSet1234)(base.Clone()));
            cln.InitVars();
            cln.SchemaSerializationMode = this.SchemaSerializationMode;
            return cln;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        protected override void ReadXmlSerializable(global::System.Xml.XmlReader reader) {
            if ((this.DetermineSchemaSerializationMode(reader) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
                this.Reset();
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXml(reader);
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXml(reader);
                this.InitVars();
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        protected override global::System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            global::System.IO.MemoryStream stream = new global::System.IO.MemoryStream();
            this.WriteXmlSchema(new global::System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return global::System.Xml.Schema.XmlSchema.Read(new global::System.Xml.XmlTextReader(stream), null);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        internal void InitVars() {
            this.InitVars(true);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        internal void InitVars(bool initTable) {
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        private void InitClass() {
            this.DataSetName = "DataSet1234";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataSet1234.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        private void SchemaChanged(object sender, global::System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == global::System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(global::System.Xml.Schema.XmlSchemaSet xs) {
            DataSet1234 ds = new DataSet1234();
            global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
            global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
            global::System.Xml.Schema.XmlSchemaAny any = new global::System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
            if (xs.Contains(dsSchema.TargetNamespace)) {
                global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                try {
                    global::System.Xml.Schema.XmlSchema schema = null;
                    dsSchema.Write(s1);
                    for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); ) {
                        schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                        s2.SetLength(0);
                        schema.Write(s2);
                        if ((s1.Length == s2.Length)) {
                            s1.Position = 0;
                            s2.Position = 0;
                            for (; ((s1.Position != s1.Length) 
                                        && (s1.ReadByte() == s2.ReadByte())); ) {
                                ;
                            }
                            if ((s1.Position == s1.Length)) {
                                return type;
                            }
                        }
                    }
                }
                finally {
                    if ((s1 != null)) {
                        s1.Close();
                    }
                    if ((s2 != null)) {
                        s2.Close();
                    }
                }
            }
            xs.Add(dsSchema);
            return type;
        }
    }
}
namespace ReportForm.DataSet1234TableAdapters {
    
    
    /// <summary>
    ///Represents the connection and commands used to retrieve and save data.
    ///</summary>
    [global::System.ComponentModel.DesignerCategoryAttribute("code")]
    [global::System.ComponentModel.ToolboxItem(true)]
    [global::System.ComponentModel.DataObjectAttribute(true)]
    [global::System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner" +
        ", Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [global::System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
    public partial class QueriesTableAdapter : global::System.ComponentModel.Component {
        
        private global::System.Data.IDbCommand[] _commandCollection;
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        protected global::System.Data.IDbCommand[] CommandCollection {
            get {
                if ((this._commandCollection == null)) {
                    this.InitCommandCollection();
                }
                return this._commandCollection;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        private void InitCommandCollection() {
            this._commandCollection = new global::System.Data.IDbCommand[1];
            this._commandCollection[0] = new global::System.Data.Odbc.OdbcCommand();
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Connection = new global::System.Data.Odbc.OdbcConnection(global::ReportForm.Properties.Settings.Default.connectpd);
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).CommandText = "{CALL \"public\".\"get_tonghopdv_2024\"(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, " +
                "?, ?, ?)}";
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).CommandType = global::System.Data.CommandType.StoredProcedure;
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("start_date", global::System.Data.Odbc.OdbcType.Text, 2147483647, global::System.Data.ParameterDirection.Input, ((byte)(255)), ((byte)(255)), null, global::System.Data.DataRowVersion.Current, false, null));
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("end_date", global::System.Data.Odbc.OdbcType.Text, 2147483647, global::System.Data.ParameterDirection.Input, ((byte)(255)), ((byte)(255)), null, global::System.Data.DataRowVersion.Current, false, null));
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("idnhanvien", global::System.Data.Odbc.OdbcType.UniqueIdentifier, 2147483647, global::System.Data.ParameterDirection.Input, ((byte)(255)), ((byte)(255)), null, global::System.Data.DataRowVersion.Current, false, null));
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("stt", global::System.Data.Odbc.OdbcType.BigInt, 19, global::System.Data.ParameterDirection.Output, ((byte)(255)), ((byte)(0)), null, global::System.Data.DataRowVersion.Current, false, null));
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("person_code", global::System.Data.Odbc.OdbcType.VarChar, 2147483647, global::System.Data.ParameterDirection.Output, ((byte)(255)), ((byte)(255)), null, global::System.Data.DataRowVersion.Current, false, null));
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("full_name", global::System.Data.Odbc.OdbcType.VarChar, 2147483647, global::System.Data.ParameterDirection.Output, ((byte)(255)), ((byte)(255)), null, global::System.Data.DataRowVersion.Current, false, null));
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("sophieu", global::System.Data.Odbc.OdbcType.VarChar, 2147483647, global::System.Data.ParameterDirection.Output, ((byte)(255)), ((byte)(255)), null, global::System.Data.DataRowVersion.Current, false, null));
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("tendichvu", global::System.Data.Odbc.OdbcType.VarChar, 2147483647, global::System.Data.ParameterDirection.Output, ((byte)(255)), ((byte)(255)), null, global::System.Data.DataRowVersion.Current, false, null));
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("thoigianhoanthanh", global::System.Data.Odbc.OdbcType.Text, 2147483647, global::System.Data.ParameterDirection.Output, ((byte)(255)), ((byte)(255)), null, global::System.Data.DataRowVersion.Current, false, null));
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("inouttimes", global::System.Data.Odbc.OdbcType.VarChar, 2147483647, global::System.Data.ParameterDirection.Output, ((byte)(255)), ((byte)(255)), null, global::System.Data.DataRowVersion.Current, false, null));
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("loaiba", global::System.Data.Odbc.OdbcType.VarChar, 2147483647, global::System.Data.ParameterDirection.Output, ((byte)(255)), ((byte)(255)), null, global::System.Data.DataRowVersion.Current, false, null));
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("nhomdichvus", global::System.Data.Odbc.OdbcType.VarChar, 2147483647, global::System.Data.ParameterDirection.Output, ((byte)(255)), ((byte)(255)), null, global::System.Data.DataRowVersion.Current, false, null));
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("nhomdichvuchitiets", global::System.Data.Odbc.OdbcType.VarChar, 2147483647, global::System.Data.ParameterDirection.Output, ((byte)(255)), ((byte)(255)), null, global::System.Data.DataRowVersion.Current, false, null));
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("chinhanh", global::System.Data.Odbc.OdbcType.VarChar, 2147483647, global::System.Data.ParameterDirection.Output, ((byte)(255)), ((byte)(255)), null, global::System.Data.DataRowVersion.Current, false, null));
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("bsth", global::System.Data.Odbc.OdbcType.VarChar, 2147483647, global::System.Data.ParameterDirection.Output, ((byte)(255)), ((byte)(255)), null, global::System.Data.DataRowVersion.Current, false, null));
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("chidinhs", global::System.Data.Odbc.OdbcType.VarChar, 2147483647, global::System.Data.ParameterDirection.Output, ((byte)(255)), ((byte)(255)), null, global::System.Data.DataRowVersion.Current, false, null));
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("bnchitra", global::System.Data.Odbc.OdbcType.Double, 2147483647, global::System.Data.ParameterDirection.Output, ((byte)(15)), ((byte)(255)), null, global::System.Data.DataRowVersion.Current, false, null));
            ((global::System.Data.Odbc.OdbcCommand)(this._commandCollection[0])).Parameters.Add(new global::System.Data.Odbc.OdbcParameter("thulao", global::System.Data.Odbc.OdbcType.Double, 2147483647, global::System.Data.ParameterDirection.Output, ((byte)(15)), ((byte)(255)), null, global::System.Data.DataRowVersion.Current, false, null));
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
        [global::System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        public virtual int get_tonghopdv_2024(
                    string start_date, 
                    string end_date, 
                    global::System.Nullable<global::System.Guid> idnhanvien, 
                    out global::System.Nullable<long> stt, 
                    out string person_code, 
                    out string full_name, 
                    out string sophieu, 
                    out string tendichvu, 
                    out string thoigianhoanthanh, 
                    out string inouttimes, 
                    out string loaiba, 
                    out string nhomdichvus, 
                    out string nhomdichvuchitiets, 
                    out string chinhanh, 
                    out string bsth, 
                    out string chidinhs, 
                    out global::System.Nullable<double> bnchitra, 
                    out global::System.Nullable<double> thulao) {
            global::System.Data.Odbc.OdbcCommand command = ((global::System.Data.Odbc.OdbcCommand)(this.CommandCollection[0]));
            if ((start_date == null)) {
                command.Parameters[0].Value = global::System.DBNull.Value;
            }
            else {
                command.Parameters[0].Value = ((string)(start_date));
            }
            if ((end_date == null)) {
                command.Parameters[1].Value = global::System.DBNull.Value;
            }
            else {
                command.Parameters[1].Value = ((string)(end_date));
            }
            if ((idnhanvien.HasValue == true)) {
                command.Parameters[2].Value = ((System.Guid)(idnhanvien.Value));
            }
            else {
                command.Parameters[2].Value = global::System.DBNull.Value;
            }
            global::System.Data.ConnectionState previousConnectionState = command.Connection.State;
            if (((command.Connection.State & global::System.Data.ConnectionState.Open) 
                        != global::System.Data.ConnectionState.Open)) {
                command.Connection.Open();
            }
            int returnValue;
            try {
                returnValue = command.ExecuteNonQuery();
            }
            finally {
                if ((previousConnectionState == global::System.Data.ConnectionState.Closed)) {
                    command.Connection.Close();
                }
            }
            if (((command.Parameters[3].Value == null) 
                        || (command.Parameters[3].Value.GetType() == typeof(global::System.DBNull)))) {
                stt = new global::System.Nullable<long>();
            }
            else {
                stt = new global::System.Nullable<long>(((long)(command.Parameters[3].Value)));
            }
            if (((command.Parameters[4].Value == null) 
                        || (command.Parameters[4].Value.GetType() == typeof(global::System.DBNull)))) {
                person_code = null;
            }
            else {
                person_code = ((string)(command.Parameters[4].Value));
            }
            if (((command.Parameters[5].Value == null) 
                        || (command.Parameters[5].Value.GetType() == typeof(global::System.DBNull)))) {
                full_name = null;
            }
            else {
                full_name = ((string)(command.Parameters[5].Value));
            }
            if (((command.Parameters[6].Value == null) 
                        || (command.Parameters[6].Value.GetType() == typeof(global::System.DBNull)))) {
                sophieu = null;
            }
            else {
                sophieu = ((string)(command.Parameters[6].Value));
            }
            if (((command.Parameters[7].Value == null) 
                        || (command.Parameters[7].Value.GetType() == typeof(global::System.DBNull)))) {
                tendichvu = null;
            }
            else {
                tendichvu = ((string)(command.Parameters[7].Value));
            }
            if (((command.Parameters[8].Value == null) 
                        || (command.Parameters[8].Value.GetType() == typeof(global::System.DBNull)))) {
                thoigianhoanthanh = null;
            }
            else {
                thoigianhoanthanh = ((string)(command.Parameters[8].Value));
            }
            if (((command.Parameters[9].Value == null) 
                        || (command.Parameters[9].Value.GetType() == typeof(global::System.DBNull)))) {
                inouttimes = null;
            }
            else {
                inouttimes = ((string)(command.Parameters[9].Value));
            }
            if (((command.Parameters[10].Value == null) 
                        || (command.Parameters[10].Value.GetType() == typeof(global::System.DBNull)))) {
                loaiba = null;
            }
            else {
                loaiba = ((string)(command.Parameters[10].Value));
            }
            if (((command.Parameters[11].Value == null) 
                        || (command.Parameters[11].Value.GetType() == typeof(global::System.DBNull)))) {
                nhomdichvus = null;
            }
            else {
                nhomdichvus = ((string)(command.Parameters[11].Value));
            }
            if (((command.Parameters[12].Value == null) 
                        || (command.Parameters[12].Value.GetType() == typeof(global::System.DBNull)))) {
                nhomdichvuchitiets = null;
            }
            else {
                nhomdichvuchitiets = ((string)(command.Parameters[12].Value));
            }
            if (((command.Parameters[13].Value == null) 
                        || (command.Parameters[13].Value.GetType() == typeof(global::System.DBNull)))) {
                chinhanh = null;
            }
            else {
                chinhanh = ((string)(command.Parameters[13].Value));
            }
            if (((command.Parameters[14].Value == null) 
                        || (command.Parameters[14].Value.GetType() == typeof(global::System.DBNull)))) {
                bsth = null;
            }
            else {
                bsth = ((string)(command.Parameters[14].Value));
            }
            if (((command.Parameters[15].Value == null) 
                        || (command.Parameters[15].Value.GetType() == typeof(global::System.DBNull)))) {
                chidinhs = null;
            }
            else {
                chidinhs = ((string)(command.Parameters[15].Value));
            }
            if (((command.Parameters[16].Value == null) 
                        || (command.Parameters[16].Value.GetType() == typeof(global::System.DBNull)))) {
                bnchitra = new global::System.Nullable<double>();
            }
            else {
                bnchitra = new global::System.Nullable<double>(((double)(command.Parameters[16].Value)));
            }
            if (((command.Parameters[17].Value == null) 
                        || (command.Parameters[17].Value.GetType() == typeof(global::System.DBNull)))) {
                thulao = new global::System.Nullable<double>();
            }
            else {
                thulao = new global::System.Nullable<double>(((double)(command.Parameters[17].Value)));
            }
            return returnValue;
        }
    }
}

#pragma warning restore 1591