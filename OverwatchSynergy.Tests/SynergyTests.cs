using System.Collections;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using OverwatchSynergy.Api;
using OverwatchSynergy.Api.Heroes;

namespace OverwatchSynergy.Tests
{
    [TestFixture]
    public class SynergyTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }
        

        [Test]
        public void synergies_can_be_retrieved()
        {
            var synergies = Calculator.GetSynergies(new[] {new Reinhardt()});

            synergies.Single(s => s.Hero is Mercy).Value.Should().Be(100);
        }  

        [Test]
        public void synergies_are_averaged_when_a_retreiving_synergies_for_multiple_teamMates()
        {
            var synergies = Calculator.GetSynergies(new[] {new Reinhardt(), (Hero)new Widowmaker()});

            synergies.Single(s => s.Hero is Mercy).Value.Should().Be(50);
        }  

        [Test]
        public void all_heroes_synergies_should_be_equivelent_to_all_heroes_synergies()
        {
            var heroes1 = Calculator.Heroes;
            var heroes2 = Calculator.Heroes;

            heroes1.ForEach(h1 =>
                           {
                               heroes2.ForEach(h2 =>
                                               {
                                                   h1.GetSynergyValue(h2).Should().Be(h2.GetSynergyValue(h1), $"{h1.Name} does not match {h2.Name}");
                                               });
                           });
        }

    }
}