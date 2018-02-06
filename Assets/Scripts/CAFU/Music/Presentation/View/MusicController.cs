using CAFU.Music.Data.DataStore.Scene;
using CAFU.Music.Data.Entity;
using UniRx;
// ReSharper disable UnusedMember.Global

namespace CAFU.Music.Presentation.View {

    public interface IMusicController<TMusicEntity> where TMusicEntity : IMusicEntity {

        [ObservableAwakeMonoBehaviour]
        MusicDataStore<TMusicEntity> MusicDataStore { get; }

    }

}