using System.Collections.Generic;

namespace ToysRMe.CommonLibrary.Contracts
{
  public interface IRepository<T>
  {
    void Add(T product);
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Delete(int id);
    void Update(T product);
  }
}
