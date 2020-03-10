using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(FoodTypeToPrefab))]
public class FoodTypeNameToSpriteEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            var o = (FoodTypeToPrefab) target;
            EditorGUILayout.LabelField("Link food Types to gameobject Prefabs Here");
            EditorGUILayout.LabelField("");
            
            var foodTypeNames = Enum.GetNames(typeof(Food.FoodType));
            while (o.FoodPrefabs.Count < foodTypeNames.Length)
            {
                o.FoodPrefabs.Add(new GameObject("Placeholder Food Object"));
                EditorUtility.SetDirty(target);
            }

            for (int i = 0; i < o.FoodPrefabs.Count; i++)
            {
                var food = o.FoodPrefabs[i].GetComponent<Food>();
                var joint = o.FoodPrefabs[i].GetComponent<FixedJoint2D>();
                if (food == null || joint == null)
                    GUI.color = new Color(1f, 1f, 0.71f);
                else
                    GUI.color = Color.white;
                
                o.FoodPrefabs[i] = (GameObject) EditorGUILayout.ObjectField(foodTypeNames[i], o.FoodPrefabs[i], typeof(GameObject), true);
                if (food == null)
                    EditorGUILayout.LabelField($"{o.FoodPrefabs[i].name} does not have Food Component!");
                if (joint == null)
                    EditorGUILayout.LabelField($"{o.FoodPrefabs[i].name} does not have Joint2D Component!");
            }
        }
    }
