using CAFU.Generator;
using CAFU.Generator.Enumerates;
using UnityEditor;

namespace CAFU.Music.GeneratorExtension
{
    [InitializeOnLoad]
    public class MusicPresenter : IClassStructureExtension
    {
        private bool ImplementsMusicPresenter { get; set; }

        static MusicPresenter()
        {
            var instance = new MusicPresenter();
            GeneratorWindow.RegisterAdditionalOptionRenderDelegate(LayerType.Controller, instance);
            GeneratorWindow.RegisterAdditionalOptionRenderDelegate(LayerType.Presenter, instance);
            GeneratorWindow.RegisterAdditionalStructureExtensionDelegate(LayerType.Presenter, instance);
        }

        public void OnGUI()
        {
            ImplementsMusicPresenter = EditorGUILayout.Toggle("Implements IMusicPresenter?", ImplementsMusicPresenter);
        }

        public void Process(Parameter parameter)
        {
            if (ImplementsMusicPresenter)
            {
                parameter.UsingList.Add("CAFU.Music.Presentation.Presenter");
                parameter.UsingList.Add("CAFU.Music.Domain.UseCase");
                parameter.UsingList.Add($"{this.CreateNamespacePrefix()}Application.Enumerate");
                parameter.ImplementsInterfaceList.Add("IMusicPresenter<MusicName>");
                parameter.PropertyList.Add(
                    new Parameter.Property()
                    {
                        Accessibility = Accessibility.Public,
                        Type = "MusicUseCase<MusicName>",
                        Interface = "IMusicUseCase<MusicName>",
                        Name = "MusicUseCase",
                    }
                );
            }
        }
    }
}