namespace LessonForElshen.Repository
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        Task CompleteAsync(CancellationToken cancellationToken);
        Task CompleteAsync();
    }
}
