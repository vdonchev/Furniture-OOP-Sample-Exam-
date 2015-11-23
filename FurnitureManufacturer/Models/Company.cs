namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Interfaces;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
        }

        public ICollection<IFurniture> Furnitures { get; } = new List<IFurniture>();

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Company name can't be null or empty.", nameof(value));
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException("Company name can't be less than 5 characters.", nameof(value));
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Company registration number can't be null.");
                }

                if (value.Trim().Length != 10 || !IsOnlyDigits(value))
                {
                    throw new ArgumentException("Company registraion number should be eaxctly 10 synbols and must contain only digits.");
                }

                this.registrationNumber = value;
            }
        }

        public void Add(IFurniture furniture) =>
            this.Furnitures.Add(furniture);

        public void Remove(IFurniture furniture) =>
            this.Furnitures.Remove(furniture);

        public IFurniture Find(string model) =>
            this.Furnitures.FirstOrDefault(f => f.Model.ToLower().Equals(model.ToLower()));

        public string Catalog()
        {
            var catalog = new StringBuilder();

            catalog.Append($"{this.Name} - {this.RegistrationNumber} - {(this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no")} {(this.Furnitures.Count != 1 ? "furnitures" : "furniture")}");

            if (this.Furnitures.Count > 0)
            {
                this.Furnitures
                    .OrderBy(f => f.Price)
                    .ThenBy(f => f.Model)
                    .ToList()
                    .ForEach(f => catalog.Append($"{Environment.NewLine}{f}"));
            }

            return catalog.ToString();
        }

        private static bool IsOnlyDigits(string regNum) =>
            Regex.IsMatch(regNum, @"\d{10}");
    }
}