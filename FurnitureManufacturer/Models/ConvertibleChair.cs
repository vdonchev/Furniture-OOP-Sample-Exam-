namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public class ConvertibleChair : Chair, IChair, IConvertibleChair
    {
        private const decimal ConvertedChairHeigth = 0.10M;
        private decimal normalStateHeigth;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
            this.IsConverted = false;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            if (!this.IsConverted)
            {
                this.normalStateHeigth = this.Height;
                this.Height = ConvertedChairHeigth;
            }
            else
            {
                this.Height = this.normalStateHeigth;
            }

            this.IsConverted = !this.IsConverted;
        }

        public override string ToString() =>
            $"{base.ToString()}, State: {(this.IsConverted ? "Converted" : "Normal")}";
    }
}