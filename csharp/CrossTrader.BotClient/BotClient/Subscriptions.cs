using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CrossTrader.BotClient
{
    internal abstract class Subscriptions<TKey, TResponse> : IDisposable
    {
        private readonly Dictionary<TKey, CancellationTokenSource> _Subscriptions;

        protected Subscriptions(CrossTraderClient client)
        {
            Client = client;
            _Subscriptions = new Dictionary<TKey, CancellationTokenSource>();
        }

        public CrossTraderClient Client { get; }

        public void Subscribe(TKey key)
        {
            lock (_Subscriptions)
            {
                if (_Subscriptions.ContainsKey(key))
                {
                    return;
                }
                var cts = new CancellationTokenSource();
                _Subscriptions[key] = cts;
                SubscribeAsync(key, (k, r) =>
                {
                    lock (_Subscriptions)
                    {
                        if (!_Subscriptions.ContainsKey(k))
                        {
                            return false;
                        }
                    }

                    Notify(k, r);

                    return true;
                }).ContinueWith(t =>
                {
                    lock (_Subscriptions)
                    {
                        if (_Subscriptions.TryGetValue(key, out var cts2)
                            && cts2 == cts)
                        {
                            cts.Cancel();
                            _Subscriptions.Remove(key);
                        }
                    }

                    if (t.IsFaulted)
                    {
                        OnError(key, t.Exception);
                    }
                });
            }
        }

        public void Unsubscribe(TKey key)
        {
            lock (_Subscriptions)
            {
                if (_Subscriptions.TryGetValue(key, out var cts))
                {
                    cts.Cancel();
                    _Subscriptions.Remove(key);
                }
            }
        }

        protected abstract Task SubscribeAsync(TKey key, Func<TKey, TResponse, bool> callback);

        protected abstract void Notify(TKey key, TResponse response);

        protected abstract void OnError(TKey key, Exception exception);

        #region IDisposable Support

        protected bool IsDisposed { get; set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                lock (_Subscriptions)
                {
                    foreach (var cts in _Subscriptions.Values)
                    {
                        cts.Cancel();
                    }
                }
                IsDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion IDisposable Support
    }
}