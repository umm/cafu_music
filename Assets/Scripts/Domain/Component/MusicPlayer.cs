using CAFU.Core.Presentation.View;
using CAFU.Music.Domain.Model;
using CAFU.Music.Domain.UseCase;
using UniRx;
using UnityEngine;

// View ではなく、Domain レイヤにより取り扱われるべきクラスなので、特別な namespace を付与する
namespace CAFU.Music.Domain.Component
{
    public class MusicPlayer : MonoBehaviour, IMusicPlayer, IInjectableView<IMusicModel>
    {
        private IMusicModel MusicModel { get; set; }

        private AudioSource AudioSource { get; set; }

        private static bool HasInstalled { get; set; }

        public static void Install(IMusicModel musicModel)
        {
            if (HasInstalled)
            {
                return;
            }

            var go = new GameObject(typeof(MusicPlayer).Name);
            var musicPlayer = go.AddComponent<MusicPlayer>();
            musicPlayer.Inject(musicModel);
            DontDestroyOnLoad(go);
            HasInstalled = true;
        }

        private void Awake()
        {
            AudioSource = gameObject.GetComponent<AudioSource>();
            if (AudioSource == default(AudioSource))
            {
                AudioSource = gameObject.AddComponent<AudioSource>();
            }

            AudioSource.playOnAwake = false;
        }

        private void OnDestroy()
        {
            HasInstalled = false;
        }

        public void Inject(IMusicModel musicModel)
        {
            MusicModel = musicModel;
            MusicModel.MusicPlayer = this;
            MusicModel.AudioClip.Subscribe(audioClip => AudioSource.clip = audioClip);
        }

        public void Play(bool loop = true)
        {
            AudioSource.loop = loop;
            AudioSource.Play();
        }

        public void Stop()
        {
            AudioSource.Stop();
        }

        public void Pause()
        {
            AudioSource.Pause();
        }

        public void Resume()
        {
            AudioSource.UnPause();
        }

        public void SetVolume(float volume)
        {
            AudioSource.volume = volume;
        }

        public void SetPitch(float pitch)
        {
            AudioSource.pitch = pitch;
        }

    }
}
