using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace EncryptionHandler;

public class Program
{
    //Enncryption is based on each letter being displaced by the next letter over
    string[] alphabetFull = new string[] {
    // Lowercase letters
    "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
    "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
    // White Space
    " ",
    // Uppercase letters
    "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
    "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
    // Numbers
    "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
    // Symbols
    "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=", "+", "[", "]", 
    "{", "}", ";", ":", "'", "\"", ",", ".", "<", ">", "/", "?", "\\", "|", "`", "~"
    };
    public string? newLetter = null;
    public string FirstLayer(string alphaKey)
    {
        List<char> betaList = new List<char>();
        char[] alphaArray = alphaKey.ToCharArray();

        foreach (var letter in alphaArray)
        {
            // Find the index of the letter in the alphabetFull array
            int indexOfMatch = Array.IndexOf(alphabetFull, letter.ToString());

            // Skip processing if the character isn't in alphabetFull
            if (indexOfMatch == -1)
            {
                Console.WriteLine($"Invalid character: {letter}");
                continue;
            }

            // Calculate the new index
            int newIndex = (indexOfMatch * 2) % alphabetFull.Length;

            // Add the new character to betaList
            betaList.Add(Convert.ToChar(alphabetFull[newIndex]));
        }

        return new string(betaList.ToArray());
    }


    public string firstPass(string betaKey, string encMaterial) 
{
    int index = 0; // Keeps track of position in the betaList
    List<char> deltaList = new List<char>(); // Stores encrypted characters
    List<int> betaList = new List<int>(); // Stores indices of betaKey characters in alphabetFull
    List<int> encList = new List<int>(); // Stores indices of encMaterial characters in alphabetFull
    char[] betaArray = betaKey.ToCharArray();
    char[] encArray = encMaterial.ToCharArray();

    // Convert betaKey characters to indices in alphabetFull
    foreach (var letter in betaArray)
    {
        int indexOfMatch = Array.IndexOf(alphabetFull, letter.ToString());
        if (indexOfMatch != -1)
        {
            betaList.Add(indexOfMatch);
        }
        else
        {
            Console.WriteLine($"Invalid character in betaKey: {letter}");
        }
    }

    // Convert encMaterial characters to indices in alphabetFull
    foreach (var encChar in encArray) 
    {
        int indexOfMatch = Array.IndexOf(alphabetFull, encChar.ToString());
        if (indexOfMatch != -1)
        {
            encList.Add(indexOfMatch);
        }
        else
        {
            Console.WriteLine($"Invalid character in encMaterial: {encChar}");
        }
    }

    // Encrypt encMaterial using betaKey indices
    foreach (var deltaChar in encList) 
    {
        if (betaList.Count == 0) 
        {
            Console.WriteLine("Error: betaList is empty, cannot encrypt.");
            return string.Empty;
        }

        // Loop through betaList repeatedly
        if (index >= betaList.Count)
        {
            index = 0;
        }

        // Calculate the new character index
        int omegaChar = (deltaChar + betaList[index]) % alphabetFull.Length;

        // Add the corresponding character to deltaList
        deltaList.Add(Convert.ToChar(alphabetFull[omegaChar]));
        index++;
    }

    // Return the encrypted string
    return new string(deltaList.ToArray());
}
    public static void Main(string[] args)
    {
        Program program = new Program();

        Console.WriteLine("Enter Key (4-16 Letters):");
        string? alphaKey = Console.ReadLine();

        if (string.IsNullOrEmpty(alphaKey) || alphaKey.Length < 4 || alphaKey.Length > 16)
        {
            Console.WriteLine("Invalid input. Key must be 4 to 16 letters.");
            return;
        }

        string betaKey = program.FirstLayer(alphaKey);
        Console.WriteLine("Input the text you would like to encrypt:");
        string? encMaterial = Console.ReadLine();
        if (string.IsNullOrEmpty(encMaterial))
        {
            Console.WriteLine("Invalid input. Material to encrypt cannot be empty.");
            return;
        }
        string encOutput = program.firstPass(betaKey, encMaterial);
        Console.WriteLine($"Here is your encrypted material, with the key: {alphaKey}");
        Console.WriteLine(encOutput);
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();

    }
}

