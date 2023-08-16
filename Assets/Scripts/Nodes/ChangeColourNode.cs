using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;
using UnityEngine.Windows;


namespace Robot
{
    public class ChangeColour : FiniteStateMachineState<Gatherer>
    {
        public Color color;
        public ChangeColour(Color col)
        {
            color = col;
            
        }
        public override void OnTick(ref Gatherer agent)
        {
            if(agent.Material == null)
            {
                if (agent.Transform.GetComponentInChildren<SkinnedMeshRenderer>())
                {
                    agent.Material = agent.Transform.GetComponentInChildren<SkinnedMeshRenderer>().material;
                }
                else if (agent.Transform.GetComponentInChildren<MeshRenderer>())
                {
                    agent.Material = agent.Transform.GetComponentInChildren<MeshRenderer>().material;
                }
            }
            agent.Material.color = color;
            if (agent.Transform.GetComponentInChildren<SkinnedMeshRenderer>())
            {
                agent.Transform.GetComponentInChildren<SkinnedMeshRenderer>().material.color = color;
            }else if (agent.Transform.GetComponentInChildren<MeshRenderer>())
            {
                agent.Transform.GetComponentInChildren<MeshRenderer>().material.color = color;
            }
        }
    }
    [CreateNodeMenu("Robot/States/ChangeColour")]
    public class ChangeColourNode : FiniteStateMachineStateGraphNode
    {
        public Color color;
        protected override FiniteStateMachineState<T> ProtectedBuild<T>()
        {
            return new ChangeColour(color) as FiniteStateMachineState<T>;
        }
    }
}
