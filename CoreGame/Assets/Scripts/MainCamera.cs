using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Camera camera;
    public GameObject player;

    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = new Vector3(-2.78f, 1.15f, -1f);

        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -2.5)
            transform.position = initialPosition;
    }

    private void CameraFollow()
    {
        if (player.transform.position.x > initialPosition.x && player.transform.position.x < 3.15)
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }

    private void LateUpdate()
    {
        CameraFollow();
    }
}