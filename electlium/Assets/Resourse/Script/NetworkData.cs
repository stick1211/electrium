using UnityEngine;
using System.Collections;

public class NetworkData : Photon.MonoBehaviour{


    public string spriteName = "";

    void Start()
    {
      
    }

	public void Init(string name){
		this.name = name;
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.isWriting)
            {                
                stream.SendNext(spriteName);
              
            }
            else
            {
                spriteName = (string)stream.ReceiveNext();          
            }
     }
    
}
