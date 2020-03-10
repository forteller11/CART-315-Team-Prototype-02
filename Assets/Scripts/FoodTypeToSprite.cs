using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

[CreateAssetMenu(fileName = "FoodType to Sprite Instance", menuName = "ScriptableObjects/FoodType to Sprite", order = 1)]
    public class FoodTypeToSprite : ScriptableObject
    {
        [SerializeField]
        public Dictionary<Food.FoodType, Sprite> FoodToSprite = new Dictionary<Food.FoodType, Sprite>(Enum.GetNames(typeof(Food.FoodType)).Length);
        // implict conversion
        
        
    }