using UnityEngine;
using System.Collections;

[RequireComponent(typeof (BoxCollider))]
public class ButtonPlatformController : MonoBehaviour {

    Collider col;

    [SerializeField]
    GameObject Platform;
    [SerializeField]
    float PlatformMovementTime;

    //Has To Have At least 2 if it is multi [The firt being always at the original position]
    [SerializeField][Tooltip ("Must Have at least 2 Transforms if single mode has not been choosen")]
    Transform[] platformTargetTransforms;

    private bool locked;


    public enum ButtonMode {Single, MultiThenRestart, MultiThenReverse }

    [SerializeField] ButtonMode mode;
    int direction = 1;
    int nextTransform = 0;

    // Use this for initialization
    void Start ()
    {
        col = GetComponent<Collider>();
        col.isTrigger = true;
	}
	

    void OnTriggerEnter(Collider other)
    {
        if (!locked)
        {
            StartCoroutine(MoveOverSeconds(Platform, platformTargetTransforms[nextTransform].position, PlatformMovementTime));
            if (nextTransform + direction >= platformTargetTransforms.Length)
            {
                if (mode == ButtonMode.Single)
                {
                    direction = 0;
                }
                else if (mode == ButtonMode.MultiThenRestart)
                {
                    nextTransform = -1;
                }
                else if (mode == ButtonMode.MultiThenReverse)
                {
                    direction = -1;
                }
            }
            else if (nextTransform + direction < 0)
            {
                nextTransform = 0;
                direction = 1;
            }

            nextTransform += direction;
        }
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        locked = true;
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
        locked = false;
    }
}
