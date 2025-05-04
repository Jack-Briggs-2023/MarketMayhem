using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class colisionScript : MonoBehaviour
{
    [SerializeField] assesmentOfMenu assetMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void calledColision(Collision collision)
    {
        Debug.Log("Colision");
        XRGrabInteractable grab = collision.gameObject.GetComponent<XRGrabInteractable>();
        try //(collision != null && grab != null)
        {
            if (collision != null || grab != null)
            {
                //Debug.Log("Colision extended");
                //collision.gameObject.GetComponent<Renderer>().enabled = false;
                //collision.gameObject.GetComponent<GameObject>().SetActive(false);
                //collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
                //Debug.Log("Collided with: " + collision.gameObject.name);
            } //else if (grab == null) {
                //Destroy(collision.gameObject);
        //}
        }
        catch (System.Exception e)
        {
            Debug.LogError("An error occurred: " + e.Message);
        }
    }

    public void calledInteractionGrab(GameObject gameObject)
    {
        Destroy(gameObject);
        assetMenu.addToLMenuList(gameObject);

    }
//}
    void OnCollisionEnter(Collision collision)
{
        ////    void OnCollisionEnter(Collision collision)
        //    Debug.Log("Pre-colistion");
        calledColision(collision);
        //    //Debug.Log("Colision of Grabables");
        //    XRGrabInteractable grab = collision.gameObject.GetComponent<XRGrabInteractable>();
        //    try //(collision != null && grab != null)
        //    {
        //        if (collision != null && grab != null)
        //        {
        //            Debug.Log("Colision of Grabables extended");
        //            //collision.gameObject.GetComponent<Renderer>().enabled = false;
        //            //collision.gameObject.GetComponent<GameObject>().SetActive(false);
        //            //collision.gameObject.SetActive(false);
        //            Destroy(collision.gameObject);
        //            //Debug.Log("Collided with: " + collision.gameObject.name);
        //        }
        //    }
        //    catch (System.Exception e)
        //    {
        //        Debug.LogError("An error occurred: " + e.Message);
        //    }
        //}

    }
}

//}
//}
