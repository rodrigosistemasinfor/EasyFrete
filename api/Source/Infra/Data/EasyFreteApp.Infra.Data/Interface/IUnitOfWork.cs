namespace EasyFreteApp.Infra.Data.Interface
{
    public interface IUnitOfWork
    {
        IContext Context { get; }

        bool ExistsTransaction();

        void StartTransaction();

        void Commit();

        void Rollbak();

        void Clear();
    }
}
