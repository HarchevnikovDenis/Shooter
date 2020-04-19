using UnityEngine;

[RequireComponent(typeof(WeaponAmmo))]
public class Weapon : MonoBehaviour
{
    private WeaponAmmo ammo;
    private float time;

    [Tooltip("Weapon Characterisics")]
    [SerializeField]private float secondsBetweenShoot;

    private void Start()
    {
        time = secondsBetweenShoot;
        ammo = GetComponent<WeaponAmmo>();
    }

    private void Update()
    {
        time += Time.deltaTime;

        if(Input.GetAxisRaw("Fire1") != 0 && time >= secondsBetweenShoot)
        {
            //Производится выстрел
            ammo.Shoot();
            time = 0.0f;
        }
    }
}
