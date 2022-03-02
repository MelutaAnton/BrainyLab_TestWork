using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Vector3 startPosition;
    private float deltaTime = 0;
    private ShootControl shootControl;

    [SerializeField]
    private GameSettings gameSettings;
    [SerializeField]
    private IntVariable scoreEnemy;
    [SerializeField]
    private GameEvent restartLevel;

    private void Awake()
    {
        shootControl = GetComponent<ShootControl>();
        startPosition = transform.position;
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BulletMove>())
        {
            scoreEnemy.Value++;
            restartLevel.Raise();
            collision.gameObject.SetActive(false);
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("DeathTrigger"))
            restartLevel.Raise();
    }

    private void Update()
    {
        deltaTime += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && deltaTime > gameSettings.IntervalShootsPlayer)
        {
            shootControl.ShootAction();
            deltaTime = 0;
        }
    }
}
