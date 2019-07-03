# Protocol Documentation
<a name="top"></a>

## Table of Contents

- [chart.proto](#chart.proto)
    - [OhlcMessage](#crosstrader.OhlcMessage)
    - [OhlcResponse](#crosstrader.OhlcResponse)
    - [TimeFrameRequest](#crosstrader.TimeFrameRequest)
  
  
  
    - [ChartService](#crosstrader.ChartService)
  

- [common.proto](#common.proto)
    - [InstrumentIdRequest](#crosstrader.InstrumentIdRequest)
    - [InstrumentIdsRequest](#crosstrader.InstrumentIdsRequest)
    - [NameRequest](#crosstrader.NameRequest)
  
    - [ChangedAction](#crosstrader.ChangedAction)
    - [OrderSide](#crosstrader.OrderSide)
    - [OrderState](#crosstrader.OrderState)
    - [OrderType](#crosstrader.OrderType)
  
  
  

- [exchanges.proto](#exchanges.proto)
    - [ExchangeMessage](#crosstrader.ExchangeMessage)
    - [ExchangeResponse](#crosstrader.ExchangeResponse)
    - [ExchangesResponse](#crosstrader.ExchangesResponse)
    - [InstrumentMessage](#crosstrader.InstrumentMessage)
  
  
  
    - [ExchangeService](#crosstrader.ExchangeService)
  

- [executions.proto](#executions.proto)
    - [ExecutionMessage](#crosstrader.ExecutionMessage)
    - [ExecutionsResponse](#crosstrader.ExecutionsResponse)
  
  
  
    - [ExecutionsService](#crosstrader.ExecutionsService)
  

- [instruments.proto](#instruments.proto)
    - [InstrumentResponse](#crosstrader.InstrumentResponse)
    - [InstrumentsResponse](#crosstrader.InstrumentsResponse)
  
  
  
    - [InstrumentService](#crosstrader.InstrumentService)
  

- [orderbooks.proto](#orderbooks.proto)
    - [OrderBookRequest](#crosstrader.OrderBookRequest)
    - [OrderBookResponse](#crosstrader.OrderBookResponse)
    - [OrderBookSnapshotRequest](#crosstrader.OrderBookSnapshotRequest)
    - [OrderLevelMessage](#crosstrader.OrderLevelMessage)
    - [UnifiedOrderBookRequest](#crosstrader.UnifiedOrderBookRequest)
    - [UnifiedOrderBookResponse](#crosstrader.UnifiedOrderBookResponse)
    - [UnifiedOrderBookSnapshotRequest](#crosstrader.UnifiedOrderBookSnapshotRequest)
    - [UnifiedOrderLevelMessage](#crosstrader.UnifiedOrderLevelMessage)
  
  
  
    - [OrderBookService](#crosstrader.OrderBookService)
    - [UnifiedOrderBookService](#crosstrader.UnifiedOrderBookService)
  

- [orders.proto](#orders.proto)
    - [EntireOrderCancellationRequest](#crosstrader.EntireOrderCancellationRequest)
    - [EntireOrderCancellationResponse](#crosstrader.EntireOrderCancellationResponse)
    - [OrderCancellationRequest](#crosstrader.OrderCancellationRequest)
    - [OrderCancellationResponse](#crosstrader.OrderCancellationResponse)
    - [OrderMessage](#crosstrader.OrderMessage)
    - [OrderParametersResponse](#crosstrader.OrderParametersResponse)
    - [OrdersRequest](#crosstrader.OrdersRequest)
    - [OrdersResponse](#crosstrader.OrdersResponse)
    - [PostOrderRequest](#crosstrader.PostOrderRequest)
  
  
  
    - [OrdersService](#crosstrader.OrdersService)
  

- [position_histories.proto](#position_histories.proto)
    - [OrderHistoryRequest](#crosstrader.OrderHistoryRequest)
    - [PositionHistoryItemMessage](#crosstrader.PositionHistoryItemMessage)
    - [PositionHistoryMessage](#crosstrader.PositionHistoryMessage)
  
  
  
    - [PositionHistoryService](#crosstrader.PositionHistoryService)
  

- [positions.proto](#positions.proto)
    - [PositionMessage](#crosstrader.PositionMessage)
    - [PositionsResponse](#crosstrader.PositionsResponse)
  
  
  
    - [PositionsService](#crosstrader.PositionsService)
  

- [ticker.proto](#ticker.proto)
    - [TickerMessage](#crosstrader.TickerMessage)
  
  
  
    - [TickerService](#crosstrader.TickerService)
  

- [Scalar Value Types](#scalar-value-types)



<a name="chart.proto"></a>
<p align="right"><a href="#top">Top</a></p>

## chart.proto



<a name="crosstrader.OhlcMessage"></a>

### OhlcMessage

OHLC(Open,High,Low,Close) value


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| opened_at | [google.protobuf.Timestamp](#google.protobuf.Timestamp) |  | Start time of this OHLC |
| open_price | [double](#double) |  | Open price |
| high_price | [double](#double) |  | High price |
| low_price | [double](#double) |  | Low price |
| close_price | [double](#double) |  | Close price |
| volume | [double](#double) |  | Volume |






<a name="crosstrader.OhlcResponse"></a>

### OhlcResponse

OHLC response


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| action | [ChangedAction](#crosstrader.ChangedAction) |  | Changed action |
| items | [OhlcMessage](#crosstrader.OhlcMessage) | repeated | OHLC data |






<a name="crosstrader.TimeFrameRequest"></a>

### TimeFrameRequest



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| instrument_id | [int32](#int32) |  |  |
| time_frame | [google.protobuf.Duration](#google.protobuf.Duration) |  |  |





 

 

 


<a name="crosstrader.ChartService"></a>

### ChartService

Provides OHLC and indicators information.

| Method Name | Request Type | Response Type | Description |
| ----------- | ------------ | ------------- | ------------|
| SubscribeOhlc | [TimeFrameRequest](#crosstrader.TimeFrameRequest) | [OhlcResponse](#crosstrader.OhlcResponse) stream |  |

 



<a name="common.proto"></a>
<p align="right"><a href="#top">Top</a></p>

## common.proto



<a name="crosstrader.InstrumentIdRequest"></a>

### InstrumentIdRequest



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| instrumentId | [int32](#int32) |  | Unique and fixed value in each gRPC server session to identify the exchange and it&#39;s instrument |






<a name="crosstrader.InstrumentIdsRequest"></a>

### InstrumentIdsRequest



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| instrumentIds | [int32](#int32) | repeated |  |






<a name="crosstrader.NameRequest"></a>

### NameRequest



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| name | [string](#string) |  |  |





 


<a name="crosstrader.ChangedAction"></a>

### ChangedAction


| Name | Number | Description |
| ---- | ------ | ----------- |
| ADD | 0 | The data was added |
| REPLACE | 1 | The data was replaced |
| REMOVE | 2 | The data was removed |



<a name="crosstrader.OrderSide"></a>

### OrderSide


| Name | Number | Description |
| ---- | ------ | ----------- |
| ORDER_SIDE_NONE | 0 | Unknown side |
| BUY | 1 | Buy |
| SELL | 2 | Sell |



<a name="crosstrader.OrderState"></a>

### OrderState


| Name | Number | Description |
| ---- | ------ | ----------- |
| ORDER_STATE_NONE | 0 | Unknown state |
| REQUESTING | 1 | Requesting to the exchange server |
| FAILED | 2 | Failed to order |
| ACTIVE | 3 | Order is accepted and listed |
| COMPLETED | 4 | Order is executed |
| CANCELING | 5 | Sending cancel request to the exchange server |
| CANCELED | 6 | Order is canceled |
| EXPIRED | 7 | Order is expired |



<a name="crosstrader.OrderType"></a>

### OrderType


| Name | Number | Description |
| ---- | ------ | ----------- |
| ORDER_TYPE_NONE | 0 |  |
| LIMIT | 1 | Limit order |
| MARKET | 2 | Market order |
| ORDER_TYPE_UNKNOWN | 3 |  |


 

 

 



<a name="exchanges.proto"></a>
<p align="right"><a href="#top">Top</a></p>

## exchanges.proto



<a name="crosstrader.ExchangeMessage"></a>

### ExchangeMessage



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| id | [int32](#int32) |  | Unique value to identify the exchange. It is guaranteed to be fixed within the same gRPC server session. |
| name | [string](#string) |  | Unique name for using in NameRequest |
| display_name | [string](#string) |  | Human readable name |
| description | [string](#string) |  |  |






<a name="crosstrader.ExchangeResponse"></a>

### ExchangeResponse



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| exchange | [ExchangeMessage](#crosstrader.ExchangeMessage) |  |  |
| instruments | [InstrumentMessage](#crosstrader.InstrumentMessage) | repeated |  |






<a name="crosstrader.ExchangesResponse"></a>

### ExchangesResponse



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| exchanges | [ExchangeMessage](#crosstrader.ExchangeMessage) | repeated | List of available exchanges |






<a name="crosstrader.InstrumentMessage"></a>

### InstrumentMessage



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| id | [int32](#int32) |  | Unique and fixed value to identify the instrument and it&#39;s exchange. It is guaranteed to be unique within the same gRPC server session. |
| exchange_id | [int32](#int32) |  |  |
| name | [string](#string) |  | Unique name for using in NameRequest |
| display_name | [string](#string) |  | Human readable name |
| description | [string](#string) |  |  |
| currency_code | [string](#string) |  | Currency code of this instrument. e.g.) XBTUSD |
| can_get_ticker | [bool](#bool) |  | Whether this instrument is support for Unary ticker RPC |
| can_subscribe_ticker | [bool](#bool) |  | Whether this instrument is support for Server Streaming tickers RPC |
| can_get_executions | [bool](#bool) |  | Whether this instrument is support for Unary executions RPC |
| can_subscribe_executions | [bool](#bool) |  | Whether this instrument is support for Server Streaming executions RPC |
| size_decimals | [int32](#int32) |  | Number of digits in this instrument&#39;s currency |
| minimum_size | [double](#double) |  | Minimum order size for this instrument |
| is_order_supported | [bool](#bool) |  | Whether this instrument is support for ordering feature |
| can_get_orders | [bool](#bool) |  | Whether this instrument is support for Unary order listing RPC |
| can_subscribe_orders | [bool](#bool) |  | Whether this instrument is support for Server Streaming orders RPC |
| is_position_supported | [bool](#bool) |  | Whether this instrument is support for position management feature |
| can_get_positions | [bool](#bool) |  | Whether this instrument is support for Unary position listing RPC |
| can_subscribe_positions | [bool](#bool) |  | Whether this instrument is support for Server Streaming positions RPC |





 

 

 


<a name="crosstrader.ExchangeService"></a>

### ExchangeService


| Method Name | Request Type | Response Type | Description |
| ----------- | ------------ | ------------- | ------------|
| GetExchanges | [.google.protobuf.Empty](#google.protobuf.Empty) | [ExchangesResponse](#crosstrader.ExchangesResponse) | Get available exchanges |
| GetExchange | [NameRequest](#crosstrader.NameRequest) | [ExchangeResponse](#crosstrader.ExchangeResponse) | Get an exchange which has specified name |

 



<a name="executions.proto"></a>
<p align="right"><a href="#top">Top</a></p>

## executions.proto



<a name="crosstrader.ExecutionMessage"></a>

### ExecutionMessage



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| created_at | [google.protobuf.Timestamp](#google.protobuf.Timestamp) |  |  |
| side | [OrderSide](#crosstrader.OrderSide) |  |  |
| price | [double](#double) |  |  |
| size | [double](#double) |  |  |






<a name="crosstrader.ExecutionsResponse"></a>

### ExecutionsResponse



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| action | [ChangedAction](#crosstrader.ChangedAction) |  |  |
| executions | [ExecutionMessage](#crosstrader.ExecutionMessage) | repeated |  |





 

 

 


<a name="crosstrader.ExecutionsService"></a>

### ExecutionsService


| Method Name | Request Type | Response Type | Description |
| ----------- | ------------ | ------------- | ------------|
| SubscribeExecutions | [InstrumentIdRequest](#crosstrader.InstrumentIdRequest) | [ExecutionsResponse](#crosstrader.ExecutionsResponse) stream |  |

 



<a name="instruments.proto"></a>
<p align="right"><a href="#top">Top</a></p>

## instruments.proto



<a name="crosstrader.InstrumentResponse"></a>

### InstrumentResponse



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| instrument | [InstrumentMessage](#crosstrader.InstrumentMessage) |  |  |
| exchange | [ExchangeMessage](#crosstrader.ExchangeMessage) |  |  |






<a name="crosstrader.InstrumentsResponse"></a>

### InstrumentsResponse



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| instruments | [InstrumentMessage](#crosstrader.InstrumentMessage) | repeated |  |
| exchanges | [ExchangeMessage](#crosstrader.ExchangeMessage) | repeated |  |





 

 

 


<a name="crosstrader.InstrumentService"></a>

### InstrumentService


| Method Name | Request Type | Response Type | Description |
| ----------- | ------------ | ------------- | ------------|
| GetInstruments | [.google.protobuf.Empty](#google.protobuf.Empty) | [InstrumentsResponse](#crosstrader.InstrumentsResponse) | Get available instruments |
| GetInstrument | [NameRequest](#crosstrader.NameRequest) | [InstrumentResponse](#crosstrader.InstrumentResponse) | Get an instrument which has specified name |

 



<a name="orderbooks.proto"></a>
<p align="right"><a href="#top">Top</a></p>

## orderbooks.proto



<a name="crosstrader.OrderBookRequest"></a>

### OrderBookRequest



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| instrument_id | [int32](#int32) |  |  |
| group_size | [double](#double) |  |  |
| level_count | [int32](#int32) |  |  |






<a name="crosstrader.OrderBookResponse"></a>

### OrderBookResponse
OrderBookResponse

BotTerminal サーバーがデータを送出した順番にincrementされる値
int64 index = 1;
BotTerminal サーバーがデータを送出した日時
google.protobuf.Timestamp streamed_at = 2;


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| asks | [OrderLevelMessage](#crosstrader.OrderLevelMessage) | repeated | asks |
| bids | [OrderLevelMessage](#crosstrader.OrderLevelMessage) | repeated | bids |






<a name="crosstrader.OrderBookSnapshotRequest"></a>

### OrderBookSnapshotRequest



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| instrument_id | [int32](#int32) |  |  |
| group_size | [double](#double) |  |  |
| level_count | [int32](#int32) |  |  |
| interval | [int32](#int32) |  |  |






<a name="crosstrader.OrderLevelMessage"></a>

### OrderLevelMessage



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| lowerbound | [double](#double) |  |  |
| volume | [double](#double) |  |  |






<a name="crosstrader.UnifiedOrderBookRequest"></a>

### UnifiedOrderBookRequest



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| instrument_ids | [int32](#int32) | repeated |  |
| group_size | [double](#double) |  |  |
| level_count | [int32](#int32) |  |  |






<a name="crosstrader.UnifiedOrderBookResponse"></a>

### UnifiedOrderBookResponse
UnifiedOrderBookResponse

// BotTerminal サーバーがデータを送出した順番にincrementされる値
    int64 index = 1;
    // BotTerminal サーバーがデータを送出した日時
    google.protobuf.Timestamp streamed_at = 2;


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| asks | [UnifiedOrderLevelMessage](#crosstrader.UnifiedOrderLevelMessage) | repeated | asks |
| bids | [UnifiedOrderLevelMessage](#crosstrader.UnifiedOrderLevelMessage) | repeated | bids |






<a name="crosstrader.UnifiedOrderBookSnapshotRequest"></a>

### UnifiedOrderBookSnapshotRequest



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| instrument_ids | [int32](#int32) | repeated |  |
| group_size | [double](#double) |  |  |
| level_count | [int32](#int32) |  |  |
| interval | [int32](#int32) |  |  |






<a name="crosstrader.UnifiedOrderLevelMessage"></a>

### UnifiedOrderLevelMessage



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| lowerbound | [double](#double) |  |  |
| asks | [double](#double) | repeated |  |
| bids | [double](#double) | repeated |  |





 

 

 


<a name="crosstrader.OrderBookService"></a>

### OrderBookService


| Method Name | Request Type | Response Type | Description |
| ----------- | ------------ | ------------- | ------------|
| SubscribeOrderBook | [OrderBookRequest](#crosstrader.OrderBookRequest) | [OrderBookResponse](#crosstrader.OrderBookResponse) stream |  |
| SubscribeOrderBookSnapshot | [OrderBookSnapshotRequest](#crosstrader.OrderBookSnapshotRequest) | [OrderBookResponse](#crosstrader.OrderBookResponse) stream | periodically streams snapshot of orderbook |


<a name="crosstrader.UnifiedOrderBookService"></a>

### UnifiedOrderBookService


| Method Name | Request Type | Response Type | Description |
| ----------- | ------------ | ------------- | ------------|
| SubscribeUnifiedOrderBook | [UnifiedOrderBookRequest](#crosstrader.UnifiedOrderBookRequest) | [UnifiedOrderBookResponse](#crosstrader.UnifiedOrderBookResponse) stream | streams unified orderbook changes |
| SubscribeUnifiedOrderBookSnapshot | [UnifiedOrderBookSnapshotRequest](#crosstrader.UnifiedOrderBookSnapshotRequest) | [UnifiedOrderBookResponse](#crosstrader.UnifiedOrderBookResponse) stream | periodically streams snapshot of unified orderbook |

 



<a name="orders.proto"></a>
<p align="right"><a href="#top">Top</a></p>

## orders.proto



<a name="crosstrader.EntireOrderCancellationRequest"></a>

### EntireOrderCancellationRequest



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| instrument_id | [int32](#int32) |  |  |






<a name="crosstrader.EntireOrderCancellationResponse"></a>

### EntireOrderCancellationResponse



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| canceled | [bool](#bool) |  |  |






<a name="crosstrader.OrderCancellationRequest"></a>

### OrderCancellationRequest



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| instrument_id | [int32](#int32) |  |  |
| order_id | [string](#string) |  |  |
| request_id | [string](#string) |  |  |






<a name="crosstrader.OrderCancellationResponse"></a>

### OrderCancellationResponse



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| canceled | [bool](#bool) |  |  |






<a name="crosstrader.OrderMessage"></a>

### OrderMessage



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| id | [google.protobuf.StringValue](#google.protobuf.StringValue) |  |  |
| request_id | [google.protobuf.StringValue](#google.protobuf.StringValue) |  |  |
| side | [OrderSide](#crosstrader.OrderSide) |  |  |
| size | [double](#double) |  |  |
| outstanding_size | [double](#double) |  |  |
| price | [double](#double) |  |  |
| average_price | [double](#double) |  |  |
| state | [OrderState](#crosstrader.OrderState) |  |  |
| type | [OrderType](#crosstrader.OrderType) |  |  |
| ordered_at | [google.protobuf.Timestamp](#google.protobuf.Timestamp) |  |  |






<a name="crosstrader.OrderParametersResponse"></a>

### OrderParametersResponse



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| request_id | [string](#string) |  |  |
| created_at | [google.protobuf.Timestamp](#google.protobuf.Timestamp) |  |  |






<a name="crosstrader.OrdersRequest"></a>

### OrdersRequest
Orders


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| instrument_id | [int32](#int32) |  |  |
| limit | [int32](#int32) |  |  |
| state | [OrderState](#crosstrader.OrderState) |  |  |
| before | [OrderMessage](#crosstrader.OrderMessage) |  |  |
| after | [OrderMessage](#crosstrader.OrderMessage) |  |  |






<a name="crosstrader.OrdersResponse"></a>

### OrdersResponse



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| action | [ChangedAction](#crosstrader.ChangedAction) |  |  |
| orders | [OrderMessage](#crosstrader.OrderMessage) | repeated |  |






<a name="crosstrader.PostOrderRequest"></a>

### PostOrderRequest
Ordering
Order request that can be requested for all exchanges.


| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| instrument_id | [int32](#int32) |  |  |
| side | [OrderSide](#crosstrader.OrderSide) |  |  |
| type | [OrderType](#crosstrader.OrderType) |  |  |
| size | [double](#double) |  |  |
| price | [double](#double) |  |  |





 

 

 


<a name="crosstrader.OrdersService"></a>

### OrdersService


| Method Name | Request Type | Response Type | Description |
| ----------- | ------------ | ------------- | ------------|
| GetOrders | [OrdersRequest](#crosstrader.OrdersRequest) | [OrdersResponse](#crosstrader.OrdersResponse) | Get available orders |
| SubscribeOrders | [InstrumentIdRequest](#crosstrader.InstrumentIdRequest) | [OrdersResponse](#crosstrader.OrdersResponse) stream |  |
| PostOrder | [PostOrderRequest](#crosstrader.PostOrderRequest) | [OrderMessage](#crosstrader.OrderMessage) | Send new order |
| CancelOrder | [OrderCancellationRequest](#crosstrader.OrderCancellationRequest) | [OrderCancellationResponse](#crosstrader.OrderCancellationResponse) |  |
| CancelAllOrders | [EntireOrderCancellationRequest](#crosstrader.EntireOrderCancellationRequest) | [EntireOrderCancellationResponse](#crosstrader.EntireOrderCancellationResponse) |  |

 



<a name="position_histories.proto"></a>
<p align="right"><a href="#top">Top</a></p>

## position_histories.proto



<a name="crosstrader.OrderHistoryRequest"></a>

### OrderHistoryRequest



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| instrument_id | [int32](#int32) |  |  |
| time_frame | [google.protobuf.Duration](#google.protobuf.Duration) |  |  |
| side | [OrderSide](#crosstrader.OrderSide) |  |  |
| before | [google.protobuf.Timestamp](#google.protobuf.Timestamp) |  |  |
| after | [google.protobuf.Timestamp](#google.protobuf.Timestamp) |  |  |






<a name="crosstrader.PositionHistoryItemMessage"></a>

### PositionHistoryItemMessage



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| side | [OrderSide](#crosstrader.OrderSide) |  |  |
| opened_at | [google.protobuf.Timestamp](#google.protobuf.Timestamp) |  |  |
| time_frame | [google.protobuf.Duration](#google.protobuf.Duration) |  |  |
| volume | [double](#double) |  |  |






<a name="crosstrader.PositionHistoryMessage"></a>

### PositionHistoryMessage



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| instrument_id | [int32](#int32) |  |  |
| position_histories | [PositionHistoryItemMessage](#crosstrader.PositionHistoryItemMessage) | repeated |  |





 

 

 


<a name="crosstrader.PositionHistoryService"></a>

### PositionHistoryService


| Method Name | Request Type | Response Type | Description |
| ----------- | ------------ | ------------- | ------------|
| getPositionHistory | [OrderHistoryRequest](#crosstrader.OrderHistoryRequest) | [PositionHistoryMessage](#crosstrader.PositionHistoryMessage) |  |
| subscribePositionHistory | [OrderHistoryRequest](#crosstrader.OrderHistoryRequest) | [PositionHistoryMessage](#crosstrader.PositionHistoryMessage) stream |  |

 



<a name="positions.proto"></a>
<p align="right"><a href="#top">Top</a></p>

## positions.proto



<a name="crosstrader.PositionMessage"></a>

### PositionMessage



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| side | [OrderSide](#crosstrader.OrderSide) |  |  |
| price | [double](#double) |  |  |
| size | [double](#double) |  |  |
| opened_at | [google.protobuf.Timestamp](#google.protobuf.Timestamp) |  |  |






<a name="crosstrader.PositionsResponse"></a>

### PositionsResponse



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| action | [ChangedAction](#crosstrader.ChangedAction) |  |  |
| positions | [PositionMessage](#crosstrader.PositionMessage) | repeated |  |





 

 

 


<a name="crosstrader.PositionsService"></a>

### PositionsService


| Method Name | Request Type | Response Type | Description |
| ----------- | ------------ | ------------- | ------------|
| GetPositions | [InstrumentIdRequest](#crosstrader.InstrumentIdRequest) | [PositionsResponse](#crosstrader.PositionsResponse) |  |
| SubscribePositions | [InstrumentIdRequest](#crosstrader.InstrumentIdRequest) | [PositionsResponse](#crosstrader.PositionsResponse) stream |  |

 



<a name="ticker.proto"></a>
<p align="right"><a href="#top">Top</a></p>

## ticker.proto



<a name="crosstrader.TickerMessage"></a>

### TickerMessage



| Field | Type | Label | Description |
| ----- | ---- | ----- | ----------- |
| bestBid | [double](#double) |  |  |
| bestAsk | [double](#double) |  |  |





 

 

 


<a name="crosstrader.TickerService"></a>

### TickerService


| Method Name | Request Type | Response Type | Description |
| ----------- | ------------ | ------------- | ------------|
| GetTicker | [InstrumentIdRequest](#crosstrader.InstrumentIdRequest) | [TickerMessage](#crosstrader.TickerMessage) |  |
| SubscribeTicker | [InstrumentIdRequest](#crosstrader.InstrumentIdRequest) | [TickerMessage](#crosstrader.TickerMessage) stream |  |

 



## Scalar Value Types

| .proto Type | Notes | C++ Type | Java Type | Python Type |
| ----------- | ----- | -------- | --------- | ----------- |
| <a name="double" /> double |  | double | double | float |
| <a name="float" /> float |  | float | float | float |
| <a name="int32" /> int32 | Uses variable-length encoding. Inefficient for encoding negative numbers – if your field is likely to have negative values, use sint32 instead. | int32 | int | int |
| <a name="int64" /> int64 | Uses variable-length encoding. Inefficient for encoding negative numbers – if your field is likely to have negative values, use sint64 instead. | int64 | long | int/long |
| <a name="uint32" /> uint32 | Uses variable-length encoding. | uint32 | int | int/long |
| <a name="uint64" /> uint64 | Uses variable-length encoding. | uint64 | long | int/long |
| <a name="sint32" /> sint32 | Uses variable-length encoding. Signed int value. These more efficiently encode negative numbers than regular int32s. | int32 | int | int |
| <a name="sint64" /> sint64 | Uses variable-length encoding. Signed int value. These more efficiently encode negative numbers than regular int64s. | int64 | long | int/long |
| <a name="fixed32" /> fixed32 | Always four bytes. More efficient than uint32 if values are often greater than 2^28. | uint32 | int | int |
| <a name="fixed64" /> fixed64 | Always eight bytes. More efficient than uint64 if values are often greater than 2^56. | uint64 | long | int/long |
| <a name="sfixed32" /> sfixed32 | Always four bytes. | int32 | int | int |
| <a name="sfixed64" /> sfixed64 | Always eight bytes. | int64 | long | int/long |
| <a name="bool" /> bool |  | bool | boolean | boolean |
| <a name="string" /> string | A string must always contain UTF-8 encoded or 7-bit ASCII text. | string | String | str/unicode |
| <a name="bytes" /> bytes | May contain any arbitrary sequence of bytes. | string | ByteString | str |

