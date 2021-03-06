// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: orderbooks.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CrossTrader.Models.Remoting {
  internal static partial class OrderBookService
  {
    static readonly string __ServiceName = "crosstrader.OrderBookService";

    static readonly grpc::Marshaller<global::CrossTrader.Models.Remoting.OrderBookRequest> __Marshaller_crosstrader_OrderBookRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CrossTrader.Models.Remoting.OrderBookRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CrossTrader.Models.Remoting.OrderBookResponse> __Marshaller_crosstrader_OrderBookResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CrossTrader.Models.Remoting.OrderBookResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CrossTrader.Models.Remoting.OrderBookSnapshotRequest> __Marshaller_crosstrader_OrderBookSnapshotRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CrossTrader.Models.Remoting.OrderBookSnapshotRequest.Parser.ParseFrom);

    static readonly grpc::Method<global::CrossTrader.Models.Remoting.OrderBookRequest, global::CrossTrader.Models.Remoting.OrderBookResponse> __Method_SubscribeOrderBook = new grpc::Method<global::CrossTrader.Models.Remoting.OrderBookRequest, global::CrossTrader.Models.Remoting.OrderBookResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "SubscribeOrderBook",
        __Marshaller_crosstrader_OrderBookRequest,
        __Marshaller_crosstrader_OrderBookResponse);

    static readonly grpc::Method<global::CrossTrader.Models.Remoting.OrderBookSnapshotRequest, global::CrossTrader.Models.Remoting.OrderBookResponse> __Method_SubscribeOrderBookSnapshot = new grpc::Method<global::CrossTrader.Models.Remoting.OrderBookSnapshotRequest, global::CrossTrader.Models.Remoting.OrderBookResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "SubscribeOrderBookSnapshot",
        __Marshaller_crosstrader_OrderBookSnapshotRequest,
        __Marshaller_crosstrader_OrderBookResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CrossTrader.Models.Remoting.OrderbooksReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for OrderBookService</summary>
    public partial class OrderBookServiceClient : grpc::ClientBase<OrderBookServiceClient>
    {
      /// <summary>Creates a new client for OrderBookService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public OrderBookServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for OrderBookService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public OrderBookServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected OrderBookServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected OrderBookServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncServerStreamingCall<global::CrossTrader.Models.Remoting.OrderBookResponse> SubscribeOrderBook(global::CrossTrader.Models.Remoting.OrderBookRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SubscribeOrderBook(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::CrossTrader.Models.Remoting.OrderBookResponse> SubscribeOrderBook(global::CrossTrader.Models.Remoting.OrderBookRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_SubscribeOrderBook, null, options, request);
      }
      /// <summary>
      /// periodically streams snapshot of orderbook
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncServerStreamingCall<global::CrossTrader.Models.Remoting.OrderBookResponse> SubscribeOrderBookSnapshot(global::CrossTrader.Models.Remoting.OrderBookSnapshotRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SubscribeOrderBookSnapshot(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// periodically streams snapshot of orderbook
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncServerStreamingCall<global::CrossTrader.Models.Remoting.OrderBookResponse> SubscribeOrderBookSnapshot(global::CrossTrader.Models.Remoting.OrderBookSnapshotRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_SubscribeOrderBookSnapshot, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override OrderBookServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new OrderBookServiceClient(configuration);
      }
    }

  }
  internal static partial class UnifiedOrderBookService
  {
    static readonly string __ServiceName = "crosstrader.UnifiedOrderBookService";

    static readonly grpc::Marshaller<global::CrossTrader.Models.Remoting.UnifiedOrderBookRequest> __Marshaller_crosstrader_UnifiedOrderBookRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CrossTrader.Models.Remoting.UnifiedOrderBookRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CrossTrader.Models.Remoting.UnifiedOrderBookResponse> __Marshaller_crosstrader_UnifiedOrderBookResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CrossTrader.Models.Remoting.UnifiedOrderBookResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CrossTrader.Models.Remoting.UnifiedOrderBookSnapshotRequest> __Marshaller_crosstrader_UnifiedOrderBookSnapshotRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CrossTrader.Models.Remoting.UnifiedOrderBookSnapshotRequest.Parser.ParseFrom);

    static readonly grpc::Method<global::CrossTrader.Models.Remoting.UnifiedOrderBookRequest, global::CrossTrader.Models.Remoting.UnifiedOrderBookResponse> __Method_SubscribeUnifiedOrderBook = new grpc::Method<global::CrossTrader.Models.Remoting.UnifiedOrderBookRequest, global::CrossTrader.Models.Remoting.UnifiedOrderBookResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "SubscribeUnifiedOrderBook",
        __Marshaller_crosstrader_UnifiedOrderBookRequest,
        __Marshaller_crosstrader_UnifiedOrderBookResponse);

    static readonly grpc::Method<global::CrossTrader.Models.Remoting.UnifiedOrderBookSnapshotRequest, global::CrossTrader.Models.Remoting.UnifiedOrderBookResponse> __Method_SubscribeUnifiedOrderBookSnapshot = new grpc::Method<global::CrossTrader.Models.Remoting.UnifiedOrderBookSnapshotRequest, global::CrossTrader.Models.Remoting.UnifiedOrderBookResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "SubscribeUnifiedOrderBookSnapshot",
        __Marshaller_crosstrader_UnifiedOrderBookSnapshotRequest,
        __Marshaller_crosstrader_UnifiedOrderBookResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CrossTrader.Models.Remoting.OrderbooksReflection.Descriptor.Services[1]; }
    }

    /// <summary>Client for UnifiedOrderBookService</summary>
    public partial class UnifiedOrderBookServiceClient : grpc::ClientBase<UnifiedOrderBookServiceClient>
    {
      /// <summary>Creates a new client for UnifiedOrderBookService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public UnifiedOrderBookServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for UnifiedOrderBookService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public UnifiedOrderBookServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected UnifiedOrderBookServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected UnifiedOrderBookServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// streams unified orderbook changes
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncServerStreamingCall<global::CrossTrader.Models.Remoting.UnifiedOrderBookResponse> SubscribeUnifiedOrderBook(global::CrossTrader.Models.Remoting.UnifiedOrderBookRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SubscribeUnifiedOrderBook(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// streams unified orderbook changes
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncServerStreamingCall<global::CrossTrader.Models.Remoting.UnifiedOrderBookResponse> SubscribeUnifiedOrderBook(global::CrossTrader.Models.Remoting.UnifiedOrderBookRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_SubscribeUnifiedOrderBook, null, options, request);
      }
      /// <summary>
      /// periodically streams snapshot of unified orderbook 
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncServerStreamingCall<global::CrossTrader.Models.Remoting.UnifiedOrderBookResponse> SubscribeUnifiedOrderBookSnapshot(global::CrossTrader.Models.Remoting.UnifiedOrderBookSnapshotRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SubscribeUnifiedOrderBookSnapshot(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// periodically streams snapshot of unified orderbook 
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncServerStreamingCall<global::CrossTrader.Models.Remoting.UnifiedOrderBookResponse> SubscribeUnifiedOrderBookSnapshot(global::CrossTrader.Models.Remoting.UnifiedOrderBookSnapshotRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_SubscribeUnifiedOrderBookSnapshot, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override UnifiedOrderBookServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new UnifiedOrderBookServiceClient(configuration);
      }
    }

  }
}
#endregion
