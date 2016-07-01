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
            var overallscores = Calculator.GetOverallScoresForAllHeroes(new[] {new Torbjorn()}, new[] {new Reaper()}, new Control());

            var  winstonValue = overallscores.Single(s => s.Hero is Winston).Value;

            Assert.AreEqual(52.5, winstonValue, 0.001);
        }

        [Test]
        public void symmetra_is_bad_against_torbjorn()
        {
            var enemyTeam = new[] { new Torbjorn() };

            var playerTeamWeights =
                Calculator.GetOverallScoresForAllHeroes(enemyTeam, new Hero[0], new AssaultAttack())
                    .Take(6)
                    .Select(w => w.Hero.Id)
                    .Should()
                    .NotContain(new Symmetra());
        }

        [Test]
        public void a_good_team_is_suggested_against_team_tobjorn()
        {
            var tobjornTeam = new[]{new Torbjorn(),new Torbjorn(),new Torbjorn(),new Torbjorn(),new Torbjorn(),new Torbjorn()};

            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[0], new AssaultAttack())
                      .Take(6).Select(w => w.Hero.Id).Should().BeEquivalentTo(new[]
                                                                      {
                                                                          new Junkrat().Id,
                                                                          new Reinhardt().Id,
                                                                          new Zarya().Id,
                                                                          new Mercy().Id,
                                                                          new Lucio().Id,
                                                                          new Widowmaker().Id
                                                                      });
        }

        [Test]
        public void a_better_team_is_iteratively_suggested_against_team_tobjorn()
        {
            var tobjornTeam = new[] {new Torbjorn(), new Torbjorn(), new Torbjorn(), new Torbjorn(), new Torbjorn(), new Torbjorn()};

            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[0], new AssaultAttack())
                      .First().Hero.Id.Should().Be(new Junkrat().Id);
            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[] {new Junkrat()}, new AssaultAttack())
                      .First().Hero.Id.Should().Be(new Widowmaker().Id);
            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[] {new Junkrat(), new Widowmaker()}, new AssaultAttack())
                      .First().Hero.Id.Should().Be(new Zenyatta().Id);
            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[] {new Junkrat(), new Widowmaker(), new Zenyatta(), }, new AssaultAttack())
                      .First().Hero.Id.Should().Be(new Reaper().Id);
            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[] {new Junkrat(), new Widowmaker(), new Zenyatta(), new Reaper()}, new AssaultAttack())
                      .First().Hero.Id.Should().Be(new Genji().Id);
            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[] {new Junkrat(), new Widowmaker(), new Zenyatta(), new Reaper(), new Genji()}, new AssaultAttack())
                      .First().Hero.Id.Should().Be(new Lucio().Id);
        }
    }
}