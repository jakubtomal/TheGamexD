using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float Starthealth = 1000;
    [SerializeField]
    private Image healthBar;
    private float health;
    private WaitForSeconds dieDelay = new WaitForSeconds(3f);
    void Start()
    {
        health = Starthealth;
        healthBar.fillAmount = health / Starthealth;
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / Starthealth;
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        yield return dieDelay;
        SceneManager.LoadScene("GameOver");
    }
}
