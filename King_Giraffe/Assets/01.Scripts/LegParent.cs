using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegParent : MonoBehaviour
{
    public bool isHead = false;
    public GameObject parent;

    public bool NinetyEuler()       // �ִ� 90������ �����̰�
    {
        Debug.Log(parent.transform.localEulerAngles.z);      // �� �̰� ���밪�� �޾ƿ��ϱ� ������� ���ϴµ�

        if (parent.transform.localEulerAngles.z > 90 && parent.transform.localEulerAngles.z < 180)       //90���� �Ѿ�����
        {
            parent.transform.localEulerAngles = new Vector3(0, 0, 90);
            Debug.Log("90�� �̻��� �Ǿ���.");
            return false;
        }
        if (parent.transform.localEulerAngles.z > 180 && parent.transform.localEulerAngles.z < 270)     //          180���� ũ�� 270���� �۰�
        {
            parent.transform.localEulerAngles = new Vector3(0, 0, 270);
            Debug.Log("-90�� �̻��� �Ǿ���");
            return false;
        }

        if ((parent.transform.localEulerAngles.z <= 90 && parent.transform.eulerAngles.z >= 0)        // 90�� ���� �۰� 0������ ũ��
            || (parent.transform.localEulerAngles.z <= 360 && parent.transform.localEulerAngles.z >= 270))            // 270���� ũ�� 360���� �۰�
            {
            return true;
        }

        return false;
    }
}
