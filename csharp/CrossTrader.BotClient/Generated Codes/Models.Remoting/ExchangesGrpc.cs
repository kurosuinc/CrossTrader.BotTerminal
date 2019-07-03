// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: exchanges.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CrossTrader.Models.Remoting {
  internal static partial class ExchangeService
  {
    static readonly string __ServiceName = "crosstrader.ExchangeService";

    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CrossTrader.Models.Remoting.ExchangesResponse> __Marshaller_crosstrader_ExchangesResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CrossTrader.Models.Remoting.ExchangesResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CrossTrader.Models.Remoting.NameRequest> __Marshaller_crosstrader_NameRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CrossTrader.Models.Remoting.NameRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CrossTrader.Models.Remoting.ExchangeResponse> __Marshaller_crosstrader_ExchangeResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CrossTrader.Models.Remoting.ExchangeResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::CrossTrader.Models.Remoting.ExchangesResponse> __Method_GetExchanges = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::CrossTrader.Models.Remoting.ExchangesResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetExchanges",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_crosstrader_ExchangesResponse);

    static readonly grpc::Method<global::CrossTrader.Models.Remoting.NameRequest, global::CrossTrader.Models.Remoting.ExchangeResponse> __Method_GetExchange = new grpc::Method<global::CrossTrader.Models.Remoting.NameRequest, global::CrossTrader.Models.Remoting.ExchangeResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetExchange",
        __Marshaller_crosstrader_NameRequest,
        __Marshaller_crosstrader_ExchangeResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CrossTrader.Models.Remoting.ExchangesReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for ExchangeService</summary>
    public partial class ExchangeServiceClient : grpc::ClientBase<ExchangeServiceClient>
    {
      /// <summary>Creates a new client for ExchangeService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public ExchangeServiceClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ExchangeService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public ExchangeServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected ExchangeServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected ExchangeServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// Get available exchanges
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::CrossTrader.Models.Remoting.ExchangesResponse GetExchanges(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetExchanges(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Get available exchanges
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::CrossTrader.Models.Remoting.ExchangesResponse GetExchanges(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetExchanges, null, options, request);
      }
      /// <summary>
      /// Get available exchanges
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::CrossTrader.Models.Remoting.ExchangesResponse> GetExchangesAsync(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetExchangesAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Get available exchanges
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::CrossTrader.Models.Remoting.ExchangesResponse> GetExchangesAsync(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetExchanges, null, options, request);
      }
      /// <summary>
      /// Get an exchange which has specified name
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::CrossTrader.Models.Remoting.ExchangeResponse GetExchange(global::CrossTrader.Models.Remoting.NameRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetExchange(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Get an exchange which has specified name
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::CrossTrader.Models.Remoting.ExchangeResponse GetExchange(global::CrossTrader.Models.Remoting.NameRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetExchange, null, options, request);
      }
      /// <summary>
      /// Get an exchange which has specified name
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::CrossTrader.Models.Remoting.ExchangeResponse> GetExchangeAsync(global::CrossTrader.Models.Remoting.NameRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetExchangeAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Get an exchange which has specified name
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::CrossTrader.Models.Remoting.ExchangeResponse> GetExchangeAsync(global::CrossTrader.Models.Remoting.NameRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetExchange, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override ExchangeServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ExchangeServiceClient(configuration);
      }
    }

  }
}
#endregion
