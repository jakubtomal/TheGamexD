using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float Starthealth = 100;
    private float health;
    private Animator myAnimtor;
    private WaitForSeconds dieDelay = new WaitForSeconds(3f);
    //Animator
    private string triggerDead = "IsDead";
    private string runningBool = "Running";
    private string attackingBool = "Attacking";
    void Start()
    {
        health = Starthealth;
        myAnimtor = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        if(health <= 0 )
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        myAnimtor.SetTrigger(triggerDead);
        yield return dieDelay;
        Destroy(gameObject);
    }
}
