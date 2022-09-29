using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] RuntimeData _runtimeData;
    [SerializeField] float _mouseSensitivity = 10f;
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] Camera _cam;
    float _currentTilt = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    


    // Update is called once per frame
    void Update()
    {
        Aim();
        if (_runtimeData.CurrentGameplayState == GameplayState.FreeWalk){
            Movement();
        }
    }

    void Aim()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        _currentTilt += mouseY;
        _currentTilt = Mathf.Clamp(_currentTilt, -90, 90);
        _cam.transform.localEulerAngles = new Vector3(_currentTilt, 0, 0);

        transform.Rotate(Vector3.up, mouseX * _mouseSensitivity);
        // _cam.transform.Rotate(Vector3.right, mouseY * _mouseSensitivity);
        
        
    }

    void Movement()
    {
        Vector3 sidewaysMovementVector = transform.right * Input.GetAxis("Horizontal");
        Vector3 forwardBackwardMovementVector = transform.forward * Input.GetAxis("Vertical");
        Vector3 movementVector = sidewaysMovementVector + forwardBackwardMovementVector;
        
        GetComponent<CharacterController>().Move(movementVector * _moveSpeed * Time.deltaTime); 
    }
}
