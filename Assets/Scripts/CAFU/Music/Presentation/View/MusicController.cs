using CAFU.Music.Data.DataStore;
using UniRx;
// ReSharper disable UnusedMember.Global

namespace CAFU.Music.Presentation.View {

    public interface IMusicController {

        [ObservableAwakeMonoBehaviour]
        IMusicDataStore MusicDataStore { get; }

    }

}