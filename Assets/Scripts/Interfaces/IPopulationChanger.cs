namespace Interfaces
{
    public interface IPopulationChanger
    {
        bool CheckPopulation();
        void ChangePopulation(int current, int max);
    }
}
