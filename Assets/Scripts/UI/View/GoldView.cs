namespace UI.View
{
    public class GoldView : BaseSourceView
    {
        public override void SetSourceText(int current, int max = 0)
        {
            _sourceText.text = "" + current;
        }
    }
}
