using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    [Header("FollowPlayer")]
    [SerializeField] private GameObject target = default;
    [SerializeField] private float timeOffSet = 0f;
    [SerializeField] private Vector3 posOffSet = Vector3.zero;

    private Vector3 velocity;



    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position + posOffSet, ref velocity, timeOffSet);
    }
}
