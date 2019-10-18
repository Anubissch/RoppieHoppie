using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject partprefab, parentObject;

    [SerializeField]
    [Range(2, 1000)]
    int NumberOfParts = 1;

    [SerializeField]
    float partDistance = 0.21f;

    [SerializeField]
    bool reset, spawn /*, snapilk, snapson*/;
    

    
    void Update()
    {
        if (reset)
        {
            foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Player"))
            {
                Destroy(tmp);

            }
        }

        if (spawn)
        {
            Spawn();
            spawn = false;
        }
    }

    public void Spawn()
    {

        int miktar = (int)(NumberOfParts);
        for (int i = 0; i < miktar; i++)
        {
            GameObject tmp;
            tmp = Instantiate(partprefab, new Vector3(transform.position.x, transform.position.y + partDistance* (i + 1), transform.position.z), Quaternion.identity, parentObject.transform);
            tmp.transform.eulerAngles = new Vector3(180, 0, 0);
            tmp.name = parentObject.transform.childCount.ToString();



            if (i == 0)
            {
                Destroy(tmp.GetComponent<CharacterJoint>());
                tmp.GetComponent<Movement>().enabled = true;
            }
    
                else
            { tmp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            

            }


            //  if (snapilk)
            //    { tmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; } 

            /*  if (snapson)
              { parentObject.transform.Find((parentObject.transform.childCount).ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; }*/
        }

    }
}
