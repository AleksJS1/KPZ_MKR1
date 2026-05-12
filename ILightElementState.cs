using System;

namespace Lab3.Task5.Composite;

public interface ILightElementState
{
    string Render(LightElementNode node, Func<string> defaultRender);
}
