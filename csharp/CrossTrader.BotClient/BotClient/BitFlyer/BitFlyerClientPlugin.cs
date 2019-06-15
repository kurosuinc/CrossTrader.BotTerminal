using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrossTrader.Models.Remoting.BitFlyer;

namespace CrossTrader.BotClient.BitFlyer
{
    public sealed class BitFlyerClientPlugin : IDisposable
    {
        private readonly CrossTraderClient _Client;

        internal BitFlyerClientPlugin(CrossTraderClient client)
        {
            _Client = client;
        }

        #region ExecutionsService

        private BitFlyerExecutionsSubscriptions _ExecutionsSubscriptions;

        public event EventHandler<CollectionReceivedEventArgs<BitFlyerExecution>> ExecutionsReceived;

        public event EventHandler<InstrumentIdErrorEventArgs> ExecutionsError;

        internal BitFlyerExecutionsSubscriptions ExecutionsSubscriptions
            => _ExecutionsSubscriptions ?? (_ExecutionsSubscriptions = new BitFlyerExecutionsSubscriptions(_Client));

        [Rpc(nameof(ExecutionsService))]
        public async Task SubscribeExecutionsAsync(int instrumentId, Func<int, CollectionReceivedEventArgs<BitFlyerExecution>, bool> callback, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await _Client.OpenAsync().ConfigureAwait(false))
            using (var res = new ExecutionsService.ExecutionsServiceClient(_Client.Channel).SubscribeExecutions(
                                    new Models.Remoting.InstrumentIdRequest() { InstrumentId = instrumentId },
                                    deadline: deadline,
                                    cancellationToken: cancellationToken))
            {
                while (await res.ResponseStream.MoveNext(cancellationToken).ConfigureAwait(false)
                        && !cancellationToken.IsCancellationRequested)
                {
                    var c = res.ResponseStream.Current;
                    var m = new CollectionReceivedEventArgs<BitFlyerExecution>(
                        c.Action,
                        c.Executions.Select(e => new BitFlyerExecution(instrumentId, e)).Where(e => e.IsValid));

                    if (callback?.Invoke(instrumentId, m) != true)
                    {
                        return;
                    }
                }
            }
        }

        public void SubscribeExecutions(int instrumentId)
            => ExecutionsSubscriptions.Subscribe(instrumentId);

        public void UnsubscribeExecutions(int instrumentId)
            => ExecutionsSubscriptions.Unsubscribe(instrumentId);

        internal void RaiseExecutionsReceived(CollectionReceivedEventArgs<BitFlyerExecution> e)
        {
            if (e?.Data?.Count > 0)
            {
                ExecutionsReceived?.Invoke(this, e);
            }
        }

        internal void RaiseExecutionsError(int instrumentId, Exception exception)
            => ExecutionsError?.Invoke(this, new InstrumentIdErrorEventArgs(instrumentId, exception));

        #endregion ExecutionsService

        public void Dispose()
        {
            _ExecutionsSubscriptions?.Dispose();
            _ExecutionsSubscriptions = null;
            ExecutionsReceived = null;
            ExecutionsError = null;
        }
    }
}