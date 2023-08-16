using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

namespace Robot
{
    public class Turn : FiniteStateMachineState<Gatherer>
    {
        float angle;
        bool direction;
        bool setAngle = false;
        float turnSpeed;
        Vector3 endAngle;
        Quaternion r;
        float time = 0; 
        public Turn(float angleTurn, float tspeed,bool dir)
        {
            angle= angleTurn;
            direction = dir; 
            turnSpeed = tspeed;
        }
        public override void OnTick(ref Gatherer agent)
        {
            if (!setAngle)
            {
                agent.DirectionTurn = direction;
                if (direction)
                {
                    Quaternion r = Quaternion.AngleAxis(agent.Transform.rotation.eulerAngles.y + angle, Vector3.up);
                    endAngle = r.eulerAngles;
                    agent.Angle = endAngle.y ;
                    Debug.Log("endAngle -" + endAngle );
                } else
                {
                    r = Quaternion.AngleAxis(agent.Transform.rotation.eulerAngles.y - angle, Vector3.up);
                    endAngle = r.eulerAngles;
                    agent.Angle = endAngle.y; 
                } 

                setAngle = true; 
            }
              
            float step = angle / ( 60 * turnSpeed);  
            agent.Transform.Rotate(new Vector3(0,direction?step:-step, 0));
        }
    }

    [CreateNodeMenu("Robot/States/Turn")]
    public class TurnNode : FiniteStateMachineStateGraphNode
    {
        public float angle;
        public float turnSpeed;
        public bool direction;
        protected override FiniteStateMachineState<T> ProtectedBuild<T>()
        {
            return new Turn(angle, turnSpeed, direction) as FiniteStateMachineState<T>;
        }
    }
    
    //        protected override void Process()
    //        {
    //            if (input1 != null)
    //            {
    //                if (direction)
    //                    input1.transform.Rotate(0, -degrees, 0);
    //                else
    //                input1.transform.Rotate(0, degrees, 0);
    //            }
    //        }
    //    }
}
