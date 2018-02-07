using System.Collections.Generic;
using System.Linq;
using CAFU.Core.Data.DataStore;
using CAFU.Music.Data.Entity;
using CAFU.Music.Domain.Repository;
using UnityEngine;

// ReSharper disable ArrangeAccessorOwnerBody

namespace CAFU.Music.Data.DataStore {

    public abstract class MusicDataStoreMultiple<TMusicEntity> : MusicDataStoreBase where TMusicEntity : IMusicEntity {

        public class Factory : SceneDataStoreFactory<Factory, MusicDataStoreMultiple<TMusicEntity>> {

        }

        [SerializeField]
        private List<TMusicEntity> musicEntityList;

        private IEnumerable<TMusicEntity> MusicEntityList {
            get {
                return this.musicEntityList;
            }
        }

        protected override void OnAwake() {
            base.OnAwake();
            MusicRepository.DataStoreFactory = Factory.Instance;
        }

        public override AudioClip GetAudioClip<TEnum>(TEnum key) {
            return this.MusicEntityList.OfType<IMusicEntity<TEnum>>().ToList().Find(x => Equals(x.Key, key)).AudioClip;
        }

    }

}