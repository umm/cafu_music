using CAFU.Core.Domain.UseCase;
using CAFU.Music.Domain.Component;
using CAFU.Music.Domain.Model;
using CAFU.Music.Domain.Repository;

// ReSharper disable UnusedMember.Global

namespace CAFU.Music.Domain.UseCase {

    public interface IMusicPlayer {

        void Play(bool loop = true);

        void Stop();

        void Pause();

        void Resume();

    }

    public interface IMusicUseCase<in TEnum> : IUseCase where TEnum : struct {

        void Play(TEnum key, bool loop = true, bool keepIfSame = true);

        void Stop();

        void Pause();

        void Resume();

    }

    public class MusicUseCase<TEnum> : IMusicUseCase<TEnum> where TEnum : struct {

        public class Factory : DefaultUseCaseFactory<MusicUseCase<TEnum>> {

            protected override void Initialize(MusicUseCase<TEnum> instance) {
                base.Initialize(instance);
                instance.MusicModel = new MusicModel.Factory().Create();
                instance.MusicRepository = new MusicRepository<TEnum>.Factory().Create();
                // タイミング的にココで注入しないと ReactiveProperty の Subscribe が間に合わない
                MusicPlayer.Install(instance.MusicModel);
            }

        }

        private IMusicModel MusicModel { get; set; }

        private IMusicRepository<TEnum> MusicRepository { get; set; }

        public void Play(TEnum key, bool loop = true, bool keepIfSame = true) {
            // 既に再生中の場合は何もしない
            if (keepIfSame && this.MusicModel.AudioClip.Value == this.MusicRepository.GetAudioClip(key)) {
                return;
            }
            this.MusicModel.AudioClip.Value = this.MusicRepository.GetAudioClip(key);
            this.MusicModel.MusicPlayer.Play(loop);
        }

        public void Stop() {
            this.MusicModel.MusicPlayer.Stop();
        }

        public void Pause() {
            this.MusicModel.MusicPlayer.Pause();
        }

        public void Resume() {
            this.MusicModel.MusicPlayer.Resume();
        }

    }

}