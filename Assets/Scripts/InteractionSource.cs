using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSource : MonoBehaviour
{
    public float damage;
    public bool destroyOnInteraction = true;

    private void OnTriggerEnter(Collider hit)
    {
        if(hit.GetComponent<StatusController>())
        {
            hit.GetComponent<StatusController>().Damage(damage);
        }
        if(destroyOnInteraction)
        {
            Destroy(gameObject);
        }
    }
}
