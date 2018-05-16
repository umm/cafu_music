using CAFU.Core.Data.DataStore;
using CAFU.Music.Data.Entity;
using CAFU.Music.Domain.Repository;
using JetBrains.Annotations;
using UnityEngine;

namespace CAFU.Music.Data.DataStore
{
    [PublicAPI]
    public abstract class MusicDataStoreSingle<TEnum, TMusicEntity> : MusicDataStoreBase<TEnum> where TEnum : struct where TMusicEntity : IMusicEntity
    {
        public class Factory : SceneDataStoreFactory<MusicDataStoreSingle<TEnum, TMusicEntity>>
        {
        }

        [SerializeField] private TMusicEntity musicEntity;

        private TMusicEntity MusicEntity => musicEntity;

        protected override void OnAwake()
        {
            base.OnAwake();
            MusicRepository<TEnum>.DataStoreFactory = new Factory();
        }

        public override AudioClip GetAudioClip(TEnum key)
        {
            return MusicEntity.AudioClip;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            musicEntity = default(TMusicEntity);
        }
    }
}