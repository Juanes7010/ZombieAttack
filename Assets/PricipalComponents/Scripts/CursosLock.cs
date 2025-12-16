using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursosLock : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
