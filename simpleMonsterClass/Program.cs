using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace simpleMonsterClass
{
	class Program
	{
		static void Main(string[] args)

		{

			DisplayOpeningScreen();
			DisplayMenu();
			DisplayClosingScreen();

		}

		/// <summary>
		/// display opening screen
		/// </summary>

		static void DisplayOpeningScreen()
		{
			Console.Clear();

			Console.WriteLine();
			Console.WriteLine("\t\tWelcome to Simple Monster Classes");
			Console.WriteLine();

			DisplayContinuePrompt();
		}

		static SeaMonster InitializeSeaMonsterSid(string name)
		{
			SeaMonster sid = new SeaMonster("Sid");

			sid.Weight = 2.5;
			sid.CanUseFreshWater = true;
			sid.CurrentEmotionalState = SeaMonster.EmotionalState.HAPPY;
			sid.HomeSea = "Red Sea";
            sid.BirthDate = new DateTime(1994,3,17);

			return sid;
		}

		static SeaMonster InitializeSeaMonsterSuzy()
		{
			SeaMonster suzy = new SeaMonster();

			suzy.Name = "Suzy";
			suzy.Weight = 1.2;
			suzy.CanUseFreshWater = true;
			suzy.CurrentEmotionalState = SeaMonster.EmotionalState.SAD;
			suzy.HomeSea = "Red Sea";
            suzy.BirthDate = new DateTime(1997,3,1);

			return suzy;
		}

		static void DisplaySeaMonsterInfo(List<SeaMonster> seaMonsters)
		{
			string seaMonsterName;
			bool monsterFound = false;

            //
            // get name from user
            //
            while (!monsterFound)
            {
                Console.Clear();
			    DisplayHeader("Display Sea Monster Info");

			    //
			    // display list of sea monster names
			    //
			    foreach (SeaMonster seaMonster in seaMonsters)
			    {
				    Console.WriteLine(seaMonster.Name);
			    }

			    Console.WriteLine();
			    Console.Write("Enter Name: ");
			    seaMonsterName = Console.ReadLine();

			    //
			    // get sea monster from list
			    //
			    foreach (SeaMonster seaMonster in seaMonsters)
			    {
				    if (seaMonster.Name == seaMonsterName)
				    {
					    Console.WriteLine(seaMonster.Name);
					    Console.WriteLine(seaMonster.Weight);
					    Console.WriteLine(seaMonster.CanUseFreshWater);
					    Console.WriteLine(seaMonster.CurrentEmotionalState);
					    Console.WriteLine(seaMonster.HomeSea);
                        Console.WriteLine(seaMonster.BirthDate);
					    monsterFound = true;
					    break;
				    }
			    }

			    //
			    // feedback - monster not found
			    //
			    if (!monsterFound)
			    {
				    Console.WriteLine("Unable to locate monster.");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to enter another Sea Monster.");
                    Console.ReadKey();
			    }
            }


			DisplayContinuePrompt();
		}

		static void DisplayDeleteSeaMonster(List<SeaMonster> seaMonsters)
		{
			string seaMonsterName;
			bool monsterFound = false;

            while (!monsterFound)
            {
			    DisplayHeader("Delete Sea Monster Info");

			    //
			    // display list of sea monster names
			    //
			    foreach (SeaMonster seaMonster in seaMonsters)
			    {
				    Console.WriteLine(seaMonster.Name);
			    }

			    //
			    // get name from user
			    //
			    Console.WriteLine();
			    Console.Write("Enter Name: ");
			    seaMonsterName = Console.ReadLine();

			    //
			    // get sea monster from list
			    //

			    foreach (SeaMonster seaMonster in seaMonsters)
			    {
				    if (seaMonster.Name == seaMonsterName)
				    {
					    seaMonsters.Remove(seaMonster);
					    monsterFound = true;
					    break;
				    }
			    }

			    //
			    // feedback - monster not found
			    //
			    if (!monsterFound)
			    {
				    Console.WriteLine("Unable to locate monster.");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to enter another Sea Monster.");
                    Console.ReadKey();
                }
            }


			DisplayContinuePrompt();
		}

		static void DisplayAllSeaMonsters(List<SeaMonster> seaMonsters)
		{
			DisplayHeader("List of Sea Monsters");
			foreach (SeaMonster seaMonster in seaMonsters)
			{
				Console.WriteLine(seaMonster.SeaMonsterAttitude());
			}

			DisplayContinuePrompt();
		}

		static void DisplayGetUserSeaMonster(List<SeaMonster> seaMonsters)
		{
            bool loop = true;
            double weight;

			//
			// create (instantiate) a new sea monter object
			//
			SeaMonster newSeaMonster = new SeaMonster();

			DisplayHeader("Add a Sea Monster");

			//
			// assaign sea monster properties
			//
			Console.Write("Enter Name: ");
			newSeaMonster.Name = Console.ReadLine();

            //
            // validate weight
            //
            while (loop)
            {
                Console.Clear();
                DisplayHeader("Add a Sea Monster");
                Console.Write("Enter Weight: ");
                if (double.TryParse(Console.ReadLine(), out weight))
                {
                    newSeaMonster.Weight = weight;
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid weight.");
                    Console.ReadKey();
                }
            }


            //
            // validate water type
            //
            while (!loop)
            {
                Console.Clear();
                DisplayHeader("Add a Sea Monster");
                Console.Write("Can Use Freshwater: ");
                string userResponse = Console.ReadLine().ToUpper();
			    if (userResponse == "YES")
			    {
				    newSeaMonster.CanUseFreshWater = true;
                    loop = true;
                }
                else if (userResponse == "NO")
                {
				    newSeaMonster.CanUseFreshWater = false;
                    loop = true;
                }
			    else
			    {
                    Console.WriteLine("Please Enter Yes or No.");
                    Console.ReadKey();
			    }
            }


            //
            // validate emotional state
            //
            while (loop)
            {
                Console.Clear();
                DisplayHeader("Add a Sea Monster");
                Console.Write("Enter Emotional State: ");
                if (Enum.TryParse(Console.ReadLine().ToUpper(), out SeaMonster.EmotionalState emotionalState))
                {
     			    newSeaMonster.CurrentEmotionalState = emotionalState;               
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid emotional state. [Sad, Happy, Angry]");
                    Console.ReadKey();
                }
            }

            //
            // get home sea
            //
            DisplayHeader("Add a Sea Monster");
            Console.Write("Home Sea: ");
			newSeaMonster.HomeSea = Console.ReadLine();

            //
            // validate date of birth
            //
            while (!loop)
            {
                Console.Clear();
                DisplayHeader("Add a Sea Monster");
                Console.Write("Date of Birth [0000,00,00]: ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    newSeaMonster.BirthDate = birthDate;
                    loop = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid birth data. [YEAR,MONTH,DAY] 0000,00,00");
                    Console.ReadKey();
                }
            }   

			seaMonsters.Add(newSeaMonster);

			DisplayContinuePrompt();
		}

		static void DisplayMenu()

		{
			//
			// instantiate sea monsters
			//
			SeaMonster suzy;
			suzy = InitializeSeaMonsterSuzy();

			SeaMonster sid;
			sid = InitializeSeaMonsterSid("Sid");

			//
			// add sea monsters to list
			//
			List<SeaMonster> seaMonsters = new List<SeaMonster>();
			seaMonsters.Add(suzy);
			seaMonsters.Add(sid);

			string menuChoice;

			bool exiting = false;

			while (!exiting)

			{
				DisplayHeader("Main Menu");

				Console.WriteLine("\tA) Display All Sea Monsters");
				Console.WriteLine("\tB) Add a Sea Monster");
				Console.WriteLine("\tC) Display Sea Monster Info");
				Console.WriteLine("\tD) Delete a Sea Monter");
                Console.WriteLine("\tE) Update a Sea Monter");
				Console.WriteLine("\tF) Exit");

				Console.Write("Enter Choice:");
				menuChoice = Console.ReadLine();

				switch (menuChoice)

				{

					case "A":
					case "a":
						DisplayAllSeaMonsters(seaMonsters);
						break;
					case "B":
					case "b":
						DisplayGetUserSeaMonster(seaMonsters);
						break;
					case "C":
					case "c":
						DisplaySeaMonsterInfo(seaMonsters);
						break;
					case "D":
					case "d":
						DisplayDeleteSeaMonster(seaMonsters);
						break;
					case "E":
					case "e":
                        DisplayUpdateSeaMonster(seaMonsters);
						break;
					case "F":
					case "f":
						exiting = true;
						break;
					default:

						break;

				}
			}
		}

        static void DisplayUpdateSeaMonster(List<SeaMonster> seaMonsters)
        {
            string seaMonsterName;
            bool monsterFound = false;

            //
            // get name from user
            //
            while (!monsterFound)
            {
                Console.Clear();
                DisplayHeader("Update a Sea Monster");

                //
                // display list of sea monster names
                //
                foreach (SeaMonster seaMonster in seaMonsters)
                {
                    Console.WriteLine(seaMonster.Name);
                }

                Console.WriteLine();
                Console.Write("Enter Name: ");
                seaMonsterName = Console.ReadLine();

                //
                // get sea monster from list
                //
                foreach (SeaMonster seaMonster in seaMonsters)
                {
                    if (seaMonster.Name == seaMonsterName)
                    {
                        bool loop = true;
                        double weight;

                        //
                        // validate weight
                        //
                        while (loop)
                        {
                            Console.Clear();
                            DisplayHeader($"Updating {seaMonster.Name}");
                            Console.Write("Enter Weight: ");
                            if (double.TryParse(Console.ReadLine(), out weight))
                            {
                                seaMonster.Weight = weight;
                                loop = false;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid weight.");
                                Console.ReadKey();
                            }
                        }


                        //
                        // validate water type
                        //
                        while (!loop)
                        {
                            Console.Clear();
                            DisplayHeader("Add a Sea Monster");
                            Console.Write("Can Use Freshwater: ");
                            string userResponse = Console.ReadLine().ToUpper();
                            if (userResponse == "YES")
                            {
                                seaMonster.CanUseFreshWater = true;
                                loop = true;
                            }
                            else if (userResponse == "NO")
                            {
                                seaMonster.CanUseFreshWater = false;
                                loop = true;
                            }
                            else
                            {
                                Console.WriteLine("Please Enter Yes or No.");
                                Console.ReadKey();
                            }
                        }


                        //
                        // validate emotional state
                        //
                        while (loop)
                        {
                            Console.Clear();
                            DisplayHeader($"Updating {seaMonster.Name}");
                            Console.Write("Enter Emotional State: ");
                            if (Enum.TryParse(Console.ReadLine().ToUpper(), out SeaMonster.EmotionalState emotionalState))
                            {
                                seaMonster.CurrentEmotionalState = emotionalState;
                                loop = false;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid emotional state. [Sad, Happy, Angry]");
                                Console.ReadKey();
                            }
                        }

                        //
                        // get home sea
                        //
                        DisplayHeader($"Updating {seaMonster.Name}");
                        Console.Write("Home Sea: ");
                        seaMonster.HomeSea = Console.ReadLine();

                        //
                        // validate date of birth
                        //
                        while (!loop)
                        {
                            Console.Clear();
                            DisplayHeader($"Updating {seaMonster.Name}");
                            Console.Write("Date of Birth [0000,00,00]: ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                            {
                                seaMonster.BirthDate = birthDate;
                                loop = true;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid birth data. [YEAR,MONTH,DAY] 0000,00,00");
                                Console.ReadKey();
                            }
                        }
                        monsterFound = true;
                        break;
                    }
                }

                //
                // feedback - monster not found
                //
                if (!monsterFound)
                {
                    Console.WriteLine("Unable to locate monster.");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to enter another Sea Monster.");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// display closing screen
        /// </summary>

        static void DisplayClosingScreen()
		{
			Console.Clear();

			Console.WriteLine();
			Console.WriteLine("\t\tThanks for using Simple Monster Classes.");
			Console.WriteLine();

			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
		}

		/// <summary>
		/// display continue prompt
		/// </summary>

		static void DisplayContinuePrompt()
		{
			Console.WriteLine();
			Console.WriteLine("Press any key to continue.");
			Console.ReadKey();
		}

		/// <summary>
		/// display header
		/// </summary>

		static void DisplayHeader(string headerTitle)
		{
			Console.Clear();
			Console.WriteLine();
			Console.WriteLine("\t\t" + headerTitle);
			Console.WriteLine();
		}
	}
}