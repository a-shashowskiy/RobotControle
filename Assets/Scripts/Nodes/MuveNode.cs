using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;
using UnityEngine.Windows;


namespace Robot
{ 
      public class Muve : FiniteStateMachineState<Gatherer>
      {  
        public float muveSpeed;
        public Vector3 muvePos;
        public Muve(float speed, Vector3 pos)
        {
            muveSpeed = speed;
            muvePos = pos;
        }
        public override void OnTick(ref Gatherer agent)
        { 
            agent.Target = muvePos;
            var direction = Vector3.Normalize(agent.Target - agent.Transform.position);
            agent.Transform.position += direction * (Time.deltaTime * muveSpeed);
            
            if (agent.Transform.GetComponent<Animator>() != null)
            {
                agent.Transform.GetComponent<Animator>().SetBool("Walk", true); 
            }
        }

        public override void OnExit(ref Gatherer agent)
        {
            base.OnExit(ref agent);
            if (agent.Transform.GetComponent<Animator>() != null)
            {
                agent.Transform.GetComponent<Animator>().SetBool("Walk", false);
            }
        }
    }
    [CreateNodeMenu("Robot/States/MoveToTarget")]
    public class MuveNode : FiniteStateMachineStateGraphNode
    {
        public float Speed;
        public Vector3 Target;
        protected override FiniteStateMachineState<T> ProtectedBuild<T>()
        {
            return new Muve(Speed, Target) as FiniteStateMachineState<T>;
        }
    } 
}
