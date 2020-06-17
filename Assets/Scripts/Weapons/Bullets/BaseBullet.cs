using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum BulletType 
{
    ClassicPistol,
    Revolver,
    SMG,
    CombatRifle,
    SniperRifle,
    ShotGun,
    Launcher
}
public abstract class BaseBullet : ScriptableObject,IBullet
{
    public DamageType DamageType { get; set; }
    public BulletType BulletType { get; set; }
    [SerializeField]
    protected GameObject bulletPrefab;

    protected Rigidbody rb;
    [SerializeField]
    protected bool isPhysical;
    [SerializeField]
    protected float gravityScale;
    [SerializeField]
    protected float bulletForce;

    public int DamagePerBullet { get; set; }

    public GameObject GetBulletPrefab() 
    {
        return bulletPrefab;
    }

    public abstract void BulletStart();

    public abstract void BulletUpdate();

    public abstract void BulletStop();

    public abstract void BulletFixedUpdate();

    public abstract void ApplyInstantForce(Rigidbody rb,Vector3 direction);
}

[CustomEditor(typeof(BaseBullet),true)]
public class BaseBulletEditor : Editor 
{
    SerializedProperty bulletPrefab;
    SerializedProperty isPhysical;
    SerializedProperty gravityScale;
    SerializedProperty bulletForce;

    private void OnEnable()
    {
        bulletPrefab = serializedObject.FindProperty("bulletPrefab");
        isPhysical = serializedObject.FindProperty("isPhysical");
        gravityScale = serializedObject.FindProperty("gravityScale");
        bulletForce = serializedObject.FindProperty("bulletForce");
    }
    public override void OnInspectorGUI()
    {

        serializedObject.Update();
        bulletPrefab = serializedObject.FindProperty("bulletPrefab");
        isPhysical = serializedObject.FindProperty("isPhysical");
        gravityScale = serializedObject.FindProperty("gravityScale");
        bulletForce = serializedObject.FindProperty("bulletForce");
        Debug.Log("Working");
        EditorGUILayout.BeginVertical();
        EditorGUILayout.PropertyField(bulletPrefab);
        EditorGUILayout.PropertyField(isPhysical);
        if (isPhysical.boolValue)
        {
            EditorGUILayout.PropertyField(gravityScale);
            EditorGUILayout.PropertyField(bulletForce);
        }
        EditorGUILayout.EndVertical();
        serializedObject.ApplyModifiedProperties();
    }
}

