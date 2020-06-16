using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { get; private set; }

    private static int weaponSlots = 4;
    [SerializeField]
    private int unlockedSlots=2;
    [SerializeField]
    private GameObject[] weapons = new GameObject[weaponSlots];
    [SerializeField]
    private Weapon[] equippedWeapons = new Weapon[weaponSlots];
    [SerializeField]
    private int currentWeaponIndex;
    [SerializeField]
    private Transform weaponPosition = null;
    [SerializeField]
    private GameObject[] bulletHolders = new GameObject[weaponSlots];
    
    public UnityEvent OutOfBullets;


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

    private void Start()
    {

    }

    private void Update()
    {
        if (equippedWeapons[currentWeaponIndex] != null) 
        {
            equippedWeapons[currentWeaponIndex].WeaponUpdate();
        }
    }

    public Transform GetSpawnPosition() 
    {
        return weaponPosition;
    }

    public Weapon GetCurrentWeapon() 
    {
        return equippedWeapons[currentWeaponIndex];
    }

    private void EnableWeapon(int index) 
    {
        currentWeaponIndex = index;
        equippedWeapons[currentWeaponIndex].GetObjectToInstantiate().SetActive(true);
    }

    public void AddWeapon(Weapon newWeapon,bool enabled) 
    {
        for (int i = 0; i <= unlockedSlots-1; i++) 
        {
            if (equippedWeapons[i] == null) 
            {
                equippedWeapons[i] = newWeapon;
                weapons[i] = Instantiate(equippedWeapons[i].GetObjectToInstantiate(), weaponPosition.position, Quaternion.identity, weaponPosition);
                equippedWeapons[i].SetFiringPosition(weapons[i].transform);
                equippedWeapons[i].Init();
                StartCoroutine(CreateBullets(i));
                if (enabled) 
                {
                    EnableWeapon(i);
                }
                break;
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
        AddWeapon(newWeapon,false);
    }

    public void SwapActiveWeapon(int newWeaponIndex) 
    {
        equippedWeapons[currentWeaponIndex].GetObjectToInstantiate().SetActive(false);
        equippedWeapons[newWeaponIndex].GetObjectToInstantiate().SetActive(true);
        currentWeaponIndex = newWeaponIndex;
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
    IEnumerator CreateBullets(int weaponIndex)
    {
        int i = 0;
        GameObject bulletPrefab = equippedWeapons[weaponIndex].bullet.GetBulletPrefab();
        while (i < equippedWeapons[weaponIndex].GetBulletPool().Length)
        {
            equippedWeapons[weaponIndex].GetBulletPool()[i] = Instantiate(bulletPrefab, bulletHolders[weaponIndex].transform.position, Quaternion.identity, bulletHolders[weaponIndex].transform);
            equippedWeapons[weaponIndex].GetBulletPool()[i].GetComponent<Bullet>().SetBulletStats(equippedWeapons[weaponIndex].bullet);
            i++;
            yield return new WaitForEndOfFrame();
        }
    }
}
