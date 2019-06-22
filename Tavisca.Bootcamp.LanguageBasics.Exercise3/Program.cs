using System;
using System.Linq;
using System.Collections;

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

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int[] output = new int[dietPlans.Length];

            int[] calories = new int[protein.Length];
            for (int i = 0; i < protein.Length; i++)
            {
                calories[i] = fat[i] * 9 + carbs[i] * 5 + protein[i] * 5;
            }

            for (int i = 0; i < dietPlans.Length; i++)
            {

                string diet = dietPlans[i];

                if (diet.Length == 0)
                {

                    output[i] = 0;

                }
                else
                {
                    ArrayList tempList = new ArrayList();
                    for (int j = 0; j < diet.Length; j++)
                    {
                        char[] temp = diet.ToCharArray();
                        if (temp[j] == 'P')
                        {
                            tempList = SelectMealsUtil(protein, tempList, "max");
                        }
                        else if (temp[j] == 'p')
                        {
                            tempList = SelectMealsUtil(protein, tempList, "min");
                        }
                        else if (temp[j] == 'C')
                        {
                            tempList = SelectMealsUtil(carbs, tempList, "max");
                        }
                        else if (temp[j] == 'c')
                        {
                            tempList = SelectMealsUtil(carbs, tempList, "min");
                        }
                        else if (temp[j] == 'F')
                        {
                            tempList = SelectMealsUtil(fat, tempList, "max");
                        }
                        else if (temp[j] == 'f')
                        {
                            tempList = SelectMealsUtil(fat, tempList, "min");
                        }
                        else if (temp[j] == 'T')
                        {
                            tempList = SelectMealsUtil(calories, tempList, "max");
                        }
                        else if (temp[j] == 't')
                        {
                            tempList = SelectMealsUtil(calories, tempList, "min");
                        }
                    }
                    output[i] = (int)tempList[0];
                }
            }
            return output;
            throw new NotImplementedException();
        }


        public static ArrayList SelectMealsUtil(int[] array, ArrayList list, string maxMin)
        {
            if (list.Count == 0)
            {
                if (maxMin.Equals("max"))
                {
                    int max = int.MinValue;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] > max) max = array[i];
                    }
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] == max) list.Add(i);
                    }
                }
                else
                {
                    int min = int.MaxValue;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] < min) min = array[i];
                    }
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] == min) list.Add(i);
                    }
                }

            }
            else
            {
                if (list.Count == 1) { return list; }
                ArrayList listTemp = new ArrayList();
                if (maxMin.Equals("max"))
                {
                    int max = int.MinValue;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (array[(int)list[i]] > max) max = (int)list[i];
                    }
                    for (int i = 0; i < list.Count; i++)
                    {
                        if ((int)list[i] == max) listTemp.Add(list[i]);
                    }

                }
                else
                {
                    int min = int.MaxValue;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (array[(int)list[i]] < min) min = (int)list[i];
                    }
                    for (int i = 0; i < list.Count; i++)
                    {
                        if ((int)list[i] == min) listTemp.Add(list[i]);
                    }

                }
                return listTemp;
            }
            return list;
        }
    }
}
