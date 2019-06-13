using CrossTrader.Models.Remoting;
using Google.Protobuf.Collections;
using System.Collections.Generic;

namespace CrossTrader.BotClient
{
    public sealed class Exchange
    {
        internal Exchange(ExchangeMessage message, RepeatedField<InstrumentMessage> instruments = null)
        {
            Id = message.Id;
            Name = message.Name;
            DisplayName = message.DisplayName;
            Description = message.Description.EmptyToNull();

            if (instruments != null)
            {
                var items = new Instrument[instruments.Count];
                for (var i = 0; i < items.Length; i++)
                {
                    items[i] = new Instrument(instruments[i]);
                }
#if NETSTANDARD1_5
                Instruments = items;
#else
                Instruments = Array.AsReadOnly(items);
#endif
            }
        }

        public int Id { get; }
        public string Name { get; }
        public string DisplayName { get; }
        public string Description { get; }

#if NETSTANDARD1_5
        public IReadOnlyList<Instrument> Instruments { get; }
#else
        public ReadOnlyCollection<Instrument> Instruments { get; }
#endif
    }
}