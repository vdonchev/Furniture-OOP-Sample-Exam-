namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public class Chair : Furniture, IChair
    {
        public Chair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs { get; }

        public override string ToString() =>
            $"{base.ToString()}, Legs: {this.NumberOfLegs}";
    }
}