using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using OverwatchSynergy.Api;
using OverwatchSynergy.Api.Heroes;
using OverwatchSynergy.Api.ObjectiveTypes;

namespace OverwatchSynergy.Tests
{
    [TestFixture]
    public class OverallScoreTests
    {
        [Test]
        public void overallscores_can_be_retrieved()
        {
            var overallscores = Calculator.GetOverallScoresForAllHeroes(new[] {new Reaper()}, new[] {new Torbjorn()}, 1);

            overallscores.Single(s => s.Hero is Winston).Value.Should().Be(50);
        }

        [Test]
        public void a_good_team_is_suggested_against_team_tobjorn()
        {
            var tobjornTeam = new[]{new Torbjorn(),new Torbjorn(),new Torbjorn(),new Torbjorn(),new Torbjorn(),new Torbjorn()};

            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[0], 1)
                      .Take(6).Select(w => w.Hero.Id).Should().BeEquivalentTo(new[]
                                                                      {
                                                                          new Hanzo().Id,
                                                                          new Junkrat().Id,
                                                                          new Widowmaker().Id,
                                                                          new Reinhardt().Id,
                                                                          new Zarya().Id,
                                                                          new Mercy().Id
                                                                      });
        }

        [Test]
        public void a_better_team_is_iteratively_suggested_against_team_tobjorn()
        {
            var tobjornTeam = new[] {new Torbjorn(), new Torbjorn(), new Torbjorn(), new Torbjorn(), new Torbjorn(), new Torbjorn()};

            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[0], 1)
                      .First().Hero.Id.Should().Be(new Hanzo().Id);
            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[] {new Hanzo()}, 1)
                      .First().Hero.Id.Should().Be(new Zarya().Id);
            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[] {new Hanzo(), new Zarya()}, 1)
                      .First().Hero.Id.Should().Be(new Tracer().Id);
            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[] {new Hanzo(), new Zarya(), new Tracer(),}, 1)
                      .First().Hero.Id.Should().Be(new Junkrat().Id);
            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[] {new Hanzo(), new Zarya(), new Tracer(), new Junkrat()}, 1)
                      .First().Hero.Id.Should().Be(new Mei().Id);
            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[] {new Hanzo(), new Zarya(), new Tracer(), new Junkrat(), new Mei()}, 1)
                      .First().Hero.Id.Should().Be(new Mercy().Id);
        }
    }
}