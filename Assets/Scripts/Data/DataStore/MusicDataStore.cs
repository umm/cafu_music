using CAFU.Core.Data.DataStore;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;

namespace CAFU.Music.Data.DataStore
{
    [PublicAPI]
    public interface IMusicDataStore<in TEnum> : IDataStore where TEnum : struct
    {
        AudioClip GetAudioClip(TEnum key);
    }

    [PublicAPI]
    [DisallowMultipleComponent]
    public abstract class MusicDataStoreBase<TEnum> : ObservableLifecycleMonoBehaviour, IMusicDataStore<TEnum> where TEnum : struct
    {
        public abstract AudioClip GetAudioClip(TEnum key);
    }
}