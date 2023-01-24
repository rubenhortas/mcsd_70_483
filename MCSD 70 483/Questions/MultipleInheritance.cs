namespace Questions
{
    public interface IFile
    {
        void Open();
    }

    public interface IDbConnection
    {
        void Open();
    }

    public class MultipleInterfaces : IFile, IDbConnection
    {
        void IDbConnection.Open()
        {
            Console.WriteLine("IDbConnection open");
        }

        void IFile.Open()
        {
            Console.WriteLine("IFile open");
        }
    }
}
