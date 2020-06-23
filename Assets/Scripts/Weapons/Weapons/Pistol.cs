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
        fireRateTimer = 0;
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
            stats.CalculatedOffset = new Vector3(Random.Range(-stats.GetAccuracy().minSpread, stats.GetAccuracy().minSpread), Random.Range(-stats.GetAccuracy().minSpread, stats.GetAccuracy().minSpread), 1);
            go.transform.position = firingPosition.position;
            go.SetActive(true);
            currentBulletsInMag--;
            fireRateTimer = 1/stats.GetFireRate();
        }
    }
    void CalculateOffset() 
    {

    }
    void ApplySpread() 
    {

    }
    void ApplyRetract() 
    {

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
