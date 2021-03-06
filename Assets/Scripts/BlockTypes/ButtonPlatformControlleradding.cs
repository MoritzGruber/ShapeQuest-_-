﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof (BoxCollider))]
public class ButtonPlatformControlleradding : MonoBehaviour {

    Collider col;

    [SerializeField]
    GameObject Platform;
    [SerializeField]
    Vector3 PlatformTargetPos;
    [SerializeField]
    float PlatformMovementTime;

    // Use this for initialization
    void Start ()
    {
        col = GetComponent<Collider>();
        col.isTrigger = true;
	}
	

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(MoveOverSeconds(Platform,PlatformTargetPos,PlatformMovementTime));
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
			objectToMove.transform.position = Vector3.Lerp(startingPos, (startingPos + end), (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
		objectToMove.transform.position = (startingPos + end);
        col.enabled = false;
    }
}
