using System;
using UnityEngine;

namespace Helpers
{
    public static class Extensions
    {
        public static Vector2 ToVector2XY(this Vector3 v) => new Vector2(v.x, v.y);
        public static int GetNumberOfValues(this Enum e) => Enum.GetNames(typeof(Food.FoodType)).Length;
    }
}