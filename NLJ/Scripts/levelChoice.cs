using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class levelChoice : MonoBehaviour
{
    [SerializeField] float time = 10;
    // Start is called before the first frame update
    void Start()
    {
        time = time * 1000;
        for (int i = 0; i < time; i++)
        {
            CircleMovement circleMovement = GameObject.Find("NameOfGameObject").GetComponent<CircleMovement>();
            circleMovement.fireObject();
            Thread.Sleep(1000);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
