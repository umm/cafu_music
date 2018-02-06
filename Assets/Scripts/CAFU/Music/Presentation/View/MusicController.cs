using CAFU.Music.Data.DataStore;
using CAFU.Music.Data.Entity;
using UniRx;
// ReSharper disable UnusedMember.Global

namespace CAFU.Music.Presentation.View {

    public interface IMusicController<TMusicEntity> where TMusicEntity : IMusicEntity {

        [ObservableAwakeMonoBehaviour]
        IMusicDataStore<TMusicEntity> MusicDataStore { get; }

    }

}