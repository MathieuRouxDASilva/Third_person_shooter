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

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform barrelPosition;
    [SerializeField] private float bulletVelocity;
    [SerializeField] private int bulletPerShot;
    [SerializeField] private GameObject aimTarget;
    [SerializeField] private GameObject fireEffect;

    [SerializeField] private AudioClip gunShot;
    private AudioSource _audioSource;

    
    
    
    // Start is called before the first frame update
    private void Start()
    {
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
    }

    private bool ShouldFire()
    {
        _fireRateTimer += Time.deltaTime;
        
        if (_fireRateTimer < fireRate)
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
        _fireRateTimer = 0;
        barrelPosition.LookAt(aimTarget.transform.position);

        for (int nbOfShoot = 0; nbOfShoot < bulletPerShot; nbOfShoot++)
        {
            fireEffect.SetActive(true);
            _audioSource.PlayOneShot(gunShot);
            GameObject actualBullet = Instantiate(bullet, barrelPosition.position, barrelPosition.rotation);
            Rigidbody rbe = actualBullet.GetComponent<Rigidbody>();
            rbe.AddForce(barrelPosition.forward * bulletVelocity, ForceMode.Impulse);
        }

        fireEffect.SetActive(false);
    }


    private void activeFireEffect()
    {
        
        _timer += Time.deltaTime;
        
        
    }
}
