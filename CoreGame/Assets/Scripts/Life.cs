using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Life : MonoBehaviour
{
    public GameObject player;
    private SpriteRenderer[] sprites;

    public int vidas = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();

        for (int i = sprites.Length - 1; i >= vidas; i--)
            sprites[i].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -2.5)
        {
            sprites[--vidas].enabled = false;

            if (vidas == 0)
            {
                Debug.Log("Moristes del todo");

                #if UNITY_EDITOR
                    if (EditorUtility.DisplayDialog("Muerto", "Te has quedado sin vidas, Quieres una vida más?", "Si", "No"))
                    {
                        sprites[vidas++].enabled = true;
                    }
                    else
                        Debug.Break();
                #endif
            }
        }
    }
}
