using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DeathEnemyHandler();
public class Enemy : MonoBehaviour
{
    [SerializeField] protected int lifePoint = 3;

    public GameObject target;
    //[SerializeField] protected ParticleSystem particle;

    public static event DeathEnemyHandler onDeathEnemy;
    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6) return;

        TryDeath();
    }

    virtual protected void TryDeath()
    {
        lifePoint--;
        if (lifePoint == 0)
        {
            StartCoroutine(DestroyCoroutine());
        }
        //else StartCoroutine(HurtCoroutine());
    }

    protected IEnumerator DestroyCoroutine()
    {
        //float timer = 0f;
        GetComponent<Collider>().enabled = false;
        onDeathEnemy?.Invoke();
        //particle.Play();

        //while (timer <= particle.main.duration)
        //{
        //    timer += Time.deltaTime;
        //yield return null;
        //}

        Destroy(gameObject);
        yield return null;
    }


}
