using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Bullet/Pistol Bullet",fileName ="")]
public class PistolBulet : BaseBullet
{
    public override void BulletStart()
    {
        Debug.Log("BulletStart Running");
    }

    public override void BulletUpdate()
    {
        Debug.Log("BulletUpdate Running");
    }
    public override void BulletStop()
    {
        Debug.Log("BulletStop Running");
    }

    public override void ApplyInstantForce(Rigidbody rb)
    {
        rb.AddForce(rb.transform.forward * bulletForce,ForceMode.Impulse);
    }

}
