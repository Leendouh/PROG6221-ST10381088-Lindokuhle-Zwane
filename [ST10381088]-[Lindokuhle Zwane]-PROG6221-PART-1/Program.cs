using System;

namespace POE1
{
    // Main program class
    public class Program
    {
        private Recipe currentRecipe;

        // Method to start the recipe manager application
        public void Start()
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("++++++++++ RECIPE MANANGER ++++++++++");

            bool running = true;
            while (running)
            {
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("1. Enter a new recipe");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("2. Display the recipe");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("3. Scale the recipe");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("4. Reset recipe scale");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("5. Clear all the data");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("6. Exit");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                string choice = Console.ReadLine();

                // Process user choice
                switch (choice)
                {
                    case "1":
                        EnterRecipe();
                        break;
                    case "2":
                        DisplayRecipe();
                        break;
                    case "3":
                        ScaleRecipe();
                        break;
                    case "4":
                        ResetRecipeScale();
                        break;
                    case "5":
                        ClearRecipe();                      
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
                // Prompt the user to press any key to display the menu again
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Press any key to display the menu again...");
                Console.ReadKey(true);
            }
        }

        // Method to enter a new recipe
        private void EnterRecipe()
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
            Console.Write("Enter the number of ingredients: ");
            int ingredientCount;
            while (!int.TryParse(Console.ReadLine(), out ingredientCount) || ingredientCount <= 0)
            {
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++");
                Console.Write("Invalid input. Please enter a positive integer: ");
            }

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
            Console.Write("Enter the number of steps: ");
            int stepCount;
            while (!int.TryParse(Console.ReadLine(), out stepCount) || stepCount <= 0)
            {
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++");
                Console.Write("Invalid input. Please enter a positive integer: ");
            }

            currentRecipe = new Recipe(ingredientCount, stepCount);

            for (int k = 0; k < ingredientCount; k++)
            {
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.Write($"Enter name of ingredient {k + 1}: ");
                string name = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine("Ingredient name cannot be empty. Please enter a valid name.");
                    k--;
                    continue;
                }

                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.Write($"Enter quantity of {name} (NB. A double): ");
                double quantity;
                while (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.Write("Invalid quantity. Please enter a positive double: ");
                }

                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.Write($"Enter unit of measurement for {name} (e.g. Tablespoon): ");
                string unit = Console.ReadLine().Trim();

                currentRecipe.AddIngredient(k, new Ingredient(name, quantity, unit));
            }


            for (int k = 0; k < stepCount; k++)
            {
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.Write($"Enter step {k + 1} description: ");
                string description = Console.ReadLine();
                currentRecipe.AddStep(k, new RecipeStep(description));
            }
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Recipe entered successfully.");
        }
        // Method to display the recipe
        private void DisplayRecipe()
        {
            if (currentRecipe == null)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("No recipe entered yet. Please enter a recipe first.");
            }
            else
            {
                currentRecipe.DisplayRecipe();
            }
        }
        // Method to scale the recipe
        private void ScaleRecipe()
        {
            if (currentRecipe == null)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("No recipe entered yet. Please enter a recipe first.");
                return;
            }
    
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.Write("Enter the scale factor (e.g. 0,5. 2. 3): ");
            double factor;
            while (!double.TryParse(Console.ReadLine(), out factor) || factor <= 0)
            {
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Invalid scale factor. Please enter a positive number (e.g. 0,5. 2. 3): ");
            }
            currentRecipe?.Scale(factor);
            Console.WriteLine("Recipe scaled successfully");
        }

        // Method to reset the recipe scale
        private void ResetRecipeScale()
        {
            if (currentRecipe == null)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("No recipe entered yet. Please enter a recipe first.");
                return;
            }

            currentRecipe.ResetQuantities();
            Console.WriteLine("Recipe scale reset to original values.");
        }

        // Method to clear the recipe
        private void ClearRecipe()
        {
            currentRecipe = null; // Reset currentRecipe to clear all data
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Recipe data cleared.");
        }

        // Main method
        public static void Main(String[] args)
        {
            Program program = new Program();
            program.Start();
        }

    }
}