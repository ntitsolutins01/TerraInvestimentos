using TerraInvestimentos.Domain.Exceptions;
using TerraInvestimentos.Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace TerraInvestimentos.Domain.UnitTests.ValueObjects;

public class BranchNameTests
{
    [Test]
    public void ShouldReturnCorrectBranchName()
    {
        var name = "develop";

        var branchName = BranchName.From(name);

        branchName.Name.Should().Be(name);
    }

    [Test]
    public void ToStringReturnsName()
    {
        var branchName = BranchName.Develop;

        branchName.ToString().Should().Be(branchName.Name);
    }

    [Test]
    public void ShouldPerformImplicitConversionToBranchNameString()
    {
        string name = BranchName.Develop;

        name.Should().Be("develop");
    }

    [Test]
    public void ShouldPerformExplicitConversionGivenSupportedBranchName()
    {
        var name = (BranchName)"develop";

        name.Should().Be(BranchName.Develop);
    }

    [Test]
    public void ShouldThrowUnsupportedBranchNameExceptionGivenNotSupportedBranchName()
    {
        FluentActions.Invoking(() => BranchName.From("#dev"))
            .Should().Throw<UnsupportedBranchException>();
    }
}
