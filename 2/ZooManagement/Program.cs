using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace ZooManagement;

public class Animal
{
    public string Name;
    public string Species;

    public Animal(string name, string species)
    {
        Name = name;
        Species = species;
    }

    public virtual void MakeSound() 
    {
        Console.WriteLine($"{Name} the {Species} makes a sound!");
    }

}


public class Lemur : Animal 
{
    public Lemur(string name) : base(name, "Lemur") {}

    //if you make a sound with a lemur it will do this, if you make a sound with another animal it will refer back to the virtual method
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} the {Species} makes a Yip!");
    }
}

public class Hippo : Animal 
{
    public Hippo(string name) : base(name, "Hippo") {}

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} the {Species} roars!");
    }
}

public class Clombus : Animal 
{
    public Clombus(string name) : base(name, "Clombus") {}

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} the {Species} gurgles!");
    }
}


public class Zoo 
{
    private List<Animal> animalList = new List<Animal>();

    //when you pass an object from the animal derived class it converts the object to animal
    public void AddAnimal(Animal animal)
    {
        animalList.Add(animal);
        Console.WriteLine($"{animal} added to Zoo!");
    }

    public void DisplayAnimals()
    {
        Console.WriteLine("Animals in your Zoo:");
        foreach (var animal in animalList)
        {
            Console.WriteLine($"{animal.Name} the {animal.Species}");
        }
    }

    public void AllMakeSound()
    {
        foreach (var animal in animalList)
        {
            animal.MakeSound();
        }
    }

    public void SpecificSound(string name)
    {
        foreach (var animal in animalList)
        {
            if (name.ToLower() == animal.Name.ToLower())
            {
                animal.MakeSound();
            }
        }
    }
    public void RemoveAnimal(string name)
    {
        int index = 0;
        foreach (var animal in animalList) {
            if (name.ToLower() == animal.Name.ToLower())
            {
                animalList.RemoveAt(index);
                Console.WriteLine($"{animal.Name} has been Removed");
                return;

            }
            index++;
        }
    }
}



class Program
{
    public static Animal CreateAnimal(string species, string name)
    {
        switch (species.ToLower())
        {
            case "clombus":
                return new Clombus(name);
            case "lemur":
                return new Lemur(name);
            case "hippo":
                return new Hippo(name);
            default:
                return null;
        }
    }
    static void Main(string[] args)
    {
        Zoo newZoo = new Zoo();
        newZoo.AddAnimal(new Clombus("Jingo"));
        newZoo.AddAnimal(new Hippo("Darmian"));

        bool inZoo = true;

        Console.WriteLine("Welcome to the Zoo");
        while (inZoo) 
        {
            Console.WriteLine(" ");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine(" ");
            Console.WriteLine("1< Add Animal");
            Console.WriteLine("2< Remove Animal");
            Console.WriteLine("3< Hear Animal Sound");
            Console.WriteLine("4< All Animals Sound");
            Console.WriteLine("5< Show All Animals");
            Console.WriteLine("6< Exit");

            int action = Convert.ToInt32(Console.ReadLine());

            if (action == 1) 
            {
                Console.WriteLine("What Animal Would You like to add?");
                Console.WriteLine("Clombus");
                Console.WriteLine("Lemur");
                Console.WriteLine("Hippo");
                string addedAnimal = Console.ReadLine();
                Console.WriteLine("What is the Name of this animal");
                string addedName = Console.ReadLine();
                Animal newAnimal = CreateAnimal(addedAnimal, addedName);
                if (newAnimal != null)
                {
                    newZoo.AddAnimal(newAnimal);
                    Console.WriteLine($"Added {addedName} to the Zoo");
                }
                else 
                {
                    Console.WriteLine("This animal is not valid :(");
                }
            }

            if (action == 2) 
            {
                newZoo.DisplayAnimals();
                Console.WriteLine("What is the name of the animal you would like to Remove?");
                string removedAnimal = Console.ReadLine();
                newZoo.RemoveAnimal(removedAnimal);


            }
            if (action == 3) 
            {
                newZoo.DisplayAnimals();
                Console.WriteLine("Which Animal would you like to Hear?");
                string hearAnimal = Console.ReadLine();
                newZoo.SpecificSound(hearAnimal);
                
            }
            if (action == 4) 
            {
                newZoo.AllMakeSound();
                
            }
            if (action == 5) 
            {
                newZoo.DisplayAnimals();
                
            }
            if (action == 6) 
            {
                inZoo = false;
                
            }
        }

    }
}
