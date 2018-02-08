using CAFU.Core.Data.DataStore;
using UniRx;
using UnityEngine;

// ReSharper disable UnusedMember.Global

namespace CAFU.Music.Data.DataStore {

    public interface IMusicDataStore<in TEnum> : IDataStore where TEnum : struct {

        AudioClip GetAudioClip(TEnum key);

    }

    [DisallowMultipleComponent]
    public abstract class MusicDataStoreBase<TEnum> : ObservableLifecycleMonoBehaviour, IMusicDataStore<TEnum> where TEnum : struct {

        public abstract AudioClip GetAudioClip(TEnum key);

    }

}