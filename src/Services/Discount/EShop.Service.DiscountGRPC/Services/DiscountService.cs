namespace EShop.Service.DiscountGRPC.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly DiscountContext _context;
        private readonly ILogger<DiscountService> _logger;

        public DiscountService(DiscountContext context, ILogger<DiscountService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.ProductName == request.ProductName);

            if (coupon == null) 
            {
                coupon = new Coupon
                {
                    ProductName = "No Discount",
                    DiscountAmount = 0,
                    Description = "No Discount Desc"
                };

                _logger.LogInformation("Discount is retrieved for ProductName : {productName}, Amount : {amount}", coupon.ProductName, coupon.DiscountAmount);
            }

            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Received request: {Coupon}", request.Coupon);

            var coupon = request.Coupon.Adapt<Coupon>();

            if (coupon == null)
            {
                _logger.LogError("Mapping failed: request.Coupon is {Coupon}", request.Coupon);
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));
            }

            _context.Coupons.Add(coupon);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Discount is successfully created. ProductName : {ProductName}", coupon.ProductName);

            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();

            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));
            }

            _context.Coupons.Update(coupon);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Discount is successfully updated. ProductName : {ProductName}", coupon.ProductName);

            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }
        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName} is not found."));
            }

            _context.Coupons.Remove(coupon);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Discount is successfully deleted. ProductName : {ProductName}", request.ProductName);

            return new DeleteDiscountResponse { Success = true };
        }
    }
}
