using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class HandleAdVideoBehavior : MonoBehaviour
{
    [SerializeField] GameObject ShowHideGO;
    [SerializeField] VideoPlayer videoPlayer;

    [SerializeField] UnityEvent action;
    void OnEnable()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnDisable()
    {
        videoPlayer.loopPointReached -= OnVideoEnd;
    }
    
    void OnVideoEnd(VideoPlayer vp)
    {
        action.Invoke();
        ShowHideGO.SetActive(false);
    }
}
