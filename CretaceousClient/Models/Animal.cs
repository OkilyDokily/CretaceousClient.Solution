using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CretaceousClient.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }

    public static async Task<List<Animal>> GetAnimals()
    {
      string result = await ApiHelper.GetAll();

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Animal> animalList = JsonConvert.DeserializeObject<List<Animal>>(jsonResponse.ToString());

      return animalList;
    }

    public async static Task<Animal> GetDetails(int id)
    {
      string result = await ApiHelper.Get(id);

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Animal animal = JsonConvert.DeserializeObject<Animal>(jsonResponse.ToString());

      return animal;
    }

    public async static Task Post(Animal animal)
    {
      string jsonAnimal = JsonConvert.SerializeObject(animal);
      await ApiHelper.Post(jsonAnimal);
    }

    public static async Task Delete(int id)
    {
      await ApiHelper.Delete(id);
    }

    public static async Task Put(Animal animal)
    {
      string jsonAnimal = JsonConvert.SerializeObject(animal);
      await ApiHelper.Put(animal.AnimalId, jsonAnimal);
    }
  }
}