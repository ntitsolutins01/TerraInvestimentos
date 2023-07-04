using FluentAssertions;
using NUnit.Framework;
using TerraInvestimentos.Application.Branches.Commands.CreateBranch;
using TerraInvestimentos.Application.Repositories.Commands.CreateRepository;
using TerraInvestimentos.Domain.Entities;

namespace TerraInvestimentos.Application.IntegrationTests.Branches.Commands;

using static Testing;

public class CreateBranchTests : BaseTestFixture
{
    [Test]
    public async Task ShouldCreateBranch()
    {
        

        var command = new CreateRepositoryCommand()
        {
            name = "Repositório",
            @private = false,
            description = "Repositorio Test",
            homepage = "ntitsolutions01@gmail.com",
            is_template = true
            
        };

        var itemId = await SendAsync(command);

        var item = await FindAsync<Branch>(itemId);

        item.Should().NotBeNull();
        item!.Name.Should().Be(command.name);
        item.CreatedBy.Should().Be(GetUserId());
        item.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        item.LastModifiedBy.Should().Be(GetUserId());
        item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
