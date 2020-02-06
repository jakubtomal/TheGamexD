using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttackController : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private float attackSpeed;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private Projectile projectile;
    [SerializeField]
    private Transform barrel;
    private Animator myAnimtor;
    private EnemyController myEnemyController;
    private EnemyMovement myEnemyMovement;

    private void Start()
    {
        myAnimtor = GetComponent<Animator>();
        myEnemyController = GetComponent<EnemyController>();
        myEnemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if (myEnemyController.IsDead)
        {
            return;
        }
        if (myEnemyMovement.DistanceToPlayer <= attackRange && !myEnemyController.IsAttacking)
        {
            StartCoroutine(Attack(EnemyMovement.Player));
        }
    }

    private IEnumerator Attack(Player player)
    {
        myEnemyController.IsAttacking = true;
        myAnimtor.SetBool(myEnemyController.attackingBool, true);
        Projectile currentProjectile = Instantiate(projectile, barrel.position, Quaternion.identity).GetComponent<Projectile>();
        currentProjectile.Shoot(player.transform.position);
        yield return new WaitForSeconds(1 / attackSpeed);
        myEnemyController.IsAttacking = false;
        myAnimtor.SetBool(myEnemyController.attackingBool, false);
    }
}
