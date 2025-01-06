namespace AutoCarParts.BusinessLogic.RepositoryPattern
{
    public interface IRepositoryCrud <T>
    {
        bool AddInstance(T instance);
        T GetInstanceById(int id);
        bool DeleteInstanceByID(int id);
        bool Update(T entity);
        IEnumerable<T> GetAllEntities();
    }
}
