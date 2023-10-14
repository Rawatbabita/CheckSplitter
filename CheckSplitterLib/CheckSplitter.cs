using System;
using System.Collections.Generic;

namespace CheckSplitterLib
{
    public class CheckSplitter
    {
        public decimal SplitAmount(decimal totalAmount, int numberOfPeople)
        {
            if (numberOfPeople <= 0)
            {
                throw new ArgumentException("Number of people must be greater than zero.");
            }

            return totalAmount / numberOfPeople;
        }

        public Dictionary<string, decimal> CalculateTipPerPerson(Dictionary<string, decimal> mealCosts, float tipPercentage)
        {
            if (mealCosts == null || mealCosts.Count == 0)
            {
                throw new ArgumentException("Meal costs dictionary is empty or null.");
            }

            if (tipPercentage < 0 || tipPercentage > 100)
            {
                throw new ArgumentException("Tip percentage must be between 0 and 100.");
            }

            var totalCost = mealCosts.Values.Sum();

            if (totalCost == 0)
            {
                // Handle the case where the total cost is zero to avoid division by zero.
                return mealCosts.ToDictionary(pair => pair.Key, pair => 0m);
            }

            var tipPerPerson = new Dictionary<string, decimal>();

            foreach (var entry in mealCosts)
            {
                var individualTip = (decimal)(entry.Value / totalCost * (decimal)tipPercentage / 100);
                tipPerPerson.Add(entry.Key, individualTip);
            }

            return tipPerPerson;
        }

        public decimal CalculateTipPerPerson(decimal totalAmount, int numberOfPeople, float tipPercentage)
        {
            if (numberOfPeople <= 0)
            {
                throw new ArgumentException("Number of people must be greater than zero.");
            }

            if (tipPercentage < 0 || tipPercentage > 100)
            {
                throw new ArgumentException("Tip percentage must be between 0 and 100.");
            }

            var tipAmount = totalAmount * (decimal)(tipPercentage / 100);
            return tipAmount / numberOfPeople;
        }
        
    }
}
