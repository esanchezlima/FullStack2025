namespace Library.Service.Domain.Authors.Interfaces
{
    public interface IUnitOfWork
    {
        void Dispose();
        Task<bool> SaveAsync();
    }
}