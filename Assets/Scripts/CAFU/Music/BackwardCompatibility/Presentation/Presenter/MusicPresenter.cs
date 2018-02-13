// ReSharper disable UnusedMember.Global

using System;

namespace Assets.Scripts.CAFU.Music.Presentation.Presenter {

    [Obsolete("Please use 'CAFU.Music.Presentation.Presenter.IMusicPresenter<TEnum>' instead of this interface.")]
    public interface IMusicPresenter<in TEnum> : global::CAFU.Music.Presentation.Presenter.IMusicPresenter<TEnum>
        where TEnum : struct {

    }

    public static class MusicPresenterExtension {

        [Obsolete("Please use 'CAFU.Music.Presentation.Presenter.IMusicPresenter<TEnum>.PlayMusic()' instead of this extension method.")]
        public static void PlayMusic<TEnum>(this IMusicPresenter<TEnum> presenter, TEnum key, bool loop = true, bool keepIfSame = true) where TEnum : struct {
            presenter.MusicUseCase.Play(key, loop, keepIfSame);
        }

        [Obsolete("Please use 'CAFU.Music.Presentation.Presenter.IMusicPresenter<TEnum>.StopMusic()' instead of this extension method.")]
        public static void StopMusic<TEnum>(this IMusicPresenter<TEnum> presenter) where TEnum : struct {
            presenter.MusicUseCase.Stop();
        }

        [Obsolete("Please use 'CAFU.Music.Presentation.Presenter.IMusicPresenter<TEnum>.PauseMusic()' instead of this extension method.")]
        public static void PauseMusic<TEnum>(this IMusicPresenter<TEnum> presenter) where TEnum : struct {
            presenter.MusicUseCase.Pause();
        }

        [Obsolete("Please use 'CAFU.Music.Presentation.Presenter.IMusicPresenter<TEnum>.ResumeMusic()' instead of this extension method.")]
        public static void ResumeMusic<TEnum>(this IMusicPresenter<TEnum> presenter) where TEnum : struct {
            presenter.MusicUseCase.Resume();
        }

    }

}