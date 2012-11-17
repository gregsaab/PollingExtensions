﻿using System.Collections.Generic;

using System.Linq;
using Machine.Specifications;
using PollExtensions;

namespace Specs
{
    [Subject(typeof(Poller))]
    public class When_polling_once
    {
        Because of = () => Producer.Poll(x => x.GetNext()).WithCallback(x => Results.Add(x)).For(1.Times()).Start();
        
        It should_have_only_one_result = () => Results.Count.ShouldEqual(1);
        It should_have_correct_value = () => Results.First().ShouldEqual(0);

        static readonly Producer Producer = new Producer();
        static readonly List<int> Results = new List<int>();
    }
}
