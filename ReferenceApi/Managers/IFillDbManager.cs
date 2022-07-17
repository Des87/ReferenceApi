using ReferenceApi.Models;

namespace ReferenceApi.Managers
{
    public interface IFillDbManager
    {
        Task<Weather?> FillDb(string city);
        Task<List<Weather>> FullfillDb(int numberOf);
    }
}