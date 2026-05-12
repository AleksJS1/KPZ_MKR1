namespace Lab3.Task5.Composite;

internal sealed class VisibleState : ILightElementState
{
    public string Render(LightElementNode node, System.Func<string> defaultRender)
    {
        return defaultRender();
    }
}
