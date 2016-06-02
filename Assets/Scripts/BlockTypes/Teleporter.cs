using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class Teleporter : MonoBehaviour {
    Collider col;
    
    [SerializeField]
    Transform teleportTargetTransform;

    // Use this for initialization
    void Start()
    {
        col = GetComponent<Collider>();
        col.isTrigger = true;
    }


    void OnTriggerEnter(Collider other)
    {
        other.transform.position = teleportTargetTransform.position;
    }

}
