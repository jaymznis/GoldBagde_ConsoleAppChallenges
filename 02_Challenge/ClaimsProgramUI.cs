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

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("\n\tPress any Key to Continue");
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
                        //NextClaim();
                        break;
                    case "3":
                    case "three":
                        NewClaim();
                        break;
                    case "4":
                    case "four":
                        //LookUpClaim();
                        break;
                    case "5":
                    case "five":
                        //DeleteClaim();
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
            Queue<Claims> allClaims = _repo.GetClaims();
            Console.WriteLine($"\t Claim ID \t\t Type \t\t Description \t\t Amount \t\t Date Of Accident \t\t Date Of Claim \t\t Claim is Valid");
            Console.WriteLine(".......................................................................................................................");
            foreach (Claims claim in allClaims)
            {
                Console.WriteLine($"\t {claim.ClaimID} \t\t {claim.Type} \t\t {claim.Description} \t\t {claim.Amount} \t\t {claim.DateOfAccident} \t\t {claim.DateOfClaim} \t\t {claim.IsValid}\n");
            }
        }
        private void NewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();

            Console.WriteLine("\n\t Enter Claim ID:");
            newClaim.ClaimID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n\t What is the Claim Type?\n" +
                "\t1. Car\n" +
                "\t2. Home\n" +
                "\t3. Theft\n");
            string input = Console.ReadLine();
            switch (input.ToLower)
            {
                case "1":
                case "one":
                case "car":
                    newClaim.Type(1);
                    break;



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
