using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    [SerializeField]
    private float sensivity;
    float mouseX, mouseY;

    Vector3 objRot;
    public Transform characterBody;

    CharacterControl characterHp;

    public bool locked = true;

    void Start()
    {
        characterHp = GameObject.Find("SWAT").GetComponent<CharacterControl>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (characterHp.Live() == false)
        {
            if (locked == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                locked = true;
            }

            else
            {
                Cursor.lockState = CursorLockMode.None;
                locked = false;
            }
        }

        if (characterHp.Live() == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (locked == false)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    locked = true;
                }

                else
                {
                    Cursor.lockState = CursorLockMode.None;
                    locked = false;
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (characterHp.Live() == true)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, target.position + offset, Time.deltaTime * 10);
            mouseX += Input.GetAxis("Mouse X") * sensivity;
            mouseY += Input.GetAxis("Mouse Y") * sensivity;

            if (mouseY >= 20)
            {
                mouseY = 20;
            }

            if (mouseY <= -30)
            {
                mouseY = -30;
            }

            this.transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
            target.transform.eulerAngles = new Vector3(0, mouseX, 0);

            Vector3 temporary = this.transform.eulerAngles;
            temporary = this.transform.eulerAngles;
            temporary.z = 0;
            temporary.y = this.transform.localEulerAngles.y;
            temporary.x = this.transform.localEulerAngles.x + 10;
            objRot = temporary;
            characterBody.transform.eulerAngles = objRot;
        }
    }
}
