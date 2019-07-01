using System;
using System.Linq;
using System.Collections.Generic;


namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        //Method that return minimum index that suits diet plans
        public static int SelectMealsUtil(string dietPlan, int[] protein, int[] carbs, int[] fat, int[] calories)
        {

            List<int> item = new List<int>();
            for (int i = 0; i < protein.Length; i++)
            {
                item.Add(i);
            }

            int minMaxElement;

            //Iterating through each character in dietplans
            foreach (var diet in dietPlan)
            {
                switch (diet)
                {
                    case 'P':
                        minMaxElement = Max(protein, item);
                        item = index(protein, item, minMaxElement);
                        break;
                    case 'p':
                        minMaxElement = Min(protein, item);
                        item = index(protein, item, minMaxElement);
                        break;
                    case 'C':
                        minMaxElement = Max(carbs, item);
                        item = index(carbs, item, minMaxElement);
                        break;
                    case 'c':
                        minMaxElement = Min(carbs, item);
                        item = index(carbs, item, minMaxElement);
                        break;
                    case 'F':
                        minMaxElement = Max(fat, item);
                        item = index(fat, item, minMaxElement);
                        break;
                    case 'f':
                        minMaxElement = Min(fat, item);
                        item = index(fat, item, minMaxElement);
                        break;
                    case 'T':
                        minMaxElement = Max(calories, item);
                        item = index(calories, item, minMaxElement);
                        break;
                    case 't':
                        minMaxElement = Min(calories, item);
                        item = index(calories, item, minMaxElement);
                        break;
                }
            }
            return item[0];
        }

        //Method to find list of indexes that contains min or max element
        public static List<int> index(int[] arr, List<int> item, int y)
        {
            List<int> temp = new List<int>();
            foreach (var i in item)
            {
                if (arr[i] == y)
                    temp.Add(i);
            }
            return temp;
        }


        //Method to fnd index of min nutrient in list
        private static int Min(int[] arr, List<int> item)
        {
            int min = arr[item[0]];
            for (int i = 1; i < item.Count; i++)
            {
                if (arr[item[i]] < min)
                    min = arr[item[i]];
            }
            return min;
        }

        //Method to fnd index of max  nutrient in list
        private static int Max(int[] arr, List<int> item)
        {
            int max = arr[item[0]];
            for (int i = 1; i < item.Count; i++)
            {
                if (arr[item[i]] > max)
                    max = arr[item[i]];
            }
            return max;
        }
        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {

            int[] calories = new int[protein.Length];
            int[] ans = new int[dietPlans.Length];
            for (int i = 0; i < protein.Length; i++)
                calories[i] = ((protein[i]) * 5) + ((carbs[i]) * 5) + fat[i] * 9;
            for (int i = 0; i < dietPlans.Length; i++)
                ans[i] = SelectMealsUtil(dietPlans[i], protein, carbs, fat, calories);
            return ans;

        }
    }
}
