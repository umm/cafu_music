using System.Collections.Generic;
using CAFU.Core.Data.DataStore;
using CAFU.Music.Data.Entity;
using UnityEngine;

namespace CAFU.Music.Data.DataStore.Scene {

    public abstract class MusicDataStore<TMusicEntity> : MonoBehaviour, IMusicDataStore<TMusicEntity> where TMusicEntity : IMusicEntity {

        public class Factory : SceneDataStoreFactory<Factory, MusicDataStore<TMusicEntity>> {

        }

        [SerializeField]
        private List<TMusicEntity> musicEntityList;

        public IEnumerable<TMusicEntity> MusicEntityList {
            get {
                return this.musicEntityList;
            }
        }

    }

}