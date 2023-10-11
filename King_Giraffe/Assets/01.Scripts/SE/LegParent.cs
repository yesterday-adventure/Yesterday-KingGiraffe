using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegParent : MonoBehaviour
{
    public bool isHead = false;
    public GameObject parent;

    public bool NinetyEuler()       // 최대 90도까지 움직이게
    {
        Debug.Log(parent.transform.localEulerAngles.z);      // 아 이건 절대값을 받아오니까 사용하지 못하는데

        if (parent.transform.localEulerAngles.z > 90 && parent.transform.localEulerAngles.z < 180)       //90도가 넘었으면
        {
            parent.transform.localEulerAngles = new Vector3(0, 0, 90);
            Debug.Log("90도 이상이 되었음.");
            return false;
        }
        if (parent.transform.localEulerAngles.z > 180 && parent.transform.localEulerAngles.z < 270)     //          180보다 크고 270보다 작고
        {
            parent.transform.localEulerAngles = new Vector3(0, 0, 270);
            Debug.Log("-90도 이상이 되었음");
            return false;
        }

        if ((parent.transform.localEulerAngles.z <= 90 && parent.transform.eulerAngles.z >= 0)        // 90도 보다 작고 0도보다 크고
            || (parent.transform.localEulerAngles.z <= 360 && parent.transform.localEulerAngles.z >= 270))            // 270보다 크고 360보단 작고
            {
            return true;
        }

        return false;
    }
}
