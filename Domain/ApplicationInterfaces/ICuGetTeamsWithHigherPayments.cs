public interface ICuGetTeamsWithHigherPayments<T>
{
    IEnumerable<T> Execute(double amount);
}
