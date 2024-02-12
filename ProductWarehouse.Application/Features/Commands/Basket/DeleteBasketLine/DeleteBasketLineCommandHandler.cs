using MediatR;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Application.Interfaces;
using Serilog;

namespace ProductWarehouse.Application.Features.Commands.Basket.DeleteBasketLine;
public class DeleteBasketLineCommandHandler : IRequestHandler<DeleteBasketLineCommand>
{
    private readonly IUnitOfWork _unitOfWork;
	private readonly ILogger _logger;

	public DeleteBasketLineCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async Task Handle(DeleteBasketLineCommand request, CancellationToken cancellationToken)
    {
        var basketLine = await _unitOfWork.BasketLines.GetByIdAsync(request.basketLineId);
        if (basketLine == null)
        {
			_logger.Error($"No basket found with id: {request.basketLineId}");
			throw new BasketNotFoundException($"No basket found with id: {request.basketLineId}");
		}
        _unitOfWork.BasketLines.Delete(basketLine);
        await _unitOfWork.SaveChangesAsync();
    }
}
