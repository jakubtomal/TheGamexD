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
    [SerializeField]
    private float damage;
    [SerializeField]
    private float attackSpeed;
    private bool isAttacking;
    private float health;
    private Animator myAnimtor;
    private WaitForSeconds dieDelay = new WaitForSeconds(3f);
    //Animator
    private string triggerDead = "IsDead";
    private string attackingBool = "Attacking";

    public bool IsAttacking { get => isAttacking; private set => isAttacking = value; }

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

    private void OnTriggerStay(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if(player != null && !IsAttacking)
        {
            StartCoroutine(Attack(player));
        }
    }

    private IEnumerator Attack(Player player)
    {
        IsAttacking = true;
        myAnimtor.SetBool(attackingBool, true);
        player.GetDamage(damage);
        yield return new WaitForSeconds(1 / attackSpeed);
        IsAttacking = false;
        myAnimtor.SetBool(attackingBool, false);
    }
}
