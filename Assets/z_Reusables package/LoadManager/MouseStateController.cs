using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseStateController : MonoBehaviour
{
    [SerializeField] private GameObject PauseScreen;
    [SerializeField] private GameObject OptionsScreen;

    [SerializeField] private bool isCursorLocked;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) || PauseScreen.activeInHierarchy || OptionsScreen.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = !Cursor.visible;
        }
        //else if (Input.GetKeyUp(KeyCode.LeftAlt))
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = false;
        //}

    }
}
