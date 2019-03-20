using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWeapons : MonoBehaviour
{
    public GameObject shell;
    public float shootPower;
    public Transform shootPoint;
    public float shootCoolDown;

    private AudioSource audioSource;
    private LayerMask enemyLayer;
    private bool isWeaponReady = true;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Init(Team team)
    {
        enemyLayer = LayerManager.GetEnemyLayer(team);
    }
    public void Shoot()
    {
        if (!isWeaponReady) return;
        GameObject newShell = Instantiate(shell, shootPoint.position, shootPoint.rotation) as GameObject;
        newShell.GetComponent<Shell>().Init(enemyLayer);
        Rigidbody r = newShell.GetComponent<Rigidbody>();
        r.velocity = shootPoint.forward * shootPower;
        audioSource.Play();
        isWeaponReady = false;
        StartCoroutine(WeaponCoolDown());
    }

    IEnumerator WeaponCoolDown()
    {
        yield return new WaitForSeconds(shootCoolDown);
        isWeaponReady = true;
    }
}
