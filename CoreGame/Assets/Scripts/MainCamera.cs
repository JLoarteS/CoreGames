using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    //private Camera camera;
    public GameObject player;

    private Vector3 initialPosition;
    private float finalpositionX = 6f;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = new Vector3(-2.78f, 1.15f, -1f);

        //camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -2.5 || player.transform.position.x > 13.3)
            transform.position = initialPosition;
    }

    private void CameraFollow()
    {
        if (player.transform.position.x > initialPosition.x && player.transform.position.x < finalpositionX)
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }

    private void LateUpdate()
    {
        CameraFollow();
    }
}