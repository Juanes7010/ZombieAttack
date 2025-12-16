using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] Transform posGun;
    [SerializeField] Transform cam;
    [SerializeField] Transform posPlayer;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] LayerMask ignoreLayer;
    [SerializeField] Gun gun;
    [SerializeField] AudioClip shootSound;

    AudioSource playerAudio;
    RaycastHit hit;
    Health health;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        health = GameObject.Find("Player").GetComponent<Health>();
    }
    private void Update()
    {
        Debug.DrawRay(cam.position, cam.forward * 100f, Color.red);
        Debug.DrawRay(posGun.position, cam.forward * 100f, Color.blue);

        if (Input.GetKeyDown(KeyCode.Mouse0) && gun.ReturnGun() && !health.ReturnGameOver())
        {
            Invoke("BulletGenerator", 0.4f);
        }
    }

    void BulletGenerator()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            GameObject bulletObj = Instantiate(bulletPrefab);
            bulletObj.transform.position = posGun.position;
            if (Physics.Raycast(cam.position, cam.forward, out hit, Mathf.Infinity, ~ignoreLayer))
            {
                bulletObj.transform.LookAt(hit.point);
            }
            else
            {
                Vector3 dir = cam.position + cam.forward * 10f;
                bulletObj.transform.LookAt(dir);
            }
            playerAudio.PlayOneShot(shootSound, 0.5f);
            Invoke("BulletGenerator", 0.2f);
        }
    }
}
