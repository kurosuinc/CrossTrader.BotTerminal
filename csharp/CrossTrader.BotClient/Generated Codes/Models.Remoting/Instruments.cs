// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: instruments.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace CrossTrader.Models.Remoting {

  /// <summary>Holder for reflection information generated from instruments.proto</summary>
  internal static partial class InstrumentsReflection {

    #region Descriptor
    /// <summary>File descriptor for instruments.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static InstrumentsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFpbnN0cnVtZW50cy5wcm90bxILY3Jvc3N0cmFkZXIaD2V4Y2hhbmdlcy5w",
            "cm90bxoMY29tbW9uLnByb3RvGhtnb29nbGUvcHJvdG9idWYvZW1wdHkucHJv",
            "dG8aH2dvb2dsZS9wcm90b2J1Zi90aW1lc3RhbXAucHJvdG8iewoTSW5zdHJ1",
            "bWVudHNSZXNwb25zZRIzCgtpbnN0cnVtZW50cxgBIAMoCzIeLmNyb3NzdHJh",
            "ZGVyLkluc3RydW1lbnRNZXNzYWdlEi8KCWV4Y2hhbmdlcxgCIAMoCzIcLmNy",
            "b3NzdHJhZGVyLkV4Y2hhbmdlTWVzc2FnZSJ4ChJJbnN0cnVtZW50UmVzcG9u",
            "c2USMgoKaW5zdHJ1bWVudBgBIAEoCzIeLmNyb3NzdHJhZGVyLkluc3RydW1l",
            "bnRNZXNzYWdlEi4KCGV4Y2hhbmdlGAIgASgLMhwuY3Jvc3N0cmFkZXIuRXhj",
            "aGFuZ2VNZXNzYWdlIjEKDVRpY2tlck1lc3NhZ2USDwoHYmVzdEJpZBgBIAEo",
            "ARIPCgdiZXN0QXNrGAIgASgBIoUBChBFeGVjdXRpb25NZXNzYWdlEi4KCmNy",
            "ZWF0ZWRfYXQYASABKAsyGi5nb29nbGUucHJvdG9idWYuVGltZXN0YW1wEiQK",
            "BHNpZGUYAiABKA4yFi5jcm9zc3RyYWRlci5PcmRlclNpZGUSDQoFcHJpY2UY",
            "AyABKAESDAoEc2l6ZRgEIAEoASJzChJFeGVjdXRpb25zUmVzcG9uc2USKgoG",
            "YWN0aW9uGAEgASgOMhouY3Jvc3N0cmFkZXIuQ2hhbmdlZEFjdGlvbhIxCgpl",
            "eGVjdXRpb25zGAIgAygLMh0uY3Jvc3N0cmFkZXIuRXhlY3V0aW9uTWVzc2Fn",
            "ZTKlAwoRSW5zdHJ1bWVudFNlcnZpY2USSgoOR2V0SW5zdHJ1bWVudHMSFi5n",
            "b29nbGUucHJvdG9idWYuRW1wdHkaIC5jcm9zc3RyYWRlci5JbnN0cnVtZW50",
            "c1Jlc3BvbnNlEkoKDUdldEluc3RydW1lbnQSGC5jcm9zc3RyYWRlci5OYW1l",
            "UmVxdWVzdBofLmNyb3NzdHJhZGVyLkluc3RydW1lbnRSZXNwb25zZRJJCglH",
            "ZXRUaWNrZXISIC5jcm9zc3RyYWRlci5JbnN0cnVtZW50SWRSZXF1ZXN0Ghou",
            "Y3Jvc3N0cmFkZXIuVGlja2VyTWVzc2FnZRJRCg9TdWJzY3JpYmVUaWNrZXIS",
            "IC5jcm9zc3RyYWRlci5JbnN0cnVtZW50SWRSZXF1ZXN0GhouY3Jvc3N0cmFk",
            "ZXIuVGlja2VyTWVzc2FnZTABEloKE1N1YnNjcmliZUV4ZWN1dGlvbnMSIC5j",
            "cm9zc3RyYWRlci5JbnN0cnVtZW50SWRSZXF1ZXN0Gh8uY3Jvc3N0cmFkZXIu",
            "RXhlY3V0aW9uc1Jlc3BvbnNlMAFCHqoCG0Nyb3NzVHJhZGVyLk1vZGVscy5S",
            "ZW1vdGluZ2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::CrossTrader.Models.Remoting.ExchangesReflection.Descriptor, global::CrossTrader.Models.Remoting.CommonReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.InstrumentsResponse), global::CrossTrader.Models.Remoting.InstrumentsResponse.Parser, new[]{ "Instruments", "Exchanges" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.InstrumentResponse), global::CrossTrader.Models.Remoting.InstrumentResponse.Parser, new[]{ "Instrument", "Exchange" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.TickerMessage), global::CrossTrader.Models.Remoting.TickerMessage.Parser, new[]{ "BestBid", "BestAsk" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.ExecutionMessage), global::CrossTrader.Models.Remoting.ExecutionMessage.Parser, new[]{ "CreatedAt", "Side", "Price", "Size" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CrossTrader.Models.Remoting.ExecutionsResponse), global::CrossTrader.Models.Remoting.ExecutionsResponse.Parser, new[]{ "Action", "Executions" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Instrument
  /// </summary>
  internal sealed partial class InstrumentsResponse : pb::IMessage<InstrumentsResponse> {
    private static readonly pb::MessageParser<InstrumentsResponse> _parser = new pb::MessageParser<InstrumentsResponse>(() => new InstrumentsResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<InstrumentsResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CrossTrader.Models.Remoting.InstrumentsReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InstrumentsResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InstrumentsResponse(InstrumentsResponse other) : this() {
      instruments_ = other.instruments_.Clone();
      exchanges_ = other.exchanges_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InstrumentsResponse Clone() {
      return new InstrumentsResponse(this);
    }

    /// <summary>Field number for the "instruments" field.</summary>
    public const int InstrumentsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::CrossTrader.Models.Remoting.InstrumentMessage> _repeated_instruments_codec
        = pb::FieldCodec.ForMessage(10, global::CrossTrader.Models.Remoting.InstrumentMessage.Parser);
    private readonly pbc::RepeatedField<global::CrossTrader.Models.Remoting.InstrumentMessage> instruments_ = new pbc::RepeatedField<global::CrossTrader.Models.Remoting.InstrumentMessage>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::CrossTrader.Models.Remoting.InstrumentMessage> Instruments {
      get { return instruments_; }
    }

    /// <summary>Field number for the "exchanges" field.</summary>
    public const int ExchangesFieldNumber = 2;
    private static readonly pb::FieldCodec<global::CrossTrader.Models.Remoting.ExchangeMessage> _repeated_exchanges_codec
        = pb::FieldCodec.ForMessage(18, global::CrossTrader.Models.Remoting.ExchangeMessage.Parser);
    private readonly pbc::RepeatedField<global::CrossTrader.Models.Remoting.ExchangeMessage> exchanges_ = new pbc::RepeatedField<global::CrossTrader.Models.Remoting.ExchangeMessage>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::CrossTrader.Models.Remoting.ExchangeMessage> Exchanges {
      get { return exchanges_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as InstrumentsResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(InstrumentsResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!instruments_.Equals(other.instruments_)) return false;
      if(!exchanges_.Equals(other.exchanges_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= instruments_.GetHashCode();
      hash ^= exchanges_.GetHashCode();
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
      instruments_.WriteTo(output, _repeated_instruments_codec);
      exchanges_.WriteTo(output, _repeated_exchanges_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += instruments_.CalculateSize(_repeated_instruments_codec);
      size += exchanges_.CalculateSize(_repeated_exchanges_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(InstrumentsResponse other) {
      if (other == null) {
        return;
      }
      instruments_.Add(other.instruments_);
      exchanges_.Add(other.exchanges_);
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
            instruments_.AddEntriesFrom(input, _repeated_instruments_codec);
            break;
          }
          case 18: {
            exchanges_.AddEntriesFrom(input, _repeated_exchanges_codec);
            break;
          }
        }
      }
    }

  }

  internal sealed partial class InstrumentResponse : pb::IMessage<InstrumentResponse> {
    private static readonly pb::MessageParser<InstrumentResponse> _parser = new pb::MessageParser<InstrumentResponse>(() => new InstrumentResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<InstrumentResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CrossTrader.Models.Remoting.InstrumentsReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InstrumentResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InstrumentResponse(InstrumentResponse other) : this() {
      instrument_ = other.instrument_ != null ? other.instrument_.Clone() : null;
      exchange_ = other.exchange_ != null ? other.exchange_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public InstrumentResponse Clone() {
      return new InstrumentResponse(this);
    }

    /// <summary>Field number for the "instrument" field.</summary>
    public const int InstrumentFieldNumber = 1;
    private global::CrossTrader.Models.Remoting.InstrumentMessage instrument_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CrossTrader.Models.Remoting.InstrumentMessage Instrument {
      get { return instrument_; }
      set {
        instrument_ = value;
      }
    }

    /// <summary>Field number for the "exchange" field.</summary>
    public const int ExchangeFieldNumber = 2;
    private global::CrossTrader.Models.Remoting.ExchangeMessage exchange_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CrossTrader.Models.Remoting.ExchangeMessage Exchange {
      get { return exchange_; }
      set {
        exchange_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as InstrumentResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(InstrumentResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Instrument, other.Instrument)) return false;
      if (!object.Equals(Exchange, other.Exchange)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (instrument_ != null) hash ^= Instrument.GetHashCode();
      if (exchange_ != null) hash ^= Exchange.GetHashCode();
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
      if (instrument_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Instrument);
      }
      if (exchange_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Exchange);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (instrument_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Instrument);
      }
      if (exchange_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Exchange);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(InstrumentResponse other) {
      if (other == null) {
        return;
      }
      if (other.instrument_ != null) {
        if (instrument_ == null) {
          Instrument = new global::CrossTrader.Models.Remoting.InstrumentMessage();
        }
        Instrument.MergeFrom(other.Instrument);
      }
      if (other.exchange_ != null) {
        if (exchange_ == null) {
          Exchange = new global::CrossTrader.Models.Remoting.ExchangeMessage();
        }
        Exchange.MergeFrom(other.Exchange);
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
            if (instrument_ == null) {
              Instrument = new global::CrossTrader.Models.Remoting.InstrumentMessage();
            }
            input.ReadMessage(Instrument);
            break;
          }
          case 18: {
            if (exchange_ == null) {
              Exchange = new global::CrossTrader.Models.Remoting.ExchangeMessage();
            }
            input.ReadMessage(Exchange);
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// Ticker
  /// </summary>
  internal sealed partial class TickerMessage : pb::IMessage<TickerMessage> {
    private static readonly pb::MessageParser<TickerMessage> _parser = new pb::MessageParser<TickerMessage>(() => new TickerMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<TickerMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CrossTrader.Models.Remoting.InstrumentsReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TickerMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TickerMessage(TickerMessage other) : this() {
      bestBid_ = other.bestBid_;
      bestAsk_ = other.bestAsk_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TickerMessage Clone() {
      return new TickerMessage(this);
    }

    /// <summary>Field number for the "bestBid" field.</summary>
    public const int BestBidFieldNumber = 1;
    private double bestBid_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double BestBid {
      get { return bestBid_; }
      set {
        bestBid_ = value;
      }
    }

    /// <summary>Field number for the "bestAsk" field.</summary>
    public const int BestAskFieldNumber = 2;
    private double bestAsk_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double BestAsk {
      get { return bestAsk_; }
      set {
        bestAsk_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as TickerMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(TickerMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(BestBid, other.BestBid)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(BestAsk, other.BestAsk)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (BestBid != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(BestBid);
      if (BestAsk != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(BestAsk);
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
      if (BestBid != 0D) {
        output.WriteRawTag(9);
        output.WriteDouble(BestBid);
      }
      if (BestAsk != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(BestAsk);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (BestBid != 0D) {
        size += 1 + 8;
      }
      if (BestAsk != 0D) {
        size += 1 + 8;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(TickerMessage other) {
      if (other == null) {
        return;
      }
      if (other.BestBid != 0D) {
        BestBid = other.BestBid;
      }
      if (other.BestAsk != 0D) {
        BestAsk = other.BestAsk;
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
          case 9: {
            BestBid = input.ReadDouble();
            break;
          }
          case 17: {
            BestAsk = input.ReadDouble();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// Execution
  /// </summary>
  internal sealed partial class ExecutionMessage : pb::IMessage<ExecutionMessage> {
    private static readonly pb::MessageParser<ExecutionMessage> _parser = new pb::MessageParser<ExecutionMessage>(() => new ExecutionMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ExecutionMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CrossTrader.Models.Remoting.InstrumentsReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExecutionMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExecutionMessage(ExecutionMessage other) : this() {
      createdAt_ = other.createdAt_ != null ? other.createdAt_.Clone() : null;
      side_ = other.side_;
      price_ = other.price_;
      size_ = other.size_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExecutionMessage Clone() {
      return new ExecutionMessage(this);
    }

    /// <summary>Field number for the "created_at" field.</summary>
    public const int CreatedAtFieldNumber = 1;
    private global::Google.Protobuf.WellKnownTypes.Timestamp createdAt_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp CreatedAt {
      get { return createdAt_; }
      set {
        createdAt_ = value;
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

    /// <summary>Field number for the "price" field.</summary>
    public const int PriceFieldNumber = 3;
    private double price_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Price {
      get { return price_; }
      set {
        price_ = value;
      }
    }

    /// <summary>Field number for the "size" field.</summary>
    public const int SizeFieldNumber = 4;
    private double size_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Size {
      get { return size_; }
      set {
        size_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ExecutionMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ExecutionMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(CreatedAt, other.CreatedAt)) return false;
      if (Side != other.Side) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Price, other.Price)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Size, other.Size)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (createdAt_ != null) hash ^= CreatedAt.GetHashCode();
      if (Side != 0) hash ^= Side.GetHashCode();
      if (Price != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Price);
      if (Size != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Size);
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
      if (createdAt_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(CreatedAt);
      }
      if (Side != 0) {
        output.WriteRawTag(16);
        output.WriteEnum((int) Side);
      }
      if (Price != 0D) {
        output.WriteRawTag(25);
        output.WriteDouble(Price);
      }
      if (Size != 0D) {
        output.WriteRawTag(33);
        output.WriteDouble(Size);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (createdAt_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CreatedAt);
      }
      if (Side != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Side);
      }
      if (Price != 0D) {
        size += 1 + 8;
      }
      if (Size != 0D) {
        size += 1 + 8;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ExecutionMessage other) {
      if (other == null) {
        return;
      }
      if (other.createdAt_ != null) {
        if (createdAt_ == null) {
          CreatedAt = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        CreatedAt.MergeFrom(other.CreatedAt);
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
            if (createdAt_ == null) {
              CreatedAt = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(CreatedAt);
            break;
          }
          case 16: {
            Side = (global::CrossTrader.Models.Remoting.OrderSide) input.ReadEnum();
            break;
          }
          case 25: {
            Price = input.ReadDouble();
            break;
          }
          case 33: {
            Size = input.ReadDouble();
            break;
          }
        }
      }
    }

  }

  internal sealed partial class ExecutionsResponse : pb::IMessage<ExecutionsResponse> {
    private static readonly pb::MessageParser<ExecutionsResponse> _parser = new pb::MessageParser<ExecutionsResponse>(() => new ExecutionsResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ExecutionsResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CrossTrader.Models.Remoting.InstrumentsReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExecutionsResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExecutionsResponse(ExecutionsResponse other) : this() {
      action_ = other.action_;
      executions_ = other.executions_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ExecutionsResponse Clone() {
      return new ExecutionsResponse(this);
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

    /// <summary>Field number for the "executions" field.</summary>
    public const int ExecutionsFieldNumber = 2;
    private static readonly pb::FieldCodec<global::CrossTrader.Models.Remoting.ExecutionMessage> _repeated_executions_codec
        = pb::FieldCodec.ForMessage(18, global::CrossTrader.Models.Remoting.ExecutionMessage.Parser);
    private readonly pbc::RepeatedField<global::CrossTrader.Models.Remoting.ExecutionMessage> executions_ = new pbc::RepeatedField<global::CrossTrader.Models.Remoting.ExecutionMessage>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::CrossTrader.Models.Remoting.ExecutionMessage> Executions {
      get { return executions_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ExecutionsResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ExecutionsResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Action != other.Action) return false;
      if(!executions_.Equals(other.executions_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Action != 0) hash ^= Action.GetHashCode();
      hash ^= executions_.GetHashCode();
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
      executions_.WriteTo(output, _repeated_executions_codec);
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
      size += executions_.CalculateSize(_repeated_executions_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ExecutionsResponse other) {
      if (other == null) {
        return;
      }
      if (other.Action != 0) {
        Action = other.Action;
      }
      executions_.Add(other.executions_);
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
            executions_.AddEntriesFrom(input, _repeated_executions_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
