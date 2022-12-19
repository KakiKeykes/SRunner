using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

static class SceneController
{
    public static void LoadScene(int _sceneNomber)
    {
        SceneManager.LoadScene(_sceneNomber);
    }
}

