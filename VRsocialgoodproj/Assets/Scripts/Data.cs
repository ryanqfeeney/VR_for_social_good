using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Food
{
    public string name;
    public string tag;
    public int calories;
    public int simpleCarbs;
    public int complexCarbs;


    public Food(string n, int c, int sc, int cc)
    {
        name = n;
        tag = n;
        calories = c;
        simpleCarbs = sc;
        complexCarbs = cc;
    }
    public Food(string n, string t, int c, int sc, int cc)
    {
        name = n;
        tag = t;
        calories = c;
        simpleCarbs = sc;
        complexCarbs = cc;
    }
}
public class Data
{

    public List<Food> list = new List<Food>();


    public Data()
    {                         //food  calories.gram  simpleCarbs.grams  ComplexCarbs.grams
        list.Add(new Food("Apple", 65, 19, 5)); //
        list.Add(new Food("Carrot", 41, 3, 5));
        list.Add(new Food("Banana", 105, 14, 8));
        list.Add(new Food("Pear", 100, 17, 10));
        list.Add(new Food("Tomato", 18, 1, 4));
        list.Add(new Food("Onion", 40, 0, 5));
        list.Add(new Food("Stawberry", 46, 7, 5));
        list.Add(new Food("Potato Chips", 160, 1, 14));
        list.Add(new Food("Cake", 400, 15, 14));
        list.Add(new Food("Sub", 450, 4, 22));
        list.Add(new Food("Bread", 150, 2, 12));
        list.Add(new Food("Steak", 160, 0, 0));
        list.Add(new Food("Soda", 110, 23, 1));
        list.Add(new Food("Slurpee", 170, 15, 5));
        list.Add(new Food("Broccoli", "broc", 25, 2, 1));
        list.Add(new Food("Cheese", 70, 0, 0));
        list.Add(new Food("Mozzarella", "mozz", 80, 0, 0));
        list.Add(new Food("Milk", 130, 11, 2));
        list.Add(new Food("Water", 0, 0, 0));
        list.Add(new Food("Juice", 120, 25, 1));
        list.Add(new Food("Ramen", 210, 1, 20));
        list.Add(new Food("Salad", 340, 2, 3));
        list.Add(new Food("Microwave Meal", 400, 10, 15));
        list.Add(new Food("Meat", 200, 0, 0));
        list.Add(new Food("Beer", 120, 1, 5));
        list.Add(new Food("Yogurt", "jog", 75, 1, 5));
        list.Add(new Food("Sandwich", 350, 27, 5));
        list.Add(new Food("Yam", 200, 6, 38));
        list.Add(new Food("Pumpkin", 30, 5, 0));
        list.Add(new Food("Waffle", 100, 2, 8));

    }
    public Food getFood(string food)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].tag.ToLower().Equals(food.ToLower()))
            {
                return list[i];
            }
        }
        return new Food("err", -1, -1, -1);
    }
    public int getCalories(string food)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].tag.ToLower().Equals(food.ToLower()))
            {
                return list[i].calories;
            }
        }
        return -1;
    }
    public int getSCarbs(string food)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].tag.ToLower().Equals(food.ToLower()))
            {
                return list[i].simpleCarbs;
            }
        }
        return -1;
    }
    public int getCCarbs(string food)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].tag.ToLower().Equals(food.ToLower()))
            {
                return list[i].complexCarbs;
            }
        }
        return -1;
    }

}


