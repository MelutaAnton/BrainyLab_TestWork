using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : NpcBaseState
{
    public override void EnterState(NpcController npc)
    {
        npc.RotateToPlayer();
    }

    public override void Update(NpcController npc, NavMeshAgent agent)
    {

    }
    
}
