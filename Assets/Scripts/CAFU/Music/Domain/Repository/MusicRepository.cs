using CAFU.Core.Data.DataStore;
using CAFU.Core.Domain.Repository;
using CAFU.Music.Data.DataStore;
using UnityEngine;

namespace CAFU.Music.Domain.Repository {

    public interface IMusicRepository : IRepository {

        AudioClip GetAudioClip<TEnum>(TEnum key) where TEnum : struct;

    }

    public class MusicRepository : IMusicRepository {

        public static IDataStoreFactory<IMusicDataStore> DataStoreFactory { private get; set; }

        public class Factory : DefaultRepositoryFactory<Factory, MusicRepository> {

            protected override void Initialize(MusicRepository instance) {
                base.Initialize(instance);
                instance.MusicDataStore = DataStoreFactory.Create();
            }

        }

        private IMusicDataStore MusicDataStore { get; set; }

        public AudioClip GetAudioClip<TEnum>(TEnum key) where TEnum : struct {
            return this.MusicDataStore.GetAudioClip(key);
        }

    }

}