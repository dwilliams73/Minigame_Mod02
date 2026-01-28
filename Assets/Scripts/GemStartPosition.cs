using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GemStartPosition : MonoBehaviour
{
	public Vector3 startPosition;
	public Quaternion startRotation;

	void Start()
	{
		startPosition = transform.position;
		startRotation = transform.rotation;
	}
}

