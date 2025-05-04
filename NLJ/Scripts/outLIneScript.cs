using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outLIneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Material outlineMat = new Material(Shader.Find("Standard"));
        outlineMat.SetColor("_EmissionColor", Color.cyan); // Change color here
        outlineMat.EnableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
