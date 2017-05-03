using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponController : MonoBehaviour
{
    public float lifetime = 2f;
    public bool destroyOnContact = true;

    void Start()
    {
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
