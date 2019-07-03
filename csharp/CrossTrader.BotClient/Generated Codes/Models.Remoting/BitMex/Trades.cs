// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: bitmex/trades.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace CrossTrader.Models.Remoting.BitMex {

  /// <summary>Holder for reflection information generated from bitmex/trades.proto</summary>
  internal static partial class TradesReflection {

    #region Descriptor
    /// <summary>File descriptor for bitmex/trades.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static TradesReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChNiaXRtZXgvdHJhZGVzLnByb3RvEhJjcm9zc3RyYWRlci5iaXRtZXgaH2dv",
            "b2dsZS9wcm90b2J1Zi90aW1lc3RhbXAucHJvdG8aDGNvbW1vbi5wcm90byKZ",
            "AgoMVHJhZGVNZXNzYWdlEi0KCXRpbWVzdGFtcBgBIAEoCzIaLmdvb2dsZS5w",
            "cm90b2J1Zi5UaW1lc3RhbXASJAoEc2lkZRgCIAEoDjIWLmNyb3NzdHJhZGVy",
            "Lk9yZGVyU2lkZRIMCgRzaXplGAMgASgBEg0KBXByaWNlGAQgASgBEjkKDnRp",
            "Y2tfZGlyZWN0aW9uGAUgASgOMiEuY3Jvc3N0cmFkZXIuYml0bWV4LlRpY2tE",
            "aXJlY3Rpb24SFgoOdHJhZGVfbWF0Y2hfaWQYBiABKAkSEwoLZ3Jvc3NfdmFs",
            "dWUYByABKAESFQoNaG9tZV9ub3Rpb25hbBgIIAEoARIYChBmb3JlaWduX25v",
            "dGlvbmFsGAkgASgBIm4KDlRyYWRlc1Jlc3BvbnNlEioKBmFjdGlvbhgBIAEo",
            "DjIaLmNyb3NzdHJhZGVyLkNoYW5nZWRBY3Rpb24SMAoGdHJhZGVzGAIgAygL",
            "MiAuY3Jvc3N0cmFkZXIuYml0bWV4LlRyYWRlTWVzc2FnZSpwCg1UaWNrRGly",
            "ZWN0aW9uEhcKE1RJQ0tfRElSRUNUSU9OX05PTkUQABINCglQTFVTX1RJQ0sQ",
            "ARISCg5aRVJPX1BMVVNfVElDSxACEg4KCk1JTlVTX1RJQ0sQAxITCg9aRVJP",
            "X01JTlVTX1RJQ0sQBDJqCg1UcmFkZXNTZXJ2aWNlElkKD1N1YnNjcmliZVRy",
            "YWRlcxIgLmNyb3NzdHJhZGVyLkluc3RydW1lbnRJZFJlcXVlc3QaIi5jcm9z",
            "c3RyYWRlci5iaXRtZXguVHJhZGVzUmVzcG9uc2UwAUIlqgIiQ3Jvc3NUcmFk",
            "ZXIuTW9kZWxzLlJlbW90aW5nLkJpdE1leGIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, global::CrossTrader.Models.Remoting.CommonReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::CrossTrader.Models.Remoting.BitMex.TickDirection), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.BitMex.TradeMessage), global::CrossTrader.Models.Remoting.BitMex.TradeMessage.Parser, new[]{ "Timestamp", "Side", "Size", "Price", "TickDirection", "TradeMatchId", "GrossValue", "HomeNotional", "ForeignNotional" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.BitMex.TradesResponse), global::CrossTrader.Models.Remoting.BitMex.TradesResponse.Parser, new[]{ "Action", "Trades" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  internal enum TickDirection {
    [pbr::OriginalName("TICK_DIRECTION_NONE")] None = 0,
    [pbr::OriginalName("PLUS_TICK")] PlusTick = 1,
    [pbr::OriginalName("ZERO_PLUS_TICK")] ZeroPlusTick = 2,
    [pbr::OriginalName("MINUS_TICK")] MinusTick = 3,
    [pbr::OriginalName("ZERO_MINUS_TICK")] ZeroMinusTick = 4,
  }

  #endregion

  #region Messages
  internal sealed partial class TradeMessage : pb::IMessage<TradeMessage> {
    private static readonly pb::MessageParser<TradeMessage> _parser = new pb::MessageParser<TradeMessage>(() => new TradeMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<TradeMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CrossTrader.Models.Remoting.BitMex.TradesReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TradeMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TradeMessage(TradeMessage other) : this() {
      timestamp_ = other.timestamp_ != null ? other.timestamp_.Clone() : null;
      side_ = other.side_;
      size_ = other.size_;
      price_ = other.price_;
      tickDirection_ = other.tickDirection_;
      tradeMatchId_ = other.tradeMatchId_;
      grossValue_ = other.grossValue_;
      homeNotional_ = other.homeNotional_;
      foreignNotional_ = other.foreignNotional_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TradeMessage Clone() {
      return new TradeMessage(this);
    }

    /// <summary>Field number for the "timestamp" field.</summary>
    public const int TimestampFieldNumber = 1;
    private global::Google.Protobuf.WellKnownTypes.Timestamp timestamp_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp Timestamp {
      get { return timestamp_; }
      set {
        timestamp_ = value;
      }
    }

    /// <summary>Field number for the "side" field.</summary>
    public const int SideFieldNumber = 2;
    private global::CrossTrader.Models.Remoting.OrderSide side_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CrossTrader.Models.Remoting.OrderSide Side {
      get { return side_; }
      set {
        side_ = value;
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

    /// <summary>Field number for the "price" field.</summary>
    public const int PriceFieldNumber = 4;
    private double price_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Price {
      get { return price_; }
      set {
        price_ = value;
      }
    }

    /// <summary>Field number for the "tick_direction" field.</summary>
    public const int TickDirectionFieldNumber = 5;
    private global::CrossTrader.Models.Remoting.BitMex.TickDirection tickDirection_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CrossTrader.Models.Remoting.BitMex.TickDirection TickDirection {
      get { return tickDirection_; }
      set {
        tickDirection_ = value;
      }
    }

    /// <summary>Field number for the "trade_match_id" field.</summary>
    public const int TradeMatchIdFieldNumber = 6;
    private string tradeMatchId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string TradeMatchId {
      get { return tradeMatchId_; }
      set {
        tradeMatchId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "gross_value" field.</summary>
    public const int GrossValueFieldNumber = 7;
    private double grossValue_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double GrossValue {
      get { return grossValue_; }
      set {
        grossValue_ = value;
      }
    }

    /// <summary>Field number for the "home_notional" field.</summary>
    public const int HomeNotionalFieldNumber = 8;
    private double homeNotional_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double HomeNotional {
      get { return homeNotional_; }
      set {
        homeNotional_ = value;
      }
    }

    /// <summary>Field number for the "foreign_notional" field.</summary>
    public const int ForeignNotionalFieldNumber = 9;
    private double foreignNotional_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double ForeignNotional {
      get { return foreignNotional_; }
      set {
        foreignNotional_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as TradeMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(TradeMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Timestamp, other.Timestamp)) return false;
      if (Side != other.Side) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Size, other.Size)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Price, other.Price)) return false;
      if (TickDirection != other.TickDirection) return false;
      if (TradeMatchId != other.TradeMatchId) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(GrossValue, other.GrossValue)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(HomeNotional, other.HomeNotional)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(ForeignNotional, other.ForeignNotional)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (timestamp_ != null) hash ^= Timestamp.GetHashCode();
      if (Side != 0) hash ^= Side.GetHashCode();
      if (Size != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Size);
      if (Price != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Price);
      if (TickDirection != 0) hash ^= TickDirection.GetHashCode();
      if (TradeMatchId.Length != 0) hash ^= TradeMatchId.GetHashCode();
      if (GrossValue != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(GrossValue);
      if (HomeNotional != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(HomeNotional);
      if (ForeignNotional != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(ForeignNotional);
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
      if (timestamp_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Timestamp);
      }
      if (Side != 0) {
        output.WriteRawTag(16);
        output.WriteEnum((int) Side);
      }
      if (Size != 0D) {
        output.WriteRawTag(25);
        output.WriteDouble(Size);
      }
      if (Price != 0D) {
        output.WriteRawTag(33);
        output.WriteDouble(Price);
      }
      if (TickDirection != 0) {
        output.WriteRawTag(40);
        output.WriteEnum((int) TickDirection);
      }
      if (TradeMatchId.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(TradeMatchId);
      }
      if (GrossValue != 0D) {
        output.WriteRawTag(57);
        output.WriteDouble(GrossValue);
      }
      if (HomeNotional != 0D) {
        output.WriteRawTag(65);
        output.WriteDouble(HomeNotional);
      }
      if (ForeignNotional != 0D) {
        output.WriteRawTag(73);
        output.WriteDouble(ForeignNotional);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (timestamp_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Timestamp);
      }
      if (Side != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Side);
      }
      if (Size != 0D) {
        size += 1 + 8;
      }
      if (Price != 0D) {
        size += 1 + 8;
      }
      if (TickDirection != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) TickDirection);
      }
      if (TradeMatchId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(TradeMatchId);
      }
      if (GrossValue != 0D) {
        size += 1 + 8;
      }
      if (HomeNotional != 0D) {
        size += 1 + 8;
      }
      if (ForeignNotional != 0D) {
        size += 1 + 8;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(TradeMessage other) {
      if (other == null) {
        return;
      }
      if (other.timestamp_ != null) {
        if (timestamp_ == null) {
          Timestamp = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        Timestamp.MergeFrom(other.Timestamp);
      }
      if (other.Side != 0) {
        Side = other.Side;
      }
      if (other.Size != 0D) {
        Size = other.Size;
      }
      if (other.Price != 0D) {
        Price = other.Price;
      }
      if (other.TickDirection != 0) {
        TickDirection = other.TickDirection;
      }
      if (other.TradeMatchId.Length != 0) {
        TradeMatchId = other.TradeMatchId;
      }
      if (other.GrossValue != 0D) {
        GrossValue = other.GrossValue;
      }
      if (other.HomeNotional != 0D) {
        HomeNotional = other.HomeNotional;
      }
      if (other.ForeignNotional != 0D) {
        ForeignNotional = other.ForeignNotional;
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
            if (timestamp_ == null) {
              Timestamp = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(Timestamp);
            break;
          }
          case 16: {
            Side = (global::CrossTrader.Models.Remoting.OrderSide) input.ReadEnum();
            break;
          }
          case 25: {
            Size = input.ReadDouble();
            break;
          }
          case 33: {
            Price = input.ReadDouble();
            break;
          }
          case 40: {
            TickDirection = (global::CrossTrader.Models.Remoting.BitMex.TickDirection) input.ReadEnum();
            break;
          }
          case 50: {
            TradeMatchId = input.ReadString();
            break;
          }
          case 57: {
            GrossValue = input.ReadDouble();
            break;
          }
          case 65: {
            HomeNotional = input.ReadDouble();
            break;
          }
          case 73: {
            ForeignNotional = input.ReadDouble();
            break;
          }
        }
      }
    }

  }

  internal sealed partial class TradesResponse : pb::IMessage<TradesResponse> {
    private static readonly pb::MessageParser<TradesResponse> _parser = new pb::MessageParser<TradesResponse>(() => new TradesResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<TradesResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CrossTrader.Models.Remoting.BitMex.TradesReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TradesResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TradesResponse(TradesResponse other) : this() {
      action_ = other.action_;
      trades_ = other.trades_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TradesResponse Clone() {
      return new TradesResponse(this);
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

    /// <summary>Field number for the "trades" field.</summary>
    public const int TradesFieldNumber = 2;
    private static readonly pb::FieldCodec<global::CrossTrader.Models.Remoting.BitMex.TradeMessage> _repeated_trades_codec
        = pb::FieldCodec.ForMessage(18, global::CrossTrader.Models.Remoting.BitMex.TradeMessage.Parser);
    private readonly pbc::RepeatedField<global::CrossTrader.Models.Remoting.BitMex.TradeMessage> trades_ = new pbc::RepeatedField<global::CrossTrader.Models.Remoting.BitMex.TradeMessage>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::CrossTrader.Models.Remoting.BitMex.TradeMessage> Trades {
      get { return trades_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as TradesResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(TradesResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Action != other.Action) return false;
      if(!trades_.Equals(other.trades_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Action != 0) hash ^= Action.GetHashCode();
      hash ^= trades_.GetHashCode();
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
      trades_.WriteTo(output, _repeated_trades_codec);
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
      size += trades_.CalculateSize(_repeated_trades_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(TradesResponse other) {
      if (other == null) {
        return;
      }
      if (other.Action != 0) {
        Action = other.Action;
      }
      trades_.Add(other.trades_);
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
            trades_.AddEntriesFrom(input, _repeated_trades_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
