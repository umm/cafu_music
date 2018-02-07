using CAFU.Core.Data.DataStore;
using UniRx;
using UnityEngine;

// ReSharper disable UnusedMember.Global

namespace CAFU.Music.Data.DataStore {

    public interface IMusicDataStore : IDataStore {

        AudioClip GetAudioClip<TEnum>(TEnum key) where TEnum : struct;

    }

    [DisallowMultipleComponent]
    public abstract class MusicDataStoreBase : ObservableLifecycleMonoBehaviour, IMusicDataStore {

        public abstract AudioClip GetAudioClip<TEnum>(TEnum key) where TEnum : struct;

    }

}