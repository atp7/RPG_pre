using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
    ThirdPersonCharacter m_Character;   // android chovecheto
    bool flagche;
    //bool flag1;
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;
    //distance to enemy ...
    const float walkStop = 0.01f;
    Vector3 clickPoint;

    private void Start()
    {
        flagche = true;
        //flag1 = true;
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        //eathen is that you ?? 
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }

    // syncing with physics
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            clickPoint = cameraRaycaster.hit.point;
            //print("pechat raycast hit :@" + cameraRaycaster.hit.collider);
            print("pechat raycast hit!!!!!!!!" + cameraRaycaster.layerHit);
            //var a = cameraRaycaster; // break
            //if (cameraRaycaster.layerHit)
            //{
            //    if ((int)Layer.Walkable == Layer.Walkable)
            //    {
            //        currentClickTarget = cameraRaycaster.hit.point;
            //    }
            //    else if ((int)Layer.Enemy == Layer.Enemy) break;
            //}
            //currentClickTarget = cameraRaycaster.hit.point;  
            switch (cameraRaycaster.layerHit)
            {
                case Layer.Walkable:
                    currentClickTarget = clickPoint; break;
                case Layer.Enemy:
                    break;
            }
        }
        //offset-a 
        m_Character.Move(currentClickTarget - transform.position, false, false);
    }
    private void Update()
    {
       // DrawGizmo();
    }

    void OnDrawGizmo()
    { 
        Gizmos.DrawLine(transform.position, currentClickTarget);
        Gizmos.DrawSphere(currentClickTarget, 0.1f);
    }
}

