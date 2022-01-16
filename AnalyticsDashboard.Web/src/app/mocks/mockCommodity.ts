import { CommodityResponse } from "../models/commodityResponse";

const mockCommodity1: CommodityResponse = {
    id: 1,
    name: 'Name 1'
};

const mockCommodity2: CommodityResponse = {
    id: 2,
    name: 'Name 2'
};

const mockCommodity3: CommodityResponse = {
    id: 3,
    name: 'Name 3'
};

const mockCommodityArray: CommodityResponse[] = [mockCommodity1, mockCommodity2, mockCommodity3];

export { mockCommodity1, mockCommodity2, mockCommodity3, mockCommodityArray };