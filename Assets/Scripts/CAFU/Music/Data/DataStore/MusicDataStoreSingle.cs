using CAFU.Core.Data.DataStore;
using CAFU.Music.Data.Entity;
using CAFU.Music.Domain.Repository;
using UnityEngine;

// ReSharper disable ArrangeAccessorOwnerBody

namespace CAFU.Music.Data.DataStore {

    public abstract class MusicDataStoreSingle<TMusicEntity> : MusicDataStoreBase where TMusicEntity : IMusicEntity {

        public class Factory : SceneDataStoreFactory<Factory, MusicDataStoreSingle<TMusicEntity>> {

        }

        [SerializeField]
        private TMusicEntity musicEntity;

        private TMusicEntity MusicEntity {
            get {
                return this.musicEntity;
            }
        }

        protected override void OnAwake() {
            base.OnAwake();
            MusicRepository.DataStoreFactory = Factory.Instance;
        }

        public override AudioClip GetAudioClip<TEnum>(TEnum key) {
            return this.MusicEntity.AudioClip;
        }



    }

}