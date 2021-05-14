using _01_ChallengeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge
{
    public class MenuProgramUI
    {
        private MenuRepository _repo = new MenuRepository();
    }
    public void Run()
    {
        SeedContent();
        MenuAccess();
    }
    private void MenuAccess()
    {
        bool keepRunning = true;
        while (keepRunning)
        {
            Console.WriteLine("Please select an option: \n" +
                "\n1. Add Menu Item\n" +
                "2. Show Full Menu\n" +
                "3. Veiw Menu Item by Number\n" +
                "4. Update Menu Item\n" +
                "5. Delete Menu Item\n" +
                "6. Exit");

            string input = Console.ReadLine();
            
        }
    }
}
