namespace UI.View
{
    public class PopulationView : BaseSourceView
    {
        public override void SetSourceText(int current, int max)
        {
            _sourceText.text = current + "/" + max;
        }
    }
}
