using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Weapon weapon;
    public GameObject objectToInstantiate;
    private void Start()
    {
        weapon.SetObjectToInstantiate(objectToInstantiate);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player Hit");
            WeaponManager.Instance.AddWeapon(weapon,true);
            Destroy(this.gameObject);
        }
    }
}
