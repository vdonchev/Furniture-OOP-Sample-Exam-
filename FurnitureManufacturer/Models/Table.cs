namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public class Table : Furniture, ITable
    {
        public Table(string model, string material, decimal price, decimal height, decimal length, decimal width)
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length { get; }

        public decimal Width { get; }

        public decimal Area =>
            this.CalculateArea();

        public override string ToString() =>
            $"Type: {this.GetType().Name}, Model: {this.Model}, Material: {this.Material}, Price: {this.Price}, Height: {this.Height}, Length: {this.Length}, Width: {this.Width}, Area: {this.Area}";

        private decimal CalculateArea() =>
            this.Length * this.Width;
    }
}