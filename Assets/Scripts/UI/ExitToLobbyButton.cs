using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToLobbyButton : MonoBehaviour
{
    public void ExitToLobby()
    {
        SceneController.LoadScene(0);
    }
}
