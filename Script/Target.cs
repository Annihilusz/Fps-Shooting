using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public int maxHealth;
    public EnemyHealth healbar;

    private int currHealth;
    public GameObject dieEffect;
    public GameObject damageText;

    private void Start()
    {
        //FloatingTxetContorller.Initialize();
        currHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        //FloatingTxetContorller.CreateFloatingText(amount.ToString(), transform);
        currHealth -= amount;
        healbar.UpdateHealth((float)currHealth / (float)maxHealth);
        health -= amount;
        DamagePopup indicator = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<DamagePopup>();
        indicator.SetDamageText(amount);
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(dieEffect,transform.position,Quaternion.identity);
        Destroy(gameObject, 0.5f);
    }
}
