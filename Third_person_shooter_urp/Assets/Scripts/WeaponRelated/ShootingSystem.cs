using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.Serialization;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField] private GameObject shootingTarget;
    [SerializeField] private GameObject shootingOrigin;
    private Camera _mainCamera;
    private StarterAssetsInputs _input;
    [SerializeField] private float maxShootDistance = 300;
    [SerializeField] private GameObject impact;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask layerMask;
    private float _smoothSpeed = 20f;


    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.isAiming)
        {
            shootingTarget.SetActive(true);

            animator.SetBool("Aiming", true);

            // Vector3 shootPoint = _mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, maxShootDistance));
            //
            // Ray ray = new Ray(shootingOrigin.transform.position, shootPoint - shootingTarget.transform.position);
            //
            // Debug.DrawRay(ray.origin, ray.direction * maxShootDistance, Color.magenta, 0.5f);
            //
            // if (Physics.Raycast(ray, out RaycastHit hitInfo, maxShootDistance, layerMask))
            // {
            //     shootingTarget.transform.position = hitInfo.point;
            //     //hitInfo.collider.gameObject.CompareTag("Target");
            //
            //     shootingTarget.transform.position = Vector3.Lerp(shootingTarget.transform.position, hitInfo.point,
            //         _smoothSpeed * Time.deltaTime);
            //
            //     // if (_input.isShooting)
            //     // {
            //     //     Instantiate(impact, hitInfo.point, Quaternion.identity);
            //     // }
            //
            //     //hitInfo.collider.gameObject.GetComponent<Target>();
            //
            //     //Instantiate();
            // }
        }
        else
        {
            shootingTarget.SetActive(false);
            animator.SetBool("Aiming", false);
        }
    }
}