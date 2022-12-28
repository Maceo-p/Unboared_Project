using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGoldManager : MonoBehaviour
{
    [SerializeField] private GameObject goldPrefab;

    [Header("Numbers")]
    [SerializeField] private float timeBetweenSpawn = 1f;
    [SerializeField][Range(0f, 100f)] private float spawnRange;

    private float elaspedTime = 0f;

    private void Start()
    {
        //GameObject enemi = Instantiate(m_Enemy);
        //enemi.GetComponent<Enemy>().target = player;
    }

    private void Update()
    {
        elaspedTime += Time.deltaTime;

        if (elaspedTime >= timeBetweenSpawn)
        {
            GameObject gold = Instantiate(goldPrefab);
            gold.SetActive(true);
            gold.transform.position = new Vector3(1f * Random.Range(-spawnRange, spawnRange), 1f * Random.Range(-spawnRange, spawnRange), 0f);

            elaspedTime = 0f;
        }
    }
}
