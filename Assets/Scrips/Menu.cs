using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
}
