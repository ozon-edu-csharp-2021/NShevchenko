using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using OzonEdu.MerchandiseService.Grpc;
using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.GrpcServices
{
    public class MerchandiseServiceGrpcService : MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseServiceGrpcService(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        public override async Task<GetByEmployeeResponse> GetByEmployee(
            GetByEmployeeRequest request,
            ServerCallContext context)
        {
            List<Sku> skuList = await _merchandiseService.GetByEmployee(request.EmployeeId, context.CancellationToken);
            return new GetByEmployeeResponse
            {
                Skus =
                {
                    skuList.Select(x => new GetByEmployeeSkuResponse
                    {
                        SkuId = x.SkuId,
                        MerchItem = new GetByEmployeeMerchResponse
                        {
                            ItemId = x.MerchItem.ItemId,
                            ItemName = x.MerchItem.ItemName,
                            ItemProperty =
                            {
                                x.MerchItem.ItemProperty.Select(y => new PropertyPairResponse
                                {
                                    Key = y.Key,
                                    Value = y.Value
                                })
                            }
                        },

                        SkuProperty =
                        {
                            x.SkuProperty.Select(y => new PropertyPairResponse
                            {
                                Key = y.Key,
                                Value = y.Value
                            })
                        }
                    })
                }
            };
        }

        public override async Task<Empty> TakeMerch(TakeMerchRequest request, ServerCallContext context)
        {
            await _merchandiseService.TakeMerch(new SkuSearchModel()
            {
                MerchItem = new MerchSearchItem()
                {
                    ItemName = request.MerchItem.ItemName,
                    ItemProperty =
                        new Dictionary<string, string>(request.MerchItem.ItemProperty.Select(x =>
                            new KeyValuePair<string, string>(x.Key, x.Value)))
                },
                SkuProperty = new Dictionary<string, string>(request.SkuProperty.Select(x =>
                    new KeyValuePair<string, string>(x.Key, x.Value)))
            }, request.EmployeeId, context.CancellationToken);

            return new Empty();
        }
    }
}