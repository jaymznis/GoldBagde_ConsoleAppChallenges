using _03_ChallengeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    public class BadgeProgramUI
    {
        private BadgeRepo _repo = new BadgeRepo();

        public void Run()
        {
            SeedContent();
            MenuAccess();
        }
        private void MenuAccess()
        {
            Console.WriteLine("\n\tWelcome to Badge Access!");

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("\n\tPress any Key to Continue");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\n\tPlease select an option: \n" +
                    "\n\t1. Add A Badge\n" +
                    "\t2. Edit a Badge\n" +
                    "\t3. List all Bagdes\n" +
                    "\t4. Delete a Badge\n" +
                    "\t5. Exit");

                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                    case "one":
                        //AddBadge();
                        break;
                    case "2":
                    case "two":
                        UpdateBadge();
                        break;
                    case "3":
                    case "three":
                        ListAllBadges();
                        break;
                    case "4":
                    case "four":
                        //DeleteBadge();
                        break;
                    case "5":
                    case "five":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("\tPlease enter a valid number");
                        break;

                }
            }
        }


        private void UpdateBadge()
        {
            Console.Clear();
            Console.Write("\n\t Enter Badge Number you want to update:\n" +
                "\t #");
            string input = Console.ReadLine();
            int badgeNum = Convert.ToInt32(input);
            Badge badge = _repo.GetByBadgeNum(badgeNum);

            Console.WriteLine($"\n\t #{badge.BadgeID} has access to doors {badge.DoorAccess}.");

            Console.WriteLine($"\n\t What would you like to do?\n" +
                $"\n\t 1. Remove a door\n" +
                $"\t 2. Add a Door");
            string inputTwo = Console.ReadLine();

            switch (inputTwo.ToLower())
            {
                case "1":
                case "one":
                case "remove":
                case "remove a door":
                    Console.WriteLine($"\n\t Which door would you like to remove?\n" +
                        $"\n\t");
                    string doorToRemove = Console.ReadLine();
                    Enum.TryParse(doorToRemove, out DoorAccess removeDoor);
                    _repo.RemoveDoorAccess(badgeNum, removeDoor);
                    Console.WriteLine($"\n\t Badge #{badge.BadgeID} now has access to doors {badge.DoorAccess}.");
                    Console.ReadKey();
                    break;
                case "2":
                case "two":
                case "add":
                case "add a door":
                    Console.WriteLine($"\n\t Which door would you like to add?\n" +
                        $"\n\t");
                    string doorToAdd = Console.ReadLine();
                    Enum.TryParse(doorToAdd, out DoorAccess addDoor);
                    _repo.RemoveDoorAccess(badgeNum, addDoor);
                    Console.WriteLine($"\n\t Badge #{badge.BadgeID} now has access to doors {badge.DoorAccess}.");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine($"\n\t Not a valid option");
                    break;

            }

        }

        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int,Badge> badges = _repo.GetFullDictionary();

            foreach(Badge badge in badges.Values)
            {
                Console.WriteLine($"\n\t Badge #{badge.BadgeID}\n" +
                    $"\t Door Access {badge.DoorAccess}");
            }

        }
        private void SeedContent()
        {
            List<DoorAccess> listOne = new List<DoorAccess>
            {
                DoorAccess.A1,
                DoorAccess.B1,
                DoorAccess.B3
            };
            List<DoorAccess> listTwo = new List<DoorAccess>
            {
                DoorAccess.A2,
                DoorAccess.A3,
                DoorAccess.B3
            };

            Badge bOne = new Badge(1234, listOne);
            Badge bTwo = new Badge(2341, listTwo);

            _repo.AddBadge(bOne);
            _repo.AddBadge(bTwo);

        }
    }
}
