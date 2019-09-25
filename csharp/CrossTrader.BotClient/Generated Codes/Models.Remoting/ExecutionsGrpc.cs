// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: executions.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CrossTrader.Models.Remoting {
  internal static partial class ExecutionsService
  {
    static readonly string __ServiceName = "crosstrader.ExecutionsService";

    static readonly grpc::Marshaller<global::CrossTrader.Models.Remoting.InstrumentIdRequest> __Marshaller_crosstrader_InstrumentIdRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CrossTrader.Models.Remoting.InstrumentIdRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CrossTrader.Models.Remoting.ExecutionsResponse> __Marshaller_crosstrader_ExecutionsResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CrossTrader.Models.Remoting.ExecutionsResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::CrossTrader.Models.Remoting.InstrumentIdRequest, global::CrossTrader.Models.Remoting.ExecutionsResponse> __Method_SubscribeExecutions = new grpc::Method<global::CrossTrader.Models.Remoting.InstrumentIdRequest, global::CrossTrader.Models.Remoting.ExecutionsResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "SubscribeExecutions",
        __Marshaller_crosstrader_InstrumentIdRequest,
        __Marshaller_crosstrader_ExecutionsResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CrossTrader.Models.Remoting.ExecutionsReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for ExecutionsService</summary>
    public partial class ExecutionsServiceClient : grpc::ClientBase<ExecutionsServiceClient>
    {
      /// <summary>Creates a new client for ExecutionsService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public ExecutionsServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ExecutionsService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public ExecutionsServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected ExecutionsServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected ExecutionsServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncServerStreamingCall<global::CrossTrader.Models.Remoting.ExecutionsResponse> SubscribeExecutions(global::CrossTrader.Models.Remoting.InstrumentIdRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SubscribeExecutions(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::CrossTrader.Models.Remoting.ExecutionsResponse> SubscribeExecutions(global::CrossTrader.Models.Remoting.InstrumentIdRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_SubscribeExecutions, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override ExecutionsServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ExecutionsServiceClient(configuration);
      }
    }

  }
}
#endregion
