using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneTransporter : MonoBehaviour
{
    [SerializeField] private string newSceneName;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(newSceneName);
        }
    }
}
