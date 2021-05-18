using _02_ChallengeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge
{
    public class ClaimsProgramUI
    {
        private ClaimsRepo _repo = new ClaimsRepo();

        public void Run()
        {
            SeedContent();
            MenuAccess();
        }
        private void MenuAccess()
        {
            //make it username and password enabled?
            Console.WriteLine("\n\tKomodo Claims Department Access");
            Console.WriteLine("\n\tPress any Key to Continue");


            bool keepRunning = true;
            while (keepRunning)
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\n\tPlease select an option: \n" +
                    "\n\t1. See All Claims\n" +
                    "\t2. Take Care of Next Claim\n" +
                    "\t3. Enter New Claim\n" +
                    "\t4. Look Up Claim by ID\n" +
                    "\t5. Delete Claim\n" +
                    "\t6. Exit");

                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                    case "one":
                        SeeAllClaims();
                        break;
                    case "2":
                    case "two":
                        NextClaim();
                        break;
                    case "3":
                    case "three":
                        NewClaim();
                        break;
                    case "4":
                    case "four":
                        LookUpClaim();
                        break;
                    case "5":
                    case "five":
                        DeleteClaim();
                        break;
                    case "6":
                    case "six":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("\tPlease enter a valid number");
                        break;

                }
            }
        }
        //needs formating
        private void SeeAllClaims()
        {
            Console.Clear();
            if (_repo.ClaimsCount() > 0)
            {
                Queue<Claims> allClaims = _repo.GetClaims();
                //Console.WriteLine($"\t Claim ID \t\t Type \t\t Description \t\t Amount \t\t Date Of Accident \t\t Date Of Claim \t\t Claim is Valid");
                //Console.WriteLine(".......................................................................................................................");
                foreach (Claims claim in allClaims)
                {
                    Console.WriteLine($"\n\t ClaimID: #{claim.ClaimID}\n" +
                   $"\t Type: \t\t\t{claim.Type}\n" +
                   $"\t Description: \t\t{claim.Description}\n" +
                   $"\t Amount: \t\t${claim.Amount}\n" +
                   $"\t Date of Accident: \t{claim.DateOfAccident}\n" +
                   $"\t Date of Claim: \t{claim.DateOfClaim}\n" +
                   $"\t IsValid: \t\t{claim.IsValid}\n" +
                   $"..................................................................................");
                    //Console.WriteLine($"\t {claim.ClaimID} \t\t {claim.Type} \t\t {claim.Description} \t\t {claim.Amount} \t\t {claim.DateOfAccident}} \t\t {claim.DateOfClaim} \t\t {claim.IsValid}\n");
                }
            }
            else
            {
                Console.WriteLine("\n\t Queue is empty ");
            }
        }

        private void SeeIDandDate()
        {
            Queue<Claims> allClaims = _repo.GetClaims();
            foreach (Claims claim in allClaims)
            {
                Console.WriteLine($"\n\t ClaimID: #{claim.ClaimID}\n" +
                    $"\t Date of Claim: { claim.DateOfClaim}\n" +
                    $"---------------------------------------------");
            }

        }
        private void NextClaim()
        {
            Console.Clear();
            if (_repo.ClaimsCount() > 0)
            {
                Claims nextClaim = _repo.ClaimsPeek();
                Console.WriteLine($"\n\t ClaimID: #{nextClaim.ClaimID}\n" +
                    $"\t Type: \t\t\t{nextClaim.Type}\n" +
                    $"\t Description: \t\t{nextClaim.Description}\n" +
                    $"\t Amount: \t\t${nextClaim.Amount}\n" +
                    $"\t Date of Accident: \t{nextClaim.DateOfAccident}\n" +
                    $"\t Date of Claim: \t{nextClaim.DateOfClaim}\n" +
                    $"\t IsValid: \t\t{nextClaim.IsValid}");

                Console.Write("\n\t Would you like to take care of this claim? y/n ");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "y":
                    case "yes":
                        _repo.DequeueClaims();
                        Console.WriteLine("\n\t Queue has been updated");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "n":
                    case "no":
                        Console.WriteLine("\n\t Returning to main menu");
                        Console.ReadKey();
                        Console.Clear();
                        //MenuAccess();
                        break;
                    default:
                        Console.WriteLine("\n\t Please enter a valid option");
                        Console.ReadKey();
                        NextClaim();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n\t There are no more claims to take care of. \n");
            }
        }

        private void NewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();

            Console.Write("\n\t Enter Claim ID#: ");
            newClaim.ClaimID = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Console.Write("\n\t What is the Claim Type?\n" +
                "\t1. Car\n" +
                "\t2. Home\n" +
                "\t3. Theft\n" +
                "\n\t");
            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "1":
                case "one":
                case "car":
                    newClaim.Type = ClaimType.Car;
                    break;
                case "2":
                case "two":
                case "home":
                    newClaim.Type = ClaimType.Home;
                    break;
                case "3":
                case "three":
                case "theft":
                    newClaim.Type = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("\t\n That is not an available option");
                    Console.ReadKey();
                    NewClaim();
                    break;
            }
            Console.Clear();

            Console.Write("\n\t Enter Claim Description:\n" +
                "\n\t");
            newClaim.Description = Console.ReadLine();
            Console.Clear();

            Console.Write("\n\t Eneter Cost of Damage: \n" +
                "\n\t $");
            newClaim.Amount = Convert.ToDouble(Console.ReadLine());
            Console.Clear();

            Console.Write("\n\t Enter Date of Accident:\n" +
                "\tExample: mm dd yyyy or January 1 2021\n" +
                "\n\t");
            DateTime accidnetDate;
            if (DateTime.TryParse(Console.ReadLine(), out accidnetDate))
            {
                newClaim.DateOfAccident = accidnetDate;
            }
            else
            {
                Console.WriteLine("\n\t That format can not be recognized");
                Console.ReadKey();
                NewClaim();
            }

            Console.Write("\n\t Enter Date of Claim:\n" +
                "\tExample: mm dd yyyy or January 1 2021\n" +
                "\n\t");
            DateTime claimDate;
            if (DateTime.TryParse(Console.ReadLine(), out claimDate))
            {
                newClaim.DateOfClaim = claimDate;
            }
            else
            {
                Console.WriteLine("\n\t That format can not be recognized");
                Console.ReadKey();
                NewClaim();
            }
            Console.Clear();


            bool wasAdded = _repo.AddClaim(newClaim);
            if (wasAdded)
            {
                Console.WriteLine("\n\t Claim has been added");
            }
            else
            {
                Console.WriteLine("\n\t Claim could not be added");
            }
        }

        private void LookUpClaim()
        {
            Console.Clear();
            if (_repo.ClaimsCount() > 0)
            {
                SeeIDandDate();
                Console.Write("\n\t Enter Claim ID#:");
                Claims claim = _repo.GetClaimsByID(Convert.ToInt32(Console.ReadLine()));

                if (claim != null)
                {
                    Console.WriteLine($"\n\t ClaimID: #{claim.ClaimID}\n" +
                  $"\t Type: \t\t\t{claim.Type}\n" +
                  $"\t Description: \t\t{claim.Description}\n" +
                  $"\t Amount: \t\t${claim.Amount}\n" +
                  $"\t Date of Accident: \t{claim.DateOfAccident}\n" +
                  $"\t Date of Claim: \t{claim.DateOfClaim}\n" +
                  $"\t IsValid: \t\t{claim.IsValid}\n" +
                  $"..................................................................................");
                    // Console.WriteLine($"\t {claim.ClaimID} \t\t {claim.Type} \t\t {claim.Description} \t\t {claim.Amount} \t\t {claim.DateOfAccident} \t\t {claim.DateOfClaim} \t\t {claim.IsValid}\n");
                }
                else
                {
                    Console.WriteLine("\n\t Can not find Claim");
                }
            }
            else
            {
                Console.WriteLine("\n\t Queue is empty ");
            }
        }

        private void DeleteClaim()
        {
            Console.Clear();
            if (_repo.ClaimsCount() > 0)
            {
                SeeIDandDate();
                Console.Write("\n\t Enter claim ID# that you wish to delete\n" +
                    "\t ID#");
                int itemDelete = Convert.ToInt32(Console.ReadLine());

                Console.Write($"\n\t Are you sure you want to delete Claim #{itemDelete}? y/n ");
                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "y":
                    case "yes":
                        bool wasDeleted = _repo.DeleteClaimByID(itemDelete);

                        if (wasDeleted)
                        {
                            Console.WriteLine("\n\tClaim was deleted");
                        }
                        else
                        {
                            Console.WriteLine("\n\tCould not delete Claim");
                        }
                        break;
                    case "n":
                    case "no":
                        Console.WriteLine("\n\t Claim was not deleted");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("\n\t Not a valid input.\n" +
                            "\n\t Claim was not deleted");
                        Console.ReadKey();
                        DeleteClaim();
                        break;

                }
            }
            else
            {
                Console.WriteLine("\n\t Queue is empty ");
            }

        }

        private void SeedContent()
        {
            Claims c1 = new Claims(1, ClaimType.Car, "Car accident on 465", 400, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            Claims c2 = new Claims(2, ClaimType.Home, "House fire in kitchen.", 4000, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
            Claims c3 = new Claims(3, ClaimType.Theft, "Stolen pancakes.", 4, new DateTime(2018, 04, 27), new DateTime(2018, 06, 02));

            _repo.AddClaim(c1);
            _repo.AddClaim(c2);
            _repo.AddClaim(c3);
        }
    }

}
