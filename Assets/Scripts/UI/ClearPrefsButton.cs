using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPrefsButton : MonoBehaviour
{
    public void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
