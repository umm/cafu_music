using System.Collections.Generic;
using System.Linq;
using CAFU.Core.Data.DataStore;
using CAFU.Music.Data.Entity;
using UnityEngine;
// ReSharper disable UnusedMember.Global

namespace CAFU.Music.Data.DataStore {

    public interface IMusicDataStore : IDataStore {

    }

    public interface IMusicDataStore<TMusicEntity> : IMusicDataStore where TMusicEntity : IMusicEntity {

        IEnumerable<TMusicEntity> MusicEntityList { get; }

    }

    public static class MusicDataStoreExtension {

        public static AudioClip GetAudioClip<TEnum, TMusicEntity>(this IMusicDataStore<TMusicEntity> musicDataStore, TEnum key) where TEnum : struct where TMusicEntity : IMusicEntity {
            return musicDataStore.MusicEntityList.OfType<IMusicEntity<TEnum>>().ToList().Find(x => Equals(x.Key, key)).AudioClip;
        }

    }

}