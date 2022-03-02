using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class NpcBaseState
{
    public abstract void EnterState(NpcController npc);

    public abstract void Update(NpcController npc, NavMeshAgent agent);
}
