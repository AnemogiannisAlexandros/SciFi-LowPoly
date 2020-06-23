using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject, IFireable
{
    public WeaponStats stats;
    private WeaponStats newStats;
    public GameObject objectToInstantiate;
    protected Transform firingPosition;
    public BaseBullet bullet;
    private BaseBullet newBullet;

    public void Init(WeaponStats stats, BaseBullet bullet)
    {
        //newStats = (WeaponStats)CreateInstance(stats.GetType());
        //newBullet = (BaseBullet)CreateInstance(bullet.GetType());
        newStats = Instantiate(stats);
        newBullet = Instantiate(bullet);
    }

    //The Crosshair This Weapon will Have
    [SerializeField]
    protected Sprite CrosshairTexture;
    //How this weapon will be called
    [SerializeField]
    protected string weaponName;
    //The Pool of Bullets this weapon will have
    protected GameObject[] bulletPool = null;
    //Returns true when fireRate allows for another bullet to be shot.
    protected bool canShoot;
    //Returns true if the player is reloading 
    protected bool isReloading;
    //How many bullets there are currently in the Magazine
    protected int currentBulletsInMag;
    //checks if currentBulletsInMag>=0
    protected bool hasBulletsInMag;
    //Checks if the player has bullets in his inventory.
    protected bool hasBulletsInInventory;
    //the time that has to pass after the player can shoot again
    protected float fireRateTimer;
    //The time that has to pass for the player to reload
    protected float reloadTimer;

    public WeaponStats GetStats()
    {
        return newStats;
    }
    public BaseBullet GetBullet()
    {
        return newBullet;
    }
    protected GameObject GetPooledObject()
    {
        for (int i = 0; i < bulletPool.Length; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                return bulletPool[i];
            }
        }
        return null;
    }
    public Sprite GetCrosshair()
    {
        return CrosshairTexture;
    }
    public void SetObjectToInstantiate(GameObject gameObject)
    {
        objectToInstantiate = gameObject;
    }
    public void SetFiringPosition(Transform position) 
    {
        firingPosition = position;
    }
    public GameObject GetObjectToInstantiate() 
    {
        return objectToInstantiate;
    }
    public Transform GetFiringPosition() 
    {
        return firingPosition;
    }
    public GameObject[] GetBulletPool() 
    {
        return bulletPool;
    }
    public virtual void Init() 
    {
        canShoot = true;
        reloadTimer = GetStats().GetRealoadTime();
        bulletPool = new GameObject[GetStats().GetMagazineSize() * 2];
        GetBullet().DamagePerBullet = GetStats().GetDamage();
        GetBullet().DamageType = GetStats().GetDamageType();
        GetBullet().BulletType = GetStats().GetBulletType();
    }
    public abstract void Reload();

    public abstract void Shoot();

    public abstract void WeaponUpdate();

}
