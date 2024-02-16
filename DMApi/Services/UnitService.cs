using DMApi.Models;

namespace DMApi.Services
{
    public class UnitService: IUnitService
    {
        List<Unit> units = new List<Unit>
        {
            new Unit(id: 1, name: "name1", aC: 10),
            new Unit(id: 2, name: "name2", aC: 5),
            new Unit(id: 3, name: "name3", aC: 15)
        };



        public Unit GetUnitById(int id)
        {
            return units.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Unit> GetAllUnits()
        {
            return units;
        }

        public Unit CreateUnit(Unit unit)
        {
            unit.Id = units.Any() ? units.Max(u => u.Id) + 1 : 1;
            units.Add(unit);
            return unit;
        }

        public void DeleteUnit(int id)
        {
            var unitToDelete = units.FirstOrDefault(u => u.Id == id);
            if (unitToDelete != null)
            {
                units.Remove(unitToDelete);
            }
        }

        public Unit UpdateUnit(Unit unitToUpdate)
        {
            var existingUnit = units.FirstOrDefault(u => u.Id == unitToUpdate.Id);
            if (existingUnit != null)
            {
                existingUnit.Name = unitToUpdate.Name;
                existingUnit.AC = unitToUpdate.AC;
                return existingUnit;
            }
            return unitToUpdate;
        }



    }
}
