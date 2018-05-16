using System.Collections.Generic;
using System.Linq;
using CAFU.Core.Data.DataStore;
using CAFU.Music.Data.Entity;
using CAFU.Music.Domain.Repository;
using JetBrains.Annotations;
using UnityEngine;

namespace CAFU.Music.Data.DataStore
{
    [PublicAPI]
    public abstract class MusicDataStoreMultiple<TEnum, TMusicEntity> : MusicDataStoreBase<TEnum> where TEnum : struct where TMusicEntity : IMusicEntity
    {
        public class Factory : SceneDataStoreFactory<MusicDataStoreMultiple<TEnum, TMusicEntity>>
        {
        }

        [SerializeField] private List<TMusicEntity> musicEntityList;

        private IEnumerable<TMusicEntity> MusicEntityList => musicEntityList;

        protected override void OnAwake()
        {
            base.OnAwake();
            MusicRepository<TEnum>.DataStoreFactory = new Factory();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            musicEntityList.Clear();
        }

        public override AudioClip GetAudioClip(TEnum key)
        {
            return MusicEntityList.OfType<IMusicEntity<TEnum>>().First(x => Equals(x.Key, key)).AudioClip;
        }
    }
}