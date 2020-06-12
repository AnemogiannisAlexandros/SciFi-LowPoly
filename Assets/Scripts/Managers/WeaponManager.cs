using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { get; private set; }

    [SerializeField]
    private Transform spawnPosition;
    private Weapon currentWeapon;

    public UnityEvent OutOfBullets;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            if (currentWeapon != null) 
            {
                currentWeapon.Init();
            }
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (currentWeapon != null) 
        {
            currentWeapon.WeaponUpdate();
        }
    }

    public void SetCurrentWeapon(Weapon weapon) 
    {
        currentWeapon = weapon;
        currentWeapon.Init();
        Instantiate(weapon.objectToInstantiate, spawnPosition.position,Quaternion.identity, spawnPosition);
    }
    public Weapon GetCurrentWeapon() 
    {
        return currentWeapon;
    }
    public Transform GetSpawnPosition() 
    {
        return spawnPosition;
    }
}
