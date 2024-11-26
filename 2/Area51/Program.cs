using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace Area51;

public class Alien
{
    public string Name;
    public string Species;
    public string Planet;
    public string Language;
    public int Age;
    public bool Condenced;


    public Alien(string name, string species, string planet, string language, int age, bool condenced)
    {
        Name = name;
        Species = species;
        Planet = planet;
        Language = language;
        Age = age;
        Condenced = condenced;
    }


    public void Display()
    {
        if (!Condenced) 
        {
            Console.WriteLine($"{Name} is a {Species} from the planet {Planet}, they speak {Language}. They have been in captivity for {Age} years.");
        }
        else
        {
            Console.WriteLine($"{Name} is a {Species} from the planet {Planet}, they speak {Language}. They have been in captivity for {Age} years. They are currently condensed.");
        }
        
    }


}

public class Object : Alien 
{
    public Object(string name, string planet, int age) : base(name, "N/A", planet, "N/A", age, false) {}


}

public class Site 
{
    private List<Alien> alienList = new List<Alien>();

    public void AddAlien(string name, string species, string planet, string language, int age)
    {
        alienList.Add(new Alien(name, species, planet, language, age, false));
        Console.WriteLine($"You have just added a {species} to this site");
    }

    public void AddObject(string name, string planet, int age)
    {
        alienList.Add(new Object(name, planet, age));
        Console.WriteLine($"You have added {name} from {planet} to the site!");
    }

    public void Condence() 
    {
        Console.WriteLine("What is the name of the Alien you would like to condence?");
        string condencedAlienName = Console.ReadLine();
        Alien condencedAlien = alienList.FirstOrDefault(a => a.Name == condencedAlienName);
        condencedAlien.Condenced = true;
        Console.WriteLine($"You have condenced a {condencedAlien.Species}");

    }

    public void CondenceGroup()
    {
        
        foreach (var alien in alienList) 
        {
            Console.WriteLine($"{alien.Name}, from {alien.Planet} has been here for {alien.Age} years");
        }
        Console.WriteLine("Would you like to condence by Age or Species?");
        string group = Console.ReadLine();

        if (group.ToLower() == "age")
        {
            Console.WriteLine("How many aliens would you like to condence?");
            int condencedCount = Convert.ToInt32(Console.ReadLine());
            var orderedAliens = alienList.OrderBy( a => a.Age);
            if (orderedAliens.Count() < condencedCount) {
                Console.WriteLine("You dont have enough aliens to condence that amount");
                return;
            }
            var condencedAliens = orderedAliens.Take(condencedCount);
            foreach (var alien in condencedAliens) 
            {
            alien.Condenced = true;
            Console.WriteLine($"{alien.Name} has been condenced.");
            }

        }
        else if (group.ToLower() == "species")
        {
            Console.WriteLine("Which species would you like to condence?");
            string condencedSpecies = Console.ReadLine();
            var condencedAliens = alienList.Where( a => a.Species == condencedSpecies );
            foreach (var alien in condencedAliens) 
            {
            alien.Condenced = true;
            Console.WriteLine($"{alien.Name} has been condenced.");
            }
        }
        else
        {
            Console.WriteLine("You cannot sort by that.");
            return;
        }
    }

    public void DisplayAll() {
        foreach (var alien in alienList) 
        {
            alien.Display();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Site area51 = new Site();
        int beingCount = 0;
        int objCount = 0;
        Console.WriteLine("Welcome to this Site! Please add 5 Aliens or Alien Objects to enter.");
        while (beingCount != 5) 
        {
            Console.WriteLine("What is the alien's name?");
            string addedName = Console.ReadLine();
            Console.WriteLine($"What species is {addedName}? ");
            string addedSpecies = Console.ReadLine();
            Console.WriteLine($"Where is {addedName} from? ");
            string addedPlanet = Console.ReadLine();
            Console.WriteLine("What language does it speak? ");
            string addedLanguage = Console.ReadLine();
            Console.WriteLine($"How many years has {addedName} been in captivity? ");
            int addedAge = Convert.ToInt32(Console.ReadLine());
            area51.AddAlien(addedName, addedSpecies, addedPlanet, addedLanguage, addedAge);

            beingCount++;

        }
        Console.WriteLine("You have added 5 Aliens to the site. Now add 2 objects");
        while (objCount != 2) 
        {
            Console.WriteLine("What is the objects name?");
            string addedName = Console.ReadLine();
            Console.WriteLine($"Where is the {addedName} from? ");
            string addedPlanet = Console.ReadLine();
            Console.WriteLine($"How many years has the {addedName} been in captivity? ");
            int addedAge = Convert.ToInt32(Console.ReadLine());
            area51.AddObject(addedName, addedPlanet, addedAge);

            objCount++;

        }

        Console.WriteLine("You can now view and manage any species that you want");
        bool playing = true;

        while (playing) {
            Console.WriteLine("1< Add an Alien");
            Console.WriteLine("2< Condence an Alien");
            Console.WriteLine("3< Condence a Group");
            Console.WriteLine("4< Display all Aliens");
            Console.WriteLine("5< Exit");
            int action = Convert.ToInt32(Console.ReadLine());

            if (action == 1)
            {
                Console.WriteLine("What is the alien's name?");
                string addedName = Console.ReadLine();
                Console.WriteLine($"What species is {addedName}? ");
                string addedSpecies = Console.ReadLine();
                Console.WriteLine($"Where is {addedName} from? ");
                string addedPlanet = Console.ReadLine();
                Console.WriteLine("What language does it speak? ");
                string addedLanguage = Console.ReadLine();
                Console.WriteLine($"How many years has {addedName} been in captivity? ");
                int addedAge = Convert.ToInt32(Console.ReadLine());
                area51.AddAlien(addedName, addedSpecies, addedPlanet, addedLanguage, addedAge);

            }
            if (action == 2)
            {
                
                area51.Condence();
                
            }
            if (action == 3)
            {
                area51.CondenceGroup();
                
            }
            if (action == 4)
            {
                area51.DisplayAll();
                
            }
            if (action == 5)
            {
                playing = false;
            }
        }

    }
}
