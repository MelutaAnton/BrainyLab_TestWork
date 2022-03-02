using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private float deltaLifeCycle;
    private Vector3 currentDirection;

    [SerializeField]
    private float lifeCyclePeriod = 5;    
    [SerializeField]
    private float speedBulet = 3;
    [SerializeField]
    private LayerMask layerObstacle;

    private void OnEnable()
    {
        deltaLifeCycle = 0;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Update()
    {
        deltaLifeCycle += Time.deltaTime;
        if(deltaLifeCycle > lifeCyclePeriod)
        {
            gameObject.SetActive(false);
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.5f, layerObstacle))
        {
            StopAllCoroutines();
            StartCoroutine(MoveReverse());
        }       
            
    }

    public void MovingActivated(Vector3 direction, Vector3 direction2)
    {
        StartCoroutine(MoveCorutine(direction, direction2));
    }

    private IEnumerator MoveCorutine(Vector3 direction, Vector3 direction2)
    {
        currentDirection = direction2 - direction;
        while (true)
        {
            transform.Translate(currentDirection * Time.deltaTime * speedBulet * 0.01f);
            yield return null;
        }
    }

    private IEnumerator MoveReverse()
    {
        currentDirection *= -1;
        while (true)
        {
            transform.Translate(currentDirection * Time.deltaTime * speedBulet * 0.01f);
            yield return null;
        }
    }


}
