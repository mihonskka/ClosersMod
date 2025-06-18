using ClosersFramework;
using ClosersFramework.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

namespace ClosersIseubi.Service
{
    /*static partial class DotNetExtend
    {
        public static T NextRandom<T>(this IEnumerable<T> mylist) => mylist.ElementAt(new Random().Next(mylist.Count()));

        public static string Signal2Real(this string desc)
        {
            desc = desc.Replace("&sect", "Pluralism").Replace("&exp", "0");
            if (ClosersModPlugin.Allin)
                desc = desc.Replace("<b>Pluralism</b>", "<b>Closers</b>");
            return desc;
        }

        public static string Real2Signal(this string desc)
        {
            if (ClosersModPlugin.Allin)
                desc = desc.Replace("<b>Closers</b>", "<b>Pluralism</b>");
            desc = desc.Replace("Pluralism", "&sect").Replace("0", "&exp");
            return desc;
        }

    }*/
}
