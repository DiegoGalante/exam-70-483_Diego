using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Bogus;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam70_483.Benchmark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class ListsVSArrayList
    {
        public List<string> nList { get; set; }
        public ArrayList ArrayList { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            nList = new List<string>();
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");

            ArrayList = new ArrayList();
            ArrayList.Add("aieuhaiuehiuaheiuaehiua");
            ArrayList.Add("aieuhaiuehiuaheiuaehiua");
            ArrayList.Add("aieuhaiuehiuaheiuaehiua");
            ArrayList.Add("aieuhaiuehiuaheiuaehiua");
            ArrayList.Add("aieuhaiuehiuaheiuaehiua");
            ArrayList.Add("aieuhaiuehiuaheiuaehiua");
            ArrayList.Add("aieuhaiuehiuaheiuaehiua");
            ArrayList.Add("aieuhaiuehiuaheiuaehiua");
            ArrayList.Add("aieuhaiuehiuaheiuaehiua");
        }

        [Benchmark]
        public ArrayList Arraylist()
        {
            var novaList = new ArrayList();
            foreach (var list in ArrayList)
                novaList.Add(list);

            return novaList;
        }

        [Benchmark]
        public List<string> List()
        {
            var nList_local = new List<string>();
            foreach (var list in nList)
                nList_local.Add(list);

            return nList;
        }

        [Benchmark]
        public List<string> List_ForEach()
        {
            var nList_local = new List<string>();
            nList.ForEach(l=> nList_local.Add(l));
            return nList;
        }

        [Benchmark]
        public List<string> List_AsParallel()
        {
            var nList_Local = new List<string>();
            Parallel.ForEach(nList, file =>
            {
                nList_Local.Add(file);
            });

            return nList_Local;
        }

    }
}
