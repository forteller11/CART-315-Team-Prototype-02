using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;
using Random = System.Random;

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
      Bread,
      Milk,
      Pepper,
      Cheese
   };

   [SerializeField]
   [Header("Type of Food")]
   public FoodType Type;
   
   }
   

