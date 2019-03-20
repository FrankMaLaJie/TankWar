using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITank : Unit
{
    public float enemySearchRange;
    public float moveSpeed;
    public ISRange attackRange;//AR
    public ISRange stoppingDistance;//SD
    //public float shootCoolDown;
    public float rotateSpeed;
    public float coreTimerInterval;

    private GameObject enemy;
    //private float timer;
    private TankWeapons tw;
    private NavMeshAgent nam;
    private LayerMask enemyLayer;
    private float curAR;
    private float curSD;

    void Start()
    {
        base.Start();
        enemyLayer = LayerManager.GetEnemyLayer(team);
        nam = GetComponent<NavMeshAgent>();
        tw = GetComponent<TankWeapons>();
        tw.Init(team);
        StartCoroutine(Timer());
    }
    //void FixedUpdate()
    //{
    //    timer += Time.fixedDeltaTime;

    //    if (player == null) return;
    //    float dist = Vector3.Distance(player.transform.position, transform.position);

    //    if (dist > attackRange)
    //    {
    //        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    //    }

    //    transform.LookAt(player.transform.position);

    //    if (timer > shootCoolDown)
    //    {
    //        tw.Shoot();
    //        timer = 0f;
    //    }
    //}

    void Update()
    {
        //timer += Time.fixedDeltaTime;

        if (enemy == null)
        {
            SearchEnemy();
            return;
        }
        float dist = Vector3.Distance(enemy.transform.position, transform.position);

        if (dist > curSD)
        {
            nam.SetDestination(enemy.transform.position);
        }
        else
        {
            nam.ResetPath();
            //transform.LookAt(enemy.transform.position);
            Vector3 dir = enemy.transform.position - transform.position;
            Quaternion wantedRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, rotateSpeed * Time.deltaTime);
            //if (timer > shootCoolDown)
            //{
            //    timer = 0f;
            //}
        }
        if (dist < curAR)
        {
            tw.Shoot();
        }
    }

    IEnumerator Timer()
    {
        while (enabled)
        {
            curAR = ISMath.Random(attackRange);
            curSD = ISMath.Random(stoppingDistance);
            curSD = Mathf.Min(curAR, curSD);
            SearchEnemy();
            yield return new WaitForSeconds(coreTimerInterval);
        }
    }

    public void SearchEnemy()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, enemySearchRange, enemyLayer);
        if (cols.Length > 0)
        {
            float curMinDist = Mathf.Infinity;
            for(int i = 0; i < cols.Length; i++)
            {
                float curDist = Vector3.Distance(transform.position, cols[i].transform.position);
                if (curDist < curMinDist)
                {
                    curMinDist = curDist;
                    enemy = cols[i].gameObject;
                }
            }
        }
    }
}
