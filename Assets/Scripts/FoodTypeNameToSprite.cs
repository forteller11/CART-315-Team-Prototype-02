using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "FoodType to Sprite", menuName = "FoodTypeNameToSprite", order = 0)]
    public class FoodTypeNameToSprite : ScriptableObject
    {
        private List<string> FoodTypeNames = new List<string>(Enum.GetNames(typeof(Food.FoodType)).Length);
        public List<Sprite> FoodSprites = new List<Sprite>(Enum.GetNames(typeof(Food.FoodType)).Length);


    }