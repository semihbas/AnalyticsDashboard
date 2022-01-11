import { CommodityResponse } from "./commodityResponse";
import { TradingModelResponse } from "./tradingModelResponse";

export interface TradeResponse {
    id: number;
    tradingModelId: number;
    commodityId: number;
    date: Date;
    contract: string;
    price: number;
    position: number;
    newTradeAction: number;
    pnLDaily: number;
    commodity: CommodityResponse;
    tradingModel: TradingModelResponse;
}