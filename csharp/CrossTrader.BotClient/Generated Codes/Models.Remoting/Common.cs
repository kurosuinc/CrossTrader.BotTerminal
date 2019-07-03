// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: common.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace CrossTrader.Models.Remoting {

  /// <summary>Holder for reflection information generated from common.proto</summary>
  internal static partial class CommonReflection {

    #region Descriptor
    /// <summary>File descriptor for common.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static CommonReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cgxjb21tb24ucHJvdG8SC2Nyb3NzdHJhZGVyIhsKC05hbWVSZXF1ZXN0EgwK",
            "BG5hbWUYASABKAkiKwoTSW5zdHJ1bWVudElkUmVxdWVzdBIUCgxpbnN0cnVt",
            "ZW50SWQYASABKAUiLQoUSW5zdHJ1bWVudElkc1JlcXVlc3QSFQoNaW5zdHJ1",
            "bWVudElkcxgBIAMoBSoxCg1DaGFuZ2VkQWN0aW9uEgcKA0FERBAAEgsKB1JF",
            "UExBQ0UQARIKCgZSRU1PVkUQAiozCglPcmRlclNpZGUSEwoPT1JERVJfU0lE",
            "RV9OT05FEAASBwoDQlVZEAESCAoEU0VMTBACKoMBCgpPcmRlclN0YXRlEhQK",
            "EE9SREVSX1NUQVRFX05PTkUQABIOCgpSRVFVRVNUSU5HEAESCgoGRkFJTEVE",
            "EAISCgoGQUNUSVZFEAMSDQoJQ09NUExFVEVEEAQSDQoJQ0FOQ0VMSU5HEAUS",
            "DAoIQ0FOQ0VMRUQQBhILCgdFWFBJUkVEEAcqTwoJT3JkZXJUeXBlEhMKD09S",
            "REVSX1RZUEVfTk9ORRAAEgkKBUxJTUlUEAESCgoGTUFSS0VUEAISFgoST1JE",
            "RVJfVFlQRV9VTktOT1dOEANCHqoCG0Nyb3NzVHJhZGVyLk1vZGVscy5SZW1v",
            "dGluZ2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::CrossTrader.Models.Remoting.ChangedAction), typeof(global::CrossTrader.Models.Remoting.OrderSide), typeof(global::CrossTrader.Models.Remoting.OrderState), typeof(global::CrossTrader.Models.Remoting.OrderType), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.NameRequest), global::CrossTrader.Models.Remoting.NameRequest.Parser, new[]{ "Name" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.InstrumentIdRequest), global::CrossTrader.Models.Remoting.InstrumentIdRequest.Parser, new[]{ "InstrumentId" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.InstrumentIdsRequest), global::CrossTrader.Models.Remoting.InstrumentIdsRequest.Parser, new[]{ "InstrumentIds" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  internal enum ChangedAction {
    [pbr::OriginalName("ADD")] Add = 0,
    [pbr::OriginalName("REPLACE")] Replace = 1,
    [pbr::OriginalName("REMOVE")] Remove = 2,
  }

  internal enum OrderSide {
    [pbr::OriginalName("ORDER_SIDE_NONE")] None = 0,
    [pbr::OriginalName("BUY")] Buy = 1,
    [pbr::OriginalName("SELL")] Sell = 2,
  }

  internal enum OrderState {
    [pbr::OriginalName("ORDER_STATE_NONE")] None = 0,
    [pbr::OriginalName("REQUESTING")] Requesting = 1,
    [pbr::OriginalName("FAILED")] Failed = 2,
    [pbr::OriginalName("ACTIVE")] Active = 3,
    [pbr::OriginalName("COMPLETED")] Completed = 4,
    [pbr::OriginalName("CANCELING")] Canceling = 5,
    [pbr::OriginalName("CANCELED")] Canceled = 6,
    [pbr::OriginalName("EXPIRED")] Expired = 7,
  }

  internal enum OrderType {
    [pbr::OriginalName("ORDER_TYPE_NONE")] None = 0,
    [pbr::OriginalName("LIMIT")] Limit = 1,
    [pbr::OriginalName("MARKET")] Market = 2,
    [pbr::OriginalName("ORDER_TYPE_UNKNOWN")] Unknown = 3,
  }

  #endregion

  #region Messages
  internal sealed partial class NameRequest : pb::IMessage<NameRequest> {
    private static readonly pb::MessageParser<NameRequest> _parser = new pb::MessageParser<NameRequest>(() => new NameRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<NameRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CrossTrader.Models.Remoting.CommonReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NameRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NameRequest(NameRequest other) : this() {
      name_ = other.name_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NameRequest Clone() {
      return new NameRequest(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as NameRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(NameRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(NameRequest other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
        }
      }
    }

  }

  internal sealed partial class InstrumentIdRequest : pb::IMessage<InstrumentIdRequest> {
    private static readonly pb::MessageParser<InstrumentIdRequest> _parser = new pb::MessageParser<InstrumentIdRequest>(() => new InstrumentIdRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<InstrumentIdRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CrossTrader.Models.Remoting.CommonReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InstrumentIdRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InstrumentIdRequest(InstrumentIdRequest other) : this() {
      instrumentId_ = other.instrumentId_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InstrumentIdRequest Clone() {
      return new InstrumentIdRequest(this);
    }

    /// <summary>Field number for the "instrumentId" field.</summary>
    public const int InstrumentIdFieldNumber = 1;
    private int instrumentId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int InstrumentId {
      get { return instrumentId_; }
      set {
        instrumentId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as InstrumentIdRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(InstrumentIdRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (InstrumentId != other.InstrumentId) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (InstrumentId != 0) hash ^= InstrumentId.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (InstrumentId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(InstrumentId);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (InstrumentId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(InstrumentId);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(InstrumentIdRequest other) {
      if (other == null) {
        return;
      }
      if (other.InstrumentId != 0) {
        InstrumentId = other.InstrumentId;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            InstrumentId = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  internal sealed partial class InstrumentIdsRequest : pb::IMessage<InstrumentIdsRequest> {
    private static readonly pb::MessageParser<InstrumentIdsRequest> _parser = new pb::MessageParser<InstrumentIdsRequest>(() => new InstrumentIdsRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<InstrumentIdsRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CrossTrader.Models.Remoting.CommonReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InstrumentIdsRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InstrumentIdsRequest(InstrumentIdsRequest other) : this() {
      instrumentIds_ = other.instrumentIds_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InstrumentIdsRequest Clone() {
      return new InstrumentIdsRequest(this);
    }

    /// <summary>Field number for the "instrumentIds" field.</summary>
    public const int InstrumentIdsFieldNumber = 1;
    private static readonly pb::FieldCodec<int> _repeated_instrumentIds_codec
        = pb::FieldCodec.ForInt32(10);
    private readonly pbc::RepeatedField<int> instrumentIds_ = new pbc::RepeatedField<int>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<int> InstrumentIds {
      get { return instrumentIds_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as InstrumentIdsRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(InstrumentIdsRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!instrumentIds_.Equals(other.instrumentIds_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= instrumentIds_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      instrumentIds_.WriteTo(output, _repeated_instrumentIds_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += instrumentIds_.CalculateSize(_repeated_instrumentIds_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(InstrumentIdsRequest other) {
      if (other == null) {
        return;
      }
      instrumentIds_.Add(other.instrumentIds_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10:
          case 8: {
            instrumentIds_.AddEntriesFrom(input, _repeated_instrumentIds_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
