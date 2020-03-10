using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judger : MonoBehaviour
{
    //TODO for all food overlapping certain collider, judge it on function call

    void JudgeFoods(List<Food> foods)
    {
        for (int i = 0; i < foods.Count; i++)
        {
            for (int j = 0; j < foods.Count; j++)
            {
                if (i == j) //don't compare self to self
                    continue;

                int flagFoodType01 = 1 << (int) foods[i].Type;
                int flagFoodType02 = 1 << (int) foods[j].Type;
                int combinedFoodTypeFlag = flagFoodType01 | flagFoodType02;
                Judge(combinedFoodTypeFlag);
            }
        }
    }

    void Judge(int foodComboFlag)
    {
        switch (foodComboFlag)
        {
            case (int) Food.FoodType.Peach | (int) Food.FoodType.Bread:
                Debug.Log("fruit sandwich");
                break;
            default:
                Debug.Log("Food combo not registered");
                break;
            
        }
    }
    
}
