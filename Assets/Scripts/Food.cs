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
      Bread
   };

   [SerializeField]
   [Header("Type of Food")]
   public FoodType Type;

   [SerializeField]
   private FoodTypeNameToSprite FoodTypeNameToSprite;

   private void Start()
   {
      
      var ranIndex = (int) UnityEngine.Random.Range(0, (float) Type.GetNumberOfValues() - Single.Epsilon);
      Type = (FoodType) ranIndex;
      GetComponent<SpriteRenderer>().sprite = FoodTypeNameToSprite.FoodSprites[ranIndex];
   }
   
}
