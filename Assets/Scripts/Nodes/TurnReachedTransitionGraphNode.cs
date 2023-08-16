using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace Robot
{
    public static class TurnReachedTransition
    {  
        public static bool Condition(Gatherer agent)
        {
            Debug.Log("angle -"+agent.Transform.rotation.eulerAngles.y);
            Debug.Log("angle -" + agent.Angle);
            Debug.Log("Angle-" + Vector3.Angle(agent.Transform.rotation.eulerAngles, new Vector3(0, agent.Angle, 0)));
            Debug.Log("Distance = " + Vector3.Distance(agent.Transform.rotation.eulerAngles, new Vector3(0, agent.Angle, 0)));
                     
            if(Vector3.Distance(agent.Transform.rotation.eulerAngles, new Vector3(0, agent.Angle, 0)) <= 1)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
    [CreateNodeMenu("Robot/Transitions/TurnIsEnd")]
    public class TurnReachedTransitionGraphNode : FiniteStateMachineTransitionGraphNode
    { 
        public override FiniteStateMachineTransition<T> Build<T>(int targetIndex)
        { 
            var transition = new FiniteStateMachineTransition<Gatherer>
            {
                Condition = TurnReachedTransition.Condition,
                TargetState = targetIndex
            };
            return transition as FiniteStateMachineTransition<T>;
        }
    }
}
