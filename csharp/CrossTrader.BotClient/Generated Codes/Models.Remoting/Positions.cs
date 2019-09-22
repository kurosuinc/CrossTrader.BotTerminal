// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: positions.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace CrossTrader.Models.Remoting {

  /// <summary>Holder for reflection information generated from positions.proto</summary>
  internal static partial class PositionsReflection {

    #region Descriptor
    /// <summary>File descriptor for positions.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static PositionsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg9wb3NpdGlvbnMucHJvdG8SC2Nyb3NzdHJhZGVyGgxjb21tb24ucHJvdG8a",
            "H2dvb2dsZS9wcm90b2J1Zi90aW1lc3RhbXAucHJvdG8iJwoKRmVlTWVzc2Fn",
            "ZRIMCgRuYW1lGAEgASgJEgsKA2ZlZRgCIAEoASK2AQoPUG9zaXRpb25NZXNz",
            "YWdlEiQKBHNpZGUYASABKA4yFi5jcm9zc3RyYWRlci5PcmRlclNpZGUSDQoF",
            "cHJpY2UYAiABKAESDAoEc2l6ZRgDIAEoARItCglvcGVuZWRfYXQYBCABKAsy",
            "Gi5nb29nbGUucHJvdG9idWYuVGltZXN0YW1wEiUKBGZlZXMYBSADKAsyFy5j",
            "cm9zc3RyYWRlci5GZWVNZXNzYWdlEgoKAmlkGAYgASgJInAKEVBvc2l0aW9u",
            "c1Jlc3BvbnNlEioKBmFjdGlvbhgBIAEoDjIaLmNyb3NzdHJhZGVyLkNoYW5n",
            "ZWRBY3Rpb24SLwoJcG9zaXRpb25zGAIgAygLMhwuY3Jvc3N0cmFkZXIuUG9z",
            "aXRpb25NZXNzYWdlMr4BChBQb3NpdGlvbnNTZXJ2aWNlElAKDEdldFBvc2l0",
            "aW9ucxIgLmNyb3NzdHJhZGVyLkluc3RydW1lbnRJZFJlcXVlc3QaHi5jcm9z",
            "c3RyYWRlci5Qb3NpdGlvbnNSZXNwb25zZRJYChJTdWJzY3JpYmVQb3NpdGlv",
            "bnMSIC5jcm9zc3RyYWRlci5JbnN0cnVtZW50SWRSZXF1ZXN0Gh4uY3Jvc3N0",
            "cmFkZXIuUG9zaXRpb25zUmVzcG9uc2UwAUIeqgIbQ3Jvc3NUcmFkZXIuTW9k",
            "ZWxzLlJlbW90aW5nYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::CrossTrader.Models.Remoting.CommonReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.FeeMessage), global::CrossTrader.Models.Remoting.FeeMessage.Parser, new[]{ "Name", "Fee" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.PositionMessage), global::CrossTrader.Models.Remoting.PositionMessage.Parser, new[]{ "Side", "Price", "Size", "OpenedAt", "Fees", "Id" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.PositionsResponse), global::CrossTrader.Models.Remoting.PositionsResponse.Parser, new[]{ "Action", "Positions" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Fee for the position
  /// </summary>
  internal sealed partial class FeeMessage : pb::IMessage<FeeMessage> {
    private static readonly pb::MessageParser<FeeMessage> _parser = new pb::MessageParser<FeeMessage>(() => new FeeMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<FeeMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CrossTrader.Models.Remoting.PositionsReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FeeMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FeeMessage(FeeMessage other) : this() {
      name_ = other.name_;
      fee_ = other.fee_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FeeMessage Clone() {
      return new FeeMessage(this);
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

    /// <summary>Field number for the "fee" field.</summary>
    public const int FeeFieldNumber = 2;
    private double fee_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Fee {
      get { return fee_; }
      set {
        fee_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as FeeMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(FeeMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Fee, other.Fee)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Fee != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Fee);
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
      if (Fee != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Fee);
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
      if (Fee != 0D) {
        size += 1 + 8;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(FeeMessage other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Fee != 0D) {
        Fee = other.Fee;
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
          case 17: {
            Fee = input.ReadDouble();
            break;
          }
        }
      }
    }

  }

  internal sealed partial class PositionMessage : pb::IMessage<PositionMessage> {
    private static readonly pb::MessageParser<PositionMessage> _parser = new pb::MessageParser<PositionMessage>(() => new PositionMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PositionMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CrossTrader.Models.Remoting.PositionsReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PositionMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PositionMessage(PositionMessage other) : this() {
      side_ = other.side_;
      price_ = other.price_;
      size_ = other.size_;
      openedAt_ = other.openedAt_ != null ? other.openedAt_.Clone() : null;
      fees_ = other.fees_.Clone();
      id_ = other.id_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PositionMessage Clone() {
      return new PositionMessage(this);
    }

    /// <summary>Field number for the "side" field.</summary>
    public const int SideFieldNumber = 1;
    private global::CrossTrader.Models.Remoting.OrderSide side_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CrossTrader.Models.Remoting.OrderSide Side {
      get { return side_; }
      set {
        side_ = value;
      }
    }

    /// <summary>Field number for the "price" field.</summary>
    public const int PriceFieldNumber = 2;
    private double price_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Price {
      get { return price_; }
      set {
        price_ = value;
      }
    }

    /// <summary>Field number for the "size" field.</summary>
    public const int SizeFieldNumber = 3;
    private double size_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Size {
      get { return size_; }
      set {
        size_ = value;
      }
    }

    /// <summary>Field number for the "opened_at" field.</summary>
    public const int OpenedAtFieldNumber = 4;
    private global::Google.Protobuf.WellKnownTypes.Timestamp openedAt_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp OpenedAt {
      get { return openedAt_; }
      set {
        openedAt_ = value;
      }
    }

    /// <summary>Field number for the "fees" field.</summary>
    public const int FeesFieldNumber = 5;
    private static readonly pb::FieldCodec<global::CrossTrader.Models.Remoting.FeeMessage> _repeated_fees_codec
        = pb::FieldCodec.ForMessage(42, global::CrossTrader.Models.Remoting.FeeMessage.Parser);
    private readonly pbc::RepeatedField<global::CrossTrader.Models.Remoting.FeeMessage> fees_ = new pbc::RepeatedField<global::CrossTrader.Models.Remoting.FeeMessage>();
    /// <summary>
    /// Fees for the position
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::CrossTrader.Models.Remoting.FeeMessage> Fees {
      get { return fees_; }
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 6;
    private string id_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Id {
      get { return id_; }
      set {
        id_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PositionMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PositionMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Side != other.Side) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Price, other.Price)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Size, other.Size)) return false;
      if (!object.Equals(OpenedAt, other.OpenedAt)) return false;
      if(!fees_.Equals(other.fees_)) return false;
      if (Id != other.Id) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Side != 0) hash ^= Side.GetHashCode();
      if (Price != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Price);
      if (Size != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Size);
      if (openedAt_ != null) hash ^= OpenedAt.GetHashCode();
      hash ^= fees_.GetHashCode();
      if (Id.Length != 0) hash ^= Id.GetHashCode();
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
      if (Side != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Side);
      }
      if (Price != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Price);
      }
      if (Size != 0D) {
        output.WriteRawTag(25);
        output.WriteDouble(Size);
      }
      if (openedAt_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(OpenedAt);
      }
      fees_.WriteTo(output, _repeated_fees_codec);
      if (Id.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(Id);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Side != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Side);
      }
      if (Price != 0D) {
        size += 1 + 8;
      }
      if (Size != 0D) {
        size += 1 + 8;
      }
      if (openedAt_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(OpenedAt);
      }
      size += fees_.CalculateSize(_repeated_fees_codec);
      if (Id.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Id);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PositionMessage other) {
      if (other == null) {
        return;
      }
      if (other.Side != 0) {
        Side = other.Side;
      }
      if (other.Price != 0D) {
        Price = other.Price;
      }
      if (other.Size != 0D) {
        Size = other.Size;
      }
      if (other.openedAt_ != null) {
        if (openedAt_ == null) {
          OpenedAt = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        OpenedAt.MergeFrom(other.OpenedAt);
      }
      fees_.Add(other.fees_);
      if (other.Id.Length != 0) {
        Id = other.Id;
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
            Side = (global::CrossTrader.Models.Remoting.OrderSide) input.ReadEnum();
            break;
          }
          case 17: {
            Price = input.ReadDouble();
            break;
          }
          case 25: {
            Size = input.ReadDouble();
            break;
          }
          case 34: {
            if (openedAt_ == null) {
              OpenedAt = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(OpenedAt);
            break;
          }
          case 42: {
            fees_.AddEntriesFrom(input, _repeated_fees_codec);
            break;
          }
          case 50: {
            Id = input.ReadString();
            break;
          }
        }
      }
    }

  }

  internal sealed partial class PositionsResponse : pb::IMessage<PositionsResponse> {
    private static readonly pb::MessageParser<PositionsResponse> _parser = new pb::MessageParser<PositionsResponse>(() => new PositionsResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PositionsResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CrossTrader.Models.Remoting.PositionsReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PositionsResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PositionsResponse(PositionsResponse other) : this() {
      action_ = other.action_;
      positions_ = other.positions_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PositionsResponse Clone() {
      return new PositionsResponse(this);
    }

    /// <summary>Field number for the "action" field.</summary>
    public const int ActionFieldNumber = 1;
    private global::CrossTrader.Models.Remoting.ChangedAction action_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CrossTrader.Models.Remoting.ChangedAction Action {
      get { return action_; }
      set {
        action_ = value;
      }
    }

    /// <summary>Field number for the "positions" field.</summary>
    public const int PositionsFieldNumber = 2;
    private static readonly pb::FieldCodec<global::CrossTrader.Models.Remoting.PositionMessage> _repeated_positions_codec
        = pb::FieldCodec.ForMessage(18, global::CrossTrader.Models.Remoting.PositionMessage.Parser);
    private readonly pbc::RepeatedField<global::CrossTrader.Models.Remoting.PositionMessage> positions_ = new pbc::RepeatedField<global::CrossTrader.Models.Remoting.PositionMessage>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::CrossTrader.Models.Remoting.PositionMessage> Positions {
      get { return positions_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PositionsResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PositionsResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Action != other.Action) return false;
      if(!positions_.Equals(other.positions_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Action != 0) hash ^= Action.GetHashCode();
      hash ^= positions_.GetHashCode();
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
      if (Action != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Action);
      }
      positions_.WriteTo(output, _repeated_positions_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Action != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Action);
      }
      size += positions_.CalculateSize(_repeated_positions_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PositionsResponse other) {
      if (other == null) {
        return;
      }
      if (other.Action != 0) {
        Action = other.Action;
      }
      positions_.Add(other.positions_);
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
            Action = (global::CrossTrader.Models.Remoting.ChangedAction) input.ReadEnum();
            break;
          }
          case 18: {
            positions_.AddEntriesFrom(input, _repeated_positions_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
