using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class VideoCtrl : MonoBehaviour
{
    public Button btn_Play;
    public Button btn_Pause;
    public Button bnt_Replay;
    public Button bnt_Close;

    public VideoPlayer video;
    // Start is called before the first frame update
    void Start()
    {
        btn_Play.onClick.AddListener(Play);
        btn_Pause.onClick.AddListener(Pause);
        bnt_Replay.onClick.AddListener(RePlay);
        bnt_Close.onClick.AddListener(Close);
        Play();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
     /*Description
      * void Play() method allows the user to play the video lesson
      */
     public void Play()
    {
        video.Play();
        btn_Pause.gameObject.SetActive(true);
        btn_Play.gameObject.SetActive(false);
    }
    /*Description
    * void Pause() method allows the user to pause the video lesson
    */
    public void Pause(){
        video.Pause();
        btn_Pause.gameObject.SetActive(false);
        btn_Play.gameObject.SetActive(true);
    }
    /*Description
     * void RePlay() method allows the user to replay the video lesson
    */
    public void RePlay(){
        video.Stop();
        Play();
    }
    public void Close()
    {
        SceneManager.LoadScene("MainMenu");
    }
}