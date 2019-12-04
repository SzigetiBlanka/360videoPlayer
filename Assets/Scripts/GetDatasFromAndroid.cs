using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDatasFromAndroid : MonoBehaviour
{
  public Text TextBoxText;
  bool hasVideoUrlExtra = false;
  public AndroidJavaObject extras;

  public string[] videoUrls = new string[10];

  public AndroidJavaObject intent;
  // Start is called before the first frame update
  void Start()
    {
    AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

    AndroidJavaObject intent = currentActivity.Call<AndroidJavaObject>("getIntent");
    bool hasVideoUrlNumExtra = intent.Call<bool>("hasExtra","videoUrlsNum");
    bool hasVideoUrlExtra = intent.Call<bool>("hasExtra","videoUrls");
    if(hasVideoUrlNumExtra) {
      AndroidJavaObject extras = intent.Call<AndroidJavaObject>("getExtras");
      int videourlnumber = extras.Call<int>("getInt","videoUrlsNum");
      Debug.Log("android urls number: " + videourlnumber);
      TextBoxText.text += videourlnumber + "\n";

      if(hasVideoUrlExtra) {
        extras = intent.Call<AndroidJavaObject>("getExtras");
        for(int i = 0; i < videourlnumber; i++) {
          string videourl = extras.Call<string>("getString","videoUrls"+i);
          Debug.Log("android url: " + videourl);
          TextBoxText.text += videourl + "\n";
        }
        
      }
    }

    

  }
}
