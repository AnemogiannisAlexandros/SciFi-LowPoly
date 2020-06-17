using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BaseBullet bulletStats;
    private Rigidbody rb;
    PlayerMovement moveDirection;
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
        moveDirection = FindObjectOfType<PlayerMovement>();

    }
    private void OnEnable()
    {
        bulletStats.BulletStart();
        bulletStats.ApplyInstantForce(rb, Camera.main.transform.forward);
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
