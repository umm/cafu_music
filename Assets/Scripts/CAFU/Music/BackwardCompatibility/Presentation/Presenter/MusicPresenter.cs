

// ReSharper disable UnusedMember.Global

using System;

namespace Assets.Scripts.CAFU.Music.Presentation.Presenter {

    [Obsolete("Please use 'CAFU.Music.Presentation.Presenter.IMusicPresenter<TEnum>' instead of this interface.")]
    public interface IMusicPresenter<in TEnum> : global::CAFU.Music.Presentation.Presenter.IMusicPresenter<TEnum>
        where TEnum : struct {

    }

}