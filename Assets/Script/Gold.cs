using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnCollectHandler();
public class Gold : MonoBehaviour
{
    public static event OnCollectHandler OnCollect;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        OnCollect?.Invoke();
        Destroy(gameObject);
    }
}
