using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Helpers;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Judger : MonoBehaviour
{
    //TODO for all food overlapping certain collider, judge it on function call
    [SerializeField] private Vector2 ColliderOffset;
    [SerializeField] private Vector2 ColliderSize;

    [ContextMenu("Score")]
    public void Score(ShowHideScore showHideScore)
    {
        Debug.Log("Score");
        var foods = FindAllFoodsOnPlate();

        int creativityScore;
        int tasteScore;
        List<String> foodCombinationNames;
        JudgeFoods(foods, out creativityScore, out tasteScore, out foodCombinationNames);
        showHideScore.scoreCreativity = creativityScore;
        showHideScore.scoreTaste = tasteScore;
        showHideScore.timeToShowScore = true;
        foreach(var combo in foodCombinationNames)
            Debug.Log(combo);


    }
    List<Food> FindAllFoodsOnPlate()
    {
        var hitFoods = new List<Food>();

        var hits = Physics2D.OverlapBoxAll(transform.position.ToVector2XY()+ColliderOffset, ColliderSize, 0f);

        for (int i = 0; i < hits.Length; i++)
        {
            var hitFood = hits[i].GetComponent<Food>();
            if (hitFood != null)
            {
                Debug.Log(hitFood.Type);
                hitFoods.Add(hitFood);
            }
                
        }

        return hitFoods;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position.ToVector2XY() + ColliderOffset, ColliderSize * transform.localScale.x);
    }

    void JudgeFoods(List<Food> foods, out int creativityScore, out int tasteScore, out List<string> foodComboNames)
    {
        foodComboNames = new List<string>();
        creativityScore = 0;
        tasteScore = 0;
        for (int i = 0; i < foods.Count; i++)
        {
            for (int j = 0; j < foods.Count; j++)
            {
                if (i == j) //don't compare self to self
                    continue;

                int flagFoodType01 = 1 << (int) foods[i].Type;
                int flagFoodType02 = 1 << (int) foods[j].Type;
                int combinedFoodTypeFlag = flagFoodType01 | flagFoodType02;

                int high = 8;
                int med = 3;
                int low = 1;
                switch (combinedFoodTypeFlag)
                {
                    case 1 << (int) Food.FoodType.Tomato | 1 << (int) Food.FoodType.Cheese:
                        foodComboNames.Add("Tomato and Cheese");
                        creativityScore -= low;
                        tasteScore += high;
                        break;
                    case 1 << (int) Food.FoodType.Peach | 1 << (int) Food.FoodType.Bread:
                        foodComboNames.Add("Fruit Sandwich");
                        creativityScore += low;
                        tasteScore += low;
                        break;
                    case 1 << (int) Food.FoodType.Cherry | 1 << (int) Food.FoodType.Bread:
                        foodComboNames.Add("Fruit Sandwich");
                        creativityScore += low;
                        tasteScore += low;
                        break;
                    case 1 << (int) Food.FoodType.Cherry | 1 << (int) Food.FoodType.Peach | 1 << (int) Food.FoodType.Banana:
                        foodComboNames.Add("Fruit Salad");
                        creativityScore += low;
                        tasteScore += med;
                        break;
                    case 1 << (int) Food.FoodType.Bread | 1 << (int) Food.FoodType.Tomato | 1 << (int) Food.FoodType.Cheese:
                        foodComboNames.Add("Sauceless Pizza");
                        creativityScore += med;
                        tasteScore += med;
                        break;
                    case 1 << (int) Food.FoodType.Lettuce | 1 << (int) Food.FoodType.Tomato | 1 << (int) Food.FoodType.Cheese:
                        foodComboNames.Add("Bland Salad");
                        creativityScore += low;
                        tasteScore += med;
                        break;
                    case 1 << (int) Food.FoodType.Steak | 1 << (int) Food.FoodType.Bread:
                        foodComboNames.Add("Bland Salad");
                        creativityScore += low;
                        tasteScore += med;
                        break;
                    case 1 << 0b_1111_1111_1111:
                        foodComboNames.Add("A Giant Mess");
                        creativityScore += med;
                        tasteScore += low;
                        break;

                    default:
                        Debug.Log("Food combo not registered");
                        break;
            
                }
            }
        }
    }
    
}
