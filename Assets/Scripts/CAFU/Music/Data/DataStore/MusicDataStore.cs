using CAFU.Core.Data.DataStore;
using UnityEngine;
// ReSharper disable UnusedMember.Global

namespace CAFU.Music.Data.DataStore {

    public interface IMusicDataStore : IDataStore {

        AudioClip GetAudioClip<TEnum>(TEnum key) where TEnum : struct;

    }

}