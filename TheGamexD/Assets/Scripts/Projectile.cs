using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool hasTarget = false;
    [SerializeField]private float speed;
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Shoot(Vector3 target)
    {
        hasTarget = true;
        rigidbody.AddForce( (target - transform.position).normalized * speed * Time.deltaTime, ForceMode.Impulse);
    }

}
