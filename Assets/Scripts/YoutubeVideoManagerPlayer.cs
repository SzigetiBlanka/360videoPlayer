using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using YoutubeExtractor;
using UnityEngine.Video;
using System.IO;

public class YoutubeVideoManagerPlayer : MonoBehaviour
{
  public string url;
  public int quality;
  public static MediaPlayerCtrl mediaPlayerCtrl;
  private VideoPlayer videoPlayer;

  public bool videoSaved;

  private string localUrl;
  private string videoName;

    // Start is called before the first frame update
    void Start()
    {
    videoPlayer = GetComponent<VideoPlayer>();
    videoName = ReplaceVideoName();
    localUrl = Application.persistentDataPath + "/" + videoName + ".mp4";
    videoSaved = false;
    run();
    }

  private string ReplaceVideoName() {
    string result=null;
    if(url != null || url != "") {
       result = url;
      result = result.Replace('/','_');
      result = result.Replace('\\','_');
      result = result.Replace(':','_');
      result = result.Replace('.','_');
      result = result.Replace('?','_');
    }
    return result;
  }

  public async void run() {
    IEnumerable<VideoInfo> videoInfos = await DownloadUrlResolver.GetDownloadUrlsAsync(url);
    VideoInfo video = videoInfos.First(info => info.VideoType == VideoType.Mp4 && info.Resolution == quality);

    if(video.RequiresDecryption) {
      DownloadUrlResolver.DecryptDownloadUrl(video);
    }
    MediaPlayerCtrl mediaPlayerCtrl = GetComponent<MediaPlayerCtrl>();
    mediaPlayerCtrl.m_strFileName = video.DownloadUrl;
    Debug.Log(mediaPlayerCtrl.m_strFileName);
    Debug.Log("File exist: " + FileChk());
    if(!FileChk()) {
      StartCoroutine(testVideoDownload(mediaPlayerCtrl.m_strFileName));
    } else {
      videoSaved = true;
    }
  }

  public void Stop() {
    videoPlayer.Stop();
  }

  public void Pause() {
    videoPlayer.Pause();
  }
  public void Play() {
    videoPlayer.Play();
  }

  public bool FileChk() {
    string filePath = localUrl;

    if(System.IO.File.Exists(filePath)) {
      return true;
    } else {
      return false;
    }
  }


    IEnumerator testVideoDownload(string url) {
    Debug.Log("url: " + url);
    var www = new WWW(url);
    Debug.Log("Downloading!");
    
    while(!www.isDone) {
      if((www.progress * 100) % 10 == 0) {
        Debug.Log("downloaded " + (((int)www.progress) * 100).ToString() + "%...");
      }
      yield return null;
    }
    yield return www;
    File.WriteAllBytes(Application.persistentDataPath + "/" + videoName + ".mp4",www.bytes);
    /*if(string.IsNullOrEmpty(www.error)) {
      var filebytes = www.bytes;
      System.IO.MemoryStream stream = new System.IO.MemoryStream(filebytes);
    } else {
      Debug.Log(string.Format("An error occurred while downloading the file: {0}",www.error));
    }*/
    Debug.Log("File Saved! ");

    //UrlToVideo(localUrl);
    videoSaved = true;
  }

  public void UrlToVideo() {
    UrlToVideo(localUrl);
  }

  public void UrlToVideo(string url) {
    Debug.Log("Bejutottam");
    videoPlayer.source = VideoSource.Url;
    videoPlayer.url = url;
    Debug.Log(url);
    videoPlayer.Prepare();
    videoPlayer.prepareCompleted += VideoPlayer_prepareCompleted;
  }

  private void VideoPlayer_prepareCompleted(VideoPlayer source) {
    Debug.Log("mindjárt indul");
    Play();
  }
}
