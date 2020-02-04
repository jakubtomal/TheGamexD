using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private static Player player;
    [SerializeField]
    private float fieldOfView = 1;
    [SerializeField]
    private float speed;
    private float distanceToPlayer;
    private Rigidbody myRigidbody;
    private EnemyController enemyController;

    //Animator
    private string runningBool = "Running";
    private Animator myAnimtor;


    private void Awake()
    {
        if(player == null)
        {
            player = FindObjectOfType<Player>();
        }
        myAnimtor = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody>();
        enemyController = GetComponent<EnemyController>();
    }


    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer <= fieldOfView && !enemyController.IsAttacking)
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * speed * Time.deltaTime;
            if(!myAnimtor.GetBool(runningBool))
            {
                myAnimtor.SetBool(runningBool,true);
            }
        }
        else if(myAnimtor.GetBool(runningBool))
        {
            myAnimtor.SetBool(runningBool, false);
        }
    }
}
