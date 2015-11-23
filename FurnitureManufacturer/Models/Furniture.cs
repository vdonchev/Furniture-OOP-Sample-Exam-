namespace FurnitureManufacturer.Models
{
    using System;
    using Interfaces;

    public abstract class Furniture : IFurniture
    {
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Furniture model can't be null or empty.", nameof(value));
                }

                if (value.Trim().Length < 3)
                {
                    throw new ArgumentException("Furniture model can't be less than 3 symbols.", nameof(value));
                }

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
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Furniture price can't be 0 or negative number");
                }

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
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Furniture length can't be 0 or negative number");
                }

                this.height = value;
            }
        }
    }
}