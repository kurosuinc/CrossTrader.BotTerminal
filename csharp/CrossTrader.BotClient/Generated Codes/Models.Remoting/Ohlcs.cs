// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: ohlcs.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace CrossTrader.Models.Remoting {

  /// <summary>Holder for reflection information generated from ohlcs.proto</summary>
  internal static partial class OhlcsReflection {

    #region Descriptor
    /// <summary>File descriptor for ohlcs.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static OhlcsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgtvaGxjcy5wcm90bxILY3Jvc3N0cmFkZXIaHmdvb2dsZS9wcm90b2J1Zi9k",
            "dXJhdGlvbi5wcm90bxofZ29vZ2xlL3Byb3RvYnVmL3RpbWVzdGFtcC5wcm90",
            "byKqAQoLT2hsY1JlcXVlc3QSFQoNaW5zdHJ1bWVudF9pZBgBIAEoBRItCgp0",
            "aW1lX2ZyYW1lGAIgASgLMhkuZ29vZ2xlLnByb3RvYnVmLkR1cmF0aW9uEioK",
            "BmJlZm9yZRgDIAEoCzIaLmdvb2dsZS5wcm90b2J1Zi5UaW1lc3RhbXASKQoF",
            "YWZ0ZXIYBCABKAsyGi5nb29nbGUucHJvdG9idWYuVGltZXN0YW1wIu8BCg9P",
            "aGxjSXRlbU1lc3NhZ2USLQoJb3Blbl90aW1lGAEgASgLMhouZ29vZ2xlLnBy",
            "b3RvYnVmLlRpbWVzdGFtcBItCgp0aW1lX2ZyYW1lGAIgASgLMhkuZ29vZ2xl",
            "LnByb3RvYnVmLkR1cmF0aW9uEi4KCmNsb3NlX3RpbWUYAyABKAsyGi5nb29n",
            "bGUucHJvdG9idWYuVGltZXN0YW1wEhIKCm9wZW5fcHJpY2UYBCABKAESEgoK",
            "aGlnaF9wcmljZRgFIAEoARIRCglsb3dfcHJpY2UYBiABKAESEwoLY2xvc2Vf",
            "cHJpY2UYByABKAEiUQoLT2hsY01lc3NhZ2USFQoNaW5zdHJ1bWVudF9pZBgB",
            "IAEoBRIrCgVvaGxjcxgCIAMoCzIcLmNyb3NzdHJhZGVyLk9obGNJdGVtTWVz",
            "c2FnZTKTAQoLT2hsY1NlcnZpY2USPQoHZ2V0T2hsYxIYLmNyb3NzdHJhZGVy",
            "Lk9obGNSZXF1ZXN0GhguY3Jvc3N0cmFkZXIuT2hsY01lc3NhZ2USRQoNc3Vi",
            "c2NyaWJlT2hsYxIYLmNyb3NzdHJhZGVyLk9obGNSZXF1ZXN0GhguY3Jvc3N0",
            "cmFkZXIuT2hsY01lc3NhZ2UwAUIeqgIbQ3Jvc3NUcmFkZXIuTW9kZWxzLlJl",
            "bW90aW5nYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.DurationReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.OhlcRequest), global::CrossTrader.Models.Remoting.OhlcRequest.Parser, new[]{ "InstrumentId", "TimeFrame", "Before", "After" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.OhlcItemMessage), global::CrossTrader.Models.Remoting.OhlcItemMessage.Parser, new[]{ "OpenTime", "TimeFrame", "CloseTime", "OpenPrice", "HighPrice", "LowPrice", "ClosePrice" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.OhlcMessage), global::CrossTrader.Models.Remoting.OhlcMessage.Parser, new[]{ "InstrumentId", "Ohlcs" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  internal sealed partial class OhlcRequest : pb::IMessage<OhlcRequest> {
    private static readonly pb::MessageParser<OhlcRequest> _parser = new pb::MessageParser<OhlcRequest>(() => new OhlcRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<OhlcRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CrossTrader.Models.Remoting.OhlcsReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OhlcRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OhlcRequest(OhlcRequest other) : this() {
      instrumentId_ = other.instrumentId_;
      timeFrame_ = other.timeFrame_ != null ? other.timeFrame_.Clone() : null;
      before_ = other.before_ != null ? other.before_.Clone() : null;
      after_ = other.after_ != null ? other.after_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OhlcRequest Clone() {
      return new OhlcRequest(this);
    }

    /// <summary>Field number for the "instrument_id" field.</summary>
    public const int InstrumentIdFieldNumber = 1;
    private int instrumentId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int InstrumentId {
      get { return instrumentId_; }
      set {
        instrumentId_ = value;
      }
    }

    /// <summary>Field number for the "time_frame" field.</summary>
    public const int TimeFrameFieldNumber = 2;
    private global::Google.Protobuf.WellKnownTypes.Duration timeFrame_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Duration TimeFrame {
      get { return timeFrame_; }
      set {
        timeFrame_ = value;
      }
    }

    /// <summary>Field number for the "before" field.</summary>
    public const int BeforeFieldNumber = 3;
    private global::Google.Protobuf.WellKnownTypes.Timestamp before_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp Before {
      get { return before_; }
      set {
        before_ = value;
      }
    }

    /// <summary>Field number for the "after" field.</summary>
    public const int AfterFieldNumber = 4;
    private global::Google.Protobuf.WellKnownTypes.Timestamp after_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp After {
      get { return after_; }
      set {
        after_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as OhlcRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(OhlcRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (InstrumentId != other.InstrumentId) return false;
      if (!object.Equals(TimeFrame, other.TimeFrame)) return false;
      if (!object.Equals(Before, other.Before)) return false;
      if (!object.Equals(After, other.After)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (InstrumentId != 0) hash ^= InstrumentId.GetHashCode();
      if (timeFrame_ != null) hash ^= TimeFrame.GetHashCode();
      if (before_ != null) hash ^= Before.GetHashCode();
      if (after_ != null) hash ^= After.GetHashCode();
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
      if (timeFrame_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(TimeFrame);
      }
      if (before_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Before);
      }
      if (after_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(After);
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
      if (timeFrame_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(TimeFrame);
      }
      if (before_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Before);
      }
      if (after_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(After);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(OhlcRequest other) {
      if (other == null) {
        return;
      }
      if (other.InstrumentId != 0) {
        InstrumentId = other.InstrumentId;
      }
      if (other.timeFrame_ != null) {
        if (timeFrame_ == null) {
          TimeFrame = new global::Google.Protobuf.WellKnownTypes.Duration();
        }
        TimeFrame.MergeFrom(other.TimeFrame);
      }
      if (other.before_ != null) {
        if (before_ == null) {
          Before = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        Before.MergeFrom(other.Before);
      }
      if (other.after_ != null) {
        if (after_ == null) {
          After = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        After.MergeFrom(other.After);
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
          case 18: {
            if (timeFrame_ == null) {
              TimeFrame = new global::Google.Protobuf.WellKnownTypes.Duration();
            }
            input.ReadMessage(TimeFrame);
            break;
          }
          case 26: {
            if (before_ == null) {
              Before = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(Before);
            break;
          }
          case 34: {
            if (after_ == null) {
              After = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(After);
            break;
          }
        }
      }
    }

  }

  internal sealed partial class OhlcItemMessage : pb::IMessage<OhlcItemMessage> {
    private static readonly pb::MessageParser<OhlcItemMessage> _parser = new pb::MessageParser<OhlcItemMessage>(() => new OhlcItemMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<OhlcItemMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CrossTrader.Models.Remoting.OhlcsReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OhlcItemMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OhlcItemMessage(OhlcItemMessage other) : this() {
      openTime_ = other.openTime_ != null ? other.openTime_.Clone() : null;
      timeFrame_ = other.timeFrame_ != null ? other.timeFrame_.Clone() : null;
      closeTime_ = other.closeTime_ != null ? other.closeTime_.Clone() : null;
      openPrice_ = other.openPrice_;
      highPrice_ = other.highPrice_;
      lowPrice_ = other.lowPrice_;
      closePrice_ = other.closePrice_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OhlcItemMessage Clone() {
      return new OhlcItemMessage(this);
    }

    /// <summary>Field number for the "open_time" field.</summary>
    public const int OpenTimeFieldNumber = 1;
    private global::Google.Protobuf.WellKnownTypes.Timestamp openTime_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp OpenTime {
      get { return openTime_; }
      set {
        openTime_ = value;
      }
    }

    /// <summary>Field number for the "time_frame" field.</summary>
    public const int TimeFrameFieldNumber = 2;
    private global::Google.Protobuf.WellKnownTypes.Duration timeFrame_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Duration TimeFrame {
      get { return timeFrame_; }
      set {
        timeFrame_ = value;
      }
    }

    /// <summary>Field number for the "close_time" field.</summary>
    public const int CloseTimeFieldNumber = 3;
    private global::Google.Protobuf.WellKnownTypes.Timestamp closeTime_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp CloseTime {
      get { return closeTime_; }
      set {
        closeTime_ = value;
      }
    }

    /// <summary>Field number for the "open_price" field.</summary>
    public const int OpenPriceFieldNumber = 4;
    private double openPrice_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double OpenPrice {
      get { return openPrice_; }
      set {
        openPrice_ = value;
      }
    }

    /// <summary>Field number for the "high_price" field.</summary>
    public const int HighPriceFieldNumber = 5;
    private double highPrice_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double HighPrice {
      get { return highPrice_; }
      set {
        highPrice_ = value;
      }
    }

    /// <summary>Field number for the "low_price" field.</summary>
    public const int LowPriceFieldNumber = 6;
    private double lowPrice_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double LowPrice {
      get { return lowPrice_; }
      set {
        lowPrice_ = value;
      }
    }

    /// <summary>Field number for the "close_price" field.</summary>
    public const int ClosePriceFieldNumber = 7;
    private double closePrice_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double ClosePrice {
      get { return closePrice_; }
      set {
        closePrice_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as OhlcItemMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(OhlcItemMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(OpenTime, other.OpenTime)) return false;
      if (!object.Equals(TimeFrame, other.TimeFrame)) return false;
      if (!object.Equals(CloseTime, other.CloseTime)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(OpenPrice, other.OpenPrice)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(HighPrice, other.HighPrice)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(LowPrice, other.LowPrice)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(ClosePrice, other.ClosePrice)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (openTime_ != null) hash ^= OpenTime.GetHashCode();
      if (timeFrame_ != null) hash ^= TimeFrame.GetHashCode();
      if (closeTime_ != null) hash ^= CloseTime.GetHashCode();
      if (OpenPrice != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(OpenPrice);
      if (HighPrice != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(HighPrice);
      if (LowPrice != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(LowPrice);
      if (ClosePrice != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(ClosePrice);
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
      if (openTime_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(OpenTime);
      }
      if (timeFrame_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(TimeFrame);
      }
      if (closeTime_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(CloseTime);
      }
      if (OpenPrice != 0D) {
        output.WriteRawTag(33);
        output.WriteDouble(OpenPrice);
      }
      if (HighPrice != 0D) {
        output.WriteRawTag(41);
        output.WriteDouble(HighPrice);
      }
      if (LowPrice != 0D) {
        output.WriteRawTag(49);
        output.WriteDouble(LowPrice);
      }
      if (ClosePrice != 0D) {
        output.WriteRawTag(57);
        output.WriteDouble(ClosePrice);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (openTime_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(OpenTime);
      }
      if (timeFrame_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(TimeFrame);
      }
      if (closeTime_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CloseTime);
      }
      if (OpenPrice != 0D) {
        size += 1 + 8;
      }
      if (HighPrice != 0D) {
        size += 1 + 8;
      }
      if (LowPrice != 0D) {
        size += 1 + 8;
      }
      if (ClosePrice != 0D) {
        size += 1 + 8;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(OhlcItemMessage other) {
      if (other == null) {
        return;
      }
      if (other.openTime_ != null) {
        if (openTime_ == null) {
          OpenTime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        OpenTime.MergeFrom(other.OpenTime);
      }
      if (other.timeFrame_ != null) {
        if (timeFrame_ == null) {
          TimeFrame = new global::Google.Protobuf.WellKnownTypes.Duration();
        }
        TimeFrame.MergeFrom(other.TimeFrame);
      }
      if (other.closeTime_ != null) {
        if (closeTime_ == null) {
          CloseTime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        CloseTime.MergeFrom(other.CloseTime);
      }
      if (other.OpenPrice != 0D) {
        OpenPrice = other.OpenPrice;
      }
      if (other.HighPrice != 0D) {
        HighPrice = other.HighPrice;
      }
      if (other.LowPrice != 0D) {
        LowPrice = other.LowPrice;
      }
      if (other.ClosePrice != 0D) {
        ClosePrice = other.ClosePrice;
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
            if (openTime_ == null) {
              OpenTime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(OpenTime);
            break;
          }
          case 18: {
            if (timeFrame_ == null) {
              TimeFrame = new global::Google.Protobuf.WellKnownTypes.Duration();
            }
            input.ReadMessage(TimeFrame);
            break;
          }
          case 26: {
            if (closeTime_ == null) {
              CloseTime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(CloseTime);
            break;
          }
          case 33: {
            OpenPrice = input.ReadDouble();
            break;
          }
          case 41: {
            HighPrice = input.ReadDouble();
            break;
          }
          case 49: {
            LowPrice = input.ReadDouble();
            break;
          }
          case 57: {
            ClosePrice = input.ReadDouble();
            break;
          }
        }
      }
    }

  }

  internal sealed partial class OhlcMessage : pb::IMessage<OhlcMessage> {
    private static readonly pb::MessageParser<OhlcMessage> _parser = new pb::MessageParser<OhlcMessage>(() => new OhlcMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<OhlcMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CrossTrader.Models.Remoting.OhlcsReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OhlcMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OhlcMessage(OhlcMessage other) : this() {
      instrumentId_ = other.instrumentId_;
      ohlcs_ = other.ohlcs_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OhlcMessage Clone() {
      return new OhlcMessage(this);
    }

    /// <summary>Field number for the "instrument_id" field.</summary>
    public const int InstrumentIdFieldNumber = 1;
    private int instrumentId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int InstrumentId {
      get { return instrumentId_; }
      set {
        instrumentId_ = value;
      }
    }

    /// <summary>Field number for the "ohlcs" field.</summary>
    public const int OhlcsFieldNumber = 2;
    private static readonly pb::FieldCodec<global::CrossTrader.Models.Remoting.OhlcItemMessage> _repeated_ohlcs_codec
        = pb::FieldCodec.ForMessage(18, global::CrossTrader.Models.Remoting.OhlcItemMessage.Parser);
    private readonly pbc::RepeatedField<global::CrossTrader.Models.Remoting.OhlcItemMessage> ohlcs_ = new pbc::RepeatedField<global::CrossTrader.Models.Remoting.OhlcItemMessage>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::CrossTrader.Models.Remoting.OhlcItemMessage> Ohlcs {
      get { return ohlcs_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as OhlcMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(OhlcMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (InstrumentId != other.InstrumentId) return false;
      if(!ohlcs_.Equals(other.ohlcs_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (InstrumentId != 0) hash ^= InstrumentId.GetHashCode();
      hash ^= ohlcs_.GetHashCode();
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
      ohlcs_.WriteTo(output, _repeated_ohlcs_codec);
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
      size += ohlcs_.CalculateSize(_repeated_ohlcs_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(OhlcMessage other) {
      if (other == null) {
        return;
      }
      if (other.InstrumentId != 0) {
        InstrumentId = other.InstrumentId;
      }
      ohlcs_.Add(other.ohlcs_);
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
          case 18: {
            ohlcs_.AddEntriesFrom(input, _repeated_ohlcs_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code