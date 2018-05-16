using CAFU.Generator;
using CAFU.Generator.Enumerates;
using JetBrains.Annotations;

namespace CAFU.Music.Generator
{
    [UsedImplicitly]
    public class MusicEntity : ClassStructureBase
    {
        private const string StructureName = "Data/Entity/MusicEntity";

        public override string Name { get; } = StructureName;

        protected override ParentLayerType ParentLayerType { get; } = ParentLayerType.Data;

        protected override LayerType LayerType { get; } = LayerType.Entity;

        protected override string ModuleName { get; } = "umm@cafu_music";

        public override void Generate(bool overwrite)
        {
            var parameter = new Parameter()
            {
                ParentLayerType = ParentLayerType,
                LayerType = LayerType,
                ClassName = "MusicEntity",
                Overwrite = overwrite,
            };
            parameter.Namespace = CreateNamespace(parameter);

            parameter.UsingList.Add("System");
            parameter.UsingList.Add("CAFU.Generics.Data.Entity");
            parameter.UsingList.Add("CAFU.Music.Data.Entity");
            parameter.UsingList.Add($"{this.CreateNamespacePrefix()}Application.Enumerate");
            parameter.UsingList.Add("UnityEngine");
            parameter.BaseClassName = "ScriptableObjectGenericEntity";
            parameter.ImplementsInterfaceList.Add("IMusicEntity<MusicName>");

            var generator = new ScriptGenerator(parameter, CreateTemplatePath(TemplateType.Class, StructureName));

            generator.Generate(CreateOutputPath(parameter));
        }
    }
}