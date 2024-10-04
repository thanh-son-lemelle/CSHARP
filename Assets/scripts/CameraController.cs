using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour{
    [SerializeField] private float speed;

    [SerializeField] private Transform character;
    [SerializeField] private float aheadDist;
    [SerializeField] private float cameraSpeed;
    private float lookAhead; 
    
    private void Update(){
        transform.position = new Vector3(character.position.x + lookAhead, character.position.y, character.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDist * character.localScale.x), Time.deltaTime * cameraSpeed);
    }
}