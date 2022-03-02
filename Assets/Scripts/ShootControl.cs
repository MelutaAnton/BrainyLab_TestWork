using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour
{
    [SerializeField]
    private Transform eyeTransform;
    [SerializeField]
    private PoolObject poolBullets;

   
    public void ShootAction()
    {
        GameObject bullet = poolBullets.GetPooledObject();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = eyeTransform.position;
        bullet.GetComponent<BulletMove>().MovingActivated(eyeTransform.localPosition,
            eyeTransform.localPosition + (eyeTransform.forward * 1000));
    }
}
