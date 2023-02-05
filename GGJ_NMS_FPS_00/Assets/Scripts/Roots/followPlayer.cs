using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

public class followPlayer : MonoBehaviour
{
    public Collider player;
    public float playerHeight = 2.5f;
    public Rigidbody forcedBody;
    public float thrust = 20f;
    public float disabledLightIntensity = 0f;
    public float enabledLightIntensity = 5f;
    private float lightDelta = 0.1f;
    private float lightActualForce = 0f;

    private bool chasing = false;

    private void Start()
    {
        player = GameManager.Instance.PlayerController.GetComponent<CapsuleCollider>();
        refreshLightAmount();
    }

    private void FixedUpdate()
    {
        refreshLightAmount();
    }

    private void refreshLightAmount()
    {
        if (chasing)
        {
            if (lightActualForce < enabledLightIntensity)
                lightActualForce += lightDelta;
            else
                lightActualForce = enabledLightIntensity;
        }
        else
        {
            if (lightActualForce >= 0f)
                lightActualForce -= lightDelta;
            else
                lightActualForce = 0f;
        }

        GetComponent<Light>().intensity = lightActualForce;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other == player)
        {
            var direction = player.transform.position + new Vector3(0f, playerHeight, 0f) - transform.position;
            forcedBody.AddForce(direction.normalized * thrust*2);
            chasing = true;
		}
    }

    void OnTriggerStay(Collider other)
    {
        if (other == player)
        {
            var direction = player.transform.position - transform.position;
            forcedBody.AddForce(direction.normalized * thrust/12);
            chasing = true;

            var distance = Vector3.Distance(other.transform.position, transform.position);
			if (distance < 2f)
				OxygenManager.Instance.SetUnderAttack(true);
            else
                OxygenManager.Instance.SetUnderAttack(false);
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        chasing = false;
	}
}
