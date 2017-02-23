using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBox : MonoBehaviour {

    NetworkData networkData;
    GameObject TouchFish;

    float StartPos;
    float EndPos;

    Camera mainCamera;
    // Use this for initialization
    void Start () {
        networkData = GameObject.Find("NetworkData").GetComponent<NetworkData>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
      
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {        
            StartPos = Input.mousePosition.y;
            foreach(GameObject obj in GameObject.FindGameObjectsWithTag("fish")) {
                //               if (obj.GetComponent<Collider2D>().OverlapPoint(mainCamera.ScreenToWorldPoint(Input.mousePosition)))
                if (obj.GetComponent<Collider2D>().OverlapPoint(Input.mousePosition))
                {
                    TouchFish = obj;
                    Debug.Log(obj.name);
                }
            }
        }
        

        if (Input.GetMouseButtonUp(0))
        {
            

            EndPos =Input.mousePosition.y;
          if (StartPos+3 < EndPos)
            {
                StartCoroutine("OutFish");
                Debug.Log(EndPos);
            }
            StartPos = 0;
            EndPos = 0;
        }
    }

    IEnumerator OutFish()
    {
        if (TouchFish != null)
        {
            Vector3 touchFishPosition = TouchFish.transform.position;
            while (touchFishPosition.y <= 200)
            {
                touchFishPosition.y += 2;
                yield return null;
            }
            Destroy(TouchFish);
        }
    }


}

