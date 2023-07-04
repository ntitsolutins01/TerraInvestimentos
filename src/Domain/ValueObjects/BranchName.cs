namespace TerraInvestimentos.Domain.ValueObjects;

public class BranchName : ValueObject
{
    static BranchName()
    {
    }

    private BranchName()
    {
    }

    private BranchName(string name)
    {
        Name = name;
    }

    public static BranchName From(string name)
    {
        var nameSupported = new BranchName { Name = name };

        if (!SupportedNames.Contains(nameSupported))
        {
            throw new UnsupportedBranchException(name);
        }

        return nameSupported;
    }

    public static BranchName Develop => new("develop");

    public static BranchName Master => new("master");

    public string Name { get; private set; } = "develop";

    public static implicit operator string(BranchName name)
    {
        return name.ToString();
    }

    public static explicit operator BranchName(string name)
    {
        return From(name);
    }

    public override string ToString()
    {
        return Name;
    }

    protected static IEnumerable<BranchName> SupportedNames
    {
        get
        {
            yield return Develop;
            yield return Master;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}
