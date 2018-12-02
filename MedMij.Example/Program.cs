// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

using System;
using System.Threading;
using System.Threading.Tasks;

namespace MedMij.Example
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Console.WriteLine("Start demo consumers for OpenPGO-Medmij-DotNet!");
            await Demo.Run();
            Console.WriteLine("End demo consumers for OpenPGO-Medmij-DotNet!");
        }
    }
}
