using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float Starthealth = 100;
    [SerializeField]
    private Image healthBar;
    private float health;
    private Animator myAnimtor;
    private WaitForSeconds dieDelay = new WaitForSeconds(3f);
    private string triggerDead = "IsDead";
    public bool IsAttacking;
    public string attackingBool = "Attacking";

    void Start()
    {
        health = Starthealth;
        myAnimtor = GetComponent<Animator>();
        healthBar.fillAmount = health / Starthealth;
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / Starthealth;
        if (health <= 0 )
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
