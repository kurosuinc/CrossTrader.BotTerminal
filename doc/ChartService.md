# ChartService

## 型定義ファイル

- [chart.proto](../proto/chart.proto)

## データ型

### `TimeFrameRequest`

- `int32 instrument_id`
- `google.protobuf.Duration time_frame`

### `OhlcMessage`
### `OhlcResponse`

## メソッド
### `SubscribeOhlc (TimeFrameRequest) returns (stream OhlcResponse)`