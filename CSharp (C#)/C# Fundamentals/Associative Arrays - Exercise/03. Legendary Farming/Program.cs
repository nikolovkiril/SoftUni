using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] keyMaterials = { "shards", "fragments", "motes" };

            Dictionary<string, int> materials = new Dictionary<string, int>();
            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();

            materials["shards"] = 0;
            materials["fragments"] = 0;
            materials["motes"] = 0;

            string itemObtained = "";
            bool obtained = false;

            while (!obtained)
            {
                string[] inputArg = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int i = 0; i < inputArg.Length; i += 2)
                {
                    int quantity = int.Parse(inputArg[i]);
                    string material = inputArg[i + 1].ToLower();

                    if (keyMaterials.Contains(material))
                    {
                        materials[material] += quantity;
                        if (materials.Any(m => m.Value >= 250))
                        {
                            if (material == "shards")
                            {
                                itemObtained = "Shadowmourne";
                            }
                            else if (material == "fragments")
                            {
                                itemObtained = "Valanyr";
                            }
                            else
                            {
                                itemObtained = "Dragonwrath";
                            }
                            materials[material] -= 250;
                            obtained = true;
                            break;
                        }
                    }
                    else
                    {
                        Junk(junkMaterials, quantity, material);
                    }
                }
            }
            Console.WriteLine($"{itemObtained} obtained!");
            materials = materials.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key).ToDictionary(a => a.Key, b => b.Value);

            foreach (var kvp in materials)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            junkMaterials =  junkMaterials.OrderBy(kvp => kvp.Key).ToDictionary(a => a.Key, b => b.Value);
            foreach (var kvp in junkMaterials)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        private static void Junk(Dictionary<string, int> junkMaterials, int quantity, string material)
        {
            if (!junkMaterials.ContainsKey(material))
            {
                junkMaterials[material] = 0;
            }
            junkMaterials[material] += quantity;
        }
    }
}
