namespace MagicBalanceConfigurator.Generators.SerealizebleGenerators
{
    public interface ISerealizebleGenerator
    {
        void ApplyGeneratorConfig(GeneratorConfig generatorConfig);

        GeneratorConfig GetGeneratorConfig();
    }
}
