using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour
{

    [SerializeField] private FoodTypeToPrefab FoodTypeToPrefab;
    [SerializeField] private float SecondsBetweenSpawn = 1f;
    [SerializeField] private float SecondsToPlaceOnPlateAfterLastSpawn = 2f;
    [SerializeField] private int AmountToSpawn = 5;
    [SerializeField] private Judger Judge;
    [SerializeField] private ShowHideScore ScoreManager;

    private void Awake()
    {
        if (FoodTypeToPrefab == null)
            Debug.LogError($"\"FoodTypeToPrefab\" must be set!");
    }

    void Start()
    {
        StartCoroutine(SpawnFood());
    }

    IEnumerator SpawnFood()
    {

        for (int i = 0; i < AmountToSpawn; i++)
        {
            var maxValue = FoodTypeToPrefab.FoodPrefabs.Count - 1;
            int randomPrefabIndex = (int) Random.Range(0f, maxValue);
            if (randomPrefabIndex == FoodTypeToPrefab.FoodPrefabs.Count)
                randomPrefabIndex = FoodTypeToPrefab.FoodPrefabs.Count - 1;
            
            var randomRotation = Quaternion.Lerp(
                Quaternion.identity,
                Quaternion.Euler(0f, 0f, 180),
                Random.Range(-1f, 1f));


            var newObj = Instantiate(
                FoodTypeToPrefab.FoodPrefabs[randomPrefabIndex],
                transform.position, randomRotation,
                transform);

            //error checking
            if (FoodTypeToPrefab.FoodPrefabs[randomPrefabIndex] == null)
                Debug.LogError($"Food Prefab {randomPrefabIndex} is not assigned!");
            if (newObj.GetComponent<Food>() == null)
                Debug.LogError("Food Prefab does not have the component \"Food\" attached!");
            
            yield return new WaitForSeconds(SecondsBetweenSpawn);
        }

        yield return new WaitForSeconds(SecondsToPlaceOnPlateAfterLastSpawn);
        Judge.Score(ScoreManager);

    }

}
