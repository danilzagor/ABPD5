using APBD5.Classes;

namespace APBD5.Services;

public interface IMockDb
{
    public ICollection<Animal> GetAll();
    public bool Add(Animal animal);
    public bool Delete(int id);
    public Animal Get(int id);
    public bool Replace(Animal animal, int id);
}