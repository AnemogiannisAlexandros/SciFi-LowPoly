using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BaseBullet bulletStats;
    private Rigidbody rb;
    public void SetBulletStats(BaseBullet stats) 
    {
        bulletStats = stats;
    }
    public BaseBullet GetBulletStats()
    {
        return bulletStats;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        bulletStats.BulletStart();
        bulletStats.ApplyInstantForce(rb);
    }
    private void Update()
    {
        bulletStats.BulletUpdate();
    }
    public void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
