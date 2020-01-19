using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            //Debug.Log(Camera.main.ScreenPointToRay(Input.mousePosition));
            
        }
    }

    private void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Projectile currentProjectile = Instantiate(projectile, transform.position, transform.rotation).GetComponent<Projectile>();
            Debug.Log(hit.transform);
            currentProjectile.Shoot(hit.point);
        }

    }
}
