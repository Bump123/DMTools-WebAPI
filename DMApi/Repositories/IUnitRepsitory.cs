using DMApi.Models;

namespace DMApi.Repositories
{
    public interface IUnitRepsitory
    {
        List<Unit> GetAll();
        Unit GetUnit(int id);
        Unit AddUnit(Unit unit);
        Unit UpdateUnit(Unit unitToBeEdited);
        void RemoveUnit(Unit unit);
        
    }
}
