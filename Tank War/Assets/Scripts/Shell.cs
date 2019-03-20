using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public int damage;
    public float explosionForfce;
    public float explosionRadius;
    public GameObject explosionEffect;
    public float explosionTimeup;

    private LayerMask lm;

    public void Init(LayerMask enemyLayer)
    {
        lm = enemyLayer;
    }

    void OnCollisionEnter()
    {
        GameObject obj = Instantiate(explosionEffect, transform.position, transform.rotation) as GameObject;
        Destroy(gameObject);
        Destroy(obj, explosionTimeup);

        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius,lm);
        if (cols.Length > 0)
        {
            for(int i = 0; i < cols.Length; i++)
            {
                Rigidbody r = cols[i].GetComponent<Rigidbody>();
                if (r != null)
                {
                    r.AddExplosionForce(explosionForfce, transform.position, explosionRadius);
                }

                Unit u = cols[i].GetComponent<Unit>();
                if(u != null)
                {
                    u.ApplyDamage(damage);
                }
            }
        }
    }
}
