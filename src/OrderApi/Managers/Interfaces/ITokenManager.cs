namespace OrderApi.Managers.Interfaces;

public interface ITokenManager<in TEntity> where TEntity : class
{
    public (string, double) GenerateToken(TEntity entity);
}