﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PistolTemlate",menuName ="Weapons/Pistol",order =0)]
public class Pistol : Weapon
{

    public override void Init()
    {
        base.Init();
        hasBulletsInInventory = true;
        currentBulletsInMag = stats.GetMagazineSize();
    }

    public override void WeaponUpdate() 
    {
        fireRateTimer -= Time.deltaTime;

        canShoot = fireRateTimer >= 0 ? false : true;

        hasBulletsInMag = currentBulletsInMag > 0 ? true : false;
        if (isReloading)
        {
            reloadTimer -= Time.deltaTime;
            if (reloadTimer <= 0)
            {
                currentBulletsInMag = stats.GetMagazineSize();
                isReloading = false;
                reloadTimer = stats.GetRealoadTime();
                Debug.Log("Reload Done");
            }
        }
        else 
        {
            WeaponChecks();
        }
    }

    public override void Reload()
    {
        Debug.Log("Reloading my pistol");
        isReloading = true;
    }
    public override void Shoot()
    {
        GameObject go = GetPooledObject();
        if (go != null) 
        {
            go.SetActive(true);
            go.transform.position = firingPosition.position;
            go.transform.rotation = firingPosition.rotation;
            currentBulletsInMag--;
            fireRateTimer = stats.GetFireRate();
        }
    }
    private void WeaponChecks() 
    {
        if (InputManager.Instance.GetInputMethod().FireKey())
        {
            if (!hasBulletsInMag)
            {
                if (!hasBulletsInInventory)
                {
                    WeaponManager.Instance.OutOfBullets.Invoke();
                    return;
                }
                else
                {
                    Reload();
                }
            }
            else
            {
                if (canShoot && !isReloading)
                {
                    Shoot();
                }
            }
        }
    }
}
