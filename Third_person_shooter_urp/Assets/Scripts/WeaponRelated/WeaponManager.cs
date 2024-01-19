using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private float fireRate;
    private float _fireRateTimer;
    private float _timer;
    private StarterAssetsInputs _input;
    private float _fireEffectTimer = 0.3f;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform barrelPosition;
    [SerializeField] private float bulletVelocity;
    [SerializeField] private int bulletPerShot;
    [SerializeField] private GameObject aimTarget;
    [SerializeField] private GameObject fireEffect;
    private WeaponAmmoSystem _ammo;

    [SerializeField] private AudioClip gunShot;
    private AudioSource _audioSource;


    // Start is called before the first frame update
    private void Start()
    {
        _ammo = GetComponent<WeaponAmmoSystem>();
        fireEffect.SetActive(false);
        _audioSource = GetComponent<AudioSource>();
        _input = GetComponentInParent<StarterAssetsInputs>();
        _fireRateTimer = fireRate;
    }

    // Update is called once per frame
    private void Update()
    {
        if (ShouldFire())
        {
            Fire();
        }
        _fireEffectTimer -= Time.deltaTime;

        if (_fireEffectTimer <=0)
        {
            fireEffect.SetActive(false);
        }
    }

    private bool ShouldFire()
    {
        _fireRateTimer += Time.deltaTime;

        if (_fireRateTimer < fireRate)
        {
            return false;
        }

        if (_ammo.currentAmmo == 0)
        {
            return false;
        }

        if (_input.isShooting)
        {
            return true;
        }

        return false;
    }

    private void Fire()
    {
        _fireEffectTimer = 0.3f;
        fireEffect.SetActive(true);
        _fireRateTimer = 0;
        _audioSource.PlayOneShot(gunShot);
        barrelPosition.LookAt(aimTarget.transform.position);
        _ammo.currentAmmo--;
        for (int nbOfShoot = 0; nbOfShoot < bulletPerShot; nbOfShoot++)
        {
            GameObject actualBullet = Instantiate(bullet, barrelPosition.position, barrelPosition.rotation);
            Rigidbody rbe = actualBullet.GetComponent<Rigidbody>();
            rbe.AddForce(barrelPosition.forward * bulletVelocity, ForceMode.Impulse);
        }
    }
}