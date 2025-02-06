using ClosersTina.Data;
using ClosersTina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersTina.Services
{
    public class BuffStagingService
    {
        public static void CleanUp()
        {
            if (BattleSystem.instance == null)
            {
                ClearData();
                return;
            }
            BuffStagingArea.Data.RemoveAll(t => BattleSystem.instance.EnemyTeam.AliveChars.All(u => u != t.Owner) || t.Owner.IsDead);
        }
        public static BuffStagingUnit GetBuffs(BattleEnemy bchar) => BuffStagingArea.Data.FirstOrDefault(t => t.Owner == bchar);

        public static void AddRegistration(BuffStagingUnit model)
        {
            //BuffStagingArea.Data.Add(new BuffStagingUnit() { Owner = model.Owner, Buffs = model.Buffs.Select(t=>t.) });
            BuffStagingArea.Data.Add(model);
        }
        public static List<BuffStagingUnit> GetData() => BuffStagingArea.Data;
        public static void ClearData()
        {
            BuffStagingArea.Data.Clear();
        }
        public static void ReturnBuff()
        {
            if (BattleSystem.instance != null)
            {
                //BattleSystem.instance.EnemyList.ForEach(t => t.Buffs.AddRange(GetBuffs(t).Buffs));
                BattleSystem.instance.EnemyTeam.AliveChars.ForEach(t => GetBuffs(t as BattleEnemy)?.Buffs?.ForEach(u => t.BuffAdd(u.buffkey, t,RemainTime: u.remainTime)));
            }
        }
        public static bool DataIsNull => GetData() == null || !GetData().Any();
    }
}
