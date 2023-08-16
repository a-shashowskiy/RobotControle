using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace Robot
{
    public static class TargetReachedTransition
    {
        public static bool Condition(Gatherer agent)
        {
            return Vector3.Distance(agent.Target, agent.Transform.position) <= agent.Reach;
        }
    }

    [CreateNodeMenu("Robot/Transitions/TargetReached")]
    public class TargetReachedTransitionGraphNode : FiniteStateMachineTransitionGraphNode
    {
        public override FiniteStateMachineTransition<T> Build<T>(int targetIndex)
        {
            var transition = new FiniteStateMachineTransition<Gatherer>
            {
                Condition = TargetReachedTransition.Condition,
                TargetState = targetIndex
            };
            return transition as FiniteStateMachineTransition<T>;
        }
    }
}