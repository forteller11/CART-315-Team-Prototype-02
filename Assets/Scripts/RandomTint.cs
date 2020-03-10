using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomTint : MonoBehaviour
{
    [SerializeField] private List<Color> _tints;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        int initSeed = (System.DateTime.Now.Millisecond);
       // Debug.Log(initSeed);
        Random.InitState(initSeed);
        RandomizeTint();
    }

    public void RandomizeTint()
    {
        float maxRange = (float) _tints.Count - 1;
        int tintIndex = Mathf.RoundToInt(Random.Range(0f, maxRange));

        _spriteRenderer.color = _tints[tintIndex];
       // Debug.Log(maxRange);
    }
}
