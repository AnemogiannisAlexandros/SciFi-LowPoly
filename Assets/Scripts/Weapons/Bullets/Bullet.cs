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
        Vector3 offset = WeaponManager.Instance.GetCurrentWeapon().stats.GetAccuracy().offset;
        offset  = Camera.main.transform.TransformDirection(offset);
        bulletStats.ApplyInstantForce(rb,offset.normalized);
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
