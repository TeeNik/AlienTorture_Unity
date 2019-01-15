using UnityEngine;

public class WeaponModel : MonoBehaviour
{
    public GameObject Object;
    public WeaponData Data { get; private set; }

    public WeaponModel(WeaponData data)
    {
        Data = data;
    }
}
