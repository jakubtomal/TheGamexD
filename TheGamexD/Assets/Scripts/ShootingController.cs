using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    float speed;
    private bool isShooting = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Projectile currentProjectile = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Projectile>();
            currentProjectile.Shoot(hit.point);
        }
        yield return new WaitForSeconds(1.0f / speed);
        isShooting = false;

    }
}
