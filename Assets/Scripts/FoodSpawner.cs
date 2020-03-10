using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject FoodPrefab;
    Food SpawnRandomFood(GameObject foodPrefab)
    {
        var randomRotation = Quaternion.Lerp(
            Quaternion.identity, 
            Quaternion.Euler(0f, 0f, 180), 
            Random.Range(-1f, 1f)); 
        

        var food = Instantiate(foodPrefab, transform.position, randomRotation, transform).GetComponent<Food>();
        
        if (food == null)
            Debug.LogError("Food Prefab does not have the component \"Food\" attached!");

        var foodTypesLength = Enum.GetNames(typeof(Food.FoodType)).Length;
        int randomFoodTypeIndex = (int) Random.Range(0, foodTypesLength - Single.MinValue);
        food.Type = (Food.FoodType) randomFoodTypeIndex;

        return food;
    }
}
