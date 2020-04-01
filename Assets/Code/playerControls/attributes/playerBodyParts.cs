using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBodyParts : MonoBehaviour {

    private GameObject PHead;
    private GameObject PLHand;
    private GameObject PRHand;
    public class part
    {
        public GameObject partObj;
        public Quaternion rotation;
        public Vector3 position;
        public Quaternion oldRotation;
        public Vector3 oldPosition;

        public part(GameObject _part)
        {
            this.partObj = _part;
            this.rotation = _part.transform.rotation;
            this.position = _part.transform.position;
        }

        public bool HasMoved
        {
            get
            {
                bool hasMoved = oldPosition != position || oldRotation != rotation;
                return hasMoved;
            }
        }


        public string serialisePart()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", position.x, position.y, position.z, rotation.x, rotation.y, rotation.z, rotation.w);
        }
    }

    public part Head = null;
    public part LHand = null;
    public part RHand = null;

    public void SetNewVectors()
    {
        Head.oldRotation = Head.rotation;
        LHand.oldRotation = LHand.rotation;
        RHand.oldRotation = RHand.rotation;
        Head.oldPosition = Head.position;
        LHand.oldPosition = LHand.position;
        RHand.oldPosition = RHand.position;

        Head.rotation = PHead.transform.rotation;
        Head.position = PHead.transform.position;
        LHand.rotation = PLHand.transform.rotation;
        LHand.position = PLHand.transform.position;
        RHand.rotation = PRHand.transform.rotation;
        RHand.position = PRHand.transform.position;
    }

    public void UpdateAllVectors()
    {


        Head.rotation = PHead.transform.rotation;
        Head.position = PHead.transform.position;
        LHand.rotation = PLHand.transform.rotation;
        LHand.position = PLHand.transform.position;
        RHand.rotation = PRHand.transform.rotation;
        RHand.position = PRHand.transform.position;

        Head.oldRotation = Head.rotation;
        LHand.oldRotation = LHand.rotation;
        RHand.oldRotation = RHand.rotation;
        Head.oldPosition = Head.position;
        LHand.oldPosition = LHand.position;
        RHand.oldPosition = RHand.position;
    }

    public playerBodyParts(Transform VRTransfrom)
    {


        PHead = VRTransfrom.Find("Camera").gameObject;
        PLHand = VRTransfrom.Find("Controller (left)").gameObject;
        PRHand = VRTransfrom.Find("Controller (right)").gameObject;

        Head = new part(PHead);
        LHand = new part(PLHand);
        RHand = new part(PRHand);
    }

    public bool HasMoved
    {
        get
        {
            return Head.HasMoved || LHand.HasMoved || RHand.HasMoved;
        }
    }


    public string serialisePlayer()
    {
        return string.Format("{0}|{1}|{2}", Head.serialisePart(), LHand.serialisePart(), RHand.serialisePart());
    }

    public void deserialisePlayer(string input)
    {
        string[] data = input.Split('|');

        Head.partObj.transform.position = new Vector3(float.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3]));
        Head.partObj.transform.rotation = new Quaternion(float.Parse(data[4]), float.Parse(data[5]), float.Parse(data[6]), float.Parse(data[7]));

        LHand.partObj.transform.position = new Vector3(float.Parse(data[8]), float.Parse(data[9]), float.Parse(data[10]));
        LHand.partObj.transform.rotation = new Quaternion(float.Parse(data[11]), float.Parse(data[12]), float.Parse(data[13]), float.Parse(data[14]));

        RHand.partObj.transform.position = new Vector3(float.Parse(data[15]), float.Parse(data[16]), float.Parse(data[17]));
        RHand.partObj.transform.rotation = new Quaternion(float.Parse(data[18]), float.Parse(data[19]), float.Parse(data[20]), float.Parse(data[21]));

        this.UpdateAllVectors();

    }


}
