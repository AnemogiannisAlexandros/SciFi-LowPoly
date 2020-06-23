using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Weapon weapon;
    //private Weapon weaponInstance;
    //private void Start()
    //{
    //    ////weaponInstance = ScriptableObject.CreateInstance(weapon.GetType()) as Weapon;
    //    //weaponInstance = Instantiate(weapon);
    //    //weaponInstance.Init(weapon.stats, weapon.bullet);
    //    //Debug.Log(weapon.GetType());
    //    //Debug.Log(weapon.stats.GetType());
    //    //Debug.Log(weapon.bullet.GetType());
    //    //Debug.Log(weapon.stats.GetFireRate());
    //    //Debug.Log(weaponInstance.GetType());
    //    //Debug.Log(weaponInstance.GetStats().GetType());
    //    //Debug.Log(weaponInstance.GetBullet().GetType());
    //    //Debug.Log(weaponInstance.GetStats().GetMagazineSize());
    //    //weaponInstance.GetStats().SetMagazineSize(2);
    //    //Debug.Log(weaponInstance.GetStats().GetMagazineSize());

    //}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player Hit");
            WeaponManager.Instance.AddWeapon(weapon,true);
            transform.gameObject.SetActive(false);
        }
    }
}
