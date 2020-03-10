using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
   public enum FoodType 
   {
      Peach,
      Tomato,
      Tuna,
      Cherry,
      Banana,
      Lettuce,
      Steak,
      Egg,
      Bread
   };

   [SerializeField]
   [Header("Type of Food")]
   public FoodType Type;
}
