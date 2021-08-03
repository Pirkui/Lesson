using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerCharacter;


    
    void LateUpdate ()
    {
        transform.position = new Vector3(playerCharacter.position.x, playerCharacter.position.y, transform.position.z);
    }
}
