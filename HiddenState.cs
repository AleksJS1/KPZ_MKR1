namespace Lab3.Task5.Composite;

internal sealed class HiddenState : ILightElementState
{
    public string Render(LightElementNode node, System.Func<string> defaultRender)
    {
        return string.Empty;
    }
}
