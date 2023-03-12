using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class VideoCtrl : MonoBehaviour
{
    public Button btn_Play;
    public Button btn_Pause;
    public Button bnt_Replay;

    public VideoPlayer video;
    // Start is called before the first frame update
    void Start()
    {
        btn_Play.onClick.AddListener(Play);
         btn_Pause.onClick.AddListener(Pause);
          bnt_Replay.onClick.AddListener(RePlay);
          Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
//
     public void Play()
    {
        video.Play();
        btn_Pause.gameObject.SetActive(true);
         btn_Play.gameObject.SetActive(false);
    }
    //
    public void Pause(){
        video.Pause();
         btn_Pause.gameObject.SetActive(false);
         btn_Play.gameObject.SetActive(true);
    }
//
    public void RePlay(){
        video.Stop();
        Play();

    }
}