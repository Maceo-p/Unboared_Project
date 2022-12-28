using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBasic : Enemy
{
    [SerializeField] private float acceleration = 5f;
    [SerializeField] private float speedMax = 5f;

    private Vector3 velocity;
    private Vector3 dir;

    private void Start()
    {
        
    }

    private void Update()
    {
        dir = target.transform.position - transform.position;
        velocity = dir * acceleration;
        velocity = Vector3.ClampMagnitude(velocity, speedMax);


        transform.position += velocity * Time.deltaTime;
    }
}
