using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "FoodType to Sprite", menuName = "FoodTypeNameToSprite", order = 0)]
    public class FoodTypeToPrefab : ScriptableObject
    {
        private List<string> FoodTypeNames = new List<string>(Enum.GetNames(typeof(Food.FoodType)).Length);
        public List<GameObject> FoodPrefabs = new List<GameObject>(Enum.GetNames(typeof(Food.FoodType)).Length);


    }