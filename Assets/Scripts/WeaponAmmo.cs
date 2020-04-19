using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class WeaponAmmo : MonoBehaviour
{
    [SerializeField] private Text ammoCount;

    [Tooltip("Ammo Settings")]
    [SerializeField] private int ammoInWeapon;  //Сколько патронов хранится в обойме оружия
    private int currentAmmoInWeapon;            //Текущее количество патронов
    [SerializeField] private int allAmmo;       //Общеей количество патронов(вне обоймы)
    [SerializeField] private bool isPistol;     //Если пистолет, то обойма ограничена

    [Tooltip("Effects")]
    [SerializeField] private ParticleSystem fireEffect;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip reloadClip;
    private new AudioSource audio;
    private Animator animator;
    private bool isReloading;

    private void Start()
    {
        currentAmmoInWeapon = ammoInWeapon;
        ammoCount.text = ToString();
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && ammoInWeapon != currentAmmoInWeapon && !isReloading)
        {
            isReloading = true;
            //Reload
            Reload();
        }
    }

    public void Shoot()
    {
        if(currentAmmoInWeapon > 0)
        {
            audio.PlayOneShot(shootClip);
            animator.SetTrigger("Shoot");
            fireEffect.Play();

            currentAmmoInWeapon--;
            ammoCount.text = ToString();

            //TODO: Здесь определяется в кого выстрелил игрок
        }
        else
        {
            Reload();
        }
    }

    private void Reload()
    {
        audio.PlayOneShot(reloadClip);
        animator.SetTrigger("Reload");
    }

    private void UpdateAmmoCount()
    {
        //Для другого типа оружия уменьшать общий объем
        currentAmmoInWeapon = ammoInWeapon;
        ammoCount.text = ToString();
        isReloading = false;
    }

    public override string ToString()
    {
        if(isPistol)
        {
            return currentAmmoInWeapon + "/∞";
        }
        else
        {
            return "";
        }
    }
}
