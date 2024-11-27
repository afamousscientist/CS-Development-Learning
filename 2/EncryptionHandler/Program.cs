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
    string[] alphabet = new string[] {
    "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", 
    "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
    };

    string[] alphabetFull = new string[] {
    // Lowercase letters
    "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
    "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
    // Uppercase letters
    "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
    "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
    // Numbers
    "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
};
    public string newLetter = null;
    public string FirstLayer(string alphaKey)
    {
        List<char> betaList = new List<char>();
        char[] alphaArray = alphaKey.ToCharArray();
        foreach (var letter in alphaArray) 
        {
            var matchingLetter = alphabet.Where( a => a.ToLower() == letter.ToString().ToLower());
            int indexOfMatch = Array.IndexOf(alphabet, letter.ToString().ToUpper());
            int newIndex = indexOfMatch*2;
            if (!(newIndex > 25)) 
            {
                newLetter = alphabet[newIndex];
            }
            else 
            {
                newLetter = alphabet[(newIndex - 26)];
            }
            betaList.Add(Convert.ToChar(newLetter));

        }
        string betaKey = new string(betaList.ToArray());
        return betaKey;
    }


    public string firstPass(string betaKey, string encMaterial) 
    {
        int index = 0;
        List<char> deltaList = new List<char>();
        List<int> betaList = new List<int>();
        List<int> encList = new List<int>();
        char[] betaArray = betaKey.ToCharArray();
        char[] encArray = encMaterial.ToCharArray();

        foreach (var letter in betaArray)
        {
            var matchingLetter = alphabet.Where( a => a.ToLower() == letter.ToString().ToLower());
            int indexOfMatch = Array.IndexOf(alphabet, letter.ToString().ToUpper());
            betaList.Add(indexOfMatch);
        }
        foreach (var encChar in encArray) 
        {
            var matchingLetter = alphabet.Where( a => a.ToLower() == encChar.ToString().ToLower());
            int indexOfMatch = Array.IndexOf(alphabet, encChar.ToString().ToUpper());
            encList.Add(indexOfMatch);
        }
        foreach (var deltaChar in encList) 
        {
            int maxCount = betaList.Count();
            if (index == maxCount){
                index = 0;
            }
            int omegaChar = deltaChar + betaList[index];
            newLetter = alphabetFull[omegaChar];
            deltaList.Add(Convert.ToChar(newLetter));
            index++;
        }
        string onePassEnc = new string(deltaList.ToArray());
        return onePassEnc;
    }
    public static void Main(string[] args)
    {
        Program program = new Program();

        Console.WriteLine("Enter Key (4-16 Letters):");
        string alphaKey = Console.ReadLine();

        if (alphaKey.Length < 4 || alphaKey.Length > 16)
        {
            Console.WriteLine("Invalid input. Key must be 4 to 16 letters.");
            return;
        }

        string betaKey = program.FirstLayer(alphaKey);
        Console.WriteLine("Input the text you would like to encrypt:");
        string encMaterial = Console.ReadLine();
        string encOutput = program.firstPass(betaKey, encMaterial);
        Console.WriteLine($"Here is your encrypted material, with the key: {alphaKey}");
        Console.WriteLine(encOutput);

    }
}

