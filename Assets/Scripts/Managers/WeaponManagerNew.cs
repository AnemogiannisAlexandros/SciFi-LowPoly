using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagerNew : MonoBehaviour
{
    public static WeaponManagerNew Instance { get; private set; }

    private static int weaponSlots = 4;
    [SerializeField]
    private int unlockedSlots=2;
    [SerializeField]
    private Weapon[] equippedWeapons = new Weapon[weaponSlots];
    [SerializeField]
    private int currentWeaponIndex;
    [SerializeField]
    private Transform weaponPosition;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void EnableWeapon(int next) 
    {
        equippedWeapons[currentWeaponIndex].GetObjectToInstantiate().SetActive(false);
        equippedWeapons[next].GetObjectToInstantiate().SetActive(true);
        currentWeaponIndex = next;
    }
    public void AddWeapon(Weapon newWeapon) 
    {
        for (int i = 0; i <= unlockedSlots-1; i++) 
        {
            if (equippedWeapons[i] == null) 
            {
                equippedWeapons[i] = newWeapon;
                Instantiate(equippedWeapons[i].GetObjectToInstantiate(), weaponPosition.position, Quaternion.identity);
            }
        }
    }
    public void RemoveWeapon(int index) 
    {
        equippedWeapons[index] = null;
    }
    public void SwapWeapon(int index, Weapon newWeapon) 
    {
        RemoveWeapon(index);
        AddWeapon(newWeapon);
    }
    public void SwapActiveWeapon(int newWeaponIndex) 
    {
        EnableWeapon(newWeaponIndex);
    }
    public void SwapActiveWeapon(bool next) 
    {
        if (next)
        {
            if (currentWeaponIndex + 1 < unlockedSlots - 1)
            {
                EnableWeapon(currentWeaponIndex + 1);
            }
            else
            {
                EnableWeapon(0);
            }
        }
        else 
        {
            if (currentWeaponIndex - 1 > 0)
            {
                EnableWeapon(currentWeaponIndex - 1);
            }
            else
            {
                EnableWeapon(unlockedSlots - 1);
            }
        }
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
}
