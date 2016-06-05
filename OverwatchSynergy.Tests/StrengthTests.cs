using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using OverwatchSynergy.Api;
using OverwatchSynergy.Api.Heroes;

namespace OverwatchSynergy.Tests
{
    [TestFixture]
    public class StrengthTests
    {
        [Test]
        public void strengths_can_be_retrieved()
        {
            var results = Calculator.GetHeroesStrengthAgainst(new[] { new Mei() });

            results.Single(s => s.Hero is Genji).Value.Should().Be(100);
        }

        [Test]
        public void strengths_are_averaged_when_retreiving_strengths_for_multiple_teamMates()
        {
            var weights = Calculator.GetHeroesStrengthAgainst(new[] { new Mei(), (Hero)new Bastion() });

            weights.Single(s => s.Hero is Genji).Value.Should().Be(50);
        }
    }
}