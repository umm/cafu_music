using System.Collections.Generic;
using System.Linq;
using CAFU.Core.Data.DataStore;
using CAFU.Music.Data.Entity;
using UniRx;
using UnityEngine;
// ReSharper disable UnusedMember.Global

namespace CAFU.Music.Data.DataStore.Scene {

    public interface IMusicDataStoreController<TMusicEntity> where TMusicEntity : IMusicEntity {

        [ObservableAwakeMonoBehaviour]
        MusicDataStore<TMusicEntity> MusicDataStore { get; }

    }

    public abstract class MusicDataStore<TMusicEntity> : MonoBehaviour, IMusicDataStore where TMusicEntity : IMusicEntity {

        public class Factory : SceneDataStoreFactory<Factory, MusicDataStore<TMusicEntity>> {

        }

        [SerializeField]
        private List<TMusicEntity> musicEntityList;

        private IEnumerable<TMusicEntity> MusicEntityList {
            get {
                return this.musicEntityList;
            }
        }

        public AudioClip GetAudioClip<TEnum>(TEnum key) where TEnum : struct {
            return this.MusicEntityList.OfType<IMusicEntity<TEnum>>().ToList().Find(x => Equals(x.Key, key)).AudioClip;
        }

    }

}