using CAFU.Music.Domain.UseCase;
using CAFU.Core.Domain.Model;
using UniRx;
using UnityEngine;

namespace CAFU.Music.Domain.Model {

    public interface IMusicModel : ISingletonModel {

        ReactiveProperty<AudioClip> AudioClip { get; }

        IMusicPlayer MusicPlayer { get; set; }

    }

    public class MusicModel : IMusicModel {

        public class Factory : DefaultModelFactory<MusicModel> {

            protected override void Initialize(MusicModel instance) {
                base.Initialize(instance);
                instance.AudioClip = new ReactiveProperty<AudioClip>();
            }

        }

        public ReactiveProperty<AudioClip> AudioClip { get; private set; }

        public IMusicPlayer MusicPlayer { get; set; }

    }

}