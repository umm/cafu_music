﻿using CAFU.Music.Domain.UseCase;
using CAFU.Core.Presentation.Presenter;
// ReSharper disable UnusedMember.Global

namespace CAFU.Music.Presentation.Presenter {

    public interface IMusicPresenter<in TEnum> : IPresenter where TEnum : struct {

        IMusicUseCase<TEnum> MusicUseCase { get; }

    }

    public static class MusicPresenterExtension {

        public static void PlayMusic<TEnum>(this IMusicPresenter<TEnum> presenter, TEnum key, bool loop = true, bool keepIfSame = true) where TEnum : struct {
            presenter.MusicUseCase.Play(key, loop, keepIfSame);
        }

        public static void StopMusic<TEnum>(this IMusicPresenter<TEnum> presenter) where TEnum : struct {
            presenter.MusicUseCase.Stop();
        }

        public static void PauseMusic<TEnum>(this IMusicPresenter<TEnum> presenter) where TEnum : struct {
            presenter.MusicUseCase.Pause();
        }

        public static void ResumeMusic<TEnum>(this IMusicPresenter<TEnum> presenter) where TEnum : struct {
            presenter.MusicUseCase.Resume();
        }

    }

}