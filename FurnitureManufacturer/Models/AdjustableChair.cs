namespace FurnitureManufacturer.Models
{
    using Interfaces;
    public class AdjustableChair : Chair, IChair, IAdjustableChair
    {
        public AdjustableChair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height) =>
            this.Height = height > 0 ? height : this.Height;
    }
}