using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType 
{
    ClassicPistol,
    Revolver,
    SMG,
    CombatRifle,
    SniperRifle,
    ShotGun,
    Launcher
}
public abstract class BaseBullet : ScriptableObject,IBullet
{
    public DamageType DamageType { get; set; }
    public BulletType BulletType { get; set; }
    [SerializeField]
    protected GameObject bulletPrefab;
    [SerializeField]
    protected bool isPhysical;
    [SerializeField]
    protected float bulletForce;

    public int DamagePerBullet { get; set; }

    public GameObject GetBulletPrefab() 
    {
        return bulletPrefab;
    }

    public abstract void BulletStart();

    public abstract void BulletUpdate();

    public abstract void BulletStop();

    public abstract void ApplyInstantForce(Rigidbody rb);
}
