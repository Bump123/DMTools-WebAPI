using DMApi.Controllers;
using DMApi.Models;

namespace DMApi.Repositories
{
    public class UnitRepository: IUnitRepsitory
    {
        private readonly UnitDB _db;


        public UnitRepository(UnitDB db) 
        {
            _db = db;
        }

        public Unit AddUnit(Unit unit)
        {
            _db.Unit.Add(unit);
            _db.SaveChanges();
            return unit;
        }

        public List<Unit> GetAll()
        {
            return _db.Unit.ToList();

        }

        public Unit GetUnit(int id)
        {
            return _db.Unit.Find(id);
        }

        public void RemoveUnit(Unit unit)
        {
            _db.Unit.Remove(unit);
            _db.SaveChanges();
        }

        public Unit UpdateUnit(Unit unitToBeEdited)
        {
            Unit unit = _db.Unit.Find(unitToBeEdited.Id);
            unit.AC = unitToBeEdited.AC;
            unit.Name = unitToBeEdited.Name;
            _db.Unit.Update(unit);
            _db.SaveChanges();
            return unit;
        }
    }
}
