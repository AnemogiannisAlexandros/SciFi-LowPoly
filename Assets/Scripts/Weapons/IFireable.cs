using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public interface IFireable 
{
    void Shoot();
    void Reload();
    void WeaponUpdate();
}
