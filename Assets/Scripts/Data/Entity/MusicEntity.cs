using CAFU.Core.Data.Entity;
using JetBrains.Annotations;
using UnityEngine;

namespace CAFU.Music.Data.Entity
{
    [PublicAPI]
    public interface IMusicEntity : IEntity
    {
        AudioClip AudioClip { get; }
    }

    [PublicAPI]
    public interface IMusicEntity<out TEnum> : IMusicEntity where TEnum : struct
    {
        TEnum Key { get; }
    }

    [PublicAPI]
    public class MusicEntity<TEnum> : IMusicEntity<TEnum> where TEnum : struct
    {
        [SerializeField] private TEnum key;

        public TEnum Key => key;

        [SerializeField] private AudioClip audioClip;

        public AudioClip AudioClip => audioClip;
    }
}