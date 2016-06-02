using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class playerController : NetworkBehaviour
{
    public GameObject playerSphere;
    public GameObject playerCube;
    public float speed = 1;
    public float jumpenergy = 1;
    public float camspeed = 100;

    [SyncVar]
    GameObject body;
    Rigidbody rb;

    [SyncVar]
    Vector3 pos;
    Vector3 velocity;

    BodyType bodyType;
    Camera cam;

    enum BodyType
    {
        sphere,
        cube
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        if (!isLocalPlayer)
        {
            enabled = false;
            return;
        }

        pos = new Vector3();
        velocity = new Vector3();

        CmdSpawnSphere();        

        if (Camera.main != null)
            cam = Camera.main;

        cam.transform.position = new Vector3(0.0f, 0.0f, -7.5f);
        cam.transform.LookAt(transform);
        cam.transform.SetParent(transform);
        transform.rotation = Quaternion.Euler(25, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

    void Update()
    {
        if (!isLocalPlayer || body == null || rb == null)
            return;

        float x = transform.localEulerAngles.x + Input.GetAxis("Mouse Y") * camspeed * Time.deltaTime;
        float y = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * camspeed * Time.deltaTime;
        if (x > 60) x = 60;
        else if (x < 15) x = 15;

        if (Input.GetMouseButton(1))
            transform.rotation = Quaternion.Euler(x, y, transform.localEulerAngles.z);

        transform.position = body.transform.position;
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer || body == null)
            return;

        if (rb == null)
        {
            rb = body.GetComponent<Rigidbody>();
            rb.velocity = velocity * 0.5f;
            rb.position = pos;
        }

        if (rb.transform.position.y < -15)
        {
            rb.velocity = Vector3.zero;
            rb.transform.position = Vector3.zero;
            return;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            switch (bodyType)
            {
                case BodyType.sphere:
                    {
                        pos = body.transform.position;
                        velocity = rb.velocity;
                        CmdDestroyBody();
                        CmdSpawnCube();
                        bodyType = BodyType.cube;
                        rb = null;
                        return;
                    }
                case BodyType.cube:
                    {
                        pos = body.transform.position;
                        velocity = rb.velocity;
                        CmdDestroyBody();
                        CmdSpawnSphere();
                        bodyType = BodyType.sphere;
                        rb = null;
                        return;
                    }
                default:
                    break;
            }
        }

        switch (bodyType)
        {
            case BodyType.sphere:
                {

                    float moveUpwards = 0.0f;

                    if (Input.GetKey(KeyCode.Space) && Physics.Raycast(body.transform.position, Vector3.down, 0.75f))
                    {
                        moveUpwards = 50.0f * jumpenergy * Time.deltaTime;
                    }

                    Vector3 movement = Input.GetAxis("Horizontal") * speed * Time.deltaTime * transform.right;
                    movement += Input.GetAxis("Vertical") * speed * Time.deltaTime * transform.forward;
                    movement += new Vector3(0.0f, moveUpwards, 0.0f);

                    rb.AddForce(movement);
                    break;
                }
            default:
                break;
        }

        transform.position = body.transform.position;
    }

    [Command]
    void CmdDestroyBody()
    {
        GameObject obj = gameObject.GetComponent<playerController>().body;
        NetworkServer.Destroy(obj);
    }

    [Command]
    void CmdSpawnSphere()
    {
        var obj = (GameObject)Instantiate(playerSphere, pos, Quaternion.identity);

        NetworkServer.SpawnWithClientAuthority(obj, connectionToClient);

        gameObject.GetComponent<playerController>().body = obj;
    }

    [Command]
    void CmdSpawnCube()
    {
        var obj = (GameObject)Instantiate(playerCube, pos, Quaternion.identity);

        NetworkServer.SpawnWithClientAuthority(obj, connectionToClient);

        gameObject.GetComponent<playerController>().body = obj;
    }
}
