namespace FurnitureManufacturer.Models
{
    using System;
    using Interfaces;

    public abstract class Furniture : IFurniture
    {
        private const int MinModelLength = 3;

        private string model;
        private decimal price;
        private decimal height;

        protected Furniture(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                Validators.ValidateNullEmpty(value, "Furniture model");
                Validators.ValidateLength(value, MinModelLength, "Furniture model");
                this.model = value;
            }
        }

        public string Material { get; }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                Validators.ValidatePositiveNum(value, "Furniture model price");
                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                Validators.ValidatePositiveNum(value, "Furniture height");
                this.height = value;
            }
        }

        public override string ToString() =>
            $"Type: {this.GetType().Name}, Model: {this.Model}, Material: {this.Material}, Price: {this.Price}, Height: {this.Height}";
    }
}