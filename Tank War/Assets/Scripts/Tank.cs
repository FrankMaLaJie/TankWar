using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Unit
{
    public float moveSpeed;
    public float rotateSpeed;

    private TankWeapons tw;
   // private LayerMask enemyMask;
    void Start()
    {
        base.Start();
       // enemyMask = LayerManager.GetEnemyLayer(team);
        tw = GetComponent<TankWeapons>();
        tw.Init(team);
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("HorizontalUI");
        float vertical = Input.GetAxis("VerticalUI");
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * vertical);
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
            {
                tw.Shoot();
            }

        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S)) { 
        //    transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        //}

    }
}
