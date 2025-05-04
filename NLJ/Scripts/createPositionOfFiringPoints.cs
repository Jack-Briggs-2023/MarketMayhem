using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class createPositionOfFiringPoints : MonoBehaviour
{
    [SerializeField] private bool isOriginal = true;
    [SerializeField] private GameObject positionObject;
    [SerializeField] float xCoord;
    [SerializeField] float yCoord;
    [SerializeField] int loopAmount;
    [SerializeField] GameObject target;
    [SerializeField] CircleMovement circleMovement;
    
    //[SerializeField] Vector3 position;
    //[SerializeField] Vector3 velocity;
    //[SerializeField] private GameObject currentObject;
    GameObject currentObject;
    // Start is called before the first frame update
    void Start()
    {
        if (isOriginal)
        {
            // me
            //currentObject = Instantiate(this.gameObject, (this.gameObject).transform.position, Quaternion.identity);
            ////currentObject = this.gameObject;
            ////Debug.Log("Button is Pressed");
            ////float width = xCoord ;
            //float randNum = UnityEngine.Random.Range(-xCoord, xCoord);
            //currentObject.transform.position = new Vector3(randNum, (float)findSinFunction(randNum), yCoord);
            //Debug.Log(currentObject.transform.position);
            for (int i = 0; i < loopAmount; i++)
            {
                //for (int a = 0; a < 4; a++)
                //{

                //}
                //float angle = i * (360f / loopAmount);  // Evenly spaced around the circle
                //float radians = angle * Mathf.Deg2Rad;

                //float x = xCoord * Mathf.Cos(radians);
                //float z = xCoord * Mathf.Sin(radians);

                //Vector3 spawnPosition = new Vector3(x, yCoord, z);

                //GameObject clone = Instantiate(this.gameObject, spawnPosition, Quaternion.identity);
                //clone.transform.LookAt(target.transform);
                //clone.transform.LookAt(target.transform);
                //clone.GetComponent<createPositionOfFiringPoints>().isOriginal = false;

                //Debug.Log($"Spawned at: {spawnPosition}, angle: {angle}");
                Vector3 position = new Vector3(positionObject.transform.position.x, positionObject.transform.position.y, positionObject.transform.position.z);
                float randNumX = UnityEngine.Random.Range((float)-Math.Sqrt(xCoord), (float)Math.Sqrt(xCoord));
                float randNumY = UnityEngine.Random.Range((yCoord - 1), (yCoord + 1));
                Vector3 vect = new Vector3(position.x + randNumX, position.y + randNumY, position.z + (float)findSinFunction(randNumX));
                GameObject clone = Instantiate(this.gameObject, vect, this.transform.rotation);
                //clone.transform.position = new Vector3(randNumX, randNumY, (float)findSinFunction(randNumX));
                clone.transform.LookAt(target.transform.position);
                clone.GetComponent<createPositionOfFiringPoints>().isOriginal = false;
                //Thread.Sleep(1000);

            //    //firingPointClones
                circleMovement.firingPointClones.Add(clone);
                Debug.Log(clone.transform.position);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //float randNum = UnityEngine.Random.Range(-xCoord, xCoord);
        //currentObject.transform.position = new Vector3(randNum, (float)findSinFunction(randNum), yCoord);
        //Debug.Log(currentObject.transform.position);
    }

    public double findSinFunction(double x)
    {
        Debug.Log(x);
        if ((int) (UnityEngine.Random.Range((float) 0.0, (float) 2.0)) == 1)
        {
            double num = -Math.Sqrt((xCoord - Math.Pow(x, 2.0)));
            Debug.Log(num);
            //if (double.IsNaN(num))
            {
                //findSinFunction(UnityEngine.Random.Range(-xCoord, xCoord));
            }
            return num;
        } else
        {
                double num = Math.Sqrt((xCoord - Math.Pow(x, 2.0)));
                //if (double.IsNaN(num))
                {
                    //findSinFunction(UnityEngine.Random.Range(-xCoord, xCoord));
                }
                Debug.Log(num);
                return num;
            }
        }
}
