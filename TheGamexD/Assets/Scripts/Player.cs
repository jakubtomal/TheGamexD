using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Move()
    {
        Input.GetAxis("Horizontal");
        Input.GetAxis("Vertical");
    }

    public void Go()
    {

    }
}
