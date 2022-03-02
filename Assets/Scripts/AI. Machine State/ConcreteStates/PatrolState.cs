using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : NpcBaseState
{
    public override void EnterState(NpcController npc)
    {
        npc.StartPatrolling();
    }

    public override void Update(NpcController npc, NavMeshAgent agent)
    {
        if (agent.remainingDistance < 0.1f)        
            npc.TransitionToState(npc.idleState);        
    }

}
