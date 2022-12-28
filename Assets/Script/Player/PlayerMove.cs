using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public delegate void OnDeathPlayer();
public delegate void OnHurtPlayer(int life);

public class PlayerMove : MonoBehaviour
{
    [Header("Numbers")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private int maxLife = 5;

    [Header("Prefab")]
    [SerializeField] private GameObject shell;
    [SerializeField] private float shellSpeed;

    private SpriteRenderer spriteRend;
    private SpriteRenderer spriteRendChild;
    private BoxCollider colliderzz;

    private int lifePoint;
    private Vector3 velocity = Vector3.zero;
    private float rotationVelocity = 0f;
    private bool isdying = false;
    private bool ishurting = false;


    public static event OnDeathPlayer onDeathPlayer;
    public static event OnHurtPlayer onHurtPlayer;

    private void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRendChild = transform.GetChild(0).transform.GetComponent<SpriteRenderer>();
        colliderzz = GetComponent<BoxCollider>();
        lifePoint = maxLife;
    }

    private void Update()
    {
        if (isdying) return;

        Move();
        Fire();
    }

    private void Move()
    {
        velocity = transform.right * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        rotationVelocity = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Rotate(0f, 0f, -rotationVelocity);
        transform.position += (velocity);
    }

    private void Fire()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameObject m_shell = Instantiate(shell);
            m_shell.transform.right = transform.GetChild(0).right;
            m_shell.transform.position = transform.GetChild(0).position + m_shell.transform.right;
            m_shell.GetComponent<Shell>().speed = shellSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        if (other.GetComponent<Enemy>())
        {
            if (ishurting) return;
            TryDeath();
            Destroy(other);
        }
    }

    private void TryDeath()
    {
        lifePoint--;
        onHurtPlayer?.Invoke(lifePoint);
        if (lifePoint == 0)
        {
            StartCoroutine(DestroyCoroutine());
        }
        else if (!isdying)
        {
            StartCoroutine(HurtCoroutine());
        }
    }

    private IEnumerator DestroyCoroutine()
    {
        isdying = true;
        colliderzz.enabled = false;

        transform.DOScale(5f, 0.5f);
        spriteRend.DOFade(0f, 0.5f);
        spriteRendChild.DOFade(0f, 0.5f);

        yield return new WaitForSeconds(0.5f);

        onDeathPlayer?.Invoke();
    }
    private IEnumerator HurtCoroutine()
    {
        ishurting = true;

        spriteRend.DOFade(0f, 0.25f);
        spriteRendChild.DOFade(0f, 0.25f);
        yield return new WaitForSeconds(0.25f);
        spriteRend.DOFade(1f, 0.25f);
        spriteRendChild.DOFade(1f, 0.25f);
        yield return new WaitForSeconds(0.25f);
        spriteRend.DOFade(0f, 0.25f);
        spriteRendChild.DOFade(0f, 0.25f);
        yield return new WaitForSeconds(0.25f);
        spriteRend.DOFade(1f, 0.25f);
        spriteRendChild.DOFade(1f, 0.25f);
        yield return new WaitForSeconds(0.25f);

        ishurting = false;
    }
}
