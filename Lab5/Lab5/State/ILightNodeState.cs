namespace State
{
    public interface ILightNodeState
    {
        void Show(LightNode node);
        void Hide(LightNode node);
        void Select(LightNode node);
        void Deselect(LightNode node);
    }
}
