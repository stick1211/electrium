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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = new RaycastHit2D();
            hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction,600,8);
            if (hit.collider)
            {
                TouchFish = hit.collider.gameObject;
                Debug.Log(hit.collider.gameObject.name);
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
                touchFishPosition.y += 10;
                yield return null;
            }
            Destroy(TouchFish);
        }
    }


}

