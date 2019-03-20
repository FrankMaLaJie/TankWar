using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISExplosion : MonoBehaviour
{

    public float explosionForfce;
    public float explosionRadius;
    void Start()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius);
        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                Rigidbody r = cols[i].GetComponent<Rigidbody>();
                if (r != null)
                {
                    r.AddExplosionForce(explosionForfce, transform.position, explosionRadius);
                }
            }
        }
    }

}
