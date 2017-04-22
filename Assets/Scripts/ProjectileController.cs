using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileController : MonoBehaviour
{
    public float speed;
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
    }
}
