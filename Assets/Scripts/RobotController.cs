using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
    public class RobotController : MonoBehaviour
    {
        public GameObject startPrefab;
        public GameObject agentPrefab;
        [SerializeField] private Transform cameraFollow;

        void Awake()
        {
            Instantiate(startPrefab);
            SpawnAgents(); 
        }

        void SpawnAgents()
        { 
            var rotation = Quaternion.Euler(0, 0, 0);
            var position = new Vector3(0, 0, 0);
            var obg = Instantiate(agentPrefab, rotation * position, Quaternion.identity);
            //cameraFollow.Init(obg.transform);
            cameraFollow.transform.parent = obg.transform;
        }


    }
}
