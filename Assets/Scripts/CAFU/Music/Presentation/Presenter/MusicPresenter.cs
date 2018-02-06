using CAFU.Music.Domain.UseCase;
using CAFU.Core.Presentation.Presenter;
// ReSharper disable UnusedMember.Global

namespace Assets.Scripts.CAFU.Music.Presentation.Presenter {

    public interface IMusicPresenter : IPresenter {

        IMusicUseCase MusicUseCase { get; }

    }

    public static class MusicPresenterExtension {

        public static void PlayMusic<TEnum>(this IMusicPresenter presenter, TEnum key, bool loop = true, bool keepIfSame = true) where TEnum : struct {
            presenter.MusicUseCase.Play(key, loop, keepIfSame);
        }

        public static void StopMusic(this IMusicPresenter presenter) {
            presenter.MusicUseCase.Stop();
        }

        public static void PauseMusic(this IMusicPresenter presenter) {
            presenter.MusicUseCase.Pause();
        }

        public static void ResumeMusic(this IMusicPresenter presenter) {
            presenter.MusicUseCase.Resume();
        }

    }

}