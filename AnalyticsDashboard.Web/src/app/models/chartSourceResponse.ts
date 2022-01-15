export interface ChartSourceResponse {
    name: string;
    series: Series[];
}

export interface Series {
    name: any;
    value: any;
}
