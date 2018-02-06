using CAFU.Core.Data.Entity;
using UnityEngine;

#pragma warning disable 649

namespace CAFU.Music.Data.Entity {

    public interface IMusicEntity : IEntity {

    }

    public interface IMusicEntity<out TEnum> : IMusicEntity where TEnum : struct {

        TEnum Key { get; }

        AudioClip AudioClip { get; }

    }

    public class MusicEntity<TEnum> : IMusicEntity<TEnum> where TEnum : struct {

        [SerializeField]
        private TEnum key;

        public TEnum Key {
            get {
                return this.key;
            }
        }

        [SerializeField]
        private AudioClip audioClip;

        public AudioClip AudioClip {
            get {
                return this.audioClip;
            }
        }

    }

}