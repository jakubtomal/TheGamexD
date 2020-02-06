using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleAttackController : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private float attackSpeed;
    private Animator myAnimtor;
    private EnemyController myEnemyController;

    private void Start()
    {
        myAnimtor = GetComponent<Animator>();
        myEnemyController = GetComponent<EnemyController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (myEnemyController.IsDead)
        {
            return;
        }
        Player player = other.GetComponent<Player>();
        if (player != null && !myEnemyController.IsAttacking)
        {
            StartCoroutine(Attack(player));
        }
    }

    private IEnumerator Attack(Player player)
    {
        myEnemyController.IsAttacking = true;
        myAnimtor.SetBool(myEnemyController.attackingBool, true);
        player.GetDamage(damage);
        yield return new WaitForSeconds(1 / attackSpeed);
        myEnemyController.IsAttacking = false;
        myAnimtor.SetBool(myEnemyController.attackingBool, false);
    }
}
