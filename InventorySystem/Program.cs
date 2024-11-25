using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace InventorySystem;

class Program
{
    static void Main(string[] args)
    {
        List<string> inventorySlots = new List<string>();
        bool playing = true;
        while (playing) {
            Console.WriteLine("1.) Add");
            Console.WriteLine("2.) Remove");
            Console.WriteLine("3.) Replace");
            Console.WriteLine("4.) List");
            Console.WriteLine("5.) Exit");
            int lengthInv = inventorySlots.Count;
            int action = Convert.ToInt32(Console.ReadLine());
            if (action == 1) {
                Console.WriteLine("What would you like to add?");
                string addedItem = Console.ReadLine();
                inventorySlots.Add(addedItem);
            }
            if (action == 2) {
                foreach (string item in inventorySlots) {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Which would you like to remove? Type No to Leave");
                string removedItem = Console.ReadLine();
                inventorySlots.Remove(removedItem);
            }
            if (action == 3) {
                Console.WriteLine($"Which Slot Would You like to Change? (0-{lengthInv-1})");
                int replacedSlot = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("What would like to swap out?");
                string newItem = Console.ReadLine();
                inventorySlots[replacedSlot] = newItem;
            }
            if (action == 4) {
                foreach (string item in inventorySlots) {
                    Console.WriteLine(item);
                }
            }
            if (action == 5) {
                playing = false;
            }
        }
    }
}
