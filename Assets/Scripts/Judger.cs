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
    public Vector2 ColliderOffset;
    public Vector2 ColliderSize;

    [ContextMenu("Score")]
    public void Score()
    {
        var foods = FindAllFoodsOnPlate();
        
        JudgeFoods(foods);
        
        
    }
    List<Food> FindAllFoodsOnPlate()
    {
        var hitFoods = new List<Food>();

        var hits = Physics2D.OverlapBoxAll(transform.position.ToVector2XY()+ColliderOffset, ColliderSize, transform.rotation.eulerAngles.z);

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
        Gizmos.DrawWireCube(transform.position.ToVector2XY() + ColliderOffset, ColliderSize);
    }

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
                
                switch (combinedFoodTypeFlag)
                {
                    case 1 << (int) Food.FoodType.Peach | 1 << (int) Food.FoodType.Bread:
                        Debug.Log("fruit sandwich");
                        break;
                    default:
                        Debug.Log("Food combo not registered");
                        break;
            
                }
            }
        }
    }

   

    void Update()
    {
        Score();
    }
    
}
