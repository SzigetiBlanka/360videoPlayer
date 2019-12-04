using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitMeasurement : MonoBehaviour
{
  public void QuitGame() {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    Debug.Log("Measurement is exiting");
  }
}
