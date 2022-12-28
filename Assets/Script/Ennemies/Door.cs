using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Enemy
{
    [SerializeField] private GameObject protector;

    [Header("Materials")]
    [SerializeField] private Material basicMaterial;
    [SerializeField] private Material hurtMaterial;
    [SerializeField] private Material sealedMaterial;

    private MeshRenderer mr;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (protector == null)
        {
            mr.material = basicMaterial;
        }
    }

    protected override void TryDeath()
    {
        if (protector != null)
        {
            return;
        }
        lifePoint--;
        if (lifePoint == 0)
        {
            StartCoroutine(DestroyCoroutine());
        }
        else StartCoroutine(HurtCoroutine());
    }


    private IEnumerator HurtCoroutine()
    {
        float timer = 0f;
        
        Material material = mr.material;

        while (timer <= 0.5f)
        {
            timer += Time.deltaTime;
            mr.material = hurtMaterial;
            yield return null;
        }

        mr.material = material;
    }
}
