using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateShotgunBlast : MonoBehaviour
{
    [SerializeField] private GameObject _shotgunBulletSpawnPoint;
    [SerializeField] private InputControls _inputControls;

    private void Awake()
    {
        _inputControls = new InputControls();
    }

    public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(_shotgunBulletSpawnPoint.transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(1000);
            }
        }
    }
}
