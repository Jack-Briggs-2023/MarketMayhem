using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public class assesmentOfMenu : MonoBehaviour
{
    //public List<GameObject> baseList;
    //public List<GameObject> collectedMenuList; 
    public Dictionary<GameObject, int> baseList = new Dictionary<GameObject, int>();
    public Dictionary<GameObject, int> collectedMenuList = new Dictionary<GameObject, int>(); 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < baseList.Count; i++)
        //{

        //}
        //int collectedITemAMount = 0;
        //foreach (KeyValuePair<GameObject, int> collectedPair in collectedMenuList)
        //{
        //    if (collectedITemAMount >= baseList.Count)
        //    {
        //        //do something here when we need to end
        //        break;
        //    }
        //    foreach (KeyValuePair<GameObject, int> basePair in baseList)
        //    {
        //        if (collectedPair.Key == basePair.Key)
        //        {
        //            if (collectedPair.Value >= basePair.Value) {
        //                collectedITemAMount++;
        //            }
        //        }

        //    }

        //}
        bool allItemsCollected = true;

        foreach (var basePair in baseList)
        {
            // If the item is missing or not enough collected, we haven't met the goal
            if (!collectedMenuList.ContainsKey(basePair.Key) || collectedMenuList[basePair.Key] < basePair.Value)
            {
                allItemsCollected = false;
                break;
            }
        }

        if (allItemsCollected)
        {
            Debug.Log("All required items collected!");
            // Do something here
        }
    }
    public void addToLMenuList(GameObject collectedItem)
    {

        //foreach (KeyValuePair<GameObject, int> pair in baseList)
        //{
        //    if (baseList.ContainsKey(gameObject))
        //    {
        //        collectedMenuList[gameObject] = pair.Value + 1;
        //    }

        //}
        if (baseList.ContainsKey(collectedItem))
        {
            if (collectedMenuList.ContainsKey(collectedItem))
            {
                collectedMenuList[collectedItem]++;
            }
            else
            {
                collectedMenuList[collectedItem] = 1;
            }
        }
    }
}
