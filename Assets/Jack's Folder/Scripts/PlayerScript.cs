using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class PlayerScript : MonoBehaviour
{
    [SerializeField] private FieldOfView FOV;
    public Transform PlayerTrans;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = UtilsClass.GetMouseWorldPosition();
        Vector3 aimDir = (targetPos ).normalized;
        FOV.SetAimDirection(aimDir);
        FOV.SetOrigin(transform.position);
        Debug.Log(targetPos);
    }
}
