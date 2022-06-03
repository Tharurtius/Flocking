using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Avoid Net")]

public class AvoidNetBehaviour : FlockBehaviour
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if ((agent.transform.position - GameManager.net.transform.position).magnitude > 10)
        {
            return Vector2.zero;
        }

        Vector2 avoidanceMove = (Vector2)(agent.transform.position - GameManager.net.transform.position); ;

        return avoidanceMove;
    }
}