using MediatR;

namespace ECommerceAPI.Application.Features.Queries.Basket.GetBasketItem
{
    public class GetBasketItemsQueryRequest: IRequest<List<GetBasketItemsQueryResponse>>
    {
    }
}