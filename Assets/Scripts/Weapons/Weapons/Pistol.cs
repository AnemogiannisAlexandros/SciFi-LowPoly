using System.Collections;
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

        WeaponChecks();
    }

    public override void Reload()
    {
        Debug.Log("Reloading my pistol");
        isReloading = true;
        reloadTimer -= Time.deltaTime;
        if (reloadTimer <= 0) 
        {
            currentBulletsInMag = stats.GetMagazineSize();
            isReloading = false;
            reloadTimer = stats.GetRealoadTime();
        }
    }
    public override void Shoot()
    {
        Debug.Log("Shooting my pistol  for : " + stats.GetDamage());
        currentBulletsInMag--;
        fireRateTimer = stats.GetFireRate();
        Debug.Log("Bullets Left : " + currentBulletsInMag);
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
