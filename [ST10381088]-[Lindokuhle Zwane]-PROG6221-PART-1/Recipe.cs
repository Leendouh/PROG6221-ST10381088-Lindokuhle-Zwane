using System;
using System.Text;

namespace POE1
{
    // Class representing a recipe
    public class Recipe
    {
        // Properties for ingredients and steps of the recipe
        private Ingredient[] Ingredients { get; set; }
        private RecipeStep[] Steps { get; set; }
        private Ingredient[] OriginalIngredients { get; set; }

        private double scale = 1.0;

        // Constructor to initialize the recipe with the specified number of ingredients and steps
        public Recipe(int ingredientCount, int stepCount)
        {
            Ingredients = new Ingredient[ingredientCount];
            Steps = new RecipeStep[stepCount];
        }

        // Method to add an ingredient to the recipe at the specified index
        public void AddIngredient(int index, Ingredient ingredient)
        {
            if (index >= 0 && index < Ingredients.Length)
            {
                Ingredients[index] = ingredient;
            }
        }

        // Method to add a step to the recipe at the specified index
        public void AddStep(int index, RecipeStep step)
        {
            if (index >= 0 && index < Steps.Length)
            {
                Steps[index] = step;
            }
        }

        // Method to scale the recipe ingredients by a factor
        public void Scale(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Scale(factor);
            }
            scale *= factor;
        }

        // Method to reset ingredient quantities to their original values
        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Reset();
            }
            scale = 1.0;
        }

        // Override ToString method to return a formatted string representation of the recipe
        public override string ToString()
        {
            var display = new StringBuilder();
            display.AppendLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                display.AppendLine($"- {ingredient}");
            }
            display.AppendLine("Steps:");
            int stepNumber = 1;
            foreach (var step in Steps)
            {
                display.AppendLine($"{stepNumber++}. {step}");
            }
            return display.ToString();
        }
        // Method to display the recipe in the console
        public void DisplayRecipe()
        {
            Console.WriteLine("===================================================");
            Console.WriteLine("Recipe Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine("===================================================");
                Console.WriteLine(ingredient);
            }

            Console.WriteLine("===================================================");
            Console.WriteLine("\nRecipe Steps:");
            for (int k = 0; k < Steps.Length; k++)
            {
                Console.WriteLine("===================================================");
                Console.WriteLine($"{k + 1}. {Steps[k]}");
            }
        }

    }
}
