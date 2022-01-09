export interface TradeResponse {
    Id: number;
    TradingModelId: number;
    CommodityId: number;
    Date: Date;
    Contract: string;
    Price: number;
    Position: number;
    NewTradeAction: number;
    PnLDaily: number;
}