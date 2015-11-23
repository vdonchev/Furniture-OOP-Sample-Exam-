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
        private const int MinCompanyNameLength = 5;

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
                Validators.ValidateNullEmpty(value, "Company name");
                Validators.ValidateLength(value, MinCompanyNameLength, "Company name");
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
                Validators.ValidateNull(value, "Company registration number");
                ValidateCompanyNumber(value);
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

        private static void ValidateCompanyNumber(string value)
        {
            if (value.Trim().Length != 10 || !IsOnlyDigits(value))
            {
                throw new ArgumentException(ModelConstants.CompanyNumberError, nameof(value));
            }
        }

        private static bool IsOnlyDigits(string regNum) =>
            Regex.IsMatch(regNum, @"\d{10}");
    }
}