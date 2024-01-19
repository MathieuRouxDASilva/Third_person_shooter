using StarterAssets;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WeaponAmmoSystem : MonoBehaviour
{

    public int clipSize;
    public int extraAmmo;
    public int currentAmmo;
    private StarterAssetsInputs _input;
    [SerializeField] private Animator animator;
    private float reloadTimer = 300f;
    
    //for right hand mouvement
    public MultiAimConstraint rHand;
    public TwoBoneIKConstraint lHand;

    [SerializeField] private AudioClip reloadClip; 
    private AudioSource _audio;
    
    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _input = GetComponentInParent<StarterAssetsInputs>();
        currentAmmo = clipSize;
    }


    private void Update()
    {
        if (_input.isReloading)
        {
            Reload();
        }
        reloadTimer -= Time.deltaTime;

        //timer baaed on reload animationtime -> 2.7sec
        if (reloadTimer <= 0)
        {
            animator.SetBool("Reload", false);
            rHand.weight = 1;
            lHand.weight = 1;
        }
        
    }

    public void Reload()
    {
        _audio.PlayOneShot(reloadClip);
        reloadTimer = 2.7f;
        rHand.weight = 0;
        lHand.weight = 0;
        animator.SetBool("Reload", true);
        if (extraAmmo >= clipSize)
        {
            int numberOfAmmoToReload = clipSize - currentAmmo;
            extraAmmo -= numberOfAmmoToReload;
            currentAmmo += numberOfAmmoToReload;
        }
        else if (extraAmmo > 0)
        {
            if (extraAmmo + currentAmmo > clipSize)
            {
                int leftOver = extraAmmo + currentAmmo - clipSize;
                extraAmmo = leftOver;
                currentAmmo = clipSize;
            }
            else
            {
                currentAmmo += extraAmmo;
                extraAmmo = 0;
            }
        }
    }
    
}
