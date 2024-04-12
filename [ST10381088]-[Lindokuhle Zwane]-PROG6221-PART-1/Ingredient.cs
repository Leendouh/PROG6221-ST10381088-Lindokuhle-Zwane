using System;
namespace POE1
{
    // Class representing an ingredient in a recipe
    public class Ingredient
    {
        // Properties for ingredient name, quantity, and unit of measurement
        private string Name { get; set; }
        private double Quantity { get; set; }
        private string Unit { get; set; }

        private double originalQuantity;

        // Constructor to initialize the ingredient with name, quantity, and unit
        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            originalQuantity = quantity;
        }
        // Method to scale the ingredient quantity by a factor 
        public void Scale(double factor)
        {
            Quantity *= factor;
        }
        // Method to reset the ingredient quantity to its original value
        public void Reset()
        {
            Quantity = originalQuantity;
        }
        // Override ToString method to return a formatted string representation of the ingredient
        public override string ToString()
        {
            return $"{Quantity} {Unit} of {Name}";
        }
    }
}
