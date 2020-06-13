using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject, IFireable
{
    public WeaponStats stats;
    protected GameObject objectToInstantiate;
    protected Transform firingPosition;
    public BaseBullet bullet;

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
        fireRateTimer = 1 / stats.GetFireRate();
        reloadTimer = stats.GetRealoadTime();
        bulletPool = new GameObject[stats.GetMagazineSize() * 2];
        bullet.DamagePerBullet = stats.GetDamage();
        bullet.DamageType = stats.GetDamageType();
        bullet.BulletType = stats.GetBulletType();
    }
    public abstract void Reload();

    public abstract void Shoot();

    public abstract void WeaponUpdate();

}
