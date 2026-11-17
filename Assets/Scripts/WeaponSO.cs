using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public string WeaponName = "";
    public int Damage = 1;
    public float FireRate = 0f;
    public float FireRange = 0f;
    public GameObject WeaponPrefab;
    public GameObject HitVFXPrefab;
    public bool IsAutomatic = false;
}
