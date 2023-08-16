using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;
using UnityEngine.Windows;


namespace Robot
{
    public class ChangeMaterialNode : FiniteStateMachineState<Gatherer>
    {
        public Material material;

        public ChangeMaterialNode(Material mat)
        {
            material = mat;
        }
        public override void OnTick(ref Gatherer agent)
        {
                         
            if(agent.Transform.GetComponentInChildren<SkinnedMeshRenderer>())
            {
                agent.Transform.GetComponentInChildren<SkinnedMeshRenderer>().material = material;
                agent.Material = agent.Transform.GetComponentInChildren<SkinnedMeshRenderer>().material;
            }
            else if (agent.Transform.GetComponentInChildren<MeshRenderer>())
            {
                agent.Transform.GetComponentInChildren<MeshRenderer>().material =material;
                agent.Material = agent.Transform.GetComponentInChildren<MeshRenderer>().material;
            }

           

        }
    }

    [CreateNodeMenu("Robot/States/ChangeMaterial")]
    public class ChangeMaterialGraphNode : FiniteStateMachineStateGraphNode
    {
        public Material material;
        protected override FiniteStateMachineState<T> ProtectedBuild<T>()
        {
            return new ChangeMaterialNode(material) as FiniteStateMachineState<T>;
        }
    }
}
