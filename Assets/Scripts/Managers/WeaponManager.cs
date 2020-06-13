using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { get; private set; }

    [SerializeField]
    private Transform spawnPosition = null;
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
        GameObject go = Instantiate(currentWeapon.GetObjectToInstantiate(), spawnPosition.position, Quaternion.identity, spawnPosition);
        currentWeapon.SetFiringPosition(go.GetComponentInChildren<FiringPoint>().transform);
        StartCoroutine(CreateBullets());
    }
    public Weapon GetCurrentWeapon() 
    {
        return currentWeapon;
    }
    public Transform GetSpawnPosition() 
    {
        return spawnPosition;
    }
    IEnumerator CreateBullets() 
    {
        int i = 0;
        GameObject bulletPrefab = currentWeapon.bullet.GetBulletPrefab();
        Transform firingPosition = currentWeapon.GetFiringPosition();
        while (i < currentWeapon.GetBulletPool().Length) 
        {
            currentWeapon.GetBulletPool()[i] = Instantiate(bulletPrefab, firingPosition.position,Quaternion.identity,firingPosition);
            currentWeapon.GetBulletPool()[i].GetComponent<Bullet>().SetBulletStats(currentWeapon.bullet);
            i++;
            yield return new WaitForEndOfFrame();
        }
    }
}
