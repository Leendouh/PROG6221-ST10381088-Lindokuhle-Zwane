using System;

namespace POE1
{
    // Class representing a step in a recipe
    public class RecipeStep
    {
        public string Description { get; set; } // Description of the step 

        // Constructor to initialize the step with a description
        public RecipeStep(string description)
        {
            Description = description;
        }

        // Override ToString method to return the description of the step
        public override string ToString()
        {
            return Description;
        }
    }
}
