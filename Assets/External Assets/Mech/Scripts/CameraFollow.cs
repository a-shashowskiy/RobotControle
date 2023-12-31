using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private Transform folowTransform; 
	private Vector3 offset;

    public void Init (Transform folowTarget) 
	{		
		folowTransform = folowTarget;
		offset = folowTransform.position +  (Vector3.back * 10f)+(Vector3.up*5) ; 
    }
	

	void LateUpdate () {
		
		Vector3 camPos = transform.position;
		Vector3 newPos =  Vector3.Lerp(camPos, folowTransform.position + offset, Time.deltaTime *5);
		transform.position = newPos;
		transform.LookAt(folowTransform.position);
	}
}
