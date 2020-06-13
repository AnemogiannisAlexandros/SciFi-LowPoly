using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType 
{
    Normal,
    Fire,
    Frost,
    Shock,
    Shadow
}

public class WeaponStats : ScriptableObject
{
    [Header("Main Stats")]
    [Tooltip("How much damage you deal with each shot")]
    [SerializeField]
    protected int damage;
    [Tooltip("Weapon's Bloom/Spread. The Higher the Less Spread")]
    [SerializeField]
    [Range(0, 100)]
    protected float accuracy;
    [Tooltip("The Higher the less your crosshair sways & lower Recoil")]
    [Range(0, 100)]
    [SerializeField]
    protected float handling;
    [Tooltip("How Long Your Gun Takes to Reload/Cooldown")]
    [SerializeField]
    protected float reloadTime;
    [Tooltip("How Quickly your gun Fires in shots per second")]
    [SerializeField]
    protected float fireRate;
    [Tooltip("How many shots you can fire without reloading")]
    [SerializeField]
    protected int magazineSize;

    [Header("Secondary Stats")]
    [Tooltip("The percentage of extra damage you will do if you crit")]
    [Range(101, 200)]
    [SerializeField]
    protected int critDamage;
    [Tooltip("Type of damage this Weapon Does")]
    [SerializeField]
    protected DamageType damageType;
    [Tooltip("The Type of Bullets this weapon Uses")]
    [SerializeField]
    protected BulletType bulletType;

    public int GetDamage()
    {
        return damage;
    }
    public float GetAccuracy()
    {
        return accuracy;
    }
    public float GetHandling()
    {
        return handling;
    }
    public float GetRealoadTime()
    {
        return reloadTime;
    }
    public float GetFireRate()
    {
        return fireRate;
    }
    public int GetMagazineSize()
    {
        return magazineSize;
    }
    public DamageType GetDamageType() 
    {
        return damageType;
    }
    public BulletType GetBulletType() 
    {
        return bulletType;
    }
}
