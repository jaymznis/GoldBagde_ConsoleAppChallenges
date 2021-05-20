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
            Console.WriteLine(@"
____    __    ____  _______  __        ______   ______   .___  ___.  _______    
\   \  /  \  /   / |   ____||  |      /      | /  __  \  |   \/   | |   ____|   
 \   \/    \/   /  |  |__   |  |     |  ,----'|  |  |  | |  \  /  | |  |__      
  \            /   |   __|  |  |     |  |     |  |  |  | |  |\/|  | |   __|     
   \    /\    /    |  |____ |  `----.|  `----.|  `--'  | |  |  |  | |  |____    
    \__/  \__/     |_______||_______| \______| \______/  |__|  |__| |_______|   
                                                                                
                           .___________.  ______                                
                           |           | /  __  \                               
                           `---|  |----`|  |  |  |                              
                               |  |     |  |  |  |                              
                               |  |     |  `--'  |                              
                               |__|      \______/                               
                                                                                
            .______        ___       _______   _______  _______                 
            |   _  \      /   \     |       \ /  _____||   ____|                
            |  |_)  |    /  ^  \    |  .--.  |  |  __  |  |__                   
            |   _  <    /  /_\  \   |  |  |  |  | |_ | |   __|                  
            |  |_)  |  /  _____  \  |  '--'  |  |__| | |  |____                 
            |______/  /__/     \__\ |_______/ \______| |_______|                
                                                                                
           ___       ______   ______  _______     _______.     _______.         
          /   \     /      | /      ||   ____|   /       |    /       |         
         /  ^  \   |  ,----'|  ,----'|  |__     |   (----`   |   (----`         
        /  /_\  \  |  |     |  |     |   __|     \   \        \   \             
       /  _____  \ |  `----.|  `----.|  |____.----)   |   .----)   |            
      /__/     \__\ \______| \______||_______|_______/    |_______/         
");

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("\n\t\t\tPress any Key to Continue");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\n\tPlease select an option: \n" +
                    "\n\t1. Add A Badge\n" +
                    "\t2. Edit a Badge\n" +
                    "\t3. List all Badges\n" +
                    "\t4. Delete a Badge\n" +
                    "\t5. Exit");

                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                    case "one":
                        AddBadge();
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
                        DeleteBadge();
                        break;
                    case "5":
                    case "five":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("\n\tPlease enter a valid number");
                        break;

                }
            }
        }
        private void AddBadge()
        {
            Badge badge = new Badge();
            List<DoorAccess> doorList = new List<DoorAccess>();
            Console.Clear();
            Console.Write($"\n\t What is the number on the badge? # ");
            badge.BadgeID = _repo.StringisInt(Console.ReadLine());
            bool addMoreDoors = true;
            while (addMoreDoors)
            {
                Console.Clear();
                Console.Write($"\n\t Please choose a door to grant access\n" +
                    $"\n\t\t1. A1\n" +
                    $"\t\t2. A2\n" +
                    $"\t\t3. A3\n" +
                    $"\t\t4. A4\n" +
                    $"\t\t5. B1\n" +
                    $"\t\t6. B2\n" +
                    $"\t\t7. B3\n" +
                    $"\t\t8. B4\n" +
                    $"\n\t # ");
                int input = _repo.StringisInt(Console.ReadLine());
                if (input <= 8 && input >= 1)
                {
                    doorList.Add((DoorAccess)input);
                    Console.Write($"\n\t Would you like to add another door?\n" +
                        $"\n\t\t y/n  ");
                    string yN = Console.ReadLine();
                    bool yesNo = true;
                    while (yesNo)
                    {
                        switch (yN.ToLower())
                        {
                            case "y":
                            case "yes":
                                yesNo = false;
                                break;
                            case "n":
                            case "no":
                                badge.DoorAccess = doorList;
                                _repo.AddBadgeToDic(badge);
                                yesNo = false;
                                addMoreDoors = false;
                                break;
                            default:
                                Console.WriteLine("\n\t Yes or No?");
                                break;
                        }
                    }


                }
                else
                {
                    Console.WriteLine($"\n\t That is not a valid option. Please enter a number 1-8");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            Console.WriteLine($"\n\t Badge {badge.BadgeID} has been created and has access to these Doors:");
            ShowDoors(badge);
            Console.ReadKey();

        }



        private void UpdateBadge()
        {
            Console.Clear();
            ListBadgeNums();
            Console.Write("\n\t Enter Badge Number you want to update:\n" +
                "\n\t Badge #: ");
            string input = Console.ReadLine();
            int badgeNum = Convert.ToInt32(input);
            Badge badge = _repo.GetByBadgeNum(badgeNum);
            if (_repo.DictContainsKey(badgeNum))
            {
                Console.WriteLine($"\n\t #{badge.BadgeID} has access to doors:");
                ShowDoors(badge);
                bool updateDoors = true;
                while (updateDoors)
                {
                    Console.Clear();
                    Console.WriteLine($"\n\t What would you like to do?\n" +
                        $"\n\t 1. Remove a door\n" +
                        $"\t 2. Add a Door\n" +
                        $"\t 3. Back to Main Menu");
                    Console.Write("\n\t ");

                    string inputTwo = Console.ReadLine();

                    switch (inputTwo.ToLower())
                    {
                        case "1":
                        case "one":
                        case "remove":
                        case "remove a door":
                            Console.Clear();
                            Console.WriteLine($"\n\t Which door would you like to remove?\n" +
                                $"\n\t");
                            ShowDoors(badge);
                            Console.Write("\n\t Door: ");
                            string doorToRemove = Console.ReadLine();
                            Enum.TryParse(doorToRemove.ToUpper(), out DoorAccess removeDoor);
                            _repo.RemoveDoorAccess(badgeNum, removeDoor);
                            Console.WriteLine($"\n\t Badge #{badge.BadgeID} now has access to doors "); ShowDoors(badge);
                            Console.ReadKey();
                            break;
                        case "2":
                        case "two":
                        case "add":
                        case "add a door":
                            bool addDoorBool = true;
                            while (addDoorBool)
                            {
                                Console.Clear();
                                Console.WriteLine($"\n\t Badge #{badge.BadgeID} currently has access to doors "); ShowDoors(badge);
                                Console.Write($"\n\t Please choose a door to grant access\n" +
                                 $"\n\t\t1. A1\n" +
                                 $"\t\t2. A2\n" +
                                 $"\t\t3. A3\n" +
                                 $"\t\t4. A4\n" +
                                 $"\t\t5. B1\n" +
                                 $"\t\t6. B2\n" +
                                 $"\t\t7. B3\n" +
                                 $"\t\t8. B4\n" +
                                 $"\n\t # ");
                                int addDoor = _repo.StringisInt(Console.ReadLine());
                                if (addDoor <= 8 && addDoor >= 1)
                                {
                                    Console.Clear();
                                    if (DoorDupCheck(badge, addDoor))
                                    {
                                        _repo.AddDoorAccess(badgeNum, addDoor);
                                        Console.WriteLine($"\n\t Badge #{badge.BadgeID} now has access to doors\n" +
                                            $"\n\t ");
                                        ShowDoors(badge);
                                        bool yesNo = true;
                                        while (yesNo)
                                        {
                                            Console.Write($"\n\tWould you like to add another door?\n" +
                                            $"\n\t y/n ");
                                            string inputThree = Console.ReadLine();


                                            switch (inputThree)
                                            {
                                                case "y":
                                                case "yes":
                                                    yesNo = false;
                                                    break;
                                                case "n":
                                                case "no":
                                                    yesNo = false;
                                                    addDoorBool = false;
                                                    break;
                                                default:
                                                    Console.WriteLine($"\n\t Yes or No?");
                                                    break;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine($"\n\t Badge already has Access to that door");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine($"\n\t Please choose a door 1-8");
                                    Console.ReadKey();

                                }
                            }
                            break;
                        case "3":
                        case "three":
                        case "exit":
                        case "main menu":
                        case "back":
                        case "back to main menu":
                            updateDoors = false;
                            break;
                        default:
                            Console.WriteLine($"\n\t Not a valid option");
                            break;

                    }
                }
            }
            else
            {
                Console.WriteLine("\n\t That is not a valid Badge #");
                Console.ReadKey();
                UpdateBadge();
            }

        }

        private void DeleteBadge()
        {
            Console.Clear();
            ListBadgeNums();
            Console.Write("\n\t Enter Badge Number you want to Delete:\n" +
                "\n\t Badge #: ");
            string input = Console.ReadLine();
            int badgeNum = Convert.ToInt32(input);
            Badge badge = _repo.GetByBadgeNum(badgeNum);

            bool yesNo = true;
            while (yesNo)
            {
                Console.Write($"\n\t Are you sure you want to Delete Badge #{badge.BadgeID}?\n" +
                    $"\n\t y/n ");
                string yN = Console.ReadLine();
                switch (yN.ToLower())
                {
                    case "y":
                    case "yes":
                        _repo.RemoveBadgeFromDic(badge);
                        Console.Clear();
                        Console.WriteLine($"\n\t Badge was removed.");
                        yesNo = false;
                        break;
                    case "n":
                    case "no":
                        Console.Clear();
                        Console.WriteLine($"\n\t Badge was not removed.");
                        yesNo = false;
                        break;
                    default:
                        Console.WriteLine("\n\t Yes or No?");
                        break;
                }
            }

        }
        private void ListBadgeNums()
        {
            Console.Clear();
            Dictionary<int, Badge> badges = _repo.GetFullDictionary();

            foreach (Badge badge in badges.Values)
            {
                Console.WriteLine($"\n\t Badge #{badge.BadgeID}\n");

            }

        }

        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, Badge> badges = _repo.GetFullDictionary();

            foreach (Badge badge in badges.Values)
            {
                Console.WriteLine($"\n\t Badge #{badge.BadgeID}\n" +
                    $"\n\t Door Access:\n");
                foreach (DoorAccess item in badge.DoorAccess)
                {
                    Console.Write($"\t\t\t Door {item}");
                    Console.WriteLine("\n");

                }
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

        public bool DoorDupCheck(Badge badge, int num)
        {
            if (badge.DoorAccess.Contains((DoorAccess)num))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ShowDoors(Badge badge)
        {

            foreach (DoorAccess item in badge.DoorAccess)
            {
                Console.Write($"\t\t\t Door {item}");
                Console.WriteLine("\n");

            }
        }

    }
}
