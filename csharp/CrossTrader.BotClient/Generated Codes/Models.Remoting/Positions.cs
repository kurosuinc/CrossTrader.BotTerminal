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
            "H2dvb2dsZS9wcm90b2J1Zi90aW1lc3RhbXAucHJvdG8igwEKD1Bvc2l0aW9u",
            "TWVzc2FnZRIkCgRzaWRlGAEgASgOMhYuY3Jvc3N0cmFkZXIuT3JkZXJTaWRl",
            "Eg0KBXByaWNlGAIgASgBEgwKBHNpemUYAyABKAESLQoJb3BlbmVkX2F0GAQg",
            "ASgLMhouZ29vZ2xlLnByb3RvYnVmLlRpbWVzdGFtcCJEChFQb3NpdGlvbnNS",
            "ZXNwb25zZRIvCglwb3NpdGlvbnMYASADKAsyHC5jcm9zc3RyYWRlci5Qb3Np",
            "dGlvbk1lc3NhZ2UyvgEKEFBvc2l0aW9uc1NlcnZpY2USUAoMR2V0UG9zaXRp",
            "b25zEiAuY3Jvc3N0cmFkZXIuSW5zdHJ1bWVudElkUmVxdWVzdBoeLmNyb3Nz",
            "dHJhZGVyLlBvc2l0aW9uc1Jlc3BvbnNlElgKElN1YnNjcmliZVBvc2l0aW9u",
            "cxIgLmNyb3NzdHJhZGVyLkluc3RydW1lbnRJZFJlcXVlc3QaHi5jcm9zc3Ry",
            "YWRlci5Qb3NpdGlvbnNSZXNwb25zZTABQh6qAhtDcm9zc1RyYWRlci5Nb2Rl",
            "bHMuUmVtb3RpbmdiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::CrossTrader.Models.Remoting.CommonReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.PositionMessage), global::CrossTrader.Models.Remoting.PositionMessage.Parser, new[]{ "Side", "Price", "Size", "OpenedAt" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.PositionsResponse), global::CrossTrader.Models.Remoting.PositionsResponse.Parser, new[]{ "Positions" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  internal sealed partial class PositionMessage : pb::IMessage<PositionMessage> {
    private static readonly pb::MessageParser<PositionMessage> _parser = new pb::MessageParser<PositionMessage>(() => new PositionMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PositionMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CrossTrader.Models.Remoting.PositionsReflection.Descriptor.MessageTypes[0]; }
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
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Side != 0) hash ^= Side.GetHashCode();
      if (Price != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Price);
      if (Size != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Size);
      if (openedAt_ != null) hash ^= OpenedAt.GetHashCode();
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
      get { return global::CrossTrader.Models.Remoting.PositionsReflection.Descriptor.MessageTypes[1]; }
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
      positions_ = other.positions_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PositionsResponse Clone() {
      return new PositionsResponse(this);
    }

    /// <summary>Field number for the "positions" field.</summary>
    public const int PositionsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::CrossTrader.Models.Remoting.PositionMessage> _repeated_positions_codec
        = pb::FieldCodec.ForMessage(10, global::CrossTrader.Models.Remoting.PositionMessage.Parser);
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
      if(!positions_.Equals(other.positions_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
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
      positions_.WriteTo(output, _repeated_positions_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
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
          case 10: {
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
