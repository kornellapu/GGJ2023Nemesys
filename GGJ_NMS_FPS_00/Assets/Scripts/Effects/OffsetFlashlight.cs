using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

public class OffsetFlashlight : MonoBehaviour
{
	[SerializeField] float speed = 3.0f;

	private Vector3 offset;
	private GameObject followObj;
	private Camera charecterCamera;

	private void Start()
	{
		followObj = GameManager.Instance.CharecterCamera.gameObject;
		offset = transform.position - followObj.transform.position;
	}

	private void Update()
	{
		transform.position = followObj.transform.position + offset;
		transform.rotation = Quaternion.Slerp(transform.rotation, followObj.transform.rotation, speed * Time.deltaTime);
	}
}
