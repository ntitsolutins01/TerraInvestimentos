namespace TerraInvestimentos.Domain.Exceptions;

public class UnsupportedBranchException : Exception
{
    public UnsupportedBranchException(string branch)
        : base($"Nome da branch \"{branch}\" é inválida.")
    {
    }
}
