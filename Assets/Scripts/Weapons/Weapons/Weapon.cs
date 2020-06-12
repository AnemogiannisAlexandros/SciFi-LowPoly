using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject, IFireable
{
    public WeaponStats stats;
    public GameObject objectToInstantiate;

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

    public virtual void Init() 
    {
        canShoot = true;
        fireRateTimer = 1 / stats.GetFireRate();
        reloadTimer = stats.GetRealoadTime();
    }
    public abstract void Reload();

    public abstract void Shoot();

    public abstract void WeaponUpdate();

}
