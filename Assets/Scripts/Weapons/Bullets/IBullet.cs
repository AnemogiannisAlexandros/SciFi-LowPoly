using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet 
{
    void BulletStart();
    void BulletUpdate();
    void BulletFixedUpdate();
    void BulletStop();
    
    void ApplyInstantForce(Rigidbody rb,Vector3 direction);
}
