using CAFU.Generator;
using CAFU.Generator.Enumerates;
using JetBrains.Annotations;

namespace CAFU.Music.Generator
{
    [UsedImplicitly]
    public class MusicName : ClassStructureBase
    {
        private const string StructureName = "Application/Enumerate/MusicName";

        public override string Name { get; } = StructureName;

        protected override ParentLayerType ParentLayerType { get; } = ParentLayerType.Application;

        protected override LayerType LayerType { get; } = LayerType.Enumerate;

        protected override string ModuleName { get; } = "umm@cafu_music";

        public override void Generate(bool overwrite)
        {
            var parameter = new Parameter()
            {
                ParentLayerType = ParentLayerType,
                LayerType = LayerType,
                ClassName = "MusicName",
                Overwrite = overwrite,
            };
            parameter.Namespace = CreateNamespace(parameter);

            var generator = new ScriptGenerator(parameter, CreateTemplatePath(TemplateType.Class, StructureName));

            generator.Generate(CreateOutputPath(parameter));
        }
    }
}