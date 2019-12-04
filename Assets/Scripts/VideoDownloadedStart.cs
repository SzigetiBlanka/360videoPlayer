using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoDownloadedStart : MonoBehaviour
{

  public GameObject VideoPlayerGO;
  VideoPlayer videoPlayer;
    
    void Awake() {
    videoPlayer = VideoPlayerGO.GetComponent<VideoPlayer>();
  }
  void Start() {
    PlayVideo("videoFile.mp4");
  }
  void PlayVideo(string fileName) {
    videoPlayer.url = Application.persistentDataPath + fileName;
    Debug.Log("Videoplayer.url: " + videoPlayer.url);
    videoPlayer.Play();
  }
}
