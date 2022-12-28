using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private GameObject littleStarPrefab;
     private GameObject littleStarPrefabStocker;

    [Header("Numbers")]
    [SerializeField] private float littleStarNb;
    [SerializeField][Range(0.1f, 1f)] private float maxScale;
    [SerializeField][Range(0f, 100f)] private float spawnRange;

    private void Start()
    {
        littleStarPrefabStocker = transform.GetChild(0).gameObject;
        GameObject littlestar;
        for (int i = 0; i < littleStarNb; i++)
        {
            littlestar = Instantiate(littleStarPrefab);

            littlestar.transform.SetParent(littleStarPrefabStocker.transform);
            littlestar.transform.position = new Vector3(1f  * Random.Range(-spawnRange, spawnRange), 1f * Random.Range(-spawnRange, spawnRange), 0f);
            littlestar.transform.localScale = Vector3.one * Random.Range(0.1f, maxScale);
        }
    }
}
