using DMApi.Models;

public interface IUnitService
{
    Unit GetUnitById(int id);
    IEnumerable<Unit> GetAllUnits();
    Unit CreateUnit(Unit unit);
    void DeleteUnit(int id);
    Unit UpdateUnit(Unit unit);
}
