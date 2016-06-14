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
            var overallscores = Calculator.GetOverallScoresForAllHeroes(new[] {new Reaper()}, new[] {new Torbjorn()}, new NeutralCapture());

            var  winstonValue = overallscores.Single(s => s.Hero is Winston).Value;

            Assert.AreEqual(52.5, winstonValue, 0.001);
        }

        [Test]
        public void a_good_team_is_suggested_against_team_tobjorn()
        {
            var tobjornTeam = new[]{new Torbjorn(),new Torbjorn(),new Torbjorn(),new Torbjorn(),new Torbjorn(),new Torbjorn()};

            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[0], new NeutralCapture())
                      .Take(6).Select(w => w.Hero.Id).Should().BeEquivalentTo(new[]
                                                                      {
                                                                          new Winston().Id,
                                                                          new Bastion().Id,
                                                                          new Junkrat().Id,
                                                                          new Reaper().Id,
                                                                          new Lucio().Id,
                                                                          new Symmetra().Id
                                                                      });
        }

        [Test]
        public void a_better_team_is_iteratively_suggested_against_team_tobjorn()
        {
            var tobjornTeam = new[] {new Torbjorn(), new Torbjorn(), new Torbjorn(), new Torbjorn(), new Torbjorn(), new Torbjorn()};

            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[0], new NeutralCapture())
                      .First().Hero.Id.Should().Be(new Winston().Id);
            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[] {new Winston()}, new NeutralCapture())
                      .First().Hero.Id.Should().Be(new Bastion().Id);
            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[] {new Winston(), new Bastion()}, new NeutralCapture())
                      .First().Hero.Id.Should().Be(new Junkrat().Id);
            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[] {new Winston(), new Bastion(), new Junkrat()}, new NeutralCapture())
                      .First().Hero.Id.Should().Be(new Reaper().Id);
            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[] {new Winston(), new Bastion(), new Junkrat(), new Reaper(), }, new NeutralCapture())
                      .First().Hero.Id.Should().Be(new Lucio().Id);
            Calculator.GetOverallScoresForAllHeroes(tobjornTeam, new Hero[] {new Winston(), new Bastion(), new Junkrat(), new Reaper(), new Lucio()}, new NeutralCapture())
                      .First().Hero.Id.Should().Be(new Symmetra().Id);
        }
    }
}