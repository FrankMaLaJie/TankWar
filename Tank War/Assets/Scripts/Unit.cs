using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    Red,Green, Blue
}
public class Unit : MonoBehaviour
{
    public int health = 100;
    public Team team;
    public GameObject deadEffect;

    private int curHealth;
    public int GetCurHealth()
    {
        return curHealth;
    }

    public void Start()
    {
        curHealth = health;
    }
    public void ApplyDamage(int damage)
    {
        if (curHealth > damage)
        {
            curHealth -= damage;
        }
        else
        {
            Destruct();
        }
    }

    public void Destruct()
    {
        curHealth = 0;
        if (deadEffect != null)
        {
            Instantiate(deadEffect, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
