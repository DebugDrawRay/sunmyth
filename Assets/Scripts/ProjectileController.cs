using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileController : MonoBehaviour
{
    public float speed;
    public float lifetime = 2f;
    public bool destroyOnContact = true;
    private Rigidbody rigid
    {
        get
        {
            return GetComponent<Rigidbody>();
        }
    }
    void Start()
    {
        rigid.AddForce(transform.right * speed, ForceMode.Impulse);
        Destroy(gameObject, lifetime);
    }
    void OnTriggerEnter(Collider hit)
    {
        if (destroyOnContact)
        {
            Destroy(gameObject);
        }
    }
}
