using TerraInvestimentos.Application.Common.Interfaces;
using TerraInvestimentos.Application.Common.Models;

namespace TerraInvestimentos.Application.Branches.Queries.GetBranchsWithPagination;

public record GetBranchsWithPaginationQuery : IRequest<PaginatedList<BranchDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetBranchsWithPaginationQueryHandler : IRequestHandler<GetBranchsWithPaginationQuery, PaginatedList<BranchDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBranchsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<BranchDto>> Handle(GetBranchsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        //Caso tiver branchs cadastradas na base de dev da empresa
        //return await _context.Branchs
        //    .Where(x => x.ListId == request.ListId)
        //    .OrderBy(x => x.Title)
        //    .ProjectTo<Branch>(_mapper.ConfigurationProvider)
        //    .PaginatedListAsync(request.PageNumber, request.PageSize);
        return null;
    }
}
