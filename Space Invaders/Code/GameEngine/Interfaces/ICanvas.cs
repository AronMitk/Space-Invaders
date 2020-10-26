namespace Space_Invaders.Code
{
    public interface ICanvas
    {
        double[] GetCanvasSize();

        void SetPosition(GameObject gameObject);

        void AddToCanvas(GameObject gameObject);

        void RemoveCanvas(GameObject gameObject);
    }
}