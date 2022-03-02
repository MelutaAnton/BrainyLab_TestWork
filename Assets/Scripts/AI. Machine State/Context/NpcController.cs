using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion quaternion;
    private NavMeshAgent agent;
    private ShootControl shootControl;

    [SerializeField]
    private GameSettings gameSettings;

    //Patrolling
    private int currentPointPatrolling;
    [SerializeField]
    private Transform[] targets;
    [SerializeField]
    private Transform playerRotTransform;    
    [SerializeField]
    private int minBorderInterval = 10;
    [SerializeField]
    private int maxBorderInterval = 25;
    [SerializeField]
    private IntVariable scorePlayer;
    [SerializeField]
    private GameEvent restartLevel;

    //State NPC
    private NpcBaseState prevState;
    public NpcBaseState currentState;
    public readonly NpcBaseState idleState = new IdleState();
    public readonly NpcBaseState patrolState = new PatrolState();

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = gameSettings.SpeedEnemy;
        shootControl = GetComponent<ShootControl>();
        prevState = null;
        startPosition = transform.position;
        quaternion = transform.rotation;
    }

    private void Start()
    {
        TransitionToState(patrolState);
    }

    public void RestartPositionNpc()
    {
        CancelInvoke();
        StopAllCoroutines();
        prevState = null;
        agent.enabled = false;
        transform.position = startPosition;
        transform.rotation = quaternion;
        agent.enabled = true;
        TransitionToState(patrolState);
    }

    private void Update()
    {
        currentState.Update(this, agent);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BulletMove>())
        {
            scorePlayer.Value++;
            restartLevel.Raise();
            collision.gameObject.SetActive(false);
        }
    }

    public void TransitionToState(NpcBaseState state)
    {
        if (currentState == state)
            return;

        StopAllCoroutines();
        currentState = state;
        currentState.EnterState(this);
    }

    public void StopMoving()
    {
        agent.SetDestination(transform.position);
    }

    public void RotateToPlayer()
    {
        StartCoroutine(RotateCorutine());
    }

    private IEnumerator RotateCorutine()
    {
        float deltaTime = 0;
        Quaternion saveStartQuaternion = transform.rotation;
        transform.LookAt(playerRotTransform);
        Quaternion playerRot = transform.rotation;
        transform.rotation = saveStartQuaternion;

        while (deltaTime < 1)
        {
            transform.rotation = Quaternion.Lerp(saveStartQuaternion, playerRot, deltaTime);
            deltaTime += Time.deltaTime * 4;
            yield return null;
        }

        shootControl.ShootAction();
        Invoke("ReturnToPatrol", gameSettings.EnemyDelayOnSpot);
    }

    private void ReturnToPatrol()
    {
        TransitionToState(patrolState);
    }

    public void StartPatrolling()
    {
        StartCoroutine(GoToNextPoint());
    }

    private IEnumerator GoToNextPoint()
    {
        int randTaret = 0;
        Vector3 startPos = transform.position;
        while (true)
        {
            while (randTaret == currentPointPatrolling)
                randTaret = Random.Range(0, targets.Length);

            currentPointPatrolling = randTaret;
            agent.destination = targets[currentPointPatrolling].position;
            yield return new WaitForSeconds(Random.Range(minBorderInterval, maxBorderInterval));
        }
    }

}



