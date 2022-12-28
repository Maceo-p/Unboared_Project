using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public float speed = 20f;

    //[SerializeField] private ParticleSystem particle;


    private void Update()
    {
        //if (particle.isPlaying) return;
        transform.position += transform.right * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        StartCoroutine(DestroyCoroutine());
        //transform.GetChild(0).gameObject.SetActive(false);
    }

    private IEnumerator DestroyCoroutine()
    {
        //float timer = 0f;
        //particle.Play();
        GetComponent<Collider>().enabled = false;

        //while (timer <= particle.main.duration)
        //{
        //    timer += Time.deltaTime;
            yield return null;
        //}

        Destroy(gameObject);
        
    }
}
