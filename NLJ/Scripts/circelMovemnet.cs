using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;



public class CircleMovement : MonoBehaviour
{
    [SerializeField] private GameObject firingPoint;
    [SerializeField] private GameObject[] firingPoints;
    public List<GameObject> firingPointClones;
    //[SerializeField] private GameObject projectile;
    [SerializeField] float shootingForce;
    [SerializeField] private GameObject[] foodObjects;
    [SerializeField] private float destructionCoord = 100;
    //[SerializeField] private int timePerFire = 50;
    //[SerializeField] public int foodCount = 5;
    //[SerializeField] private XRGrabInteractable grabInteractable;
    [SerializeField] public int maxObjects = 50;
    //[SerializeField] public XRController controller;
    [SerializeField] GameObject handR;
    [SerializeField] GameObject handL;
    [SerializeField] assesmentOfMenu menuScript;
    [SerializeField] colisionScript ColisionScript;
    private XRBaseInputInteractor controller;
    //float currentTime = 0;
    List<GameObject> netFoodObjects = new List<GameObject>();
    public float spawnInterval;  // Time between spawns
    private float timeSinceLastSpawn = 0f;
    private int currentObjectCount = 0;
    public bool start = false;
    //Gamepad gamepad = Gamepad.current;
    //GameObject[] netFoodObjects;
    //GameObject projectileClone;
    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < foodCount; i++)
        {
            //fireObject(randNum(foodObjects.Length), 0);
            //Thread.Sleep(timePerFire * 1000);

        }
        //timePerFire = timePerFire * 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {

            if (currentObjectCount < maxObjects)
            {

                timeSinceLastSpawn += Time.deltaTime;

                if (timeSinceLastSpawn >= spawnInterval)
                {
                    Debug.Log(foodObjects.Length);
                    Debug.Log("asdfasdf");
                    fireObject(randNum(foodObjects.Length - 1), randNum(firingPointClones.Count - 1));
                    //fireObject(randNum(foodObjects.Length), 0);  
                    timeSinceLastSpawn = 0f;
                }
                //Debug.Log(Time.deltaTime);
                //if (Input.GetButtonDown("Trigger"))
            }
        }
        //if (Time.deltaTime >= currentTime + 0.05)
        //{
        //Debug.Log("Button is Pressed");
        //for (int i = 0; i < firingPoints.Length; i++)
        //{

        //    //if (randNum(1) == 1)
        //    {

        //        fireObject(randNum(foodObjects.Length), randNum(firingPoints.Length));
        //    }
        //    //Thread.Sleep(timePerFire * 1000);
        //}

        //currentTime = Time.deltaTime;
        //}
        //we need to shoot a cannonball
        foreach (XRGrabInteractable grab in FindObjectsOfType<XRGrabInteractable>())
        {
            if (grab.isSelected)
            {
                Debug.Log(grab.gameObject.name + " is being grabbed.");
                grab.gameObject.GetComponent<Renderer>().enabled = false;
                grab.gameObject.GetComponent<GameObject>().SetActive(false);
                //if (gamepad != null)
                //{
                //    gamepad.SetMotorSpeeds(0.5f, 0.5f); // Left motor at 50%, Right motor at 25%
                //                                        //controller.SendHapticImpulse(50.0f, 50.0f);
                //}
            }
        }
        for (int i = 0; i < netFoodObjects.Count; i++)
        {
            //XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();

            //grabInteractable.selectEntered.AddListener(OnGrab);
            //grabInteractable.selectExited.AddListener(OnRelease);
            if (netFoodObjects[i] != null)
            {
                if ((netFoodObjects[i] != null) && (netFoodObjects[i].transform.position.x > destructionCoord || netFoodObjects[i].transform.position.y > destructionCoord || netFoodObjects[i].transform.position.z > destructionCoord))
                {
                    DestroyImmediate(netFoodObjects[i]);
                    controller = GetComponent<XRBaseInputInteractor>();
                    if (controller != null)
                    {
                        controller.SendHapticImpulse(1.0f, 100.0f);
                    }
                    else
                    {
                        Debug.LogWarning("Haptic controller is missing.");
                    }
                    //handR.GetComponent<VibrateController>().ActivateHaptics(1.0f, Time.deltaTime);
                    //if (gamepad != null)
                    {
                        // Rumble the motors
                        //gamepad.SetMotorSpeeds(0.5f, 0.5f); // Left motor at 50%, Right motor at 25%
                        //controller.SendHapticImpulse(50.0f, 50.0f);

                        // Optionally, stop the rumble after a delay (e.g., 2 seconds)
                        //Invoke("StopRumble", 10);
                    }
                }
                //if ((netFoodObjects[i] != null) && (netFoodObjects[i].transform.position.x < -destructionCoord || netFoodObjects[i].transform.position.y < -destructionCoord || netFoodObjects[i].transform.position.z < -destructionCoord))
                //{
                //    DestroyImmediate(netFoodObjects[i]);
                //    controller = GetComponent<XRBaseInputInteractor>();
                //    if (controller != null)
                //    {
                //        Debug.Log("Haptics should be working");
                //        controller.SendHapticImpulse(1.0f, 100.0f);
                //    }
                //    else
                //    {
                //        Debug.LogWarning("Haptic controller is missing.");
                //    }
                    //if (gamepad != null)
                    //{
                        // Rumble the motors
                        //gamepad.SetMotorSpeeds(0.5f, 0.5f); // Left motor at 50%, Right motor at 25%

                        // Optionally, stop the rumble after a delay (e.g., 2 seconds)
                        //Invoke("StopRumble", 2);
                    //}
                //}
            }
        }
    }

    public void fireObject()
    {
        int numForFood = randNum(foodObjects.Length); int numForFiring = randNum(firingPoints.Length);
        if (foodObjects[numForFood] != null)
        {
            //GameObject projectileClone = Instantiate(projectile, firingPoint.transform.position, Quaternion.identity); firingPoints[numForFiring]
            GameObject projectileClone = Instantiate(foodObjects[numForFood], firingPoints[numForFiring].transform.position, Quaternion.identity);
            Rigidbody projectileRB = projectileClone.GetComponent<Rigidbody>(); //get the rigid body
            projectileRB.AddForce(firingPoints[numForFiring].transform.forward * shootingForce, ForceMode.Impulse);
            netFoodObjects.Add(projectileClone);
            Debug.Log("thing is shot");
            //GameObject projectileClone = Instantiate(foodObjects[randNum(foodObjects.Length)], firingPoint.transform.position, Quaternion.identity);
            //Rigidbody projectileRB = foodObjects[randNum(foodObjects.Length)].GetComponent<Rigidbody>(); //get the rigid body
            //projectileRB.AddForce(firingPoint.transform.forward * shootingForce, ForceMode.Impulse);
        }
    }
    public void fireObject(int numForFood, int numForFiring)
    {
        Debug.Log($"numForFood: {numForFood}| numForFiring: {numForFiring}|  foodObjects: {foodObjects.Length}| firingPointClones: {firingPointClones.Count}");
        if ((foodObjects[numForFood] != null))// && (firingPointClones[numForFiring].activeInHierarchy))
        {
            //GameObject projectileClone = Instantiate(projectile, firingPoint.transform.position, Quaternion.identity); firingPointClones[numForFiring]
            GameObject projectileClone = Instantiate(foodObjects[numForFood], firingPointClones[numForFiring].transform.position, Quaternion.identity);
            Rigidbody projectileRB = projectileClone.GetComponent<Rigidbody>(); //get the rigid body
            projectileRB.AddForce(firingPointClones[numForFiring].transform.forward * shootingForce, ForceMode.Impulse);
            netFoodObjects.Add(projectileClone);
            Debug.Log("thing is shot");
            //GameObject projectileClone = Instantiate(foodObjects[randNum(foodObjects.Length)], firingPoint.transform.position, Quaternion.identity);
            //Rigidbody projectileRB = foodObjects[randNum(foodObjects.Length)].GetComponent<Rigidbody>(); //get the rigid body
            //projectileRB.AddForce(firingPoint.transform.forward * shootingForce, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("thing tried to be shot");
        }
    }
    public int randNum(float upper)
    {
        return (int)Random.Range(0, upper);
    }
    //void StopRumble()
    //{
    //    // Stop the rumble by setting both motor speeds to 0
    //    Gamepad.current.SetMotorSpeeds(0, 0);
    //}
    void OnGrab(SelectEnterEventArgs args)
    {
        controller = GetComponent<XRBaseInputInteractor>();
        if (controller != null)
        {
            Debug.Log("Haptics should be working with a grab");
            controller.SendHapticImpulse(1.0f, 100.0f);
        }
        else
        {
            Debug.LogWarning("Haptic controller is missing.");
        }
        ColisionScript.calledInteractionGrab(this.gameObject);
        //isBeingGrabbed = true;
    }

    //void OnRelease(SelectExitEventArgs args)
    //{
    //    //isBeingGrabbed = false;

    //}
    //void OnCollisionEnter(Collision collision)
    //{
        //Debug.Log("Pre-colistion");
        ////ColisionScript.calledColision(collision);
        ////Debug.Log("Colision of Grabables");
        //XRGrabInteractable grab = collision.gameObject.GetComponent<XRGrabInteractable>();
        //try //(collision != null && grab != null)
        //{
        //    if (collision != null && grab != null)
        //    {
        //        Debug.Log("Colision of Grabables extended");
        //        //collision.gameObject.GetComponent<Renderer>().enabled = false;
        //        //collision.gameObject.GetComponent<GameObject>().SetActive(false);
        //        //collision.gameObject.SetActive(false);
        //        Destroy(collision.gameObject);
        //        //Debug.Log("Collided with: " + collision.gameObject.name);
        //    }
        //}
        //catch (System.Exception e)
        //{
        //    Debug.LogError("An error occurred: " + e.Message);
        //}
        //}

    //}
}
