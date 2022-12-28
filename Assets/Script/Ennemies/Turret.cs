using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Enemy
{
    [SerializeField] private GameObject target;

    [Header("Children")]
    [SerializeField] private GameObject top;

    [Header("Prefab")]
    [SerializeField] private GameObject shell;
    [SerializeField] private float shellSpeed;

    private float distanceDetection = 25f;
    private float cooldownFire = 2f;
    private bool canFire = true;

    private void Update()
    {
        //if (!Detect()) return;

        Fire();
        AimCanon();
    }


    private bool Detect()
    {
        if (target.transform.position.z > -distanceDetection & target.transform.position.z < transform.position.z + distanceDetection)
        {
            return true;
        }

        return false;
    }

    private void Fire()
    {
        if (canFire)
        {
            GameObject m_shell = Instantiate(shell);
            m_shell.transform.forward = top.transform.forward;
            m_shell.transform.position = top.transform.position + (m_shell.transform.forward * 2f);
            m_shell.GetComponent<Shell>().speed = shellSpeed;

            StartCoroutine(RefreshCooldown());
        }
    }

    private void AimCanon()
    {
        top.transform.LookAt(target.transform);
    }

    private IEnumerator RefreshCooldown()
    {
        canFire = false;

        yield return new WaitForSeconds(cooldownFire);

        canFire = true;
    }
}
