﻿namespace ECommerceAPI.Application.Features.Queries.Basket.GetBasketItem
{
    public class GetBasketItemsQueryResponse
    {
        public string BasketItemId { get; set; }
        public string  Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}