using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTower : MonoBehaviour
{
    public CinemachineFreeLook FlCam;
    public float speedRotation = 5;
    public GameObject tower;
    public GameObject primaryPart;
    float currentXValue;
    float oldXValue;
    // Start is called before the first frame update
    void Start()
    {
        currentXValue = FlCam.m_XAxis.Value;
        oldXValue = currentXValue;
     //tower.transform.RotateAround(primaryPart.transform.position, Vector3.up, 90);
    }

    // Update is called once per frame
    void Update()
    {
        currentXValue = FlCam.m_XAxis.Value;

        /* if (oldXValue != currentXValue)
         {
             //tower.transform.RotateAround(primaryPart.transform.position, Vector3.up, currentXValue - oldXValue);
             oldXValue = currentXValue;
         }*/


        float angle = FlCam.m_XAxis.Value - tower.transform.rotation.y;


       Quaternion towerR   = Quaternion.Lerp(tower.transform.rotation, Quaternion.AngleAxis(angle, tower.transform.up), 0.001f); ;
        tower.transform.localRotation = towerR;

        // primaryPart.transform.rotation=tower.transform.rotation;
    }
}
