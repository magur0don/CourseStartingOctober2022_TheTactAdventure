using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TactAdventureSoundManager : SingletonMonoBehaviour<TactAdventureSoundManager>
{
    public enum SoundType
    {
        Invalide = -1,
        BGM,
        SEAttack1,
        SEAttack2,
        SoundTypesMax
    }
    private AudioSource[] audioSources;


    public enum BGMType
    {
        Invalide = -1,
        TitleBGM,
        StageChoiceBGM,
        GameMainBGM,
        GameResultBGM,
        SoundTypesMax
    }

    [SerializeField]
    private AudioClip[] BGMClips;

    [SerializeField]
    private AudioClip[] SEClips;

    public override void Awake()
    {
        audioSources = new AudioSource[(int)SoundType.SoundTypesMax];
        base.Awake();
        for (int i = 0; i < (int)SoundType.SoundTypesMax; i++)
        {
            audioSources[i] = this.gameObject.AddComponent<AudioSource>();
        }

        // BGM再生用のAudioSourceはLoopをtrueにする
        audioSources[(int)SoundType.BGM].loop = true;

    }

    public void PlayeBGM(BGMType bgmType)
    {
        // 現在再生中の音源とは違う音源を再生する場合は再生できる
        if (audioSources[(int)SoundType.BGM].clip != BGMClips[(int)bgmType])
        {
            audioSources[(int)SoundType.BGM].clip = BGMClips[(int)bgmType];
            audioSources[(int)SoundType.BGM].Play();
        }
    }

    public void PlaySE(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.SEAttack1:
                audioSources[(int)SoundType.SEAttack1].PlayOneShot(SEClips[0]);
                break;
            case SoundType.SEAttack2:
                audioSources[(int)SoundType.SEAttack2].PlayOneShot(SEClips[1]);
                break;
        }
    }
}
