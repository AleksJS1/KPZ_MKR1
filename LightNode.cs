namespace Lab3.Task5.Composite;

public abstract class LightNode
{
    protected LightNode()
    {
        OnCreated();
    }

    public abstract string OuterHtml();

    public abstract string InnerHtml();

    protected virtual void OnCreated() { }

    protected virtual void OnInserted(LightElementNode parent) { }

    protected virtual void OnRemoved(LightElementNode parent) { }

    protected virtual void OnStylesApplied() { }

    protected virtual void OnClassListApplied() { }

    protected virtual void OnTextRendered() { }
}