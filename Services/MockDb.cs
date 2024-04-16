using System.Security.Cryptography;
using APBD5.Classes;

namespace APBD5.Services;

public class MockDb : IMockDb
{
    private ICollection<Animal> _animals;
    public ICollection<Animal> GetAll()
    {
        return _animals;
    }

    public MockDb()
    {
        _animals = new List<Animal>();
    }
    
    public bool Add(Animal animal)
    {
        _animals.Add(animal);
        return true;
    }

    public bool Delete(int id)
    {
        var animalToRemove = _animals.FirstOrDefault(e => e.Id == id);
        if (animalToRemove is null)
            return false;
        _animals.Remove(animalToRemove);
        return true;
    }

    public Animal Get(int id)
    {
        return _animals.FirstOrDefault(e => e.Id == id);
    }

    public bool Replace(Animal animal, int id)
    {
        var animalToRemove = _animals.FirstOrDefault(e => e.Id == id);
        if (animalToRemove is null)
            return false;
        _animals.Remove(animalToRemove);
        _animals.Add(animal);
        return true;
    }
}