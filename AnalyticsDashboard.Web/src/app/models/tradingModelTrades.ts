import { TradeResponse } from "./tradeResponse";
import { TradingModelResponse } from "./tradingModelResponse";

export interface TradingModelTrades {
    tradingModel: TradingModelResponse;
    trades: TradeResponse[];
}