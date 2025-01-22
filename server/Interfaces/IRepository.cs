namespace help_reviews.Interfaces;


// interface is a contract that a class subscribes to. When you implement an interface, you must must support the methods from the interface (names, return types, parameter types) but the class handles the actual code inside of the methods
// classes can only inherit from one parent class, but can implement as many interfaces as needed
public interface IRepository<T>
{
  public T GetById(int id);
  public List<T> GetAll();
  public T Create(T rawData);
  public void Update(T updateData);
  public void Delete(int id);
}