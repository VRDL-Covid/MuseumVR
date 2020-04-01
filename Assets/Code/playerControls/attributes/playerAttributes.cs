using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttributes : MonoBehaviour {

    public enum enmplayerType
    {
        genericVR,genericFlatscreen
    };

    public enmplayerType playerType = new enmplayerType();


    public GameObject playerObj;

    public void SpawnPlayer(enmplayerType type, GameObject prefab)
    {
        SpawnPlayer((int)type, prefab);
    }
    public void SpawnPlayer(int playerType, GameObject prefab)
    {
        this.playerType = (enmplayerType)playerType;
        this.playerObj = Instantiate(prefab);

        return;
    }


}
