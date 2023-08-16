using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace Robot
{
    public static class ColorReachedTransition
    {
        public static bool Condition(Gatherer agent)
        {
            if (agent.Transform.GetComponentInChildren<SkinnedMeshRenderer>())
            {   
                //Debug.Log("MaterialInMemory = "+agent.Material.name);
                //Debug.Log("MaterialOnMech = "+agent.Transform.GetComponentInChildren<SkinnedMeshRenderer>().material.name);
                //Debug.Log("Material changed = "+(agent.Transform.GetComponentInChildren<SkinnedMeshRenderer>().material == agent.Material));
                if (agent.Transform.GetComponentInChildren<SkinnedMeshRenderer>().materials[0] == agent.Material)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (agent.Transform.GetComponentInChildren<MeshRenderer>())
            {
                if (agent.Transform.GetComponentInChildren<MeshRenderer>().materials[0] == agent.Material)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
              
        }
    }
    [CreateNodeMenu("Robot/Transitions/ColorIsSet")]
    public class ColorChangeTransitionGraphNode : FiniteStateMachineTransitionGraphNode
    {
        public override FiniteStateMachineTransition<T> Build<T>(int targetIndex)
        {
            var transition = new FiniteStateMachineTransition<Gatherer>
            {
                Condition = ColorReachedTransition.Condition,
                TargetState = targetIndex
            };
            return transition as FiniteStateMachineTransition<T>;
        }
    }
}
