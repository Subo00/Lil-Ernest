using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer player;
    public VideoClip helloClip;
    public VideoClip idleClip;

    void Start()
    {
        player.playOnAwake = false;
        player.isLooping = false;
        player.loopPointReached += OnClipEnd;
        Play(helloClip, false);
    }

    void Play(VideoClip clip, bool loop)
    {
        player.clip = clip;
        player.isLooping = loop;
        player.Play();
    }

    void OnClipEnd(VideoPlayer vp)
    {
        if (vp.clip == helloClip)
            Play(idleClip, true);
    }
}
