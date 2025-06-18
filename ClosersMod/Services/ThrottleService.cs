using ClosersFramework.KeyWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClosersFramework.Services
{
    public static class ThrottleService
    {
        public static List<ThrottleRegistration> RegistList { get; private set; } = new List<ThrottleRegistration>();

        public static Guid AddRegistrationSecond(string Name, int Countdown)
        {
            var rv = Guid.NewGuid();
            var repeat = RegistList.FirstOrDefault(t => t.Name == Name);
            if (repeat != null)
            {
                clog.w($"防抖注册表-已存在名为{Name}的注册项");
                repeat.CreateTime = DateTime.UtcNow;
                repeat.EndTime = DateTime.UtcNow.AddSeconds(Countdown);
                rv = repeat.Id;
            }
            else
            {
                RegistList.Add(new ThrottleRegistration()
                {
                    Id = rv,
                    Name = Name,
                    CreateTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow.AddSeconds(Countdown)
                });
            }
            RemoveTimeout();
            return rv;
        }
        public static Guid AddRegistrationMilliSeconds(string Name, int Countdown, int Seat = 1)
        {
            var rv = Guid.NewGuid();
            var repeat = RegistList.FirstOrDefault(t => t.Name == Name);
            if (repeat != null)
            {
                rv = repeat.Id;
                if (!repeat.isFull) return rv;
                //clog.w($"防抖注册表-已存在名为{Name}的注册项");
                repeat.CreateTime = DateTime.UtcNow;
                repeat.EndTime = DateTime.UtcNow.AddMilliseconds(Countdown);
            }
            else
            {
                //clog.w($"防抖注册表-添加名为{Name}的注册项");
                RegistList.Add(new ThrottleRegistration()
                {
                    Id = rv,
                    Name = Name,
                    BusSeat = Seat,
                    CreateTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow.AddMilliseconds(Countdown)
                });
            }
            return rv;
        }

        public static ThrottleRegistration SearchRegistration(string Name)
        {
            RemoveTimeout();
            return RegistList.FirstOrDefault(x => x.Name == Name) ?? new ThrottleRegistration() { EndTime = DateTime.MinValue };
        }
        public static ThrottleRegistration SearchRegistration(Guid guid)
        {
            RemoveTimeout();
            return RegistList.FirstOrDefault(x => x.Id == guid) ?? new ThrottleRegistration() { EndTime = DateTime.MinValue };
        }

        public static bool CheckTimeout(string Name) => SearchRegistration(Name)?.isTimeout ?? true;
        public static bool CheckTimeout(Guid guid) => SearchRegistration(guid)?.isTimeout ?? true;

        public static bool CheckAvailable(string Name)
        {
            var res = SearchRegistration(Name);
            if (res?.isTimeout ?? true) return true;
            else if (!res.isFull)
            {
                res.Passenger++;
                return true;
            }
            else return false;
        }
        public static bool CheckAvailable(Guid guid)
        {
            var res = SearchRegistration(guid);
            if (res?.isTimeout ?? true) return true;
            else if (!res.isFull)
            {
                res.Passenger++;
                return true;
            }
            else return false;
        }

        public static void RemoveTimeout() => RegistList.RemoveAll(t => t.isTimeout);

        public static void Regist(string Name, int ms, Action action)
        {
            if (SearchRegistration(Name)?.isTimeout ?? true)
            {
                action.Invoke();
                AddRegistrationMilliSeconds(Name, ms);
            }
        }
        public static bool AddPassenger(string Name)
        {
            var res = SearchRegistration(Name);
            if (res.isFull) return false;
            else
            {
                res.Passenger++;
                return true;
            }
        }
        public static bool AddPassenger(Guid guid)
        {
            var res = SearchRegistration(guid);
            if (res.isFull) return false;
            else
            {
                res.Passenger++;
                return true;
            }
        }
    }
    public class ThrottleRegistration
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool isTimeout { get { return DateTime.UtcNow >= EndTime; } }
        public int BusSeat { get; set; } = 1;
        public int Passenger { get; set; } = 0;
        public bool isFull => BusSeat >= Passenger;
    }
}
