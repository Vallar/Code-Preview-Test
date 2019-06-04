using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float forcePower;
    private Rigidbody rb;
    private WaitForSeconds waitTime = new WaitForSeconds(10);

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        DestorySelf();
    }

    public void Throw(Vector3 _direction, float _multiplayer)
    {
        rb.AddForce(_direction * forcePower * _multiplayer);
    }

    private void OnCollisionEnter(Collision _collision)
    {
        Target target = _collision.transform.GetComponent<Target>();

        if (target != null)
        {
            target.DropTreat();
            gameObject.SetActive(false);
        }
    }

    private IEnumerator DestorySelf()
    {
        yield return waitTime;

        Destroy(gameObject);
    }
}
