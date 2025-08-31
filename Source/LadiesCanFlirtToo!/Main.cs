using System.Reflection;
using HarmonyLib;
using Verse;

namespace LadiesCanFlirtToo;

[StaticConstructorOnStartup]
public static class Main
{
    static Main()
    {
        new Harmony("ladies.can.flirt.too").PatchAll(Assembly.GetExecutingAssembly());
    }
}