using CAFU.Core.Domain.UseCase;
using CAFU.Music.Data.Entity;
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

    public interface IMusicUseCase : ISingletonUseCase {

        void Play<TEnum>(TEnum key, bool loop = true, bool keepIfSame = true) where TEnum : struct;

        void Stop();

        void Pause();

        void Resume();

    }

    public class MusicUseCase<TMusicEntity> : IMusicUseCase where TMusicEntity : IMusicEntity {

        public class Factory : DefaultUseCaseFactory<Factory, MusicUseCase<TMusicEntity>> {

            protected override void Initialize(MusicUseCase<TMusicEntity> instance) {
                base.Initialize(instance);
                instance.MusicModel = Model.MusicModel.Factory.Instance.Create();
                instance.MusicRepository = MusicRepository<TMusicEntity>.Factory.Instance.Create();
                // タイミング的にココで注入しないと ReactiveProperty の Subscribe が間に合わない
                MusicPlayer.Install(instance.MusicModel);
            }

        }

        private IMusicModel MusicModel { get; set; }

        private IMusicRepository MusicRepository { get; set; }

        public void Play<TEnum>(TEnum key, bool loop = true, bool keepIfSame = true) where TEnum : struct {
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