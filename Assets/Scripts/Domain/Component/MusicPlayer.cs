using CAFU.Music.Domain.UseCase;
using CAFU.Core.Presentation.View;
using CAFU.Music.Domain.Model;
using UniRx;
using UnityEngine;

// View ではなく、Domain レイヤにより取り扱われるべきクラスなので、特別な namespace を付与する
namespace CAFU.Music.Domain.Component {

    public class MusicPlayer : MonoBehaviour, IMusicPlayer, IInjectableView<IMusicModel> {

        private IMusicModel MusicModel { get; set; }

        private AudioSource AudioSource { get; set; }

        private static bool HasInstalled { get; set; }

        public static void Install(IMusicModel musicModel) {
            if (HasInstalled) {
                return;
            }
            GameObject go = new GameObject(typeof(MusicPlayer).Name);
            MusicPlayer musicPlayer = go.AddComponent<MusicPlayer>();
            musicPlayer.Inject(musicModel);
            DontDestroyOnLoad(go);
            HasInstalled = true;
        }

        private void Awake() {
            this.AudioSource = this.gameObject.GetComponent<AudioSource>();
            if (this.AudioSource == default(AudioSource)) {
                this.AudioSource = this.gameObject.AddComponent<AudioSource>();
            }
            this.AudioSource.playOnAwake = false;
        }

        public void Inject(IMusicModel musicModel) {
            this.MusicModel = musicModel;
            this.MusicModel.MusicPlayer = this;
            this.MusicModel.AudioClip.Subscribe(audioClip => this.AudioSource.clip = audioClip);
        }

        public void Play(bool loop = true) {
            this.AudioSource.loop = loop;
            this.AudioSource.Play();
        }

        public void Stop() {
            this.AudioSource.Stop();
        }

        public void Pause() {
            this.AudioSource.Pause();
        }

        public void Resume() {
            this.AudioSource.UnPause();
        }

        public void SetVolume(float volume) {
            this.AudioSource.volume = volume;
        }

    }

}