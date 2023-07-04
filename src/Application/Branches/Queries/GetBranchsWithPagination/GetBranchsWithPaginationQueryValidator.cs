namespace TerraInvestimentos.Application.Branches.Queries.GetBranchsWithPagination;

public class GetBranchsWithPaginationQueryValidator : AbstractValidator<GetBranchsWithPaginationQuery>
{
    public GetBranchsWithPaginationQueryValidator()
    {

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber deve ser pelo menos maior ou igual a 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize deve ser pelo menos maior ou igual a 1.");
    }
}
