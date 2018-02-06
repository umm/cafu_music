using CAFU.Core.Domain.Repository;
using CAFU.Music.Data.DataStore;
using CAFU.Music.Data.DataStore.Scene;
using CAFU.Music.Data.Entity;
using UnityEngine;

namespace CAFU.Music.Domain.Repository {

    public interface IMusicRepository : IRepository {

        AudioClip GetAudioClip<TEnum>(TEnum key) where TEnum : struct;

    }

    public interface IMusicRepository<TMusicEntity> : IMusicRepository where TMusicEntity : IMusicEntity {

    }

    public class MusicRepository<TMusicEntity> : IMusicRepository<TMusicEntity> where TMusicEntity : IMusicEntity {

        public class Factory : DefaultRepositoryFactory<Factory, MusicRepository<TMusicEntity>> {

            protected override void Initialize(MusicRepository<TMusicEntity> instance) {
                base.Initialize(instance);
                instance.MusicDataStore = MusicDataStore<TMusicEntity>.Factory.Instance.Create();
            }

        }

        private IMusicDataStore<TMusicEntity> MusicDataStore { get; set; }

        public AudioClip GetAudioClip<TEnum>(TEnum key) where TEnum : struct {
            return this.MusicDataStore.GetAudioClip(key);
        }

    }

}