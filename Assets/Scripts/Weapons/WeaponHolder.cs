using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Weapon weapon;

    private void Start()
    {
        weapon.objectToInstantiate = gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player Hit");
            WeaponManager.Instance.SetCurrentWeapon(weapon);
            Destroy(this.gameObject);
        }
    }
}
