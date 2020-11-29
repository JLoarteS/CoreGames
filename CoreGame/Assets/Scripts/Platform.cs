using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public List<GameObject> prefabs;
    private int prefab;
    private GameObject platform;
    public static bool hasChangedPosition;

    // Start is called before the first frame update
    void Start()
    {
        ChangePlatform();

        hasChangedPosition = false;
        //player = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasChangedPosition)
        {
            ChangePlatform();
            hasChangedPosition = false;
            Debug.Log("Se han cambiado las plataforma");
        }
        
    }

    private void ChangePlatform()
    {
        prefab = getRandom();
        Destroy(platform);
        platform = Instantiate(prefabs[prefab], new Vector3(1.11f, -2.25f, 1f), Quaternion.identity, transform);
    }

    private int getRandom()
    {
        System.Random rnd = new System.Random();
        return rnd.Next(0, prefabs.Count);
    }
}
