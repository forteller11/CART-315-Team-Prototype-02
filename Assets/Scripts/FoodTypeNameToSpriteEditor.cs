using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(FoodTypeNameToSprite))]
public class FoodTypeNameToSpriteEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            var o = (FoodTypeNameToSprite) target;
            var foodTypeNames = Enum.GetNames(typeof(Food.FoodType));
            while (o.FoodSprites.Count < foodTypeNames.Length)
            {
                o.FoodSprites.Add(Sprite.Create(Texture2D.linearGrayTexture, Rect.zero, Vector2.zero));
                EditorUtility.SetDirty(target);
            }

            for (int i = 0; i < o.FoodSprites.Count; i++)
            {
                o.FoodSprites[i] = (Sprite) EditorGUILayout.ObjectField(foodTypeNames[i], o.FoodSprites[i], typeof(Sprite).BaseType, false);
            }
        }
    }
