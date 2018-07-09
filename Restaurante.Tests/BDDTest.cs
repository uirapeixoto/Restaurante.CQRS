﻿using NUnit.Framework;
using Restaurante.Contract;
using Restaurante.Events;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Restaurante.Tests
{
    /// <summary>
    /// Provides infrastructure for a set of tests on a given aggregate.
    /// </summary>
    /// <typeparam name="TAggregate"></typeparam>
    public class BDDTest<TAggregate>
        where TAggregate : Aggregate, new()
    {
        private TAggregate sut;

        [SetUp]
        public void BDDTestSetup()
        {
            sut = new TAggregate();
        }

        protected void Test(IEnumerable given, Func<TAggregate, object> when, Action<object> then)
        {
            then(when(ApplyEvents(sut, given)));
        }

        protected IEnumerable Given(params object[] events)
        {
            return events;
        }

        

        protected Action<object> Then(params object[] expectedEvents)
        {
            return got =>
            {
                var gotEvents = got as object[];
                if (gotEvents != null)
                {
                    if (gotEvents.Length == expectedEvents.Length)
                        for (var i = 0; i < gotEvents.Length; i++)
                            if (gotEvents[i].GetType() == expectedEvents[i].GetType())
                                Assert.AreEqual(Serialize(expectedEvents[i]), Serialize(gotEvents[i]));
                            else
                                Assert.Fail(string.Format(
                                    "Resultados incorretos no evento; esperado um {0} mas obteve um {1}",
                                    expectedEvents[i].GetType().Name, gotEvents[i].GetType().Name));
                    else if (gotEvents.Length < expectedEvents.Length)
                        Assert.Fail(string.Format("Expected event(s) missing: {0}",
                            string.Join(", ", EventDiff(expectedEvents, gotEvents))));
                    else
                        Assert.Fail(string.Format("Unexpected event(s) emitted: {0}",
                            string.Join(", ", EventDiff(gotEvents, expectedEvents))));
                }
                else if (got is CommandHandlerNotDefiendException)
                    Assert.Fail((got as Exception).Message);
                else
                    Assert.Fail("Eventos esperados, mas obtido uma exceção {0}",
                        got.GetType().Name);
            };
        }

        private string[] EventDiff(object[] a, object[] b)
        {
            var diff = a.Select(e => e.GetType().Name).ToList();
            foreach (var remove in b.Select(e => e.GetType().Name))
                diff.Remove(remove);
            return diff.ToArray();
        }

        protected Action<object> ThenFailWith<TException>()
        {
            return got =>
            {
                if (got is TException)
                    Assert.Pass("Got correct exception type");
                else if (got is CommandHandlerNotDefiendException)
                    Assert.Fail((got as Exception).Message);
                else if (got is Exception)
                    Assert.Fail(string.Format(
                        "Expected exception {0}, but got exception {1}",
                        typeof(TException).Name, got.GetType().Name));
                else
                    Assert.Fail(string.Format(
                        "Expected exception {0}, but got event result",
                        typeof(TException).Name));
            };
        }

        
        private TAggregate ApplyEvents(TAggregate agg, IEnumerable events)
        {
            agg.ApplyEvents(events);
            return agg;
        }

        private string Serialize(object obj)
        {
            var ser = new XmlSerializer(obj.GetType());
            var ms = new MemoryStream();
            ser.Serialize(ms, obj);
            ms.Seek(0, SeekOrigin.Begin);
            return new StreamReader(ms).ReadToEnd();
        }

        private class CommandHandlerNotDefiendException : Exception
        {
            public CommandHandlerNotDefiendException(string msg) : base(msg) { }
        }
    }
}
