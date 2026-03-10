namespace Framework.Driver
{
    public interface IDriverSessionFactory
    {
        IDriverSession Create(string browser, string baseUrl);
    }
}
